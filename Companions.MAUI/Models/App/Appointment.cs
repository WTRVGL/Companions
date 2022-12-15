using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Companions.MAUI.Models.App
{
    public class Appointment
    {
        public string AppointmentName { get; set; }
        public string BuddyName { get; set; }
        public string BuddyURL { get; set; }
        public DateTime AppointmentDate { get; set; }
    }
}
