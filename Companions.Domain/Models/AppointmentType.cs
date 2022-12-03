namespace Companions.Domain
{
    public class AppointmentType : Entity
    {
        public string Description { get; set; }
        public List<Appointment> Appointments { get; set; }
    }
} 