using Companions.MAUI.Views;
using Companions.MAUI.Views.App;
using Companions.MAUI.Views.Login;

namespace Companions.MAUI
{
    public partial class BogusShell : Shell
    {
        public BogusShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(BogusPage), typeof(BogusPage));
        }
    }
}