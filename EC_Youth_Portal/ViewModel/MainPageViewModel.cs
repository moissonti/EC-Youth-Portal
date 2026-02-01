using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;

namespace EC_Youth_Portal.ViewModel
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public MainPageViewModel()
        {
            // Initialize commands
            LoginCommand = new Command(OnLogin);
            RegisterCommand = new Command(OnRegister);
            OpenWebsiteCommand = new Command(OnOpenWebsite);
        }

        #region Properties

        // Add your properties here as needed

        #endregion

        #region Commands
        public ICommand LoginCommand { get; }
        public ICommand RegisterCommand { get; }
        public ICommand OpenWebsiteCommand { get; }

        #endregion

        #region Command Methods

        private async void OnLogin()
        {
            // Navigate to login page
            try
            {
                await Application.Current.MainPage.Navigation.PushAsync(
                    new Views.LoginPage());
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Navigation error: {ex.Message}");
            }
        }

        private void OnRegister()
        {
            // Navigate to register page
            try
            {
                Application.Current.MainPage.Navigation.PushAsync(
                    new Views.RegisterPage());
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Navigation error: {ex.Message}");
            }
        }

        private async void OnOpenWebsite()
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

        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}




