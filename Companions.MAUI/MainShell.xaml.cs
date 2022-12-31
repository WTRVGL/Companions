using Companions.MAUI.Views.App;
using Companions.MAUI.Views.App.Actions;
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
            Routing.RegisterRoute(nameof(FeedingPage), typeof(FeedingPage));
            Routing.RegisterRoute(nameof(WalkingPage), typeof(WalkingPage));
            Routing.RegisterRoute(nameof(AppointmentPage), typeof(AppointmentPage));
            Routing.RegisterRoute(nameof(TrackWeightPage), typeof(TrackWeightPage));
            Routing.RegisterRoute(nameof(AppointmentDetailPage), typeof(AppointmentDetailPage));
            Routing.RegisterRoute(nameof(EditAppointmentPage), typeof(EditAppointmentPage));
            Routing.RegisterRoute(nameof(EditBuddyPage), typeof(EditBuddyPage));
        }

        //HACK LOL
        protected override async void OnNavigating(ShellNavigatingEventArgs args)
        {
            bool navigatedToActionButton =
                args.Target.Location.OriginalString == "//D_FAULT_ShellContent6" ||
                args.Target.Location.OriginalString == "//D_FAULT_ShellContent11" ||
                args.Target.Location.OriginalString == "//D_FAULT_ShellContent12";

            if (navigatedToActionButton)
            {
                args.Cancel();

                string action =
                    await DisplayActionSheet(
                        "Add Action:",
                        "Cancel",
                        null,
                        "Feeding",
                        "Walking",
                        "Appointment",
                        "Track weight");

                switch (action)
                {
                    case "Feeding":
                        await Application.Current.MainPage.Navigation.PushAsync(new FeedingPage());
                        return;
                    case "Walking":
                        await Application.Current.MainPage.Navigation.PushAsync(new WalkingPage());
                        return;
                    case "Appointment":
                        await Application.Current.MainPage.Navigation.PushAsync(new AppointmentPage());
                        return;
                    case "Track weight":
                        await Application.Current.MainPage.Navigation.PushAsync(new TrackWeightPage());
                        return;
                    default:
                        break;
                }
                return;
            }
        }
    }
}