namespace Companions.Api.Models
{
    public class JWTConfiguration
    {
        public string JWTHttpCookieName { get; set; }
        public string ValidAudience { get; set; }
        public string ValidIssuer { get; set; }
        public string Secret { get; set; }
    }
}
