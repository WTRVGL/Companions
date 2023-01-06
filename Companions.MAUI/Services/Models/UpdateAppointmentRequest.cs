using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Companions.MAUI.Services.Models
{
    internal class UpdateAppointmentRequest
    {
        public string Id{ get; set; }
        public string AppointmentName { get; set; }
        public string Description { get; set; }
        public string BuddyId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string PlaceId { get; set; }

    }
}
