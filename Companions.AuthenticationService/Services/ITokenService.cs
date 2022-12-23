using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using Companions.AuthenticationService.Models;

namespace Companions.AuthenticationService.Services
{
    public interface ITokenService
    {
        string getJwtSecurityToken(Gebruiker user);
        JwtSecurityToken decodeJwtSecurityToken(string token);
        int ExtractIdFromJwtSecurityToken(JwtSecurityToken securityToken);

    }
}
