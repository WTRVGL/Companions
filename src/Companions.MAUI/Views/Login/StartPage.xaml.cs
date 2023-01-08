using Companions.MAUI.ViewModels.Login;

namespace Companions.MAUI.Views.Login;

public partial class StartPage : ContentPage
{
	public StartPage(StartPageViewModel vm)
	{
		InitializeComponent();
		this.BindingContext = vm;
	}
}