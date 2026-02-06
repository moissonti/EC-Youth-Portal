using EC_Youth_Portal.ViewModel;

namespace EC_Youth_Portal.Views.ProfileSections;

public partial class DocumentsSection : ContentView
{
	public DocumentsSection()
	{
		InitializeComponent();

		BindingContext = new CreateProfilePageViewModel();
    }
}