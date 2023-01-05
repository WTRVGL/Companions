using Companions.Domain;

namespace Companions.API.Services
{
    public class ActivityService : IActivityService
    {
        private readonly AppDbContext _db;

        public ActivityService(AppDbContext db)
        {
            _db = db;
        }

        public Activity CreateActivity(Activity activity)
        {
            _db.Activities.Add(activity);
            _db.SaveChanges();
            return activity;
        }
    }
}
