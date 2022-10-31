namespace Companions.API.Models
{
    public class Activity : Entity
    {
        public List<Buddy> Buddies { get; set; }
        public ActivityType ActivityType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}