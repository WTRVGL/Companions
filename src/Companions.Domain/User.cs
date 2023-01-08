using System.ComponentModel.DataAnnotations;

namespace Companions.Domain
{
    public class User : Entity
    {
        [Required]
        public string UserName { get; set; }

        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        public string Role { get; set; }
        public string ImageURL { get; set; }
    }
}