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
        // Will Move all these to become Models on all my view Models
        private string _welcomeMessage = "Welcome back, User!";
        private string _subMessage = "Here's what's happening with your opportunities today.";
        private string _userLocation = "East London, Eastern Cape";
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

        public string UserLocation
        {
            get => _userLocation;
            set { _userLocation = value; OnPropertyChanged(); }
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

        public ICommand ViewBursaryDetailCommand { get; }
        public ICommand ViewJobDetailCommand { get; }
        public ICommand ViewAllOpportunitiesCommand { get; }
        public ICommand NotificationsTappedCommand { get; }
        public ICommand OptionsTappedCommand { get; }
        public ICommand ViewApplicationsCommand { get; }
        public ICommand ViewOpportunitiesCommand { get; }
        public ICommand ViewMessagesCommand { get; }
        public ICommand BrowseJobsCommand { get; }
        public ICommand UpdateProfileCommand { get; }
        public ICommand Y2RConnectCommand { get; }
        public ICommand SearchTappedCommand { get; }
        public ICommand ChangeLocationCommand { get; }

        public DashboardLandingPageViewModel()
        {
            //ProfileTappedCommand = new Command(OnProfileTapped);
            NotificationsTappedCommand = new Command(OnNotificationsTapped);
            OptionsTappedCommand = new Command(OnOptionsTapped);
            ViewApplicationsCommand = new Command(OnViewApplications);
            ViewOpportunitiesCommand = new Command(OnViewOpportunities);
            ViewMessagesCommand = new Command(OnViewMessages);
            BrowseJobsCommand = new Command(OnBrowseJobs);
            UpdateProfileCommand = new Command(OnUpdateProfile);
            Y2RConnectCommand = new Command(OnY2RConnect);
            SearchTappedCommand = new Command(OnSearchTapped);
            ChangeLocationCommand = new Command(OnChangeLocation);
            ViewBursaryDetailCommand = new Command(async () => await OnViewBursaryDetail());
            ViewJobDetailCommand = new Command(async () => await OnViewJobDetail());
            ViewAllOpportunitiesCommand = new Command(async () => await OnViewAllOpportunities());
        }

        private async Task OnViewBursaryDetail()
        {
            // Pass bursary data to the detail page
                    var navigationParameter = new Dictionary<string, object>
            {
                { "OpportunityType", "Bursary" },
                { "Title", "Engineering Excellence Bursary 2026" },
                { "Company", "National Bursary Foundation" },
                { "MatchScore", "95% Match" },
                { "Location", "Eastern Cape" },
                { "Value", "R120,000 p/a" },
                { "Duration", "4 Years" },
                { "Description", "Full bursary covering tuition, accommodation, and living expenses for Engineering students." }
            };

            await Shell.Current.GoToAsync("ApplyOpportunityPage", navigationParameter);
        }

        private async Task OnViewJobDetail()
        {
            // Pass job data to the detail page
            var navigationParameter = new Dictionary<string, object>
                {
                    { "OpportunityType", "Job" },
                    { "Title", "Junior Software Developer" },
                    { "Company", "Tech Solutions SA" },
                    { "MatchScore", "88% Match" },
                    { "Location", "East London" },
                    { "JobType", "Full-time" },
                    { "Salary", "R25,000 - R35,000" },
                    { "Description", "Exciting opportunity for a Junior Software Developer to join our growing team." }
                };

            await Shell.Current.GoToAsync("ApplyOpportunityPage", navigationParameter);
        }

        private async Task OnViewAllOpportunities()
        {
            await Shell.Current.DisplayAlert("All Opportunities", "View all opportunities page coming soon!", "OK");
        }

        private async void OnSearchTapped()
        {
            // TODO: Navigate to search page when created
            await Shell.Current.DisplayAlert("Search", "Search page coming soon!", "OK");
        }

        private async void OnChangeLocation()
        {
            await Shell.Current.DisplayAlert("Location", "Change location feature coming soon!", "OK");
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
            //await Shell.Current.DisplayAlert("Update Profile", "Edit your profile", "OK");
            await Shell.Current.GoToAsync("//DashboardTabs/MyProfilePage");
        }

        private async void OnY2RConnect()
        {
            await Shell.Current.GoToAsync("//DashboardTabs/ApplicationsPage");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
