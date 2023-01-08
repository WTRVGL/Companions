namespace Companions.MAUI.Services.Models
{
    public class CreateActivity
    {
        public string ActivityTypeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}