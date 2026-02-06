using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace EC_Youth_Portal.ViewModel
{
    [QueryProperty(nameof(OpportunityType), "OpportunityType")]
    [QueryProperty(nameof(Title), "Title")]
    [QueryProperty(nameof(Company), "Company")]
    [QueryProperty(nameof(MatchScore), "MatchScore")]
    [QueryProperty(nameof(Location), "Location")]
    [QueryProperty(nameof(Value), "Value")]
    [QueryProperty(nameof(JobType), "JobType")]
    [QueryProperty(nameof(Salary), "Salary")]
    [QueryProperty(nameof(Duration), "Duration")]
    [QueryProperty(nameof(Description), "Description")]

    public  class ApplyOpportunityPageViewModel : INotifyPropertyChanged
    {
        private string _opportunityType;
        private string _title;
        private string _company;
        private string _matchScore;
        private string _location;
        private string _value;
        private string _jobType;
        private string _salary;
        private string _duration;
        private string _description;

        // Properties
        public string OpportunityType
        {
            get => _opportunityType;
            set
            {
                _opportunityType = value;
                OnPropertyChanged();
            }
        }

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }

        public string Company
        {
            get => _company;
            set
            {
                _company = value;
                OnPropertyChanged();
            }
        }

        public string MatchScore
        {
            get => _matchScore;
            set
            {
                _matchScore = value;
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

        public string Value
        {
            get => _value;
            set
            {
                _value = value;
                OnPropertyChanged();
            }
        }

        public string JobType
        {
            get => _jobType;
            set
            {
                _jobType = value;
                OnPropertyChanged();
            }
        }

        public string Salary
        {
            get => _salary;
            set
            {
                _salary = value;
                OnPropertyChanged();
            }
        }

        public string Duration
        {
            get => _duration;
            set
            {
                _duration = value;
                OnPropertyChanged();
            }
        }

        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged();
            }
        }

        // Computed properties for display
        public string DetailLabel => OpportunityType == "Bursary" ? "💰 Value" : "💼 Type";
        public string DetailValue => OpportunityType == "Bursary" ? Value ?? Duration : JobType ?? Salary;

        // Commands
        public ICommand BackCommand { get; }
        public ICommand SaveOpportunityCommand { get; }
        public ICommand ApplyCommand { get; }

        public ApplyOpportunityPageViewModel()
        {
            BackCommand = new Command(async () => await GoBack());
            SaveOpportunityCommand = new Command(async () => await SaveOpportunity());
            ApplyCommand = new Command(async () => await Apply());
        }

        private async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }

        private async Task SaveOpportunity()
        {
            // TODO: Save opportunity to favorites/saved list
            await Application.Current.MainPage.DisplayAlert(
                "Saved",
                $"{Title} has been saved to your favorites!",
                "OK");
        }

        private async Task Apply()
        {
            bool confirm = await Application.Current.MainPage.DisplayAlert(
                "Apply",
                $"Are you ready to apply for {Title}?",
                "Yes, Apply",
                "Not Yet");

            if (confirm)
            {
                // TODO: Navigate to application form or submit application
                await Application.Current.MainPage.DisplayAlert(
                    "Success",
                    "Your application has been submitted successfully!",
                    "OK");

                // Navigate back to dashboard
                await Shell.Current.GoToAsync("//DashboardTabs/DashboardHome");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

























