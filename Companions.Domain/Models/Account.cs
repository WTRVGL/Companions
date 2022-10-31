using System.ComponentModel.DataAnnotations;

namespace Companions.Domain
{
    public class Account : Entity
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string PasswordHash { get; set; }
        
        [Required]
        public string FirstName { get; set; }
        
        [Required]
        public string LastName { get; set; }
        public string FullName => FirstName +" " + LastName;
    }
}