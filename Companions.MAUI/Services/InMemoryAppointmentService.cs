using Companions.MAUI.Models.App;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Companions.MAUI.Services
{
    public class InMemoryAppointmentService : IAppointmentService
    {
        private readonly ObservableCollection<Appointment> _appointments;
        private readonly IBuddyService _buddyService;
        public InMemoryAppointmentService(IBuddyService buddyService)
        {
            _buddyService = buddyService;
            _appointments = new ObservableCollection<Appointment>()
            {
                new Appointment {
                    Id = "1",
                    Buddy = _buddyService.GetBuddies().FirstOrDefault(b => b.Name == "Ori"),
                    AppointmentName = "CPV Vaccinatie",
                    AppointmentType = "Dierenarts",
                    AppointmentDate = new DateTime(2022,12,24,15,30,00),
                    Description = "Tweede herhalingsprik voor CPV. Nog één vaccinatiemoment vereist tot volledige immunisatie. Standaard checkup wordt ook uitgevoerd en voedingsschema wordt nagekeken. Gewichtsverlies zal gecheckt worden.",
                    LocationCoordinates = new Location(50.956659, 5.328609),
                    LocationName = "DAC Prinsenhof"
                },
                new Appointment {
                    Id = "2",
                    AppointmentName = "Jaarlijkse checkup",
                    AppointmentType = "Dierenarts",
                    Buddy = _buddyService.GetBuddies().FirstOrDefault(b => b.Name == "Bassie"),
                    Description = "Routine checkup ter controle gewicht en voedings.",
                    AppointmentDate = new DateTime(2022,12,24,15,30,00),
                    LocationName = "DAC Prinsenhof",
                    LocationCoordinates = new Location(50.956659, 5.328609),
                },
            };
        }

        public Appointment AddAppointment(Appointment appointment)
        {
            _appointments.Add(appointment);
            return appointment;
        }

        public bool DeleteAppointment(Appointment appointment)
        {
            _appointments.Remove(appointment);
            return true;
        }

        public ObservableCollection<Appointment> GetAppointments()
        {
            return _appointments;
        }

        public Appointment UpdateAppointment(Appointment appointment)
        {
            var previousAppointment = _appointments.First(a => a.Id == appointment.Id);
            _appointments.Remove(previousAppointment);
            _appointments.Add(appointment);
            return appointment;
        }
    }
}
