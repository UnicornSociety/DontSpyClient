using System.ComponentModel;
using System.Windows.Input;
using DontSpy.Model;
using DontSpy.Presentation.Validation;
using DontSpy.Presentation.Validation.Rules;
using DontSpy.Presentation.View;
using DontSpy.Translations;
using Xamarin.Forms;

namespace DontSpy.Presentation.ViewModel
{
    public class RegistrationPageViewModel : ValidationBase, INotifyPropertyChanged
    {
        private RegistrationPage _view;
        private string _title = AppResources.RegistrationHeading;
        private ValidatableObject<string> _username = new ValidatableObject<string>();
        public ICommand RegistrationCommand { protected set; get; }
        public ICommand ValidateUsernameCommand { protected set; get; }

        public string Title
        {
            get => _title;
            set
            {
                if (_title == value) return;
                _title = value;
                OnPropertyChanged("Title");
            }
        }

        public ValidatableObject<string> Username
        {
            get => _username;
            set
            {
                if (_username == value) return;
                _username = value;
                OnPropertyChanged("Username");
            }
        }

        public RegistrationPageViewModel()
        {
            AddValidations();

            RegistrationCommand = new Command<object>(param =>
            {
                var result = DependencyManager.UserService.CreateOwnUser(new User(Username.Value));
                if (!result) return;

                Application.Current.MainPage = DependencyManager.AnchorPage;
                DependencyManager.PullService.PullChannelRequests();
                DependencyManager.PullService.PullNewMessages();
            });

            ValidateUsernameCommand = new Command<object>(param =>
            {
                ValidateUsername();
            });
        }

        protected sealed override void AddValidations()
        {
            _username.Validations.Add(new StringLengthRule<string>(3, 64) { ValidationMessage = AppResources.ErrorMsgUsernameLength });
        }

        protected override bool Validate()
        {
            return ValidateUsername();
        }

        private bool ValidateUsername()
        {
            return _username.Validate();
        }

        public void SetView(RegistrationPage view)
        {
            _view = view;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
