using System.ComponentModel.DataAnnotations;

namespace Companions.Domain
{
    public class FeedingSchedule : Entity
    {
        public List<DailyFeeding> DailyFeedings { get; set; }
        [Required]
        public FeedProduct FeedProduct { get; set; }

        [Required]
        public string TimeOfDay { get; set; }

        [Required]
        public double Amount { get; set; }
    }
}