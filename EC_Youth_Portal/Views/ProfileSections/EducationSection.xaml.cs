using EC_Youth_Portal.ViewModel;

namespace EC_Youth_Portal.Views.ProfileSections;

public partial class EducationSection : ContentView
{
	public EducationSection()
	{
		InitializeComponent();

		BindingContext = new EducationSectionViewModel();
    }
}