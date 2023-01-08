using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Companions.MAUI.Models.App
{
    public class ActionFeedingSchedule
    {
        public string BuddyName { get; set; }
        public List<FeedingSchedule> FeedingSchedules { get; set; }
    }
}