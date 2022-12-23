using Companions.AuthenticationService.Models;
using Companions.AuthenticationService.Repositories;

namespace Companions.AuthenticationService.Repositories
{
    public class UserRepository : IUserRepository
    {
        public Gebruiker CreateUser(string username, string voornaam, string achternaam, string passwoord)
        {
            throw new NotImplementedException();
        }

        public Gebruiker GetUser(int id)
        {
            throw new NotImplementedException();
        }

        public Gebruiker GetUserByUserName(string username)
        {
            throw new NotImplementedException();
        }

        public List<Gebruiker> GetUsers()
        {
            throw new NotImplementedException();
        }
    }
}
