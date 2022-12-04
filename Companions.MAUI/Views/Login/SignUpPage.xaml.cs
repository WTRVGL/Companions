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
}