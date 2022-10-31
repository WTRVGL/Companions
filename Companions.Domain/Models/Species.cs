using System.ComponentModel.DataAnnotations;

namespace Companions.Domain
{
    public class Species : Entity
    {
        [Required]
        public string SpeciesName { get; set; }

        [Required]
        public string SpeciesRace { get; set; }
    }
}