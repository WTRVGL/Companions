using Companions.MAUI.ViewModels.App;

namespace Companions.MAUI.Views.App.BuddyDetail;

public partial class BuddyDetailPage : ContentPage
{
	public BuddyDetailPage(BuddyDetailPageViewModel vm)
	{
        InitializeComponent();
        this.BindingContext = vm;
    }

	protected override void OnNavigatedTo(NavigatedToEventArgs args)
	{
		base.OnNavigatedTo(args);
	}
}