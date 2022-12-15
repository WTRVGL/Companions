using Companions.MAUI.ViewModels.App;

namespace Companions.MAUI.Views.App;

public partial class AppointmentDetailPage : ContentPage
{
	public AppointmentDetailPage(AppointmentDetailPageViewModel vm)
	{
		this.BindingContext = vm;
		InitializeComponent();
	}
}