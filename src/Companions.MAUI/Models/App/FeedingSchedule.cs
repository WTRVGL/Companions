using System.ComponentModel.DataAnnotations;

namespace Companions.MAUI.Models.App
{
    public class FeedingSchedule
    {
        public string Id { get; set; }
        public FeedProduct FeedProduct { get; set; }
        public string TimeOfDay { get; set; }
        public double Amount { get; set; }
        public string BuddyId { get; set; }
        public bool IsChecked { get; set; }
    }
}