using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
namespace EC_Youth_Portal.ViewModel
{
    public class CreateProfilePageViewModel : INotifyPropertyChanged
    {
        private int _currentStep = 1;
        private ContentView _currentSectionView;
        private string stepColour = "#FFA500";

        public string Step1Color
        {
            get => stepColour;
            set { stepColour = value; OnPropertyChanged(); }
        }

        public string Step2Color
        {
            get => stepColour;
            set { stepColour = value; OnPropertyChanged(); }
        }

        public string Step3Color
        {
            get => stepColour;
            set { stepColour = value; OnPropertyChanged(); }
        }

        public string Step4Color
        {
            get => stepColour;
            set { stepColour = value; OnPropertyChanged(); }
        }

        public string Step5Color
        {
            get => stepColour;
            set { stepColour = value; OnPropertyChanged(); }
        }

        public int CurrentStep
        {
            get => _currentStep;
            set
            {
                _currentStep = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ShowPreviousButton));
                OnPropertyChanged(nameof(NextButtonText));
                UpdateStepIndicators(); 
                LoadCurrentSection();
            }
        }

        public ContentView CurrentSectionView
        {
            get => _currentSectionView;
            set
            {
                _currentSectionView = value;
                OnPropertyChanged();
            }
        }

        public bool ShowPreviousButton => CurrentStep > 1;
        public string NextButtonText => CurrentStep < 5 ? "Next →" : "Complete Profile";

        // KEEP ONLY THESE COMMANDS (remove the duplicates below)
        public ICommand NextCommand { get; }
        public ICommand PreviousCommand { get; }

        public CreateProfilePageViewModel()
        {
            NextCommand = new Command(OnNext);
            PreviousCommand = new Command(OnPrevious);
            LoadCurrentSection();
        }

        private void LoadCurrentSection()
        {
            switch (CurrentStep)
            {
                case 1:
                    CurrentSectionView = new Views.ProfileSections.PersonalInfoSection();
                    break;
                case 2:
                    CurrentSectionView = new Views.ProfileSections.EducationSection();
                    break;
                case 3:
                    CurrentSectionView = new Views.ProfileSections.SkillsSection();
                    break;
                case 4:
                    CurrentSectionView = new Views.ProfileSections.PreferencesSection();
                    break;
                case 5:
                    CurrentSectionView = new Views.ProfileSections.DocumentsSection();
                    break;
            }
        }

        private void UpdateStepIndicators()
        {
            Step1Color = CurrentStep >= 1 ? "#FFA500" : "#E0E0E0";
            Step2Color = CurrentStep >= 2 ? "#FFA500" : "#E0E0E0";
            Step3Color = CurrentStep >= 3 ? "#FFA500" : "#E0E0E0";
            Step4Color = CurrentStep >= 4 ? "#FFA500" : "#E0E0E0";
            Step5Color = CurrentStep >= 5 ? "#FFA500" : "#E0E0E0";
        }

        private void OnNext()
        {
            if (CurrentStep < 5)
                CurrentStep++;
            else
                CompleteProfile();
        }

        private void OnPrevious()
        {
            if (CurrentStep > 1)
                CurrentStep--;
        }

        private async void CompleteProfile()
        {
            await Shell.Current.GoToAsync("DashboardLandingPage");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}