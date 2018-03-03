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
    }
}
