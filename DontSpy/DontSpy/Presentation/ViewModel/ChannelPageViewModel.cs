﻿using System.Collections.ObjectModel;
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
    public class ChannelPageViewModel : ValidationBase, INotifyPropertyChanged
    {
        private ChannelPage _view;
        private string _title = AppResources.ChannelHeading;
        private ValidatableObject<string> _message = new ValidatableObject<string>();
        public ObservableCollection<DecryptedMessage> Messages { get; } = new ObservableCollection<DecryptedMessage>();
        public ICommand SendMessageCommand { protected set; get; }
        public ICommand ValidateMessageCommand { protected set; get; }
        public ICommand ShowKeyCommand { protected set; get; }
        public Page KeyPage { get; set; }
        private bool _keyVisibility = true;

        public bool KeyVisibility
        {
            get => _keyVisibility;
            set
            {
                if (_keyVisibility == value) return;
                _keyVisibility = value;
                OnPropertyChanged("KeyVisibility");
            }
        }

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

        public ValidatableObject<string> Message
        {
            get => _message;
            set
            {
                if (_message == value) return;
                _message = value;
                OnPropertyChanged("Message");
            }
        }

        public ChannelPageViewModel(Channel channel)
        {
            AddValidations();

            // Load all messages from local database
            foreach (var decryptedMessage in DependencyManager.ChannelService.LoadDecryptedMessagesForChannel(channel))
                Messages.Add(decryptedMessage);

            SendMessageCommand = new Command<object>(param =>
            {
                if (!Validate()) return;

                DependencyManager.ChannelService.SendMessage(Message.Value, channel);
                Message.Value = string.Empty; // Clear field
            });

            ValidateMessageCommand = new Command<object>(param =>
            {
                Validate();
            });

            KeyVisibility = channel.ChannelKeyVisibility;

            ShowKeyCommand = new Command<object>(param =>
            {
                DependencyManager.AnchorPage.Children[1].Navigation.PopToRootAsync(false);
                _view.Navigation.PushAsync(new KeyPage());
                KeyVisibility = false;
                channel.ChannelKeyVisibility = false;
            });
        }

        protected sealed override void AddValidations()
        {
            _message.Validations.Add(new IsNullOrEmptyRule<string>());
            _message.Validations.Add(new HasSupportedCharacterRule<string>(){ValidationMessage = AppResources.InvalidCharacter});
        }

        protected override bool Validate()
        {
            return _message.Validate();
        }

        public void SetView(ChannelPage view)
        {
            _view = view;
        }

        /* protected override void OnAppearing()
        {
            OnAppearing();

            RefreshScrollDown = () => {
                if (Messages.Count > 0)
                {
                    Device.BeginInvokeOnMainThread(() => {

                        Messages.ScrollTo(Messages[Messages.Count - 1], ScrollToPosition.End, true);
                    });
                }
            };
        }*/

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
