using Companions.AuthenticationService.Repositories;

namespace Companions.AuthenticationService.Services
{
    public class RegistrationService
    {
        private readonly IUserRepository _repository;

        public RegistrationService(IUserRepository repository)
        {
            _repository = repository;
        }

        public bool userAlreadyExists(string username)
        {
            var user = _repository.GetUserByUserName(username);
            if (user.GebruikerID == 0)
            {
                return false;
            }
            return true;
        }

        public bool createNewUser(string username, string voornaam, string achternaam, string passwoord)
        {
            if (userAlreadyExists(username))
            {
                return false;
            }


            var createdUser = _repository.CreateUser(username, voornaam, achternaam, passwoord);
            return true;
        }
    }
}
