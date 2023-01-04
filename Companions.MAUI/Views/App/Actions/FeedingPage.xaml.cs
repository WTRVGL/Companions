using Companions.MAUI.ViewModels.App.Actions;

namespace Companions.MAUI.Views.App.Actions;

public partial class FeedingPage : ContentPage
{
	public FeedingPage(FeedingPageViewModel vm)
	{
		InitializeComponent();
		this.BindingContext = vm;
	}
}