using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace EC_Youth_Portal.ViewModel
{
    public class MainPageViewModel : BaseViewModel
    {
        public MainPageViewModel()
        {
            LoginCommand = new Command(async () => await OnLogin());
            RegisterCommand = new Command(async () => await OnRegister());
            OpenWebsiteCommand = new Command(async () => await OnOpenWebsite());
        }

        #region Commands
        public ICommand LoginCommand { get; }
        public ICommand RegisterCommand { get; }
        public ICommand OpenWebsiteCommand { get; }
        #endregion

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
}