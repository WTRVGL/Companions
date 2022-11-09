using System.ComponentModel.DataAnnotations;

namespace Companions.Domain
{
    public class FeedingSchedule : Entity
    {
        [Required]
        public Buddy Buddy { get; set; }

        [Required]
        public FeedProduct FeedProduct { get; set; }

        [Required]
        public string TimeOfDay { get; set; }

        [Required]
        public double Amount { get; set; }
    }
}