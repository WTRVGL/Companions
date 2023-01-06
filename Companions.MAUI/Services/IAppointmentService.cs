using Companions.MAUI.Models.App;
using Companions.MAUI.Services.Models;
using Syncfusion.Maui.Scheduler;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Companions.MAUI.Services
{
    public interface IAppointmentService
    {
        Task<ObservableCollection<Appointment>> GetAppointments();
        ObservableCollection<SchedulerAppointment> GetSchedulerAppointments();
        Task<Appointment> UpdateAppointment(Appointment appointment);
        Task<Appointment> CreateAppointment(CreateAppointment appointment);
        Task<bool> DeleteAppointment(string id);
    }
}
