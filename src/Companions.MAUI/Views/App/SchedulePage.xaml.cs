using Companions.MAUI.ViewModels.App;

namespace Companions.MAUI.Views.App;

public partial class SchedulePage : ContentPage
{
	public SchedulePage(SchedulePageViewModel vm)
	{
		InitializeComponent();
		this.BindingContext = vm;
	}

}