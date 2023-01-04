using Companions.MAUI.Models;
using Companions.MAUI.Views;
using Microsoft.Extensions.Configuration;

namespace Companions.MAUI
{
    public partial class App : Application
    {
        public static User User;
        public App(IConfiguration config)
        {
            InitializeComponent();
            MainPage = new BogusPage();
        }

        protected async override void OnStart()
        {
            var token = await SecureStorage.GetAsync("JWT");

            if (token == null)
            {
                MainPage = new LoginShell();
                base.OnStart();
            }

            else
            {
                MainPage = new MainShell();
                base.OnStart();
            }

        }
    }
}

