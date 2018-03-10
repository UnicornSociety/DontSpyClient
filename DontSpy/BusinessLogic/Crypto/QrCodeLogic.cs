using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DontSpy.Utils;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using SkiaSharp;
using ZXing;
using ZXing.QrCode;
using ZXing.SkiaSharp;
using BarcodeReader = ZXing.BarcodeReader;

namespace DontSpy.BusinessLogic.Crypto
{
    internal class QrCodeLogic
    {
        public List<SKBitmap> Create(string content, int signsPerQrCode, int widthHeight)
        {
            var qrCodes = new List<SKBitmap>();

            var sumQrCodes = content.Length / signsPerQrCode;
            if (content.Length % signsPerQrCode > 0) sumQrCodes++;
            var sumQrCodesCounter = 1;

            for (var i = 0; i < content.Length; i += signsPerQrCode)
            {
                qrCodes.Add(new BarcodeWriter
                {
                    Format = BarcodeFormat.QR_CODE,
                    Options = new QrCodeEncodingOptions
                    {
                        Width = widthHeight,
                        Height = widthHeight
                    }
                }.Write(sumQrCodesCounter++ + ";" + sumQrCodes + "#" + content.Substring(i, Math.Min(signsPerQrCode, content.Length - i))));
            }

            return qrCodes;
        }

        private string Read(SKBitmap qrCodeImage)
        {
            var qrCodes = new Dictionary<int, string>();

            var decodedQrCodeResults = new BarcodeReader
            {
                Options =
                {
                    TryHarder = true,
                    PossibleFormats = new List<BarcodeFormat> {BarcodeFormat.QR_CODE}
                },
                TryInverted = true,
                AutoRotate = true
            }.DecodeMultiple(qrCodeImage);

            if (decodedQrCodeResults == null) return null;

            string qrCodesIntegrity = null;
            foreach (var decodedQrCodeResult in decodedQrCodeResults)
            {
                var qrCodeDataSplit = decodedQrCodeResult.Text.Split(new[] { '#' }, 2);
                var qrCodeOrderingNumbers = qrCodeDataSplit[0].Split(new[] { ';' }, 2);

                // Check integrity of the qr codes sum
                if (qrCodesIntegrity == null) qrCodesIntegrity = qrCodeOrderingNumbers[1];
                else if (qrCodesIntegrity != qrCodeOrderingNumbers[1]) return null;
                if (qrCodes.ContainsKey(int.Parse(qrCodeOrderingNumbers[0]))) return null; // Injured integrity

                qrCodes.Add(int.Parse(qrCodeOrderingNumbers[0]), qrCodeDataSplit[1]);
            }
            
            if (qrCodes.Count != int.Parse(qrCodesIntegrity)) return null; // Injured integrity
            
            var key = string.Empty;
            for (var i = 1; i <= qrCodes.Count; i++)
            {
                if (!qrCodes.ContainsKey(i)) return null; // Injured integrity
                key += qrCodes[i];
            }

            return key;
        }

        public async Task<string> ReadViaCamera()
        {
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsCameraAvailable) return null; // Is camera available?

            // Permissions
            var cameraStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Camera);
            var storageStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Storage);

            if (cameraStatus != PermissionStatus.Granted || storageStatus != PermissionStatus.Granted)
            {
                var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Camera, Permission.Storage);
                cameraStatus = results[Permission.Camera];
                storageStatus = results[Permission.Storage];
            }
            if (cameraStatus != PermissionStatus.Granted || storageStatus != PermissionStatus.Granted) return null;

            // Access camera
            if (!CrossMedia.Current.IsTakePhotoSupported) return null;
            var file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
            {
                DefaultCamera = CameraDevice.Front,
                SaveToAlbum = false,
                Directory = "TemporaryKeys",
                Name = TimeManagement.UnixTimestampNow + ".jpg"
            });

            var qrCodeResult = Read(SKBitmap.Decode(file.GetStream()));
            System.IO.File.Delete(file.Path); // Delete temporary QR-Code

            return qrCodeResult;
        }

        public async Task<string> PickFromGallery()
        {
            await CrossMedia.Current.Initialize();

            // Permissions
            var storageStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Storage);

            if (storageStatus != PermissionStatus.Granted)
            {
                var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Storage);
                storageStatus = results[Permission.Storage];
            }
            if (storageStatus != PermissionStatus.Granted) return null;

            // Access gallery
            if (!CrossMedia.Current.IsPickPhotoSupported) return null;
            var file = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions
            {
                PhotoSize = PhotoSize.Full
            });

            return Read(SKBitmap.Decode(file.GetStream()));
        }
    }
}