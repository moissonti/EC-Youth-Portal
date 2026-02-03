using EC_Youth_Portal.ViewModel;
using EC_Youth_Portal.Views.ProfileSections;


namespace EC_Youth_Portal.Views;

public partial class CreateProfilePage : ContentPage
{
    private readonly CreateProfilePageViewModel _viewModel;

    public CreateProfilePage(CreateProfilePageViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = viewModel;

        // Listen for section changes
        _viewModel.PropertyChanged += (s, e) =>
        {
            if (e.PropertyName == nameof(_viewModel.CurrentStep))
            {
                LoadCurrentSection();
            }
        };

        // Load first section
        LoadCurrentSection();
    }

    private void LoadCurrentSection()
    {
        // Remove old section
        SectionContainer.Content = null;

        // Load new section based on current step
        switch (_viewModel.CurrentStep)
        {
            case 1:
                var section1 = new PersonalInfoSection();
                section1.BindingContext = _viewModel;
                SectionContainer.Content = section1;
                break;
            case 2:
                var section2 = new EducationSection();
                section2.BindingContext = _viewModel;
                SectionContainer.Content = section2;
                break;
            case 3:
                var section3 = new SkillsSection();
                section3.BindingContext = _viewModel;
                SectionContainer.Content = section3;
                break;
            case 4:
                var section4 = new PreferencesSection();
                section4.BindingContext = _viewModel;
                SectionContainer.Content = section4;
                break;
            case 5:
                var section5 = new DocumentsSection();
                section5.BindingContext = _viewModel;
                SectionContainer.Content = section5;
                break;
        }
    }
}
