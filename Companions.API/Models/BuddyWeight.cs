namespace Companions.API.Models
{
    public class BuddyWeight : Entity
    {
        public Buddy Buddy { get; set; }
        public double Weight { get; set; }
        public DateTime DateWeighed { get; set; }
    }
}