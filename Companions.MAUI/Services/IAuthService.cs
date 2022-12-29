using Companions.MAUI.Models.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Companions.MAUI.Services
{
    public interface IAuthService
    {
        Task<string> GetJWTToken(LoginModel loginModel);

    }
}
