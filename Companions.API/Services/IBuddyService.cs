using Companions.Domain;

namespace Companions.API.Services
{
    public interface IBuddyService
    {
        Buddy GetBuddyById(string id);
        List<Buddy> GetAllBuddies();
        List<Buddy> GetAllBuddiesByUserId(string userId);
        Buddy AddBuddy(Buddy buddy);
        Buddy UpdateBuddy(Buddy buddy);
        bool DeleteBuddy(string id);
    }
}
