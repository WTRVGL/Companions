using Companions.MAUI.Services;
using Companions.MAUI.ViewModels.App;
using Companions.MAUI.ViewModels.Login;
using Companions.MAUI.Views.App;
using Companions.MAUI.Views.App.BuddyDetail;
using Companions.MAUI.Views.Login;
using Microsoft.Extensions.DependencyInjection;
using Syncfusion.Maui.Core.Hosting;

namespace Companions.MAUI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
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
                });

            


            #region View Services
            builder.Services.AddSingleton<StartPage>();
            builder.Services.AddSingleton<LoginPage>();
            builder.Services.AddSingleton<SignUpPage>();

            builder.Services.AddTransient<BuddyDetailPage>();
            builder.Services.AddTransient<SchedulePage>();
            builder.Services.AddTransient<DiscoverPage>();
            builder.Services.AddTransient<SettingsPage>();
            builder.Services.AddTransient<HomePage>();
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

            builder.Services.AddTransient<IBuddyService, InMemoryBuddyService>();

            #endregion

            return builder.Build();
        }
    }
} 