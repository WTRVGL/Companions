using Companions.MAUI.Models.App;

namespace Companions.MAUI.Services
{
    public interface IActivityService
    {
        Task<Activity> CreateActivity(Activity activity);
    }
}