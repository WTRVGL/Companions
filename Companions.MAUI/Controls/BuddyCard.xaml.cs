using Companions.MAUI.Models.App;

namespace Companions.MAUI.Controls;

public partial class BuddyCard : ContentView
{
    private readonly TapGestureRecognizer _tapGestureRecognizer;
	public BuddyCard()
	{
		InitializeComponent();
        _tapGestureRecognizer = new TapGestureRecognizer();
        _tapGestureRecognizer.Tapped += _tapGestureRecognizer_Tapped;
        cardFrame.GestureRecognizers.Add(_tapGestureRecognizer);
	}

    private async void _tapGestureRecognizer_Tapped(object sender, EventArgs e)
    {
        await cardFrame.ScaleTo(0.95, 100, Easing.CubicIn);
        await cardFrame.ScaleTo(1, 100, Easing.CubicOut);
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