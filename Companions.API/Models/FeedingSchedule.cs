namespace Companions.API.Models
{
    public class FeedingSchedule : Entity
    {
        public Buddy Buddy { get; set; }
        public FeedProduct FeedProduct { get; set; }
        public string TimeOfDay { get; set; }
        public double Amount { get; set; }
    }
}