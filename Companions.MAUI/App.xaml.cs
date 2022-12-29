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
            MainPage = new LoginShell();
            //MainPage = new MainShell();
        }

        protected async override void OnStart()
        {
            base.OnStart();
        }
    }
}