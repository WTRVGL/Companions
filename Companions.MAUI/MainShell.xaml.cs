using Companions.MAUI.Views.App;
using Companions.MAUI.Views.App.BuddyDetail;
using Companions.MAUI.Views.Login;

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
        }

    }
}