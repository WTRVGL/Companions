using Companions.MAUI.ViewModels.App;

namespace Companions.MAUI.Views.App;

public partial class HomePage : ContentPage
{
	public HomePage(HomePageViewModel vm)
	{
		this.BindingContext = vm;
		InitializeComponent();
	}

	protected override void OnNavigatedTo(NavigatedToEventArgs args)
	{
		base.OnNavigatedTo(args);
	 }
}