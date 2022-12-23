using Companions.AuthenticationService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Companions.AuthenticationService.Services
{
    public interface IHashPasswordService
    {
        PBKDF2Keys GenerateHashAndSalt(string password);
        bool CompareBase64HashValues(string password, string hashBase64, string saltBase64);
    }
}
