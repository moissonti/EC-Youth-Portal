using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace EC_Youth_Portal.ViewModel
{
    public class MainPageViewModel : BaseViewModel
    {
        private int _currentCarouselPosition;
        private System.Timers.Timer _carouselTimer;


        public MainPageViewModel()
        {
            LoginCommand = new Command(async () => await OnLogin());
            RegisterCommand = new Command(async () => await OnRegister());
            OpenWebsiteCommand = new Command(async () => await OnOpenWebsite());

            InitializeCarouselItems();
            StartCarouselAutoScroll(); 
        }

        #region Commands
        public ICommand LoginCommand { get; }
        public ICommand RegisterCommand { get; }
        public ICommand OpenWebsiteCommand { get; }
        #endregion

        public ObservableCollection<CarouselItemModel> CarouselItems { get; set; }

        public int CurrentCarouselPosition
        {
            get => _currentCarouselPosition;
            set
            {
                _currentCarouselPosition = value;
                OnPropertyChanged();
            }
        }

        // ADD THIS METHOD
        private void InitializeCarouselItems()
        {
            CarouselItems = new ObservableCollection<CarouselItemModel>
        {
            new CarouselItemModel
            {
                Title = "Career Opportunities",
                Description = "Explore jobs, learnerships and internships across Eastern Cape",
                Icon = ImageSource.FromFile("opportunities_icon.jpg"),
                GradientStart = "#1E3A5F",
                GradientEnd = "#2C5282"
            },
            new CarouselItemModel
            {
                Title = "SMME Funding",
                Description = "Access funding and support for small business development",
                Icon = ImageSource.FromFile("funding_icon.png"),
                GradientStart = "#1E3A5F",
                GradientEnd = "#2C5282"
            },
            new CarouselItemModel
            {
                Title = "Bursaries",
                Description = "Find scholarship and bursary opportunities for your studies",
                Icon = ImageSource.FromFile("bursary_icon.png"),
                GradientStart = "#1E3A5F",
                GradientEnd = "#2C5282"
            },
            new CarouselItemModel
            {
                Title = "Training Programs",
                Description = "Upskill yourself with certified training and development programs",
                Icon = ImageSource.FromFile("training_icon.png"),
                GradientStart = "#1E3A5F",
                GradientEnd = "#2C5282"
            }
        };
        }

        private async Task OnLogin()
        {
            try
            {
                await Shell.Current.GoToAsync("LoginPage");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Navigation to Login failed: {ex.Message}");
            }
        }

        private async Task OnRegister()
        {
            try
            {
                await Shell.Current.GoToAsync("RegisterPage");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Navigation to Register failed: {ex.Message}");
            }
        }

        private void StartCarouselAutoScroll()
        {
            _carouselTimer = new System.Timers.Timer(6000); // 3 seconds interval
            _carouselTimer.Elapsed += (sender, e) =>
            {
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    if (CarouselItems != null && CarouselItems.Count > 0)
                    {
                        CurrentCarouselPosition = (CurrentCarouselPosition + 1) % CarouselItems.Count;
                    }
                });
            };
            _carouselTimer.Start();
        }

        // ADD THIS METHOD to stop timer when page is destroyed
        public void StopCarouselAutoScroll()
        {
            _carouselTimer?.Stop();
            _carouselTimer?.Dispose();
        }

        private async Task OnOpenWebsite()
        {
            try
            {
                string url = "https://www.ccmlplabs.com";
                await Microsoft.Maui.ApplicationModel.Launcher.OpenAsync(url);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Failed to open website: {ex.Message}");
            }
        }
    }

    public class CarouselItemModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public ImageSource Icon { get; set; }
        public string GradientStart { get; set; }
        public string GradientEnd { get; set; }
    }
}