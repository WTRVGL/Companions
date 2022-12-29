namespace Companions.API.DTOs.Appointment
{
    public class CreateAppointmentDTO
    {
        public string AppointmentName { get; set; }
        public string Description { get; set; }
        public string BuddyId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public DateTime AppointmentTime { get; set; }
        public string PlaceId { get; set; }
    }
}
