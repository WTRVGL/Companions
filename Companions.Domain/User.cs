using System.ComponentModel.DataAnnotations;

namespace Companions.Domain
{
    public class User : Entity
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string PasswordHash { get; set; }
        [Required]
        public string PasswordSalt{ get; set; }

        [Required]
        public string FirstName { get; set; }
        
        [Required]
        public string LastName { get; set; }
    }
}