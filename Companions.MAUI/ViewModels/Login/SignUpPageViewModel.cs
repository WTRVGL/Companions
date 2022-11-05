using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Companions.MAUI.Views.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Companions.MAUI.ViewModels.Login
{
    public partial class SignUpPageViewModel : BaseViewModel
    {
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(SignUpCommand))]
        private string _email;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(SignUpCommand))]
        private string _password;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(SignUpCommand))]
        private string _passwordRepeat;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(SignUpCommand))]
        private bool _TOSChecked;

        [RelayCommand]
        async void GoToLogin()
        {
            await Shell.Current.GoToAsync(nameof(LoginPage));
        }

        [RelayCommand(CanExecute = nameof(CanSignUp))]
        async void SignUp()
        {

        }

        private bool CanSignUp()
        {
            if (
                string.IsNullOrWhiteSpace(Email) || 
                string.IsNullOrWhiteSpace(Password) || 
                string.IsNullOrWhiteSpace(PasswordRepeat) || 
                TOSChecked == false)
            {
                return false;
            }

            if (!string.Equals(Password, PasswordRepeat))
            {
                return false;
            }
            else return true;
        }
    }
}
