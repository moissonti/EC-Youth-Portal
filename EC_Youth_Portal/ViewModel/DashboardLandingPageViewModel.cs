using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;

namespace EC_Youth_Portal.ViewModel
{
    public class DashboardLandingPageViewModel : INotifyPropertyChanged 
    {
        private string _welcomeMessage = "Welcome back, User!";
        private string _subMessage = "Here's what's happening with your opportunities today.";
        private int _applicationCount = 5;
        private int _opportunityCount = 23;
        private string _profileCompletionPercentage = "85%";
        private int _messageCount = 3;
        private bool _hasNotifications = true;
        private int _notificationCount = 2;

        // Properties
        public string WelcomeMessage
        {
            get => _welcomeMessage;
            set { _welcomeMessage = value; OnPropertyChanged(); }
        }

        public string SubMessage
        {
            get => _subMessage;
            set { _subMessage = value; OnPropertyChanged(); }
        }

        public int ApplicationCount
        {
            get => _applicationCount;
            set { _applicationCount = value; OnPropertyChanged(); }
        }

        public int OpportunityCount
        {
            get => _opportunityCount;
            set { _opportunityCount = value; OnPropertyChanged(); }
        }

        public string ProfileCompletionPercentage
        {
            get => _profileCompletionPercentage;
            set { _profileCompletionPercentage = value; OnPropertyChanged(); }
        }

        public int MessageCount
        {
            get => _messageCount;
            set { _messageCount = value; OnPropertyChanged(); }
        }

        public bool HasNotifications
        {
            get => _hasNotifications;
            set { _hasNotifications = value; OnPropertyChanged(); }
        }

        public int NotificationCount
        {
            get => _notificationCount;
            set { _notificationCount = value; OnPropertyChanged(); }
        }

        // Commands
        public ICommand ProfileTappedCommand { get; }
        public ICommand NotificationsTappedCommand { get; }
        public ICommand OptionsTappedCommand { get; }
        public ICommand ViewApplicationsCommand { get; }
        public ICommand ViewOpportunitiesCommand { get; }
        public ICommand ViewMessagesCommand { get; }
        public ICommand BrowseJobsCommand { get; }
        public ICommand UpdateProfileCommand { get; }
        public ICommand Y2RConnectCommand { get; }

        public DashboardLandingPageViewModel()
        {
            ProfileTappedCommand = new Command(OnProfileTapped);
            NotificationsTappedCommand = new Command(OnNotificationsTapped);
            OptionsTappedCommand = new Command(OnOptionsTapped);
            ViewApplicationsCommand = new Command(OnViewApplications);
            ViewOpportunitiesCommand = new Command(OnViewOpportunities);
            ViewMessagesCommand = new Command(OnViewMessages);
            BrowseJobsCommand = new Command(OnBrowseJobs);
            UpdateProfileCommand = new Command(OnUpdateProfile);
            Y2RConnectCommand = new Command(OnY2RConnect);
        }

        private async void OnProfileTapped()
        {
            await Shell.Current.DisplayAlert("Profile", "Navigate to profile page", "OK");
        }

        private async void OnNotificationsTapped()
        {
            await Shell.Current.DisplayAlert("Notifications", $"You have {NotificationCount} new notifications", "OK");
        }

        private async void OnOptionsTapped()
        {
            var action = await Shell.Current.DisplayActionSheet(
                "Options",
                "Cancel",
                null,
                "Settings",
                "Help & Support",
                "Logout");

            if (action == "Logout")
            {
                await Shell.Current.GoToAsync("//MainTabs");
            }
        }

        private async void OnViewApplications()
        {
            await Shell.Current.GoToAsync("//DashboardTabs/ApplicationsPage");
        }

        private async void OnViewOpportunities()
        {
            await Shell.Current.DisplayAlert("Opportunities", "Browse opportunities", "OK");
        }

        private async void OnViewMessages()
        {
            await Shell.Current.DisplayAlert("Messages", $"You have {MessageCount} unread messages", "OK");
        }

        private async void OnBrowseJobs()
        {
            await Shell.Current.DisplayAlert("Browse Jobs", "View all available jobs", "OK");
        }

        private async void OnUpdateProfile()
        {
            await Shell.Current.DisplayAlert("Update Profile", "Edit your profile", "OK");
        }

        private async void OnY2RConnect()
        {
            await Shell.Current.GoToAsync("//DashboardTabs/Y2RPage");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
