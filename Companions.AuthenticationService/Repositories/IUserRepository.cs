using Companions.AuthenticationService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Companions.AuthenticationService.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserById(string id);
        Task<User> GetUserByUserName(string username);
    }
}
