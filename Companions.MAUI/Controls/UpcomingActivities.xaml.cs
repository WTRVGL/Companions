using Companions.MAUI.Models.App;
using System.Collections.ObjectModel;

namespace Companions.MAUI.Controls;

public partial class UpcomingActivities : ContentView
{
	public UpcomingActivities()
	{
		InitializeComponent();
	}

    public static readonly BindableProperty ActivitiesProperty = BindableProperty.Create(
        propertyName: nameof(Activities),
        returnType: typeof(ObservableCollection<UpcomingActivitesActivityModel>),
        declaringType: typeof(ContentView),
        defaultValue: null,
        defaultBindingMode: BindingMode.TwoWay);

    public ObservableCollection<UpcomingActivitesActivityModel> Activities
    {
        get => (ObservableCollection<UpcomingActivitesActivityModel>)GetValue(ActivitiesProperty);
        set { SetValue(ActivitiesProperty, value); }
    }
}