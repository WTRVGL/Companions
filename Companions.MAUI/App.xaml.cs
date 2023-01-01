using Companions.MAUI.Models;
using Microsoft.Extensions.Configuration;

namespace Companions.MAUI
{
    public partial class App : Application
    {
        public static User User;
        public App(IConfiguration config)
        {
            InitializeComponent();
            MainPage = new BogusShell();
            
        }

        protected async override void OnStart()
        {
            var token = await SecureStorage.GetAsync("JWT");

            if (token == null)
            {
                MainPage = new LoginShell();
                return;
            }

            MainPage = new MainShell();
            base.OnStart();
        }
    }
}

