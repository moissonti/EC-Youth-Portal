using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace EC_Youth_Portal.ViewModel
{
    public class MyProfilePageViewModel : INotifyPropertyChanged
    {

        // Will Move all these to become Models on all my view Models
        private string _userName = "John Doe";
        private string _userEmail = "john.doe@example.com";
        private string _profileCompletionPercentage = "85%";

        // Properties
        public string UserName
        {
            get => _userName;
            set
            {
                _userName = value;
                OnPropertyChanged();
            }
        }

        public string UserEmail
        {
            get => _userEmail;
            set
            {
                _userEmail = value;
                OnPropertyChanged();
            }
        }

        public string ProfileCompletionPercentage
        {
            get => _profileCompletionPercentage;
            set
            {
                _profileCompletionPercentage = value;
                OnPropertyChanged();
            }
        }

        // Commands
        public ICommand OptionsCommand { get; }
        public ICommand EditProfileCommand { get; }
        public ICommand NavigateToSavedItemsCommand { get; }
        public ICommand NavigateToPersonalInfoCommand { get; }
        public ICommand NavigateToSettingsCommand { get; }
        public ICommand NavigateToAboutCommand { get; }
        public ICommand NavigateToPrivacyCommand { get; }
        public ICommand LogoutCommand { get; }

        public MyProfilePageViewModel()
        {
            OptionsCommand = new Command(OnOptions);
            EditProfileCommand = new Command(OnEditProfile);
            NavigateToSavedItemsCommand = new Command(OnNavigateToSavedItems);
            NavigateToPersonalInfoCommand = new Command(OnNavigateToPersonalInfo);
            NavigateToSettingsCommand = new Command(OnNavigateToSettings);
            NavigateToAboutCommand = new Command(OnNavigateToAbout);
            NavigateToPrivacyCommand = new Command(OnNavigateToPrivacy);
            LogoutCommand = new Command(OnLogout);
        }

        private async void OnOptions()
        {
            var action = await Shell.Current.DisplayActionSheet(
                "Options",
                "Cancel",
                null,
                "Share Profile",
                "Help & Support");

            if (action == "Share Profile")
            {
                await Shell.Current.DisplayAlert("Share", "Share profile feature coming soon!", "OK");
            }
            else if (action == "Help & Support")
            {
                await Shell.Current.DisplayAlert("Support", "Help & support feature coming soon!", "OK");
            }
        }

        private async void OnEditProfile()
        {
            
            await Shell.Current.GoToAsync("EditProfilePage");
            //await Shell.Current.DisplayAlert("Edit Profile", "Edit profile page coming soon!", "OK");
        }

        private async void OnNavigateToSavedItems()
        {
            // TODO: Navigate to saved items page
            await Shell.Current.DisplayAlert("Saved Items", "Saved items page coming soon!", "OK");
        }

        private async void OnNavigateToPersonalInfo()
        {
            
            await Shell.Current.GoToAsync("AccountInformationPage");
        }

        private async void OnNavigateToSettings()
        {
            await Shell.Current.GoToAsync("SettingsPage");
        }

        private async void OnNavigateToAbout()
        {
            // TODO: Navigate to about page
            await Shell.Current.DisplayAlert("About", "About page coming soon!", "OK");
        }

        private async void OnNavigateToPrivacy()
        {
            // TODO: Navigate to privacy page
            await Shell.Current.DisplayAlert("Privacy", "Privacy page coming soon!", "OK");
        }

        private async void OnLogout()
        {
            var confirm = await Shell.Current.DisplayAlert(
                "Logout",
                "Are you sure you want to logout?",
                "Yes",
                "No");

            if (confirm)
            {
                // Navigate back to main tabs (login screen)
                await Shell.Current.GoToAsync("//MainPage");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }   
}

