using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Companions.MAUI.Models.Login
{
    public class AuthResponse
    {
        public User User { get; set; }
        public string Token { get; set; }
        public string AuthStatus { get; set; }
    }
}
