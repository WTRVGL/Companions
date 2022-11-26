using Companions.MAUI.Views.App;
using Companions.MAUI.Views.App.BuddyDetail;
using Companions.MAUI.Views.Login;
using Action = Companions.MAUI.Views.App.Action;

namespace Companions.MAUI
{
    public partial class MainShell : Shell
    {
        public MainShell()
        {
            InitializeComponent();

            //Register routing
            Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
            Routing.RegisterRoute(nameof(BuddyDetailPage), typeof(BuddyDetailPage));
            Routing.RegisterRoute(nameof(SchedulePage), typeof(SchedulePage));
            Routing.RegisterRoute(nameof(DiscoverPage), typeof(DiscoverPage));
            Routing.RegisterRoute(nameof(SettingsPage), typeof(SettingsPage));
            Routing.RegisterRoute(nameof(Action), typeof(Action));
        }

        //HACK LOL
        protected override async void OnNavigating(ShellNavigatingEventArgs args)
        {
            if (args.Target.Location.OriginalString == "//D_FAULT_ShellContent6")
            {
                args.Cancel();
                await DisplayAlert("yo", "yo", "cancel");
                return;
            }
        }
    }
}