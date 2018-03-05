using DontSpy.Model;
using DontSpy.Presentation.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DontSpy.Presentation.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChannelPage : ContentPage
    {
        public ChannelPageViewModel ViewModel { get; }

        public ChannelPage(Channel channel)
        {
            InitializeComponent();
            ViewModel = new ChannelPageViewModel(channel);
            ViewModel.SetView(this);
            BindingContext = ViewModel;
        }
    }
}