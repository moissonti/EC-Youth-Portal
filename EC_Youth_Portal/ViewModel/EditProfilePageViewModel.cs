using EC_Youth_Portal.Views.ProfileSections;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;

namespace EC_Youth_Portal.ViewModel
{
    public class EditProfilePageViewModel : INotifyPropertyChanged
    {
        private View _currentSectionView;
        private int _currentTabIndex = 0;

        // Tab Colors
        private Color _activeTabColor = Color.FromArgb("#FFA500");
        private Color _inactiveTabColor = Color.FromArgb("#FFFFFF");
        private Color _activeTextColor = Color.FromArgb("#FFFFFF");
        private Color _inactiveTextColor = Color.FromArgb("#1E3A5F");
        private Color _activeBorderColor = Color.FromArgb("#FFA500");
        private Color _inactiveBorderColor = Color.FromArgb("#E0E0E0");

        // Section ViewModels
        public PersonalInfoSectionViewModel PersonalInfoVM { get; set; }
        public EducationSectionViewModel EducationVM { get; set; }
        public SkillsSectionViewModel SkillsVM { get; set; }
        public DocumentsSectionViewModel DocumentsVM { get; set; }

        // Section Views (Lazy Loaded)
        private PersonalInfoSection _personalInfoView;
        private EducationSection _educationView;
        private SkillsSection _skillsView;
        private DocumentsSection _documentsView;

        public View CurrentSectionView
        {
            get => _currentSectionView;
            set
            {
                _currentSectionView = value;
                OnPropertyChanged(nameof(CurrentSectionView));
            }
        }

        public string SaveButtonText => GetSaveButtonText();

        // Tab 1 Colors
        public Color PersonalInfoTabColor => _currentTabIndex == 0 ? _activeTabColor : _inactiveTabColor;
        public Color PersonalInfoTextColor => _currentTabIndex == 0 ? _activeTextColor : _inactiveTextColor;
        public Color PersonalInfoBorderColor => _currentTabIndex == 0 ? _activeBorderColor : _inactiveBorderColor;

        // Tab 2 Colors
        public Color EducationTabColor => _currentTabIndex == 1 ? _activeTabColor : _inactiveTabColor;
        public Color EducationTextColor => _currentTabIndex == 1 ? _activeTextColor : _inactiveTextColor;
        public Color EducationBorderColor => _currentTabIndex == 1 ? _activeBorderColor : _inactiveBorderColor;

        // Tab 3 Colors
        public Color SkillsTabColor => _currentTabIndex == 2 ? _activeTabColor : _inactiveTabColor;
        public Color SkillsTextColor => _currentTabIndex == 2 ? _activeTextColor : _inactiveTextColor;
        public Color SkillsBorderColor => _currentTabIndex == 2 ? _activeBorderColor : _inactiveBorderColor;

        // Tab 4 Colors
        public Color DocumentsTabColor => _currentTabIndex == 3 ? _activeTabColor : _inactiveTabColor;
        public Color DocumentsTextColor => _currentTabIndex == 3 ? _activeTextColor : _inactiveTextColor;
        public Color DocumentsBorderColor => _currentTabIndex == 3 ? _activeBorderColor : _inactiveBorderColor;

        // Commands
        public ICommand SwitchToPersonalInfoCommand { get; }
        public ICommand SwitchToEducationCommand { get; }
        public ICommand SwitchToSkillsCommand { get; }
        public ICommand SwitchToDocumentsCommand { get; }
        public ICommand SaveCurrentSectionCommand { get; }
        public ICommand BackCommand { get; }

        public EditProfilePageViewModel()
        {
            // Initialize ViewModels
            PersonalInfoVM = new PersonalInfoSectionViewModel();
            EducationVM = new EducationSectionViewModel();
            SkillsVM = new SkillsSectionViewModel();
            DocumentsVM = new DocumentsSectionViewModel();

            // Initialize Commands
            SwitchToPersonalInfoCommand = new Command(() => SwitchToTab(0));
            SwitchToEducationCommand = new Command(() => SwitchToTab(1));
            SwitchToSkillsCommand = new Command(() => SwitchToTab(2));
            SwitchToDocumentsCommand = new Command(() => SwitchToTab(3));
            SaveCurrentSectionCommand = new Command(async () => await SaveCurrentSection());
            BackCommand = new Command(async () => await GoBack());

            //// Load first tab by default
            //MainThread.BeginInvokeOnMainThread(() =>
            //{
            //    SwitchToTab(0);
            //});

            _ = LoadInitialTabAsync();
        }

