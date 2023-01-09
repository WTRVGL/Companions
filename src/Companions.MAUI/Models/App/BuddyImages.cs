using System.Collections.ObjectModel;

namespace Companions.MAUI.Models.App
{
    public class BuddyImages
    {
        public string BuddyName { get; set; }
        public string BuddyId { get; set; }
        public ObservableCollection<Image> Images { get; set; }
    }
}