using System.ComponentModel.DataAnnotations;

namespace Companions.API.DTOs.Buddy
{
    public class CreateBuddyWeightDTO
    {
        public double Weight { get; set; }
        public DateTime DateWeighed { get; set; }
    }
}