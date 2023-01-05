using System.ComponentModel.DataAnnotations;

namespace Companions.Domain
{
    public class Activity : Entity
    {
        public Buddy Buddy { get; set; }
        public string BuddyId { get; set; }
        public ActivityType ActivityType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}