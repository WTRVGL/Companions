using Companions.MAUI.ViewModels.App;
using Companions.MAUI.ViewModels.Login;
using Companions.MAUI.Views.App;
using Companions.MAUI.Views.App.BuddyDetail;
using Companions.MAUI.Views.Login;
using Syncfusion.Maui.Core.Hosting;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using CommunityToolkit.Maui;
using Companions.MAUI.ViewModels.App.Actions;
using Companions.MAUI.Views.App.Actions;
using Companions.MAUI.Services.Interface;
using Companions.MAUI.Services.Implementation;

namespace Companions.MAUI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            string package = AppInfo.Current.PackageName;

            var a = Assembly.GetExecutingAssembly();

#if LOCAL_DEBUG
            using var stream = a.GetManifestResourceStream("Companions.MAUI.appsettings.LocalDevelopment.json");
#elif DEBUG
            using var stream = a.GetManifestResourceStream("Companions.MAUI.appsettings.Development.json");
#elif RELEASE
            using var stream = a.GetManifestResourceStream("Companions.MAUI.appsettings.Production.json");
#endif

            var config = new ConfigurationBuilder()
                .AddJsonStream(stream)
                .Build();

            builder.Configuration.AddConfiguration(config);

            builder
                .UseMauiApp<App>()
                .ConfigureSyncfusionCore()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("Poppins-Black.ttf", "PoppinsBlack");
                    fonts.AddFont("Poppins-Bold.ttf", "PoppinsBold");
                    fonts.AddFont("Inter-Regular.ttf", "Inter");
                    fonts.AddFont("Inter-Bold.ttf", "InterBold");
                    fonts.AddFont("Inter-SemiBold.ttf", "InterSemiBold");

                    //FontAwesome Icons
                    fonts.AddFont("fa-brands-400.otf", "FaBrands");
                    fonts.AddFont("fa-regular-400.otf", "FaRegular");
                    fonts.AddFont("fa-solid-900.otf", "FaSolid");

                })
                .UseMauiMaps()
                .UseMauiCommunityToolkit();


            var sfKey = builder.Configuration.GetValue<string>("SFLicenseKey");
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(sfKey);

            #region View Services
            builder.Services.AddTransient<StartPage>();
            builder.Services.AddTransient<LoginPage>();
            builder.Services.AddTransient<SignUpPage>();

            builder.Services.AddTransient<BuddyDetailPage>();
            builder.Services.AddTransient<SchedulePage>();
            builder.Services.AddTransient<DiscoverPage>();
            builder.Services.AddTransient<SettingsPage>();
            builder.Services.AddTransient<HomePage>();
            builder.Services.AddTransient<AppointmentDetailPage>();
            builder.Services.AddTransient<EditAppointmentPage>();
            builder.Services.AddTransient<EditBuddyPage>();

            builder.Services.AddTransient<FeedingPage>();
            builder.Services.AddTransient<WalkingPage>();
            builder.Services.AddTransient<TrackWeightPage>();
            builder.Services.AddTransient<AppointmentPage>();

            #endregion

            #region ViewModel Services
            builder.Services.AddTransient<StartPageViewModel>();
            builder.Services.AddTransient<LoginPageViewModel>();
            builder.Services.AddTransient<SignUpPageViewModel>();

            builder.Services.AddTransient<FeedingPageViewModel>();
            builder.Services.AddTransient<WalkingPageViewModel>();
            builder.Services.AddTransient<TrackWeightViewModel>();
            builder.Services.AddTransient<AppointmentPageViewModel>();

            builder.Services.AddTransient<HomePageViewModel>();
            builder.Services.AddTransient<SchedulePageViewModel>();
            builder.Services.AddTransient<DiscoverPageViewModel>();
            builder.Services.AddTransient<SettingsPageViewModel>();
            builder.Services.AddTransient<BuddyDetailPageViewModel>();
            builder.Services.AddTransient<AppointmentDetailPageViewModel>();
            builder.Services.AddTransient<EditAppointmentPageViewModel>();
            builder.Services.AddTransient<EditBuddyPageViewModel>();

            #endregion

            builder.Services.AddTransient<IBuddyService, BuddyService>();
            builder.Services.AddTransient<IAppointmentService, AppointmentService>();
            builder.Services.AddTransient<IAuthService, AuthService>();
            builder.Services.AddTransient<IGoogleService, GoogleService>();
            builder.Services.AddTransient<IPlaceService, PlaceService>();
            builder.Services.AddTransient<IActivityService, ActivityService>();

            builder.ConfigureSyncfusionCore();



#if __ANDROID__
            ImageHandler.Mapper.PrependToMapping(nameof(Microsoft.Maui.IImage.Source), (handler, view) => PrependToMappingImageSource(handler, view));
#endif

            return builder.Build();
        }

#if __ANDROID__
            public static void PrependToMappingImageSource(IImageHandler handler, Microsoft.Maui.IImage image)
            {
                handler.PlatformView?.Clear();
            }
#endif
    }
}
