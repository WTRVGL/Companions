using Companions.API.Models;
using Companions.Domain;
using System.Net.Http;

namespace Companions.API.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;
        private readonly AppDbContext _db;
        public UserService(IConfiguration config, AppDbContext db)
        {
            _db = db;
            _httpClient = new HttpClient();
            var apiBaseURL = config.GetValue<string>("CompanionsAuthenticationServiceURL");
            _httpClient.BaseAddress = new Uri(apiBaseURL);
        }

        public User GetUserById(string id)
        {
            var user = _db.Users.FirstOrDefault(u => u.Id == id);
            if (user == null) return null;
            return user;
        }

        public User GetUserByUserName(string username)
        {
            var user = _db.Users.FirstOrDefault(u => u.UserName == username);
            if (user == null) return null;
            return user;
        }

        public async Task<User> AddUser(CreateUser user)
        {
            var hashRequest = new HashRequest { Password = user.Password };
            var hashResponse = await _httpClient.PostAsJsonAsync<HashRequest>("/api/Hash/GenerateHashKeys", hashRequest);
            var hashKeys = await hashResponse.Content.ReadFromJsonAsync<HashResponse>();

            if (hashKeys == null) throw new Exception("Auth Service error");

            var newUser = new User
            {
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PasswordHash = hashKeys.Hash,
                PasswordSalt = hashKeys.Salt,
                Role = user.Role
            };

            _db.Users.Add(newUser);
            _db.SaveChanges();

            return newUser;
        }


        public bool DeleteUser(string id)
        {
            throw new NotImplementedException();
        }



        public User UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
