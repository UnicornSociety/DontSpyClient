using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using DontSpy.BusinessLogic.Crypto;
using DontSpy.Interfaces;
using DontSpy.Model;
using DontSpy.Presentation.Validation;
using DontSpy.Presentation.Validation.Rules;
using DontSpy.Presentation.View;
using DontSpy.Translations;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;

namespace DontSpy.Presentation.ViewModel
{
    public class ChannelPageViewModel : ValidationBase, INotifyPropertyChanged
    {
        private ChannelPage _view;
        private string _title = AppResources.ChannelHeading;
        private ValidatableObject<string> _message = new ValidatableObject<string>();
        private bool _keyConfigurationVisibility;
        private bool _keyCreationVisibility;
        private bool _messageListViewVisibility;
        private readonly Channel _channel;
        private string _pathToQrCode = string.Empty;
        public ObservableCollection<DecryptedMessage> Messages { get; } = new ObservableCollection<DecryptedMessage>();
        public ICommand SendMessageCommand { protected set; get; }
        public ICommand ValidateMessageCommand { protected set; get; }
        public ICommand KeyViaCameraCommand { protected set; get; }
        public ICommand KeyViaGalleryCommand { protected set; get; }
        public ICommand ExitKeyDisplaying { protected set; get; }
        public Page KeyPage { get; set; }

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

        public bool KeyCreationVisibility
        {
            get => _keyCreationVisibility;
            set
            {
                if (_keyCreationVisibility == value) return;
                _keyCreationVisibility = value;
                OnPropertyChanged("KeyCreationVisibility");
            }
        }

        public bool KeyConfigurationVisibility
        {
            get => _keyConfigurationVisibility;
            set
            {
                if (_keyConfigurationVisibility == value) return;
                _keyConfigurationVisibility = value;
                OnPropertyChanged("KeyConfigurationVisibility");
            }
        }

        public bool MessageListViewVisibility
        {
            get => _messageListViewVisibility;
            set
            {
                if (_messageListViewVisibility == value) return;
                _messageListViewVisibility = value;
                OnPropertyChanged("MessageListViewVisibility");
            }
        }

        public string PathToQrCode
        {
            get => _pathToQrCode;
            set
            {
                if (_pathToQrCode == value) return;
                _pathToQrCode = value;
                OnPropertyChanged("PathToQrCode");
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
            _channel = channel;
            ChangeViewState();
            AddValidations();

            // Load all messages from local database
            foreach (var decryptedMessage in DependencyManager.ChannelService.LoadDecryptedMessagesForChannel(channel))
                Messages.Add(decryptedMessage);

            SendMessageCommand = new Command<object>(param =>
            {
#if DEBUG
                if (Message.Value.Length > 6)
                {
                    if (Message.Value.Substring(0, 6).Equals("code::"))
                    {
                        DebuggingOptions.ExecuteCode(Message.Value.Substring(6));
                        Message.Value = "Code executed. You may have to restart the app."; // Feedback
                        return;
                    }
                }
#endif

                if (!Validate()) return;

                DependencyManager.ChannelService.SendMessage(Message.Value, channel);
                Message.Value = string.Empty; // Clear field

                _view.GetMessagesListView.ScrollTo(Messages.LastOrDefault(), ScrollToPosition.End, true); // Scroll to ListView bottom
            });

            KeyViaCameraCommand = new Command<object>(async param =>
            {
                ConfigureKey(await new QrCodeLogic().ReadViaCamera());
            });

            KeyViaGalleryCommand = new Command<object>(async param =>
            {
                ConfigureKey(await new QrCodeLogic().PickFromGallery());
            });

            ValidateMessageCommand = new Command<object>(param =>
            {
                Validate();
            });

            ExitKeyDisplaying = new Command<object>(param =>
            {
                _channel.KeyInformation = Channel.KeyMetadata.InitiatorKeyDisplayed;
                ChangeViewState();
            });
        }

        public void PostConstruct()
        {
            _view.GetMessagesListView.ScrollTo(Messages.LastOrDefault(), ScrollToPosition.End, true); // Scroll to ListView bottom
        }

        protected sealed override void AddValidations()
        {
            _message.Validations.Add(new IsNullOrEmptyRule<string>());
            _message.Validations.Add(new HasSupportedCharacterRule<string>() { ValidationMessage = AppResources.InvalidCharacter });
        }

        protected override bool Validate()
        {
            return _message.Validate();
        }

        private void ChangeViewState()
        {
            KeyCreationVisibility = false;
            KeyConfigurationVisibility = false;
            MessageListViewVisibility = false;

            switch (_channel.KeyInformation)
            {
                case Channel.KeyMetadata.InitiatorKeyNotDisplayed:
                    KeyCreationVisibility = true;
                    break;
                case Channel.KeyMetadata.InitiatorKeyDisplayed:
                    MessageListViewVisibility = true;
                    break;
                case Channel.KeyMetadata.ConcernedKeyless:
                    KeyConfigurationVisibility = true;
                    break;
                case Channel.KeyMetadata.ConcernedHasKey:
                    MessageListViewVisibility = true;
                    break;
            }
        }

        private void ConfigureKey(string key)
        {
            if (key == null) return;
            DependencyService.Get<IStorage>().SetValueWithKey(_channel.Id, key);
            _channel.KeyInformation = Channel.KeyMetadata.ConcernedHasKey;
            ChangeViewState();
        }

        public void SetView(ChannelPage view)
        {
            _view = view;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public async void KeyPainting(SKPaintSurfaceEventArgs paintingArgs)
        {
            paintingArgs.Surface.Canvas.Clear();

            var signsPerQrCode = 1620;
            var sumKeyQrCodeBitmaps = new QrCodeLogic().Create(DependencyService.Get<IStorage>().GetValueFromKey(_channel.Id), signsPerQrCode, 300);

            var posX = 0;
            var posY = 0;
            for (int i = 0; i < sumKeyQrCodeBitmaps.Count; i++)
            {
                paintingArgs.Surface.Canvas.DrawBitmap(sumKeyQrCodeBitmaps[i], posX, posY);
                posX += 301;

                if (i == 4 )
                {
                    posX = 0;
                    posY = 301;
                }


            }
                        /*
                        var surfaceWidth = paintingArgs.Info.Width;
                        var surfaceHeight = paintingArgs.Info.Height;
                        var signsPerQrCode = 2500;
                        var key = DependencyService.Get<IStorage>().GetValueFromKey(_channel.Id);
                        var sumQrCodesNeeded = key.Length / signsPerQrCode;
                        if (key.Length % signsPerQrCode > 0) sumQrCodesNeeded++;

                        // TODO: Use space optimal
                        var qrCodeWidthHeight = 500;
                        var sumKeyQrCodeBitmaps = new QrCodeLogic().Create(DependencyService.Get<IStorage>().GetValueFromKey(_channel.Id), signsPerQrCode, qrCodeWidthHeight);
                        // TODO: End
                        */

            var aggregatedQrCodeBitmap = paintingArgs.Surface.Snapshot().PeekPixels().Encode(SKEncodedImageFormat.Png, 100);
           PathToQrCode = AppResources.PathToQrCode + " " + await DependencyService.Get<IStorage>().SaveImage(_channel.Id + ".png", aggregatedQrCodeBitmap.ToArray());
        }
    }
}
