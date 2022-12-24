using System.ComponentModel.DataAnnotations;

namespace Companions.Domain
{
    public class Vaccination : Entity
    {
        [Required]
        public Buddy Buddy { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime DateFirstVaccination { get; set; }

        [Required]
        public byte AmountOfRepeats { get; set; }

    }
}