using Companions.MAUI.ViewModels.Login;

namespace Companions.MAUI.Views.Login;

public partial class LoginPage : ContentPage
{
	public LoginPage(LoginPageViewModel vm)
	{
		InitializeComponent();
		this.BindingContext = vm;
	}

	protected override bool OnBackButtonPressed()
	{
		return true;
	}

	//Hides the keyboard to prevent ugly glitch
    private void Login_Clicked(object sender, EventArgs e)
	{
		EmailEntry.IsEnabled = false;
		EmailEntry.IsEnabled = true;
	}
}