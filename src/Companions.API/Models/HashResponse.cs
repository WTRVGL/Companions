namespace Companions.API.Models
{
    /// <summary>
    /// Base64 strings of a PBKDF2 function
    /// </summary>
    public class HashResponse
    {
        public string Hash { get; set; }
        public string Salt { get; set; }

    }
}
