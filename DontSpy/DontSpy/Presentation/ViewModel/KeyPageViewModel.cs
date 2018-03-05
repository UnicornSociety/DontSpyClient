using DontSpy.Presentation.View;
using DontSpy.Translations;

namespace DontSpy.Presentation.ViewModel
{
    public class KeyPageViewModel
    {
        private KeyPage _view;
        private string _title = AppResources.RegistrationHeading;

        public void SetView(KeyPage view)
        {
            _view = view;
        }
    }
    
}
