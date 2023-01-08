using Companions.MAUI.ViewModels.App;

namespace Companions.MAUI.Views.App;

public partial class EditAppointmentPage : ContentPage
{
	public EditAppointmentPage(EditAppointmentPageViewModel vm)
	{
		this.BindingContext = vm;
		InitializeComponent();
	}
}