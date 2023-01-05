using Companions.MAUI.Models;
using Companions.MAUI.Services;
using Companions.MAUI.Views;
using Microsoft.Extensions.Configuration;

namespace Companions.MAUI
{
    public partial class App : Application
    {
        public static User User;
        private readonly IAuthService _authService;

        public App(IConfiguration config, IAuthService authService)
        {
            _authService = authService;
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
                return;
            }

            MainPage = new MainShell();
            base.OnStart();

        }
    }
}

