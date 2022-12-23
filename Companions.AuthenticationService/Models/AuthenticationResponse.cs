
namespace Companions.AuthenticationService.Models
{
    public class AuthenticateResponse
    {
        //Zou custom DTO kunnen maken
        public User User { get; set; }
        public string Token { get; set; }
        public string AuthStatus { get; set; }


        public AuthenticateResponse(User user, string token, string authStatus)
        {
            User = user;
            Token = token;
            AuthStatus = authStatus;
        }
    }
}
