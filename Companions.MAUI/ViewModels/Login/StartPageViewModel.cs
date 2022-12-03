using CommunityToolkit.Mvvm.Input;
using Companions.MAUI.Views.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Companions.MAUI.ViewModels.Login
{
    public partial class StartPageViewModel : BaseViewModel
    {
        [RelayCommand]
        async void GoToLogin()
        {
            await Shell.Current.GoToAsync(nameof(LoginPage));
        }

        [RelayCommand]
        async void GoToSignUp()
        {
            await Shell.Current.GoToAsync(nameof(SignUpPage));
        }
    }
}
