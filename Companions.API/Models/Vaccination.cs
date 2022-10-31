namespace Companions.API.Models
{
    public class Vaccination : Entity
    {
        public Buddy Buddy { get; set; }
        public string Name { get; set; }
        public DateTime DateFirstVaccination { get; set; }
        public byte AmountOfRepeats { get; set; }

    }
}