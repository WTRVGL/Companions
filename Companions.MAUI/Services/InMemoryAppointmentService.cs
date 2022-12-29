using CommunityToolkit.Maui.Core.Extensions;
using Companions.MAUI.Models.App;
using Syncfusion.Maui.Scheduler;
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
            var buddies = Task.Run(_buddyService.GetBuddies).Result;
            _appointments = new ObservableCollection<Appointment>()
            {
                new Appointment {
                    Id = "1",
                    Buddy =  buddies.FirstOrDefault(b => b.Name == "Ori"),
                    AppointmentName = "CPV Vaccinatie",
                    AppointmentDate = new DateTime(2022,12,24,10,10,00),
                    AppointmentTime = new DateTime(2022,12,24,15,45,00),
                    Description = "Tweede herhalingsprik voor CPV. Nog één vaccinatiemoment vereist tot volledige immunisatie. Standaard checkup wordt ook uitgevoerd en voedingsschema wordt nagekeken. Gewichtsverlies zal gecheckt worden.",
                    Place = new Place {
                        Location =  new Location(50.956659, 5.328609),
                        Name = "DAC Prinsenhof",
                        Address = "Nieuwstraat 143, 3511 Hasselt",
                        Description = "Dierenarts"
                    }
                },
                new Appointment {
                    Id = "2",
                    AppointmentName = "Jaarlijkse checkup",
                    Buddy = buddies.FirstOrDefault(b => b.Name == "Bassie"),
                    Description = "Routine checkup ter controle gewicht en voedings.",
                    AppointmentDate = new DateTime(2022,12,24,10,10,00),
                    AppointmentTime = new DateTime(2022,12,24,15,30,00),
                    Place = new Place {
                        Location =  new Location(50.956659, 5.328609),
                        Name = "DAC Prinsenhof",
                        Address = "Nieuwstraat 143, 3511 Hasselt",
                        Description = "Dierenarts"
                    }
                },
                new Appointment {
                    Id = "3",
                    AppointmentName = "Gewone afspraak",
                    Buddy = buddies.FirstOrDefault(b => b.Name == "Ori"),
                    Description = "Routine checkup ter controle gewicht en voedings.",
                    AppointmentDate = new DateTime(2023,02,03,10,10,00),
                    AppointmentTime = new DateTime(2023,02,03,15,30,00),
                    Place = new Place {
                        Location =  new Location(50.956659, 5.328609),
                        Name = "DAC Prinsenhof",
                        Address = "Nieuwstraat 143, 3511 Hasselt",
                        Description = "Dierenarts"
                    }
                },
                new Appointment {
                    Id = "5",
                    AppointmentName = "Halfjaarlijkse checkup",
                    Buddy = buddies.FirstOrDefault(b => b.Name == "Robot"),
                    Description = "Routine checkup ter controle gewicht en voedings.",
                    AppointmentDate = new DateTime(2023,02,03,10,10,00),
                    AppointmentTime = new DateTime(2023,04,02,15,30,00),
                    Place = new Place {
                        Location =  new Location(50.956659, 5.328609),
                        Name = "DAC Prinsenhof",
                        Address = "Nieuwstraat 143, 3511 Hasselt",
                        Description = "Dierenarts"
                    }
                },
                new Appointment {
                    Id = "4",
                    AppointmentName = "Kappersbezoek",
                    Buddy = buddies.FirstOrDefault(b => b.Name == "Ori"),
                    Description = "Gewone kappersbezoek",
                    AppointmentDate = new DateTime(2023,01,04,10,10,00),
                    AppointmentTime = new DateTime(2023,01,04,12,30,00),
                    Place = new Place {
                        Location =  new Location(51.000720, 5.339853),
                        Name = "Ine's Trimpaleis",
                        Address = "Nieuwstraat 51, 3520 Zonhoven",
                        Description = "Dierenkapper"
                    }
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
            return _appointments.OrderBy(a => a.AppointmentDate).ToObservableCollection();
        }

        public ObservableCollection<SchedulerAppointment> GetSchedulerAppointments()
        {
            var schedulerAppointments = new ObservableCollection<SchedulerAppointment>();
            _appointments.ToList().ForEach(appointment =>
            {
                schedulerAppointments.Add(new SchedulerAppointment
                {
                    Location = appointment.Place.Address,
                    StartTime = appointment.AppointmentDate,
                    Notes = appointment.Description
                });
            });

            return schedulerAppointments;
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
