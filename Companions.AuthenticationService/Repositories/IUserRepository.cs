using Companions.AuthenticationService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Companions.AuthenticationService.Repositories
{
    public interface IUserRepository
    {
        List<User> GetUsers();
        User GetUser(int id);
        User GetUserByUserName(string username);
        User CreateUser(string username, string firstName, string lastName, string password);
    }
}
