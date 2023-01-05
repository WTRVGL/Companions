using Companions.MAUI.ViewModels.App.Actions;

namespace Companions.MAUI.Views.App.Actions;

public partial class TrackWeightPage : ContentPage
{
	public TrackWeightPage(TrackWeightViewModel vm)
	{
		InitializeComponent();
		this.BindingContext = vm;
	}
}