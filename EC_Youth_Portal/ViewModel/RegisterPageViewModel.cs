using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace EC_Youth_Portal.ViewModel
{
    internal class RegisterPageViewModel : INotifyPropertyChanged
    {
        private Page _page; 

        public void SetView(Page page) 
        {
            _page = page;
        }

        // Fields
        private string _fullName;
        private string _username;
        private string _location;
        private string _password;
        private string _rePassword;
        private double _bottomSheetTranslationY = 800;
        private double _overlayOpacity = 0;
        private bool _isOverlayInputTransparent = true;

        // Properties
        public string FullName
        {
            get => _fullName;
            set
            {
                _fullName = value;
                OnPropertyChanged();
            }
        }

        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged();
            }
        }

        public string Location
        {
            get => _location;
            set
            {
                _location = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        public string RePassword
        {
            get => _rePassword;
            set
            {
                _rePassword = value;
                OnPropertyChanged();
            }
        }

        public double BottomSheetTranslationY
        {
            get => _bottomSheetTranslationY;
            set
            {
                _bottomSheetTranslationY = value;
                OnPropertyChanged();
            }
        }

        public double OverlayOpacity
        {
            get => _overlayOpacity;
            set
            {
                _overlayOpacity = value;
                OnPropertyChanged();
            }
        }

        public bool IsOverlayInputTransparent
        {
            get => _isOverlayInputTransparent;
            set
            {
                _isOverlayInputTransparent = value;
                OnPropertyChanged();
            }
        }

        // Commands
        public ICommand RegisterCommand { get; }
        public ICommand AcceptCommand { get; }
        public ICommand DeclineCommand { get; }
        public ICommand OverlayTappedCommand { get; }
        public ICommand LoginCommand { get; }

        // Constructor
        public RegisterPageViewModel()
        {
            RegisterCommand = new Command(async () => await OnRegister());
            AcceptCommand = new Command(async () => await OnAccept());
            DeclineCommand = new Command(async () => await OnDecline());
            OverlayTappedCommand = new Command(async () => await OnOverlayTapped());
            LoginCommand = new Command(async () => await OnLogin());
        }

        // Methods
        private async Task OnRegister()
        {
            // Show bottom sheet
            await ShowBottomSheet();
        }

        private async Task ShowBottomSheet()
        {
            IsOverlayInputTransparent = false;

            // Use _page instead of Application.Current.MainPage
            var overlayAnimation = new Animation(v => OverlayOpacity = v, 0, 0.5);
            overlayAnimation.Commit(_page, "OverlayFadeIn", 16, 250, Easing.CubicOut);

            var sheetAnimation = new Animation(v => BottomSheetTranslationY = v, 800, 0);
            sheetAnimation.Commit(_page, "SheetSlideUp", 16, 350, Easing.CubicOut);

            await Task.Delay(350);
        }

        private async Task HideBottomSheet()
        {
            var sheetAnimation = new Animation(v => BottomSheetTranslationY = v, 0, 800);
            sheetAnimation.Commit(_page, "SheetSlideDown", 16, 300, Easing.CubicIn);

            var overlayAnimation = new Animation(v => OverlayOpacity = v, 0.5, 0);
            overlayAnimation.Commit(_page, "OverlayFadeOut", 16, 200, Easing.CubicIn);

            await Task.Delay(300);
            IsOverlayInputTransparent = true;
        }

        private async Task OnAccept()
        {
            await HideBottomSheet();

            // small delay to ensure animations complete and clean up
            await Task.Delay(100);

            try
            {
                await Shell.Current.GoToAsync("CreateProfilePage");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Navigation error: {ex.Message}");
            }
        }


        private async Task OnDecline()
        {
            await HideBottomSheet();

            try
            {
                await Shell.Current.GoToAsync("//MainPage");
                //await Shell.Current.GoToAsync(nameof(Views.MainPage));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Navigation error: {ex.Message}");
            }
        }

        private async Task OnOverlayTapped()
        {
            await HideBottomSheet();
        }

        private async Task OnLogin()
        {
            try
            {
                await Shell.Current.GoToAsync(nameof(Views.LoginPage));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Navigation error: {ex.Message}");
            }

        }

        // INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}