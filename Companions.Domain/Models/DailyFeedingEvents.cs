namespace Companions.Domain
{
    public class DailyFeedingEvents : Entity
    {
        public Buddy Buddy { get; set; }
        public FeedingSchedule FeedingSchedule { get; set; }
        public DateTime Date { get; set; }
    }
}