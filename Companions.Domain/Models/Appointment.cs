using System.ComponentModel.DataAnnotations;

namespace Companions.Domain
{
    public class Appointment : Entity
    {
        public DateTime AppoinmentDueDate { get; set; }
        [Required]
        public List<Buddy> Buddies { get; set; }

        [Required]
        public List<AppointmentType> AppointmentType { get; set; }
    }
}