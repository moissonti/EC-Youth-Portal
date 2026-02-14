using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;

namespace EC_Youth_Portal.ViewModel
{
    public class PersonalInfoSectionViewModel : BaseViewModel
    {
        // Will Move all these to become Models on all my view Models
        private string _preferredName;
        private string _idNumber;
        private string _location;
        private DateTime _dateOfBirth = DateTime.Now.AddYears(-18);
        private string _gender;
        private string _race;
        private bool _hasDisability;
        private string _disabilityDetails;
        private string _district;
        private string _preferredLanguage;
        private string _bio;
        private ImageSource _profilePicture;

        public DateTime TodayDate => DateTime.Now;

        // Properties
        public string PreferredName { get => _preferredName; set => SetProperty(ref _preferredName, value); }
        public string IdNumber { get => _idNumber; set => SetProperty(ref _idNumber, value); }
        public string Location { get => _location; set => SetProperty(ref _location, value); }
        public DateTime DateOfBirth { get => _dateOfBirth; set => SetProperty(ref _dateOfBirth, value); }
        public string Gender { get => _gender; set => SetProperty(ref _gender, value); }
        public string Race { get => _race; set => SetProperty(ref _race, value); }
        public bool HasDisability { get => _hasDisability; set => SetProperty(ref _hasDisability, value); }
        public string DisabilityDetails { get => _disabilityDetails; set => SetProperty(ref _disabilityDetails, value); }
        public string District { get => _district; set => SetProperty(ref _district, value); }
        public string PreferredLanguage { get => _preferredLanguage; set => SetProperty(ref _preferredLanguage, value); }
        public string Bio { get => _bio; set => SetProperty(ref _bio, value); }
        public ImageSource ProfilePicture { get => _profilePicture; set => SetProperty(ref _profilePicture, value); }

        public ICommand UploadPhotoCommand { get; }

        public PersonalInfoSectionViewModel()
        {
            UploadPhotoCommand = new Command(async () => await UploadPhoto());
            LoadUserData();
        }

        private void LoadUserData()
        {
            // TODO: Load user data from database/API
            PreferredName = "John Doe";
            Location = "EL, SA";
        }

        private async Task UploadPhoto()
        {
            // TODO: Implement photo upload
            await Application.Current.MainPage.DisplayAlert("Upload Photo", "Photo upload feature coming soon!", "OK");
        }

        public async Task<bool> SavePersonalInfo()
        {
            // Validation
            if (string.IsNullOrWhiteSpace(IdNumber))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "ID Number is required", "OK");
                return false;
            }

            if (string.IsNullOrWhiteSpace(Location))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Phone Number is required", "OK");
                return false;
            }

            // TODO: Save to database/API
            await Task.Delay(500); // Simulate API call
            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
