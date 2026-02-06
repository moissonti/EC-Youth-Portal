using EC_Youth_Portal.ViewModel;	

namespace EC_Youth_Portal.Views.ProfileSections;

public partial class SkillsSection : ContentView
{
	public SkillsSection()
	{
		InitializeComponent();

		BindingContext = new CreateProfilePageViewModel();	
    }
}