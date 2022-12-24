using Companions.Domain;

namespace Companions.API.Services
{
    public interface IBuddyService
    {
        Buddy GetBuddyById(string id);
        List<Buddy> GetAllBuddies();
        Buddy AddBuddy(Buddy buddy);
        Buddy UpdateBuddy(Buddy buddy);
        bool DeleteBuddy(string id);
    }
}
