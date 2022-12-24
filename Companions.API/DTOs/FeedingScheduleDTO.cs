using System.ComponentModel.DataAnnotations;

namespace Companions.API.DTOs
{
    public class FeedingScheduleDTO
    {
        public string Id { get; set; }
        public BuddyDTO Buddy { get; set; }
        public FeedProductDTO FeedProduct { get; set; }
        public string TimeOfDay { get; set; }
        public double Amount { get; set; }
    }
}