using Companions.MAUI.ViewModels.App;
using Map = Microsoft.Maui.Controls.Maps.Map;
using Microsoft.Maui.Maps;
using Companions.MAUI.Models.App;

namespace Companions.MAUI.Views.App;

public partial class AppointmentDetailPage : ContentPage
{
	public AppointmentDetailPage(AppointmentDetailPageViewModel vm)
	{
		this.BindingContext = vm;
        InitializeComponent();
    }
}
