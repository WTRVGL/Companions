using Companions.Domain;
using Microsoft.EntityFrameworkCore;

namespace Companions.API.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly AppDbContext _db;
        private readonly IBuddyService _buddyService;

        public AppointmentService(AppDbContext db, IBuddyService buddyService)
        {
            _db = db;
            _buddyService = buddyService;
        }

        public Appointment CreateAppointment(Appointment appointment)
        {
            _db.Appointments.Add(appointment);
            _db.SaveChanges();
            return appointment;
        }

        public bool DeleteAppointment(string id)
        {
            var appointment = _db.Appointments.First(b => b.Id == id);
            if (appointment == null) return false;

            _db.Appointments.Remove(appointment);
            _db.SaveChanges();
            return true;
        }

        public List<Appointment> GetAllAppointmentsByBuddyId(string buddyId)
        {
            var appointments = _db.Appointments
                .Where(a => a.Buddy.Id == buddyId)
                .Include(a => a.Buddy)
                .ToList();
            return appointments;
        }

        public List<Appointment> GetAllAppointmentsByUserId(string userId)
        {
            var buddiesByUser = _buddyService.GetAllBuddiesByUserId(userId);
            var appointments = new List<Appointment>();

            //For each buddy
            for (int i = 0; i < buddiesByUser.Count; i++)
            {
                if (buddiesByUser[i].Appointments == null) continue;
                //For each appointment
                buddiesByUser[i].Appointments.ForEach(a =>
                {
                    appointments.Add(a);
                });
            }

            return appointments;
        }

        public Appointment? GetAppointentById(string id)
        {
            var appointment = _db.Appointments.FirstOrDefault(a => a.Id == id);
            if (appointment == null) return null;
            return appointment;
        }

        public Appointment? UpdateAppointment(Appointment appointment)
        {
            var appointmentToBeUpdated = _db.Appointments.FirstOrDefault(a => a.Id == appointment.Id);
            if (appointment == null) return null;

            //Automapper here?
            appointmentToBeUpdated.AppointmentDate = appointment.AppointmentDate;
            appointmentToBeUpdated.AppointmentName = appointment.AppointmentName;
            appointmentToBeUpdated.AppointmentType = appointment.AppointmentType;
            appointmentToBeUpdated.AppointmentTypeId = appointment.AppointmentTypeId;
            appointmentToBeUpdated.BuddyId = appointment.BuddyId;
            appointmentToBeUpdated.PlaceId = appointment.PlaceId;
            appointmentToBeUpdated.Description = appointment.Description;


            _db.SaveChanges();
            return appointmentToBeUpdated;
        }
    }
}
