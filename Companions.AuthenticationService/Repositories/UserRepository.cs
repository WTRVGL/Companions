using Companions.AuthenticationService.Models;
using Companions.AuthenticationService.Repositories;
using Companions.AuthenticationService.Services;

namespace Companions.AuthenticationService.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _users;
        private readonly IHashPasswordService _hashPasswordService;

        public UserRepository(IHashPasswordService hashPasswordService)
        {
            _hashPasswordService = hashPasswordService;
            _users= new List<User>();
            _users.Add(CreateUser("admin", "Wouter", "Vangeel", "admin"));
        }

        public User CreateUser(string email, string firstName, string lastName, string password)
        {
            var hashAndSalt = _hashPasswordService.GenerateHashAndSalt(password);
            var user = new User { 
                Id = _users.Count + 1, 
                Email = email, 
                FirstName = firstName, 
                LastName = lastName ,
                PasswordHash = hashAndSalt.Hash,
                PasswordSalt= hashAndSalt.Salt,
                Role = "admin"
            };
            
            _users.Add(user);
            return user;
        }

        public User GetUser(int id)
        {
            return _users.FirstOrDefault(u => u.Id == id);
        }   

        public User GetUserByUserName(string username)
        {
            return _users.FirstOrDefault(u => u.Email == username);
        }

        public List<User> GetUsers()
        {
            return _users;
        }
    }
}
