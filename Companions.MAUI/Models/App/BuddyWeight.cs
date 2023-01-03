using System.ComponentModel.DataAnnotations;

namespace Companions.MAUI.Models.App
{
    public class BuddyWeight
    {
        public string BuddyId { get; set; }
        public double Weight { get; set; }
        public DateTime DateWeighed { get; set; }
    }
}