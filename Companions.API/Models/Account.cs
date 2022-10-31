namespace Companions.API.Models
{
    public class Account : Entity
    {
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => FirstName +" " + LastName;
    }
}