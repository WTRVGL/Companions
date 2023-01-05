using Companions.Domain;

namespace Companions.API.Services
{
    public interface IActivityService
    {
        Activity CreateActivity(Activity activity);
        List<ActivityType> GetActivityTypes();
    }
}
