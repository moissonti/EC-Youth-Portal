using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;

namespace EC_Youth_Portal.ViewModel
{
    public class DocumentsSectionViewModel : INotifyPropertyChanged
    {
        private bool _hasIDDocument;
        private bool _hasCVDocument;
        private bool _hasMatricDocument;
        private string _idDocumentName;
        private string _cvDocumentName;
        private string _matricDocumentName;
        //private bool _acceptTerms;
        //private bool _acceptPrivacy;

        public bool HasIDDocument { get => _hasIDDocument; set { _hasIDDocument = value; OnPropertyChanged(); } }
        public bool HasCVDocument { get => _hasCVDocument; set { _hasCVDocument = value; OnPropertyChanged(); } }
        public bool HasMatricDocument { get => _hasMatricDocument; set { _hasMatricDocument = value; OnPropertyChanged(); } }
        public string IDDocumentName { get => _idDocumentName; set { _idDocumentName = value; OnPropertyChanged(); } }
        public string CVDocumentName { get => _cvDocumentName; set { _cvDocumentName = value; OnPropertyChanged(); } }
        public string MatricDocumentName { get => _matricDocumentName; set { _matricDocumentName = value; OnPropertyChanged(); } }
        //public bool AcceptTerms { get => _acceptTerms; set { _acceptTerms = value; OnPropertyChanged(); } }
        //public bool AcceptPrivacy { get => _acceptPrivacy; set { _acceptPrivacy = value; OnPropertyChanged(); } }

        public string SummaryPersonalInfo => "Personal information completed";
        public string SummaryEducation => "Education details added";
        public string SummaryEmployment => "Skills and employment saved";
        public string SummaryPreferences => "Ready to submit";

        public ICommand UploadIDCommand { get; }
        public ICommand UploadCVCommand { get; }
        public ICommand UploadMatricCommand { get; }
        //public ICommand ViewTermsCommand { get; }
        //public ICommand ViewPrivacyCommand { get; }

        public DocumentsSectionViewModel()
        {
            UploadIDCommand = new Command(async () => await UploadID());
            UploadCVCommand = new Command(async () => await UploadCV());
            UploadMatricCommand = new Command(async () => await UploadMatric());
            //ViewTermsCommand = new Command(async () => await ViewTerms());
            //ViewPrivacyCommand = new Command(async () => await ViewPrivacy());
        }

        private async Task UploadID()
        {
            await Application.Current.MainPage.DisplayAlert("Upload", "ID upload coming soon!", "OK");
        }

        private async Task UploadCV()
        {
            await Application.Current.MainPage.DisplayAlert("Upload", "CV upload coming soon!", "OK");
        }

        private async Task UploadMatric()
        {
            await Application.Current.MainPage.DisplayAlert("Upload", "Certificate upload coming soon!", "OK");
        }

        //private async Task ViewTerms()
        //{
        //    await Application.Current.MainPage.DisplayAlert("Terms", "Terms and Conditions", "OK");
        //}

        //private async Task ViewPrivacy()
        //{
        //    await Application.Current.MainPage.DisplayAlert("Privacy", "Privacy Policy", "OK");
        //}

        public async Task<bool> SubmitProfile()
        {
            if (!HasIDDocument)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "ID Document is required", "OK");
                return false;
            }

            //if (!AcceptTerms || !AcceptPrivacy)
            //{
            //    await Application.Current.MainPage.DisplayAlert("Error", "You must accept the Terms and Privacy Policy", "OK");
            //    return false;
            //}

            // TODO: Submit final profile 
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
