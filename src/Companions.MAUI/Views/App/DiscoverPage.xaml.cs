using Companions.MAUI.ViewModels.App;

namespace Companions.MAUI.Views.App;

public partial class DiscoverPage : ContentPage
{
	public DiscoverPage(DiscoverPageViewModel vm)
	{
		InitializeComponent();
		this.BindingContext = vm;
	}
}