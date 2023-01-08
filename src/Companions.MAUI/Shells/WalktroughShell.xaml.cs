using Companions.MAUI.Views.App;
using Companions.MAUI.Views.Login;

namespace Companions.MAUI
{
    public partial class WalkTroughShell : Shell
    {
        public WalkTroughShell()
        {
            InitializeComponent();

            //Register routing
            Routing.RegisterRoute(nameof(LoginPage),typeof(LoginPage));
            Routing.RegisterRoute(nameof(SignUpPage), typeof(SignUpPage));
            Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));

        }
    }
}