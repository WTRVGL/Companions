using Companions.MAUI.Models.App;

namespace Companions.MAUI
{
    public partial class App : Application
    {
        public static User User;
        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }
    }
}