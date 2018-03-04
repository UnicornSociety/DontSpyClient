using System.IO;
using System.Threading.Tasks;
using Plugin.Media;
using SkiaSharp;
using ZXing;
using ZXing.Common;
using ZXing.QrCode;
using ZXing.SkiaSharp;

namespace ModernEncryption.BusinessLogic.Crypto
{
    internal class QrCode
    {
        public SKBitmap Create(string content, int width, int height) {
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

        public async Task<Stream> ReadViaCamera(long channelId)
        {
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported) return null;
            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                DefaultCamera = Plugin.Media.Abstractions.CameraDevice.Front,
                Directory = "TemporaryKeys",
                Name = channelId + ".jpg"
            });
            
            return file?.GetStream();
        }
    }
}
