using Companions.Api;
using Companions.Domain;

namespace Companions.API.Services
{
    public class BuddyService : IBuddyService
    {
        private readonly AppDbContext _db;

        public BuddyService(AppDbContext db)
        {
            _db = db;
        }

        public Buddy AddBuddy(Buddy buddy)
        {
            _db.Buddies.Add(buddy);
            _db.SaveChanges();
            return buddy;
        }

        public bool DeleteBuddy(string id)
        {
            var buddy = _db.Buddies.First(b => b.Id == id);
            if (buddy == null) return false;

            _db.Buddies.Remove(buddy);
            _db.SaveChanges();
            return true;

        }

        public List<Buddy> GetAllBuddies()
        {
            var buddies = _db.Buddies.ToList();
            return buddies;
        }

        public Buddy GetBuddyById(string id)
        {
            var buddy = _db.Buddies.First(b => b.Id == id);
            if (buddy == null) return null;
            return buddy;
        }

        public Buddy UpdateBuddy(Buddy request)
        {
            var buddy = _db.Buddies.First(b => b.Id == request.Id);
            if (buddy == null) return null;

            buddy.FeedingSchedules = request.FeedingSchedules;
            buddy.Vaccinations = request.Vaccinations;
            buddy.User = request.User;
            buddy.DateOfBirth = request.DateOfBirth;
            buddy.Activities = request.Activities;
            buddy.Appointments = request.Appointments;
            buddy.Name = request.Name;
            buddy.ImageURL = request.ImageURL;
            buddy.DailyFeedingEvents = request.DailyFeedingEvents;
            buddy.Activities = request.Activities;
            buddy.Species = request.Species;
            buddy.BuddyWeights = request.BuddyWeights;

            _db.SaveChanges();
            return buddy;
        }
    }
}
