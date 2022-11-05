using Companions.MAUI.Models.App;
using static System.Net.Mime.MediaTypeNames;

namespace Companions.MAUI.Controls;

public partial class BuddyCard : VerticalStackLayout
{
	public BuddyCard()
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