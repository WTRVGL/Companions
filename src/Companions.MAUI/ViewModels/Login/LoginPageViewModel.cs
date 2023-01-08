using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Companions.MAUI.Models.Login;
using Companions.MAUI.Services.Interface;
using Companions.MAUI.Views.Login;
using Newtonsoft.Json;
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
        private readonly IAuthService _authService;

        public LoginPageViewModel(IAuthService authService)
        {
            _authService = authService;
        }

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
            var req = new LoginModel
            {
                Username = Email,
                Password = Password,
            };

            //Try and login user
            IsBusy = true;
            var authResponse = await _authService.GetJWTToken(req);
            IsBusy = false;

            if (authResponse.AuthStatus == "User does not exist")
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"User does not exist", "Ok");
                return;
            }

            //If failed to login
            if (authResponse == null)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"Wrong password", "Ok");
                return;
            }

            //User object
            var user = authResponse.User;

            //Set token
            await SecureStorage.SetAsync("JWT", authResponse.Token);

            //Set User
            var userSerialized = JsonConvert.SerializeObject(user);
            Preferences.Set("User", userSerialized);

            //Go to home screen. / Walktrough screen.
            IsBusy = true;
            Application.Current.MainPage = new MainShell();
            IsBusy = false;
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
