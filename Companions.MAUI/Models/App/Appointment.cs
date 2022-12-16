using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Companions.MAUI.Models.App
{
    public class Appointment
    {
        public string Id { get; set; }
        public string AppointmentName { get; set; }
        public string AppointmentType { get; set; }
        public string BuddyName { get; set; }
        public string BuddyURL { get; set; }
        public string Description { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string LocationName { get; set; }
        public Location LocationCoordinates { get; set; }
    }
}
