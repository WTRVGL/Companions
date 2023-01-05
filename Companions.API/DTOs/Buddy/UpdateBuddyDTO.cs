namespace Companions.API.DTOs.Buddy
{
    public class UpdateBuddyDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Race { get; set; }
        public List<BuddyWeightDTO> BuddyWeights { get; set; }
    }
}
