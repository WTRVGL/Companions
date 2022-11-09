using System.ComponentModel.DataAnnotations;

namespace Companions.Domain
{
    public class Activity : Entity
    {
        [Required]
        public List<Buddy> Buddies { get; set; }

        [Required]
        public ActivityType ActivityType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}