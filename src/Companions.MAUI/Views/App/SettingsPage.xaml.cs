using Companions.MAUI.ViewModels.App;

namespace Companions.MAUI.Views.App;

public partial class SettingsPage : ContentPage
{
	public SettingsPage(SettingsPageViewModel vm)
	{
		InitializeComponent();
		this.BindingContext = vm;
	}
}