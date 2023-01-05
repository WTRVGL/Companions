namespace Companions.MAUI.Views.App.Actions;

public partial class WalkingPage : ContentPage
{
	public WalkingPage(WalkingPageViewModel vm)
	{
		InitializeComponent();
		this.BindingContext = vm;
	}
}