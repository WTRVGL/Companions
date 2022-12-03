namespace Companions.MAUI.Views.App.BuddyDetail;

public partial class FoodControl : ContentView
{
	public FoodControl()
	{
		InitializeComponent();
	}

	private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
	{
		var x = BindingContext.ToString();
	}
}