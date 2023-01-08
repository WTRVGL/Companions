namespace Companions.API.DTOs.Activity
{
    public class CreateActivityDTO
    {
        public string ActivityTypeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}