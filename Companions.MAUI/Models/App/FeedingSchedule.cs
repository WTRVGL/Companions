using System.ComponentModel.DataAnnotations;

namespace Companions.MAUI.Models.App
{
    public class FeedingSchedule
    {
        public FeedProduct FeedProduct { get; set; }
        public string TimeOfDay { get; set; }
        public double Amount { get; set; }
    }
}