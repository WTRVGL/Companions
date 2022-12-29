using Companions.MAUI.Models.Login;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Companions.MAUI.Services
{
    public class AuthService : IAuthService
    {
        private readonly string _baseURL;

        public AuthService(IConfiguration config)
        {
            _baseURL = config.GetValue<string>("CompanionsAuthBaseURL");
        }
        public Task<string> GetJWTToken(LoginModel loginModel)
        {

            return Task.FromResult("");

        }
    }
}
