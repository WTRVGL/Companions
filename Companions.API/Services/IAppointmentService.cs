using Companions.Domain;

namespace Companions.API.Services
{
    public interface IAppointmentService
    {
        Appointment GetAppointentById(string id);
        List<Appointment> GetAllAppointmentsByUserId(string userId);
        List<Appointment> GetAllAppointmentsByBuddyId(string buddyId);
        Appointment CreateAppointment(Appointment appointment);
        Appointment UpdateAppointment(Appointment appointment);
        bool DeleteAppointment(string id);
    }
}
