using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Companions.MAUI.Messages;
using Companions.MAUI.Models.App;
using Companions.MAUI.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Companions.MAUI.ViewModels.App
{
    [QueryProperty("Appointment", "Appointment")]
    public partial class EditAppointmentPageViewModel : BaseViewModel
    {
        private readonly IBuddyService _buddyService;
        private readonly IAppointmentService _appointmentService;

        public EditAppointmentPageViewModel(IBuddyService buddyService, IAppointmentService appointmentService)
        {
            _buddyService = buddyService;
            _appointmentService = appointmentService;
            Buddies = _buddyService.GetBuddies();
        }

        [ObservableProperty]
        private Appointment _appointment;

        [ObservableProperty]
        private ObservableCollection<Buddy> _buddies;

        [ObservableProperty]
        private Buddy _selectedBuddy;


        [RelayCommand]
        async void GoBack()
        {
            //Update appointment in db
            var updatedAppointment = _appointmentService.UpdateAppointment(Appointment);
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        [RelayCommand]
        async void BuddySelected()
        {
            Appointment.Buddy = _selectedBuddy;
        }

        partial void OnAppointmentChanged(Appointment appointment)
        {
            SelectedBuddy = Buddies.First(b => b.Id == appointment.Buddy.Id);
        }
    }
}
