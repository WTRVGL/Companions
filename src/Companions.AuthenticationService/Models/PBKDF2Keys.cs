namespace Companions.AuthenticationService.Models
{
    /// <summary>
    /// Base64 strings of a PBKDF2 function
    /// </summary>
    public class PBKDF2Keys
    {
        public string Hash { get; }
        public string Salt { get; }

        public PBKDF2Keys(string hash, string salt)
        {
            Hash = hash;
            Salt = salt;
        }
    }
}
