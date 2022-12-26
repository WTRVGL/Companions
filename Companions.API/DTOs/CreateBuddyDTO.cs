namespace Companions.API.DTOs
{
    public class CreateBuddyDTO
    {
        public string Name { get; set; }
        public string Race { get; set; }
        public string Gender { get; set; }
        public int CurrentAge { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ImageURL { get; set; }
        public int Weight { get; set; }
        public string UserId { get; set; }
        public List<FeedingScheduleDTO>? FeedingSchedules { get; set; }
        public List<BuddyWeightDTO>? BuddyWeights { get; set; }
    }
}
