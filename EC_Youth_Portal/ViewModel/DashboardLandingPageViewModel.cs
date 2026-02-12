using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;

namespace EC_Youth_Portal.ViewModel
{
    public class DashboardLandingPageViewModel : BaseViewModel
    {
        // Private fields
        private string _welcomeMessage = "Welcome back, User!";
        private string _userLocation = "East London, Eastern Cape";
        private int _applicationCount = 5;
        private int _opportunityCount = 23;
        private string _profileCompletionPercentage = "85%";
        private int _messageCount = 3;
        private bool _hasNotifications = true;
        private int _notificationCount = 2;
        private string _selectedFilter = "All";

        // Properties using SetProperty
        public string WelcomeMessage
        {
            get => _welcomeMessage;
            set => SetProperty(ref _welcomeMessage, value);
        }

        public string UserLocation
        {
            get => _userLocation;
            set => SetProperty(ref _userLocation, value);
        }

        public int ApplicationCount
        {
            get => _applicationCount;
            set => SetProperty(ref _applicationCount, value);
        }

        public int OpportunityCount
        {
            get => _opportunityCount;
            set => SetProperty(ref _opportunityCount, value);
        }

        public string ProfileCompletionPercentage
        {
            get => _profileCompletionPercentage;
            set => SetProperty(ref _profileCompletionPercentage, value);
        }

        public int MessageCount
        {
            get => _messageCount;
            set => SetProperty(ref _messageCount, value);
        }

        public bool HasNotifications
        {
            get => _hasNotifications;
            set => SetProperty(ref _hasNotifications, value);
        }

        public int NotificationCount
        {
            get => _notificationCount;
            set => SetProperty(ref _notificationCount, value);
        }

        public string SelectedFilter
        {
            get => _selectedFilter;
            set => SetProperty(ref _selectedFilter, value, onChanged: FilterOpportunities);
        }

        // Observable Collections
        public ObservableCollection<OpportunityCard> Opportunities { get; set; }

        // Commands - Only the ones actually being used
        public ICommand ViewOpportunityDetailCommand { get; }
        public ICommand NotificationsTappedCommand { get; }
        public ICommand OptionsTappedCommand { get; }
        public ICommand ViewApplicationsCommand { get; }
        public ICommand ViewMessagesCommand { get; }
        public ICommand UpdateProfileCommand { get; }
        public ICommand SearchTappedCommand { get; }
        public ICommand FilterCommand { get; }
        public ICommand ViewAllOpportunitiesCommand { get; }

        // Constructor
        public DashboardLandingPageViewModel()
        {
            // Initialize Commands
            ViewOpportunityDetailCommand = new Command<OpportunityCard>(async (card) => await OnViewOpportunityDetail(card));
            NotificationsTappedCommand = new Command(OnNotificationsTapped);
            OptionsTappedCommand = new Command(OnOptionsTapped);
            ViewApplicationsCommand = new Command(OnViewApplications);
            ViewMessagesCommand = new Command(OnViewMessages);
            UpdateProfileCommand = new Command(OnUpdateProfile);
            SearchTappedCommand = new Command(OnSearchTapped);
            FilterCommand = new Command<string>(OnFilterSelected);
            //ViewAllOpportunitiesCommand = new Command(async () => await OnViewAllOpportunities);

            // Initialize Sample Opportunities
            InitializeOpportunities();
        }

