using System.ComponentModel.DataAnnotations;

namespace Companions.Domain
{
    public class Appointment : Entity
    {
        public DateTime AppoinmentDueDate { get; set; }
        [Required]
        public Buddy Buddy { get; set; }

        [Required]
        public AppointmentType AppointmentType { get; set; }
    }
}