using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;

namespace EC_Youth_Portal.ViewModel
{
    public class EducationSectionViewModel : INotifyPropertyChanged
    {
        private string _educationLevel;
        private bool _isCurrentlyStudying;
        private string _currentStudy;
        private string _fieldOfStudy;
        private string _institution;
        private string _yearCompleted;

        public string EducationLevel { get => _educationLevel; set { _educationLevel = value; OnPropertyChanged(); } }
        public bool IsCurrentlyStudying { get => _isCurrentlyStudying; set { _isCurrentlyStudying = value; OnPropertyChanged(); } }
        public string CurrentStudy { get => _currentStudy; set { _currentStudy = value; OnPropertyChanged(); } }
        public string FieldOfStudy { get => _fieldOfStudy; set { _fieldOfStudy = value; OnPropertyChanged(); } }
        public string Institution { get => _institution; set { _institution = value; OnPropertyChanged(); } }
        public string YearCompleted { get => _yearCompleted; set { _yearCompleted = value; OnPropertyChanged(); } }

        public ICommand UploadCertificatesCommand { get; }

        public EducationSectionViewModel()
        {
            UploadCertificatesCommand = new Command(async () => await UploadCertificates());
        }

        private async Task UploadCertificates()
        {
            await Application.Current.MainPage.DisplayAlert("Upload", "Certificate upload coming soon!", "OK");
        }

        public async Task<bool> SaveEducation()
        {
            if (string.IsNullOrWhiteSpace(EducationLevel))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Education Level is required", "OK");
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
