using DontSpy.Presentation.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DontSpy.Presentation.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage : ContentPage
    {
        public RegistrationPageViewModel ViewModel { get; }

        public RegistrationPage()
        {
            InitializeComponent();
            ViewModel = new RegistrationPageViewModel();
            ViewModel.SetView(this);
            BindingContext = ViewModel;
        }
    }
}