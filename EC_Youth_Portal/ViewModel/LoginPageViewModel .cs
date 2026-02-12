using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;

namespace EC_Youth_Portal.ViewModel
{
    public class LoginPageViewModel : BaseViewModel
    {

        // Will Move all these to become Models on all my view Models
        private string _email;
        private string _password;
        private string _errorMessage;

        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set => SetProperty(ref _errorMessage, value);
        }

        public ICommand LoginCommand { get; }
        public ICommand GoogleLoginCommand { get; }
        public ICommand MicrosoftLoginCommand { get; }
        public ICommand NavigateToRegisterCommand { get; }
        public ICommand ForgotPasswordCommand { get; }

        public LoginPageViewModel()
        {
            LoginCommand = new Command(async () => await OnLogin());
            GoogleLoginCommand = new Command(async () => await OnGoogleLogin());
            MicrosoftLoginCommand = new Command(async () => await OnMicrosoftLogin());
            NavigateToRegisterCommand = new Command(async () => await OnNavigateToRegister());
            ForgotPasswordCommand = new Command(async () => await OnForgotPassword());
        }

        private async Task OnLogin()
        {
            // Simple validation
            if (string.IsNullOrWhiteSpace(Email))
            {
                ErrorMessage = "Please enter your email address";
                return;
            }

            if (string.IsNullOrWhiteSpace(Password))
            {
                ErrorMessage = "Please enter your password";
                return;
            }

            // Clear any previous error
            ErrorMessage = string.Empty;

            // Navigate to Dashboard tabs
            await Shell.Current.GoToAsync("//DashboardTabs/DashboardHome");
        }

        private async Task OnGoogleLogin()
        {
            // For now, just navigate to dashboard
            // TODO: Implement actual Google authentication
            await Shell.Current.DisplayAlert("Google Authentication", "Login Uisng google", "OK");
        }

        private async Task OnMicrosoftLogin()
        {
            // For now, just navigate to dashboard
            // TODO: Implement actual Microsoft authentication
            await Shell.Current.DisplayAlert("Microsoft Authentication", "Login Uisng Microsoft", "OK");
        }

        private async Task OnNavigateToRegister()
        {
            await Shell.Current.GoToAsync("RegisterPage");
        }

        private async Task OnForgotPassword()
        {
            // TODO: Implement forgot password functionality
            await Application.Current.MainPage.DisplayAlert(
                "Forgot Password",
                "Password recovery feature coming soon!",
                "OK");
        }
    }
}

