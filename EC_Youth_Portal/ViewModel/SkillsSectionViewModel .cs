using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;

namespace EC_Youth_Portal.ViewModel
{
    public class SkillsSectionViewModel : INotifyPropertyChanged
    {
        private string _employmentStatus;
        private bool _isEmployed;
        private string _companyName;
        private string _position;
        private string _duration;
        private string _technicalSkillsDisplayText = "Select technical skills";
        private string _softSkillsDisplayText = "Select soft skills";
        private string _industriesDisplayText = "Select industries";
        private string _goalsDisplayText = "Select your goals";

        public string EmploymentStatus
        {
            get => _employmentStatus;
            set
            {
                _employmentStatus = value;
                IsEmployed = value == "Working full-time" || value == "Working part-time" || value == "Freelancer";
                OnPropertyChanged();
            }
        }

        public bool IsEmployed { get => _isEmployed; set { _isEmployed = value; OnPropertyChanged(); } }
        public string CompanyName { get => _companyName; set { _companyName = value; OnPropertyChanged(); } }
        public string Position { get => _position; set { _position = value; OnPropertyChanged(); } }
        public string Duration { get => _duration; set { _duration = value; OnPropertyChanged(); } }

        public string TechnicalSkillsDisplayText { get => _technicalSkillsDisplayText; set { _technicalSkillsDisplayText = value; OnPropertyChanged(); } }
        public string SoftSkillsDisplayText { get => _softSkillsDisplayText; set { _softSkillsDisplayText = value; OnPropertyChanged(); } }
        public string IndustriesDisplayText { get => _industriesDisplayText; set { _industriesDisplayText = value; OnPropertyChanged(); } }
        public string GoalsDisplayText { get => _goalsDisplayText; set { _goalsDisplayText = value; OnPropertyChanged(); } }

        public Color TechnicalSkillsTextColor => Color.FromArgb("#94A3B8");
        public Color SoftSkillsTextColor => Color.FromArgb("#94A3B8");
        public Color IndustriesTextColor => Color.FromArgb("#94A3B8");
        public Color GoalsTextColor => Color.FromArgb("#94A3B8");

        public bool HasTechnicalSkills => false;
        public bool HasSoftSkills => false;
        public bool HasIndustries => false;
        public bool HasGoals => false;

        public string SelectedTechnicalSkillsText => "";
        public string SelectedSoftSkillsText => "";
        public string SelectedIndustriesText => "";
        public string SelectedGoalsText => "";

        public ICommand OpenTechnicalSkillsCommand { get; }
        public ICommand OpenSoftSkillsCommand { get; }
        public ICommand OpenIndustriesCommand { get; }
        public ICommand OpenGoalsCommand { get; }

        public SkillsSectionViewModel()
        {
            OpenTechnicalSkillsCommand = new Command(async () => await OpenTechnicalSkills());
            OpenSoftSkillsCommand = new Command(async () => await OpenSoftSkills());
            OpenIndustriesCommand = new Command(async () => await OpenIndustries());
            OpenGoalsCommand = new Command(async () => await OpenGoals());
        }

        private async Task OpenTechnicalSkills()
        {
            await Application.Current.MainPage.DisplayAlert("Skills", "Multi-select coming soon!", "OK");
        }

        private async Task OpenSoftSkills()
        {
            await Application.Current.MainPage.DisplayAlert("Skills", "Multi-select coming soon!", "OK");
        }

        private async Task OpenIndustries()
        {
            await Application.Current.MainPage.DisplayAlert("Industries", "Multi-select coming soon!", "OK");
        }

        private async Task OpenGoals()
        {
            await Application.Current.MainPage.DisplayAlert("Goals", "Multi-select coming soon!", "OK");
        }

        public async Task<bool> SaveSkills()
        {
            if (string.IsNullOrWhiteSpace(EmploymentStatus))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Employment Status is required", "OK");
                return false;
            }

            // TODO: Save to database/API
            await Task.Delay(500);
            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
