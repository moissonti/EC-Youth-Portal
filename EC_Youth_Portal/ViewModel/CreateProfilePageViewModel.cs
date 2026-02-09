using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
namespace EC_Youth_Portal.ViewModel
{
    public class CreateProfilePageViewModel : BaseViewModel
    {
        // Will Move all these to become Models on all my view Models
        private int _currentStep = 1;
        private ContentView _currentSectionView;
        private string _step1Color = "#FFA500";
        private string _step2Color = "#E0E0E0";
        private string _step3Color = "#E0E0E0";
        private string _step4Color = "#E0E0E0";
        private string _step5Color = "#E0E0E0";


        public string Step1Color
        {
            get => _step1Color;
            set => SetProperty(ref _step1Color, value);
        }

        public string Step2Color
        {
            get => _step2Color;
            set => SetProperty(ref _step2Color, value);
        }

        public string Step3Color
        {
            get => _step3Color;
            set => SetProperty(ref _step3Color, value);
        }

        public string Step4Color
        {
            get => _step4Color;
            set => SetProperty(ref _step4Color, value);
        }

        public string Step5Color
        {
            get => _step5Color;
            set => SetProperty(ref _step5Color, value);
        }

        public int CurrentStep
        {
            get => _currentStep;
            set
            {
                if (SetProperty(ref _currentStep, value))
                {
                    OnPropertyChanged(nameof(ShowPreviousButton));
                    OnPropertyChanged(nameof(NextButtonText));
                    OnPropertyChanged(nameof(CurrentStepText));
                    OnPropertyChanged(nameof(ProgressPercentage));
                    UpdateStepIndicators();
                    LoadCurrentSection();
                }
            }
        }

        public ContentView CurrentSectionView
        {
            get => _currentSectionView;
            set => SetProperty(ref _currentSectionView, value);
        }

        // Computed Properties
        public bool ShowPreviousButton => CurrentStep > 1;

        public string NextButtonText => CurrentStep < 5 ? "Next →" : "Complete Profile";

        public string CurrentStepText => CurrentStep switch
        {
            1 => "Personal Information",
            2 => "Education Background",
            3 => "Skills & Interests",
            4 => "Preferences",
            5 => "Documents & Verification",
            _ => "Profile Setup"
        };

        public string ProgressPercentage => $"{(CurrentStep * 20)}%";

        // Commands
        public ICommand NextCommand { get; }
        public ICommand PreviousCommand { get; }
        public ICommand SaveDraftCommand { get; }
        public ICommand BackCommand { get; }

        public CreateProfilePageViewModel()
        {
            NextCommand = new Command(OnNext);
            PreviousCommand = new Command(OnPrevious);
            SaveDraftCommand = new Command(OnSaveDraft);
            //BackCommand = new Command(OnBack);

            UpdateStepIndicators();
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
            // Active step: Orange, Completed: Orange, Upcoming: Gray
            Step1Color = CurrentStep >= 1 ? "#FFA500" : "#E0E0E0";
            Step2Color = CurrentStep >= 2 ? "#FFA500" : "#E0E0E0";
            Step3Color = CurrentStep >= 3 ? "#FFA500" : "#E0E0E0";
            Step4Color = CurrentStep >= 4 ? "#FFA500" : "#E0E0E0";
            Step5Color = CurrentStep >= 5 ? "#FFA500" : "#E0E0E0";
        }

        private async void OnNext()
        {
            // TODO: Add validation for current step
            if (!await ValidateCurrentStep())
            {
                return;
            }

            if (CurrentStep < 5)
            {
                CurrentStep++;
            }
            else
            {
                await CompleteProfile();
            }
        }

        private void OnPrevious()
        {
            if (CurrentStep > 1)
            {
                CurrentStep--;
            }
        }

        private async void OnSaveDraft()
        {
            // TODO: Implement save draft functionality
            await Application.Current.MainPage.DisplayAlert(
                "Draft Saved",
                "Your profile progress has been saved. You can continue later.",
                "OK");
        }

        //private async void OnBack()
        //{
        //    bool confirm = await Application.Current.MainPage.DisplayAlert(
        //        "Discard Changes?",
        //        "Are you sure you want to go back? Unsaved changes will be lost.",
        //        "Yes",
        //        "No");

        //    if (confirm)
        //    {
        //        await Shell.Current.GoToAsync("..");
        //    }
        //}

        private async Task<bool> ValidateCurrentStep()
        {
            // TODO: Implement validation logic for each step
            // For now, return true
            return await Task.FromResult(true);
        }

        private async Task CompleteProfile()
        {
            // TODO: Save all profile data
            await Application.Current.MainPage.DisplayAlert(
                "Success!",
                "Your profile has been completed successfully!",
                "OK");

            await Shell.Current.GoToAsync("//DashboardTabs/DashboardHome");
        }
    }
}










