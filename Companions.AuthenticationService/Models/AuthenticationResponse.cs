
namespace Companions.AuthenticationService.Models
{
    public class AuthenticateResponse
    {
        //Zou custom DTO kunnen maken
        public Gebruiker User { get; set; }
        public string Token { get; set; }


        public AuthenticateResponse(Gebruiker user, string token)
        {
            User = user;
            Token = token;
        }
    }
}
