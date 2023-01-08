using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Companions.MAUI.Models;
using Companions.MAUI.Models.App;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Companions.MAUI.ViewModels.App
{
    public partial class SettingsPageViewModel : BaseViewModel
    {
        [ObservableProperty]
        private User _user;

        [RelayCommand]
        public async void Logout()
        {
            var logout = await Application.Current.MainPage.DisplayAlert("Logout?", "Are you sure you want to log out?", "Yes", "No");
            if (logout)
            {
                var success = SecureStorage.Remove("JWT");
                Preferences.Remove("User");
                if (success) Application.Current.MainPage = new LoginShell();
                return;
            }
        }

        [RelayCommand]
        public async void PageAppearing()
        {
            var userJSON = Preferences.Get("User", null);
            User user = JsonConvert.DeserializeObject<User>(userJSON);
            User = user;
        }
    }

}
