using Companions.AuthenticationService.Models;
using Companions.AuthenticationService.Repositories;
using Companions.AuthenticationService.Services;
using System.Net.Http;

namespace Companions.AuthenticationService.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _users;
        private readonly IHashPasswordService _hashPasswordService;
        private readonly HttpClient _httpClient;

        public UserRepository(IHashPasswordService hashPasswordService, IConfiguration config)
        {
            _hashPasswordService = hashPasswordService;

            _httpClient = new HttpClient();
            var apiBaseURL = config.GetValue<string>("CompanionsAPIURL");
            _httpClient.BaseAddress = new Uri(apiBaseURL);
        }

        public async Task<User> GetUserById(string id)
        {
            var user = await _httpClient.GetFromJsonAsync<User>($"api/User/GetUserById/{id}");
            return user;
        }

        public async Task<User> GetUserByUserName(string username)
        {
            var user = await _httpClient.GetFromJsonAsync<User>($"api/User/GetUserByUserName/{username}");
            return user;
        }
    }
}
