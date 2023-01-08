using Companions.AuthenticationService.Models;
using Companions.AuthenticationService.Repositories;

namespace Companions.AuthenticationService.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
        private readonly IHashPasswordService _hashPasswordService;

        public AuthService(IUserRepository userRepository, ITokenService tokenService, IHashPasswordService hashPasswordService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
            _hashPasswordService = hashPasswordService;
        }

        /// <summary>
        /// Calls external Companions REST API to retrieve a user and checks if credentials match.
        /// </summary>
        /// <returns>
        /// null if user does not exist. 
        /// AuthStatus "Not Authenticated" if user is not authenticated.
        /// AuthStatus "Authenticated" if user is authenticated.
        /// </returns>
        public async Task<AuthenticateResponse> AuthenticateUser(AuthenticateRequest model)
        {
            var user = await _userRepository.GetUserByUserName(model.Username);

            if (user == null)
            {
                return new AuthenticateResponse(null, null, "User does not exist");
            }


            var authenticated =
                _hashPasswordService.CompareBase64HashValues(model.Password, user.PasswordHash, user.PasswordSalt);

            if (!authenticated)
            {
                return new AuthenticateResponse(null, null, "Not Authenticated");
            }

            var authResult = _tokenService.GetJwtSecurityToken((user));


            return new AuthenticateResponse(user, authResult, "Authenticated");

        }


    }
}
