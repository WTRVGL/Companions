using Companions.MAUI.Models;
using Companions.MAUI.Models.Login;
using Companions.MAUI.Services.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Companions.MAUI.Services.Implementation
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseURL;
        private readonly string _authBaseURL;

        public AuthService(IConfiguration config)
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            _apiBaseURL = config.GetValue<string>("CompanionsAPIBaseURL");
            _authBaseURL = config.GetValue<string>("CompanionsAuthBaseURL");
        }
        public async Task<AuthResponse> GetJWTToken(LoginModel loginModel)
        {
            var req = await _httpClient.PostAsJsonAsync($"{_authBaseURL}/api/Token", loginModel);
            if (req.StatusCode != HttpStatusCode.OK) return null;

            var authResponse = await req.Content.ReadFromJsonAsync<AuthResponse>();
            return authResponse;
        }

        public async Task<RegistrationResponse> RegisterUser(RegisterModel registerModel)
        {
            var res = await _httpClient.PostAsJsonAsync($"{_apiBaseURL}/api/User/CreateUser", registerModel);

            if (res.StatusCode == HttpStatusCode.Found)
                return new RegistrationResponse
                {
                    RegistrationStatus = RegistrationStatus.UserExists,
                    User = null
                };


            var user = await res.Content.ReadFromJsonAsync<User>();

            return new RegistrationResponse
            {
                RegistrationStatus = RegistrationStatus.UserSucesfullyRegistered,
                User = user
            };
        }
    }
}

