using Companions.MAUI.Models.App;
using System.Collections.ObjectModel;

namespace Companions.MAUI.Views.App.BuddyDetail;

public partial class TabControl : ContentView
{
	public TabControl()
	{
		InitializeComponent();
	}


    public static readonly BindableProperty BuddyProperty = BindableProperty.Create(
    propertyName: nameof(Buddy),
    returnType: typeof(Buddy),
    declaringType: typeof(VerticalStackLayout),
    defaultValue: null,
    defaultBindingMode: BindingMode.TwoWay);

    public Buddy Buddy
    {
        get => (Buddy)GetValue(BuddyProperty);
        set { SetValue(BuddyProperty, value); }
    }
}