namespace Companions.MAUI.Models.App
{
    public class Activity
    {
        public string Id { get; set; }
        public ActivityType ActivityType { get; set; }
        public string ImageURL { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}