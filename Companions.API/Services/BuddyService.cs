using Companions.Domain;
using Microsoft.EntityFrameworkCore;

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
            var buddy = _db.Buddies
                .Include(b => b.Activities)
                .Include(b => b.Vaccinations)
                .Include(b => b.Appointments)
                .Include(b => b.FeedingSchedules)
                .Include(b => b.BuddyWeights)
                .First(b => b.Id == id);

            if (buddy == null) return false;

            _db.Buddies.Remove(buddy);
            _db.SaveChanges();
            return true;

        }

        public List<Buddy> GetAllBuddies()
        {
            var buddies = _db.Buddies
                .Include(b => b.BuddyWeights)
                .Include(b => b.Activities)
                    .ThenInclude(a => a.ActivityType)
                .Include(b => b.FeedingSchedules)
                .ToList();
            return buddies;
        }

        public List<Buddy> GetAllBuddiesByUserId(string userId)
        {
            var buddies = _db.Buddies
                .Where(b => b.UserId == userId)
                .Include(b => b.BuddyWeights)
                .Include(b => b.Appointments)
                    .ThenInclude(a => a.Place)
                .Include(b => b.Activities)
                    .ThenInclude(a => a.ActivityType)
                .Include(b => b.FeedingSchedules)
                    .ThenInclude(f => f.FeedProduct)
                .ToList();

            if (buddies == null) return null;
            return buddies;
        }

        public Buddy GetBuddyById(string id)
        {
            var buddy = _db.Buddies.FirstOrDefault(b => b.Id == id);
            if (buddy == null) return null;
            return buddy;
        }

        public Buddy UpdateBuddy(Buddy request)
        {
            var buddy = _db.Buddies.FirstOrDefault(b => b.Id == request.Id);
            if (buddy == null) return null;

            buddy.Name = request.Name;
            buddy.Race = request.Race;
            buddy.Gender = request.Gender;

            //buddy.FeedingSchedules = request.FeedingSchedules;
            //buddy.Vaccinations = request.Vaccinations;
            //buddy.User = request.User;
            //buddy.DateOfBirth = request.DateOfBirth;
            //buddy.Activities = request.Activities;
            //buddy.Appointments = request.Appointments;
            //buddy.Name = request.Name;
            //buddy.ImageURL = request.ImageURL;
            //buddy.Activities = request.Activities;
            //buddy.Race = request.Race;
            //buddy.BuddyWeights = request.BuddyWeights;

            _db.SaveChanges();
            return buddy;
        }
    }
}
