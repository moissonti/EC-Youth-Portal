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
                    TypeIcon = "🎓",
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
                    TypeIcon = "💼",
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
                    TypeIcon = "🏢",
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
                    TypeIcon = "🧩",
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
                    TypeIcon = "💼",
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
                    TypeIcon = "🎓",
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
        public string TypeIcon { get; set; }
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