using CommunityToolkit.Mvvm.Input;
using Companions.MAUI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Companions.MAUI.ViewModels.App.Actions
{
    public partial class FeedingPageViewModel : BaseViewModel
    {
        private readonly IBuddyService _buddyService;

        public FeedingPageViewModel(IBuddyService buddyService)
        {
            _buddyService = buddyService;
        }

        [RelayCommand]
        async void GoBack()
        {
            ////Update appointment in db
            //var updatedAppointment = _appointmentService.UpdateAppointment(Appointment);
            await Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
