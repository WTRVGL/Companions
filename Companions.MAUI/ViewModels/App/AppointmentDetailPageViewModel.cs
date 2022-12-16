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
    [QueryProperty("Appointment", "Appointment")]
    public partial class AppointmentDetailPageViewModel : BaseViewModel
    {
        [ObservableProperty]
        private Appointment _appointment;

        [RelayCommand]
        async void GoBack()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
