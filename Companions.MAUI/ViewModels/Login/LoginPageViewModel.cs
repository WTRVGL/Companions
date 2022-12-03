using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Companions.MAUI.Views.Login;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Companions.MAUI.ViewModels.Login
{
    public partial class LoginPageViewModel : BaseViewModel
    {

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(LoginCommand))]
        private string _email;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(LoginCommand))]
        private string _password;

        [RelayCommand]
        async void GoToSignUp()
        {
            await Shell.Current.GoToAsync(nameof(SignUpPage));
        }

        [RelayCommand(CanExecute = nameof(CanLogin))]
        async public void Login()
        {
            Application.Current.MainPage = new MainShell();
        }

        private bool CanLogin()
        {
            if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
            {
                return false;
            }
            else return true;
        }
    }
}
