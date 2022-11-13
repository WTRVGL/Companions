using Companions.MAUI.ViewModels.App;

namespace Companions.MAUI.Views.App;

public partial class HomePage : ContentPage
{
	public HomePage(HomePageViewModel vm)
	{
		InitializeComponent();
		this.BindingContext = vm;
	}

	protected override void OnNavigatedTo(NavigatedToEventArgs args)
	{
		base.OnNavigatedTo(args);
	 }
}