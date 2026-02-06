using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;

namespace EC_Youth_Portal.ViewModel
{
    public class AccountInformationPageViewModel : BaseViewModel
    {
        private string _fullName;
        private string _email;
        private string _location;
        private bool _isChangingPassword;
        private string _currentPassword;
        private string _newPassword;
        private string _confirmPassword;

        // Properties
        
        public string FullName
        {
            get => _fullName;
            set => SetProperty(ref _fullName, value);
        }


        public string Email
        {
            get => _email;
            set
            {
                _email = value;
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

        public bool IsChangingPassword
        {
            get => _isChangingPassword;
            set
            {
                _isChangingPassword = value;
                OnPropertyChanged();
            }
        }

        public string CurrentPassword
        {
            get => _currentPassword;
            set
            {
                _currentPassword = value;
                OnPropertyChanged();
            }
        }

        public string NewPassword
        {
            get => _newPassword;
            set
            {
                _newPassword = value;
                OnPropertyChanged();
            }
        }

        public string ConfirmPassword
        {
            get => _confirmPassword;
            set
            {
                _confirmPassword = value;
                OnPropertyChanged();
            }
        }

        // Commands
        public ICommand SaveCommand { get; }
        public ICommand BackCommand { get; }
        public ICommand DeleteAccountCommand { get; }

        public AccountInformationPageViewModel()
        {
            SaveCommand = new Command(async () => await SaveAccountInfo());
            BackCommand = new Command(async () => await GoBack());
            DeleteAccountCommand = new Command(async () => await DeleteAccount());

            // Load existing account data
            LoadAccountData();
        }

        private void LoadAccountData()
        {
            // TODO: Load from database/API
            // For now, mock data
            FullName = "John Doe";
            Email = "john.doe@example.com";
            Location = "East London, Eastern Cape";
        }

        private async Task SaveAccountInfo()
        {
            // Validation
            if (string.IsNullOrWhiteSpace(FullName))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Full Name is required", "OK");
                return;
            }

            if (string.IsNullOrWhiteSpace(Email))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Email is required", "OK");
                return;
            }

            if (!IsValidEmail(Email))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please enter a valid email address", "OK");
                return;
            }

            if (string.IsNullOrWhiteSpace(Location))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Location is required", "OK");
                return;
            }

            // If changing password, validate password fields
            if (IsChangingPassword)
            {
                if (string.IsNullOrWhiteSpace(CurrentPassword))
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Current password is required", "OK");
                    return;
                }

                if (string.IsNullOrWhiteSpace(NewPassword))
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "New password is required", "OK");
                    return;
                }

                if (NewPassword.Length < 8)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Password must be at least 8 characters", "OK");
                    return;
                }

                if (NewPassword != ConfirmPassword)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Passwords do not match", "OK");
                    return;
                }

                // TODO: Verify current password with backend
                // TODO: Update password in database
            }

            // TODO: Save account information to database/API
            await Task.Delay(500); // Simulate API call

            await Application.Current.MainPage.DisplayAlert(
                "Success",
                "Account information updated successfully!",
                "OK");

            // Clear password fields after successful save
            if (IsChangingPassword)
            {
                CurrentPassword = string.Empty;
                NewPassword = string.Empty;
                ConfirmPassword = string.Empty;
                IsChangingPassword = false;
            }
        }

        private async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }

        private async Task DeleteAccount()
        {
            bool confirm = await Application.Current.MainPage.DisplayAlert(
                "Delete Account",
                "Are you sure you want to delete your account? This action cannot be undone and all your data will be permanently removed.",
                "Yes, Delete",
                "Cancel");

            if (confirm)
            {
                // Double confirmation for safety
                bool doubleConfirm = await Application.Current.MainPage.DisplayAlert(
                    "Final Confirmation",
                    "This is your last chance. Are you absolutely sure you want to delete your account?",
                    "Yes, I'm Sure",
                    "Cancel");

                if (doubleConfirm)
                {
                    // TODO: Call API to delete account
                    await Task.Delay(500); // Simulate API call

                    await Application.Current.MainPage.DisplayAlert(
                        "Account Deleted",
                        "Your account has been deleted. You will now be logged out.",
                        "OK");

                    // Navigate back to login/main page
                    await Shell.Current.GoToAsync("//MainTabs");
                }
            }
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
