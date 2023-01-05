namespace Companions.API.DTOs.Activity
{
    public class ActivityDTO
    {
        public string Id { get; set; }
        public DateTime DateCreated { get; }
        public ActivityTypeDTO ActivityType { get; set; }
        public string BuddyId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}