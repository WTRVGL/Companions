using System;
using System.Collections.Generic;
using System.Text;

namespace Companions.AuthenticationService.Models
{
    public class User
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public string Role { get; set; }
        public string ImageURL { get; set; }

    }
}