        private void SwitchToTab(int tabIndex)
        {
            _currentTabIndex = tabIndex;

            // Lazy load the view
            switch (tabIndex)
            {
                case 0:
                    if (_personalInfoView == null)
                    {
                        _personalInfoView = new PersonalInfoSection
                        {
                            BindingContext = PersonalInfoVM
                        };
                    }
                    CurrentSectionView = _personalInfoView;
                    break;

                case 1:
                    if (_educationView == null)
                    {
                        _educationView = new EducationSection
                        {
                            BindingContext = EducationVM
                        };
                    }
                    CurrentSectionView = _educationView;
                    break;

                case 2:
                    if (_skillsView == null)
                    {
                        _skillsView = new SkillsSection
                        {
                            BindingContext = SkillsVM
                        };
                    }
                    CurrentSectionView = _skillsView;
                    break;

                case 3:
                    if (_documentsView == null)
                    {
                        _documentsView = new DocumentsSection
                        {
                            BindingContext = DocumentsVM
                        };
                    }
                    CurrentSectionView = _documentsView;
                    break;
            } 

            // Update all tab colors
            UpdateTabColors();
        }

        private async Task LoadInitialTabAsync()
        {
            await Task.Delay(50);
            SwitchToTab(0);
        }


        private void UpdateTabColors()
        {
            OnPropertyChanged(nameof(PersonalInfoTabColor));
            OnPropertyChanged(nameof(PersonalInfoTextColor));
            OnPropertyChanged(nameof(PersonalInfoBorderColor));

            OnPropertyChanged(nameof(EducationTabColor));
            OnPropertyChanged(nameof(EducationTextColor));
            OnPropertyChanged(nameof(EducationBorderColor));

            OnPropertyChanged(nameof(SkillsTabColor));
            OnPropertyChanged(nameof(SkillsTextColor));
            OnPropertyChanged(nameof(SkillsBorderColor));

            OnPropertyChanged(nameof(DocumentsTabColor));
            OnPropertyChanged(nameof(DocumentsTextColor));
            OnPropertyChanged(nameof(DocumentsBorderColor));

            OnPropertyChanged(nameof(SaveButtonText));
        }

        private string GetSaveButtonText()
        {
            return _currentTabIndex switch
            {
                0 => "Save Personal Information",
                1 => "Save Education Details",
                2 => "Save Skills & Employment",
                3 => "Submit Profile",
                _ => "Save Changes"
            };
        }

        private async Task SaveCurrentSection()
        {
            bool success = false;
            string message = "";

            switch (_currentTabIndex)
            {
                case 0:
                    success = await PersonalInfoVM.SavePersonalInfo();
                    message = success ? "Personal information saved successfully!" : "Failed to save personal information";
                    break;

                case 1:
                    success = await EducationVM.SaveEducation();
                    message = success ? "Education details saved successfully!" : "Failed to save education details";
                    break;

                case 2:
                    success = await SkillsVM.SaveSkills();
                    message = success ? "Skills and employment saved successfully!" : "Failed to save skills";
                    break;

                case 3:
                    success = await DocumentsVM.SubmitProfile();
                    message = success ? "Profile submitted successfully!" : "Failed to submit profile";
                    break;
            }

            await Application.Current.MainPage.DisplayAlert(
                success ? "Success" : "Error",
                message,
                "OK");

            // If it's the last section and successful, navigate back
            if (_currentTabIndex == 3 && success)
            {
                await Shell.Current.GoToAsync("..");
            }
        }

        private async Task GoBack()
        {
            bool confirm = await Application.Current.MainPage.DisplayAlert(
                "Discard Changes?",
                "Are you sure you want to go back? Any unsaved changes will be lost.",
                "Yes",
                "No");

            if (confirm)
            {
                await Shell.Current.GoToAsync("..");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