        // Initialize Opportunities
        private void InitializeOpportunities()
        {
            Opportunities = new ObservableCollection<OpportunityCard>
            {
                new OpportunityCard
                {
                    Type = "Bursary",
                    Title = "Engineering Excellence Bursary 2026",
                    Company = "National Bursary Foundation",
                    MatchScore = 95,
                    Location = "Eastern Cape",
                    Detail1Label = "Value",
                    Detail1Value = "R120,000 p/a",
                    Detail2Label = "Duration",
                    Detail2Value = "4 Years",
                    IconPath = "M12 2L3 7V8H21V7L12 2ZM12 4.236L17.236 7H6.764L12 4.236ZM4 9V11H6V9H4ZM7 9V11H9V9H7ZM10 9V11H12V9H10ZM13 9V11H15V9H13ZM16 9V11H18V9H16ZM4 12V14H6V12H4ZM7 12V14H9V12H7ZM10 12V14H12V12H10ZM13 12V14H15V12H13ZM16 12V14H18V12H16ZM3 15V17H21V15H3ZM2 18V20H22V18H2Z",
                    Description = "Full bursary covering tuition, accommodation, and living expenses for Engineering students."
                },
                new OpportunityCard
                {
                    Type = "Job",
                    Title = "Junior Software Developer",
                    Company = "Tech Solutions SA",
                    MatchScore = 88,
                    Location = "East London",
                    Detail1Label = "Salary",
                    Detail1Value = "R25k - R35k",
                    Detail2Label = "Type",
                    Detail2Value = "Full-time",
                    IconPath = "M8 2C7.448 2 7 2.448 7 3V4H4C2.895 4 2 4.895 2 6V18C2 19.105 2.895 20 4 20H16C17.105 20 18 19.105 18 18V6C18 4.895 17.105 4 16 4H13V3C13 2.448 12.552 2 12 2H8ZM8 3H12V5H8V3ZM4 5H7V6H13V5H16C16.552 5 17 5.448 17 6V9H3V6C3 5.448 3.448 5 4 5ZM3 10H17V18C17 18.552 16.552 19 16 19H4C3.448 19 3 18.552 3 18V10Z",
                    Description = "Exciting opportunity for a Junior Software Developer to join our growing team."
                },
                new OpportunityCard
                {
                    Type = "Internship",
                    Title = "Digital Marketing Internship",
                    Company = "Creative Agency EC",
                    MatchScore = 82,
                    Location = "Port Elizabeth",
                    Detail1Label = "Duration",
                    Detail1Value = "12 Months",
                    Detail2Label = "Stipend",
                    Detail2Value = "R6,000 p/m",
                    IconPath = "M3 3V21H21V3H3ZM5 5H19V19H5V5ZM7 7V9H17V7H7ZM7 11V13H17V11H7ZM7 15V17H14V15H7Z",
                    Description = "Gain hands-on experience in digital marketing with a creative team."
                },
                new OpportunityCard
                {
                    Type = "Learnership",
                    Title = "Business Management NQF5",
                    Company = "Skills Development Institute",
                    MatchScore = 91,
                    Location = "Eastern Cape",
                    Detail1Label = "Duration",
                    Detail1Value = "18 Months",
                    Detail2Label = "Level",
                    Detail2Value = "NQF Level 5",
                    IconPath = "M19 3H14.82C14.4 1.84 13.3 1 12 1C10.7 1 9.6 1.84 9.18 3H5C3.9 3 3 3.9 3 5V19C3 20.1 3.9 21 5 21H19C20.1 21 21 20.1 21 19V5C21 3.9 20.1 3 19 3ZM12 3C12.55 3 13 3.45 13 4C13 4.55 12.55 5 12 5C11.45 5 11 4.55 11 4C11 3.45 11.45 3 12 3ZM7 7H17V9H7V7ZM7 11H17V13H7V11ZM7 15H14V17H7V15Z",
                    Description = "Comprehensive business management learnership with certification."
                },
                new OpportunityCard
                {
                    Type = "Job",
                    Title = "Data Analyst",
                    Company = "Analytics Corp",
                    MatchScore = 78,
                    Location = "Gqeberha",
                    Detail1Label = "Salary",
                    Detail1Value = "R30k - R40k",
                    Detail2Label = "Type",
                    Detail2Value = "Hybrid",
                    IconPath = "M8 2C7.448 2 7 2.448 7 3V4H4C2.895 4 2 4.895 2 6V18C2 19.105 2.895 20 4 20H16C17.105 20 18 19.105 18 18V6C18 4.895 17.105 4 16 4H13V3C13 2.448 12.552 2 12 2H8ZM8 3H12V5H8V3ZM4 5H7V6H13V5H16C16.552 5 17 5.448 17 6V9H3V6C3 5.448 3.448 5 4 5ZM3 10H17V18C17 18.552 16.552 19 16 19H4C3.448 19 3 18.552 3 18V10Z",
                    Description = "Analyze data and provide insights for business decision-making."
                },
                new OpportunityCard
                {
                    Type = "Bursary",
                    Title = "Medical Sciences Bursary",
                    Company = "Health Department EC",
                    MatchScore = 92,
                    Location = "Eastern Cape",
                    Detail1Label = "Value",
                    Detail1Value = "R150,000 p/a",
                    Detail2Label = "Duration",
                    Detail2Value = "5 Years",
                    IconPath = "M12 2L3 7V8H21V7L12 2ZM12 4.236L17.236 7H6.764L12 4.236ZM4 9V11H6V9H4ZM7 9V11H9V9H7ZM10 9V11H12V9H10ZM13 9V11H15V9H13ZM16 9V11H18V9H16ZM4 12V14H6V12H4ZM7 12V14H9V12H7ZM10 12V14H12V12H10ZM13 12V14H15V12H13ZM16 12V14H18V12H16ZM3 15V17H21V15H3ZM2 18V20H22V18H2Z",
                    Description = "Full medical sciences bursary for aspiring healthcare professionals."
                }
            };
        }

