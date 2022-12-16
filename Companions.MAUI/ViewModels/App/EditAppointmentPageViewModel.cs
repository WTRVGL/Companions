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
    public partial class EditAppointmentPageViewModel : BaseViewModel
    {
        [ObservableProperty]
        private Appointment _appointment;

        [ObservableProperty]
        private Appointment _newAppointment;

        [RelayCommand]
        async void GoBack()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
