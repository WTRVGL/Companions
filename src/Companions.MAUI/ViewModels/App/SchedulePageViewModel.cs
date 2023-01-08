using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Companions.MAUI.Models.App;
using Companions.MAUI.Services.Interface;
using Syncfusion.Maui.Scheduler;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Companions.MAUI.ViewModels.App
{
    public partial class SchedulePageViewModel : BaseViewModel
    {
        private readonly IAppointmentService _appointmentService;
        public SchedulePageViewModel(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
            _appointments = _appointmentService.GetSchedulerAppointments();
        }

        [ObservableProperty]
        private ObservableCollection<SchedulerAppointment> _appointments;

        //[ObservableProperty]
        //private ReadOnlyCollection<object> _selectedAppointments;

        //[RelayCommand]
        //async void AppointmentTapped(SchedulerTappedEventArgs args)
        //{
        //    _selectedAppointments = args.Appointments;
        //}

        [RelayCommand]
        async void PageAppearing()
        {
            _appointments = _appointmentService.GetSchedulerAppointments();
        }
    }

}
