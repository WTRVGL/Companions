using Companions.MAUI.Views.App;
using Companions.MAUI.Views.Login;

namespace Companions.MAUI
{
    public partial class LoginShell : Shell
    {
        public LoginShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(LoginPage),typeof(LoginPage));
            Routing.RegisterRoute(nameof(SignUpPage), typeof(SignUpPage));
            Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));

        }
    }
}