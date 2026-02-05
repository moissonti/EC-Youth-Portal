using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;

namespace EC_Youth_Portal.ViewModel
{
    public class PersonalInfoSectionViewModel : INotifyPropertyChanged
    {
        // Will Move all these to become Models on all my view Models
        private string _preferredName;
        private string _idNumber;
        private string _phoneNumber;
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
        public string PreferredName { get => _preferredName; set { _preferredName = value; OnPropertyChanged(); } }
        public string IdNumber { get => _idNumber; set { _idNumber = value; OnPropertyChanged(); } }
        public string PhoneNumber { get => _phoneNumber; set { _phoneNumber = value; OnPropertyChanged(); } }
        public DateTime DateOfBirth { get => _dateOfBirth; set { _dateOfBirth = value; OnPropertyChanged(); } }
        public string Gender { get => _gender; set { _gender = value; OnPropertyChanged(); } }
        public string Race { get => _race; set { _race = value; OnPropertyChanged(); } }
        public bool HasDisability { get => _hasDisability; set { _hasDisability = value; OnPropertyChanged(); } }
        public string DisabilityDetails { get => _disabilityDetails; set { _disabilityDetails = value; OnPropertyChanged(); } }
        public string District { get => _district; set { _district = value; OnPropertyChanged(); } }
        public string PreferredLanguage { get => _preferredLanguage; set { _preferredLanguage = value; OnPropertyChanged(); } }
        public string Bio { get => _bio; set { _bio = value; OnPropertyChanged(); } }
        public ImageSource ProfilePicture { get => _profilePicture; set { _profilePicture = value; OnPropertyChanged(); } }

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
            PhoneNumber = "0712345678";
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

            if (string.IsNullOrWhiteSpace(PhoneNumber))
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
