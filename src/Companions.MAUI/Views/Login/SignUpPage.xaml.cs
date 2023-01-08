using Companions.MAUI.ViewModels.Login;

namespace Companions.MAUI.Views.Login;

public partial class SignUpPage : ContentPage
{
	public SignUpPage(SignUpPageViewModel vm)
	{
		InitializeComponent();
		this.BindingContext = vm;
	}

    protected override bool OnBackButtonPressed()
    {
        return true;
    }

    //Hides the keyboard to prevent ugly glitch
    private void Signup_Clicked(object sender, EventArgs e)
    {
        UsernameEntry.IsEnabled = false;
        UsernameEntry.IsEnabled = true;
    }
}