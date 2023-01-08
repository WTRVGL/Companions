using Companions.MAUI.ViewModels.App.Actions;

namespace Companions.MAUI.Views.App.Actions;

public partial class AppointmentPage : ContentPage
{
    public AppointmentPage(AppointmentPageViewModel vm)
    {
        InitializeComponent();
        this.BindingContext = vm;
    }

    private void picker_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}