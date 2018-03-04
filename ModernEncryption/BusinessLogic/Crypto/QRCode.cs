using System.Collections.Generic;
using System.Threading.Tasks;
using ModernEncryption.Utils;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using SkiaSharp;
using ZXing;
using ZXing.QrCode;
using ZXing.SkiaSharp;
using BarcodeReader = ZXing.BarcodeReader;

namespace ModernEncryption.BusinessLogic.Crypto
{
    internal class QrCode
    {
        public SKBitmap Create(string content, int width, int height)
        {
            return new BarcodeWriter
            {
                Format = BarcodeFormat.QR_CODE,
                Options = new QrCodeEncodingOptions
                {
                    Width = width,
                    Height = height
                }
            }.Write(content);
        }

        private string Read(SKBitmap qrCodeImage)
        {
            var decodedQrCodeResult = new BarcodeReader
            {
                Options =
                {
                    TryHarder = true,
                    PossibleFormats = new List<BarcodeFormat> {BarcodeFormat.QR_CODE}
                },
                TryInverted = true,
                AutoRotate = true
            }.Decode(qrCodeImage);

            return decodedQrCodeResult?.Text;
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
    }
}