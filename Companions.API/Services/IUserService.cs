using Companions.API.Models;
using Companions.Domain;

namespace Companions.API.Services
{
    public interface IUserService
    {
        User GetUserById(string id);
        Task<User> AddUser(CreateUser user);
        User UpdateUser(User user);
        bool DeleteUser(string id);
    }
}
