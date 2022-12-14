using Companions.MAUI.Models;
using Companions.MAUI.Models.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Companions.MAUI.Services.Interface
{
    public interface IAuthService
    {
        Task<AuthResponse> GetJWTToken(LoginModel loginModel);
        Task<RegistrationResponse> RegisterUser(RegisterModel registerModel);

    }
}
