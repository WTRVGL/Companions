using Companions.MAUI.Services;
using Companions.MAUI.ViewModels.App;
using Companions.MAUI.ViewModels.Login;
using Companions.MAUI.Views.App;
using Companions.MAUI.Views.App.BuddyDetail;
using Companions.MAUI.Views.Login;
using Syncfusion.Maui.ListView.Hosting;
using Syncfusion.Maui.Core.Hosting;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace Companions.MAUI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            var a = Assembly.GetExecutingAssembly();
            using var stream = a.GetManifestResourceStream("Companions.MAUI.appsettings.json");

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
                .UseMauiMaps();

            


            #region View Services
            builder.Services.AddSingleton<StartPage>();
            builder.Services.AddSingleton<LoginPage>();
            builder.Services.AddSingleton<SignUpPage>();

            builder.Services.AddTransient<BuddyDetailPage>();
            builder.Services.AddTransient<SchedulePage>();
            builder.Services.AddTransient<DiscoverPage>();
            builder.Services.AddTransient<SettingsPage>();
            builder.Services.AddTransient<HomePage>();
            builder.Services.AddTransient<AppointmentDetailPage>();
            builder.Services.AddTransient<EditAppointmentPage>();
            #endregion

            #region ViewModel Services
            builder.Services.AddSingleton<StartPageViewModel>();
            builder.Services.AddSingleton<LoginPageViewModel>();
            builder.Services.AddSingleton<SignUpPageViewModel>();

            builder.Services.AddTransient<HomePageViewModel>();
            builder.Services.AddTransient<SchedulePageViewModel>();
            builder.Services.AddTransient<DiscoverPageViewModel>();
            builder.Services.AddTransient<SettingsPageViewModel>();
            builder.Services.AddTransient<BuddyDetailPageViewModel>();
            builder.Services.AddTransient<AppointmentDetailPageViewModel>();
            builder.Services.AddTransient<EditAppointmentPageViewModel>();

            builder.Services.AddTransient<IBuddyService, InMemoryBuddyService>();

            #endregion

            builder.ConfigureSyncfusionListView();

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
