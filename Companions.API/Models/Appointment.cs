namespace Companions.API.Models
{
    public class Appointment : Entity
    {
        public DateTime AppoinmentDueDate { get; set; }
        public List<AppointmentType> AppointmentType { get; set; }
    }
}