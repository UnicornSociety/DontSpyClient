using DontSpy.Presentation.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DontSpy.Presentation.View
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
    }
}