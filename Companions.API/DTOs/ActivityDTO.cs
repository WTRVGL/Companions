namespace Companions.API.DTOs
{
    public class ActivityDTO
    {
        public string Id { get; set; }
        public ActivityTypeDTO ActivityType { get; set; }
        public string BuddyId { get; set; }
        public string ImageURL { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}