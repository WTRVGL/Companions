using System.ComponentModel.DataAnnotations;

namespace Companions.Domain
{
    public class Appointment : Entity
    {
        public string AppointmentName { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Description { get; set; }
        [Required]
        public Buddy Buddy { get; set; }
        public string BuddyId { get; set; }
        public Place Place { get; set; }
        public string PlaceId { get; set; }
        public AppointmentType AppointmentType { get; set; }
        public string AppointmentTypeId { get; set; }
    }
}