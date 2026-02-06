using EC_Youth_Portal.ViewModel;

namespace EC_Youth_Portal.Views.ProfileSections;

public partial class PersonalInfoSection : ContentView
{
	public PersonalInfoSection()
	{
		InitializeComponent();

		BindingContext = new PersonalInfoSectionViewModel();
    }
}