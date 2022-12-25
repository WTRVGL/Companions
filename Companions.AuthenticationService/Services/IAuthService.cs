using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Companions.AuthenticationService.Models;

namespace Companions.AuthenticationService.Services
{
    public interface IAuthService
    {
        Task<AuthenticateResponse> AuthenticateUser(AuthenticateRequest model);
    }
}
