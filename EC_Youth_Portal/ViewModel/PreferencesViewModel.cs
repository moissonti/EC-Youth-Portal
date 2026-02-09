using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;

namespace EC_Youth_Portal.ViewModel
{
    public class PreferencesViewModel : BaseViewModel
    {

        private bool _enableY2RConnect;
        private bool _notifyByEmail;
        private bool _notifyBySMS;
        private bool _notifyByPush;
        private string _notificationFrequency;
        private string _preferredLanguage;
        private string _profileVisibility;

        // Y2R Connect
        public bool EnableY2RConnect
        {
            get => _enableY2RConnect;
            set => SetProperty(ref _enableY2RConnect, value);
        }

        // Notification Settings
        public bool NotifyByEmail
        {
            get => _notifyByEmail;
            set => SetProperty(ref _notifyByEmail, value);
        }

        public bool NotifyBySMS
        {
            get => _notifyBySMS;
            set => SetProperty(ref _notifyBySMS, value);
        }

        public bool NotifyByPush
        {
            get => _notifyByPush;
            set => SetProperty(ref _notifyByPush, value);
        }

        public string NotificationFrequency
        {
            get => _notificationFrequency;
            set => SetProperty(ref _notificationFrequency, value);
        }

        // Accessibility
        public string PreferredLanguage
        {
            get => _preferredLanguage;
            set => SetProperty(ref _preferredLanguage, value);
        }

        // Privacy
        public string ProfileVisibility
        {
            get => _profileVisibility;
            set => SetProperty(ref _profileVisibility, value);
        }

        // Commands
        public ICommand BackCommand { get; }
        public ICommand SaveSettingsCommand { get; }

        public PreferencesViewModel()
        {
            BackCommand = new Command(async () => await GoBack());
            SaveSettingsCommand = new Command(async () => await SaveSettings());

            // Load existing settings
            LoadSettings();
        }

        private void LoadSettings()
        {
            // TODO: Load from database/preferences
            // For now, set defaults
            EnableY2RConnect = true;
            NotifyByEmail = true;
            NotifyBySMS = false;
            NotifyByPush = true;
            NotificationFrequency = "Daily";
            PreferredLanguage = "English";
            ProfileVisibility = "Recruiters only";
        }

        private async Task SaveSettings()
        {
            // Validation
            if (string.IsNullOrWhiteSpace(PreferredLanguage))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Please select a preferred language",
                    "OK");
                return;
            }

            if (string.IsNullOrWhiteSpace(ProfileVisibility))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Please select profile visibility",
                    "OK");
                return;
            }

            // TODO: Save to database/preferences
            // For now, just show success message
            await Application.Current.MainPage.DisplayAlert(
                "Success",
                "Your settings have been saved successfully!",
                "OK");

            // Navigate back
            await Shell.Current.GoToAsync("..");
        }

        private async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
