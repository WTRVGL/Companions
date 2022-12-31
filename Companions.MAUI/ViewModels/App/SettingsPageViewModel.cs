using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Companions.MAUI.Models.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Companions.MAUI.ViewModels.App
{
    public partial class SettingsPageViewModel : BaseViewModel
    {
        [RelayCommand]
        public async void Logout()
        {
            var success =  SecureStorage.Remove("JWT");
            if (success) Application.Current.MainPage = new LoginShell();

        }
    }

}
