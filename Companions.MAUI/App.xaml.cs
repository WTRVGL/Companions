using Companions.MAUI.Models.App;
using Microsoft.Extensions.Configuration;

namespace Companions.MAUI
{
    public partial class App : Application
    {
        public static User User;
        public App(IConfiguration config)
        {
            InitializeComponent();
            //MainPage = new LoginShell();
            MainPage = new MainShell();
        }
    }
}