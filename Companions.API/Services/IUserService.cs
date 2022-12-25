using Companions.API.Models;
using Companions.Domain;

namespace Companions.API.Services
{
    public interface IUserService
    {
        User GetUserById(string id);
        User GetUserByUserName(string username);
        Task<User> AddUser(CreateUser user);
        User UpdateUser(User user);
        bool DeleteUser(string id);
    }
}
