using System.ComponentModel.DataAnnotations;

namespace Companions.API.DTOs.Buddy
{
    public class BuddyWeightDTO
    {
        public string BuddyId { get; set; }
        public double Weight { get; set; }
        public DateTime DateWeighed { get; set; }
    }
}