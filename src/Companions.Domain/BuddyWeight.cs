using System.ComponentModel.DataAnnotations;

namespace Companions.Domain
{
    public class BuddyWeight : Entity
    {
        [Required]
        public Buddy Buddy { get; set; }

        public double Weight { get; set; }
        public DateTime DateWeighed { get; set; }
    }
}