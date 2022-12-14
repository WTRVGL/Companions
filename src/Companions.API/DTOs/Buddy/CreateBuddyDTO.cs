namespace Companions.API.DTOs.Buddy
{
    public class CreateBuddyDTO
    {
        public string Name { get; set; }
        public string Race { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ImageURL { get; set; }
    }
}
