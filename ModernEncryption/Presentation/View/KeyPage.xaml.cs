using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModernEncryption.BusinessLogic.Crypto;
using ModernEncryption.Interfaces;
using ModernEncryption.Presentation.ViewModel;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.QrCode.Internal;

namespace ModernEncryption.Presentation.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class KeyPage : ContentPage
	{
        public KeyPageViewModel ViewModel { get; }

        public KeyPage()
        {
            InitializeComponent();
            ViewModel = new KeyPageViewModel();
            ViewModel.SetView(this);
            BindingContext = ViewModel;
        }

        // TODO: Only demo
	    private async void OnPainting(object sender, SKPaintSurfaceEventArgs e)
	    {
	        var x = new QrCodeLogic().Create("Lore242424m ipsum dolor sit amet, consectetuer adipiscing elit. Ae1nean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec pede justo, fringilla vel, aliquet nec, vulputate eget, arcu. In enim justo, rhoncus ut, imperdiet a, venenatis vitae, justo. Nullam dictum felis eu pede mollis pretium. Integer tincidunt. Cras dapib1", 500, 500, 500);

	        e.Surface.Canvas.DrawBitmap(x[0], 0, 0);
	        e.Surface.Canvas.DrawBitmap(x[1], 500, 0);

	        var pixmap = e.Surface.Snapshot().PeekPixels();
	        var data = pixmap.Encode(SKEncodedImageFormat.Png, 100);
	        DependencyService.Get<IStorage>().SaveImage("test.png", data.ToArray());


	        //var x = await new QrCodeLogic().ReadViaCamera();
	        //var x = await new QrCodeLogic().PickFromGallery();
	        //System.Diagnostics.Debug.WriteLine(x);
	    }
    }
}