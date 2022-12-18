using Companions.MAUI.ViewModels.App;

namespace Companions.MAUI.Views.App;

public partial class EditBuddyPage : ContentPage
{
	public EditBuddyPage(EditBuddyPageViewModel vm)
	{
		this.BindingContext= vm;
		InitializeComponent();
	}
}