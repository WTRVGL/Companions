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

            Email = new ValidatableObject<string>();
            FirstName = new ValidatableObject<string>();


            AddValidations();
        }


        private void AddValidations()
        {

            Email.Validations.Add(new EmailRule<string>
            {
                ValidationMessage = "A valid email must be entered."
            });

            FirstName.Validations.Add(new IsNotNullOrEmptyRule<string>
            {
                ValidationMessage = "First name is required."
            });
        }

        public ValidatableObject<string> Email { get; private set; }
        public ValidatableObject<string> FirstName { get; private set; }

        [RelayCommand]
        public void ValidateEmail()
        {
            Email.Validate();
        }

        //[ObservableProperty]
        //[NotifyCanExecuteChangedFor(nameof(SignUpCommand))]
        //private string _email;

        //[ObservableProperty]
        //[NotifyCanExecuteChangedFor(nameof(SignUpCommand))]
        //private string _firstName;

        //[ObservableProperty]
        //[NotifyCanExecuteChangedFor(nameof(SignUpCommand))]
        //private string _lastName;

        //[ObservableProperty]
        //[NotifyCanExecuteChangedFor(nameof(SignUpCommand))]
        //private string _password;

        //[ObservableProperty]
        //[NotifyCanExecuteChangedFor(nameof(SignUpCommand))]
        //private string _passwordRepeat;

        //[ObservableProperty]
        //[NotifyCanExecuteChangedFor(nameof(SignUpCommand))]
        //private bool _TOSChecked;

        [RelayCommand]
        async void GoToLogin()
        {
            await Shell.Current.GoToAsync(nameof(LoginPage));
        }

        [RelayCommand(CanExecute = nameof(CanSignUp))]
        async void SignUp()
        {

            //var req = new RegisterModel
            //{
            //    FirstName = FirstName,
            //    LastName = LastName,
            //    Password = Password,
            //    Username = Email  
            //};

            //RegistrationResponse registrationResponse = await _authService.RegisterUser(req);

            //if (registrationResponse.RegistrationStatus == RegistrationStatus.UserExists)
            //{
            //    await Application.Current.MainPage.DisplayAlert("Error", $"User already exists", "Ok");
            //    return;
            //}

            ////Retrieve JWT
            //var loginModel = new LoginModel { Username = req.Username, Password = req.Password };
            //var token = await _authService.GetJWTToken(loginModel);

            ////Set token
            //SecureStorage.SetAsync("JWT", token);
        }

        private bool CanSignUp()
        {
            //if (
            //    string.IsNullOrWhiteSpace(Email) ||
            //    string.IsNullOrWhiteSpace(Password) ||
            //    string.IsNullOrWhiteSpace(PasswordRepeat) ||
            //    TOSChecked == false)
            //{
            //    return false;
            //}

            //if (!string.Equals(Password, PasswordRepeat))
            //{
            //    return false;
            //}
            //else 
            return true;
        }
    }
}
