using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Companions.MAUI.Models.Login
{
    public class RegistrationResponse
    {
        public User? User { get; set; }
        public RegistrationStatus RegistrationStatus { get; set; }

    }

    public enum RegistrationStatus
    {
        UserExists,
        UserSucesfullyRegistered
    }
}
