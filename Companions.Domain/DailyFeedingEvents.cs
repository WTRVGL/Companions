namespace Companions.Domain
{
    public class DailyFeeding : Entity
    {
        public Buddy Buddy { get; set; }
        public FeedingSchedule FeedingSchedule { get; set; }
        public DateTime Date { get; set; }
    }
}