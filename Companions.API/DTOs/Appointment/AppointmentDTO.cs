using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Companions.API.DTOs.Appointment
{
    public class AppointmentDTO
    {
        public string Id { get; set; }
        public string AppointmentName { get; set; }
        public string Description { get; set; }
        public BuddyDTO Buddy { get; set; }
        public DateTime AppointmentDate { get; set; }
        public DateTime AppointmentTime { get; set; }
        public PlaceDTO Place { get; set; }
    }
}
