using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Companions.MAUI.Models.Login;
using Companions.MAUI.Services;
using Companions.MAUI.Validation;
using Companions.MAUI.Validation.Rules;
using Companions.MAUI.Views.Login;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Companions.MAUI.ViewModels.Login
{
    public partial class SignUpPageViewModel : BaseViewModel
    {
        private readonly IAuthService _authService;

        public SignUpPageViewModel(IAuthService authService)
        {
            _authService = authService;
        }



        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(SignUpCommand))]
        private string _email;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(SignUpCommand))]
        private string _firstName;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(SignUpCommand))]
        private string _lastName;

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
            if (Password != PasswordRepeat)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"Passwords do not match", "Ok");
                return;
            }

            var req = new RegisterModel
            {
                FirstName = FirstName,
                LastName = LastName,
                Password = Password,
                Username = Email
            };

            RegistrationResponse registrationResponse = await _authService.RegisterUser(req);

            if (registrationResponse.RegistrationStatus == RegistrationStatus.UserExists)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"User already exists", "Ok");
                return;
            }

            //Retrieve JWT
            var loginModel = new LoginModel { Username = req.Username, Password = req.Password };
            var token = await _authService.GetJWTToken(loginModel);

            //Set token
            await SecureStorage.SetAsync("JWT", token);
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

            return true;
        }
    }
}