        // Filter Logic
        private void FilterOpportunities()
        {
            // TODO: Implement filtering logic
            // This would filter the Opportunities collection based on SelectedFilter
            System.Diagnostics.Debug.WriteLine($"Filter selected: {SelectedFilter}");
        }

        private void OnFilterSelected(string filter)
        {
            SelectedFilter = filter;
        }

        // Navigation Methods
        private async Task OnViewOpportunityDetail(OpportunityCard opportunity)
        {
            if (opportunity == null) return;

            var navigationParameter = new Dictionary<string, object>
            {
                { "OpportunityType", opportunity.Type },
                { "Title", opportunity.Title },
                { "Company", opportunity.Company },
                { "MatchScore", $"{opportunity.MatchScore}% Match" },
                { "Location", opportunity.Location },
                { "Description", opportunity.Description }
            };

            // Add type-specific parameters
            if (opportunity.Type == "Bursary")
            {
                navigationParameter.Add("Value", opportunity.Detail1Value);
                navigationParameter.Add("Duration", opportunity.Detail2Value);
            }
            else if (opportunity.Type == "Job")
            {
                navigationParameter.Add("Salary", opportunity.Detail1Value);
                navigationParameter.Add("JobType", opportunity.Detail2Value);
            }
            else if (opportunity.Type == "Internship")
            {
                navigationParameter.Add("Duration", opportunity.Detail1Value);
                navigationParameter.Add("Stipend", opportunity.Detail2Value);
            }
            else if (opportunity.Type == "Learnership")
            {
                navigationParameter.Add("Duration", opportunity.Detail1Value);
                navigationParameter.Add("Level", opportunity.Detail2Value);
            }

            await Shell.Current.GoToAsync("ApplyOpportunityPage", navigationParameter);
        }

        private async Task OnViewAllOpportunities()
        {
            await Shell.Current.DisplayAlert("All Opportunities", "View all opportunities page coming soon!", "OK");
        }

        private async void OnSearchTapped()
        {
            await Shell.Current.DisplayAlert("Search", "Search page coming soon!", "OK");
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
                await Shell.Current.GoToAsync("//MainPage");
            }
        }

        private async void OnViewApplications()
        {
            await Shell.Current.GoToAsync("//DashboardTabs/ApplicationsPage");
        }

        private async void OnViewMessages()
        {
            await Shell.Current.DisplayAlert("Messages", $"You have {MessageCount} unread messages", "OK");
        }

        private async void OnUpdateProfile()
        {
            await Shell.Current.GoToAsync("//DashboardTabs/MyProfilePage");
        }
    }

    // Opportunity Card Model
    public class OpportunityCard
    {
        public string Type { get; set; }
        public string IconPath { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        public int MatchScore { get; set; }
        public string Location { get; set; }
        public string Detail1Label { get; set; }
        public string Detail1Value { get; set; }
        public string Detail2Label { get; set; }
        public string Detail2Value { get; set; }
        public string Description { get; set; }
    }
}