using Companions.MAUI.ViewModels.App.Actions;

namespace Companions.MAUI.Views.App.Actions;

public partial class WalkingPage : ContentPage
{
	public WalkingPage(WalkingPageViewModel vm)
	{
		InitializeComponent();
        this.BindingContext = vm;

        picker.ItemsSource = picker.GetItemsAsArray();
    }

    private void OnPickerSelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;

        if (selectedIndex != -1)
        {
            picker.Title = picker.Items[selectedIndex];
        }
    }
}