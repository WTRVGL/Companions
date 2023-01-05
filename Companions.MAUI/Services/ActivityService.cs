using CommunityToolkit.Maui.Core.Extensions;
using Companions.MAUI.Models.App;
using Companions.MAUI.Services.Models;
using Microsoft.Extensions.Configuration;
using Syncfusion.Maui.Scheduler;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Companions.MAUI.Services
{
    public class ActivityService : IActivityService
    {
        private readonly HttpClient _httpClient;

        private readonly string _apiBaseURL;
        public ActivityService(IConfiguration config)
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

            _apiBaseURL = config.GetValue<string>("CompanionsAPIBaseURL");
        }

        private async Task EnsureAuthHeaders()
        {
            //Check if headers present
            if (_httpClient.DefaultRequestHeaders.Authorization != null) return;

            var jwt = await SecureStorage.GetAsync("JWT");
            _httpClient.DefaultRequestHeaders.Add("Authorization", jwt);
        }

        public async Task<Activity> CreateActivity(Activity activity)
        {
            await EnsureAuthHeaders();

            var buddyId = activity.BuddyId;
            var createActivityModel = new CreateActivity
            {
                ActivityTypeId = activity.ActivityType.Id,
                EndDate = activity.EndDate,
                StartDate = activity.StartDate,
            };

            var res = await _httpClient.PostAsJsonAsync<CreateActivity>($"{_apiBaseURL}/api/Buddy/{buddyId}/Activity", createActivityModel);

            var createdActivity = await res.Content.ReadFromJsonAsync<Activity>();
            return createdActivity;
        }

        public async Task<List<ActivityType>> GetActivityTypes()
        {
            await EnsureAuthHeaders();

            var res = await _httpClient.GetAsync($"{_apiBaseURL}/api/ActivityTypes");

            var activityTypes = await res.Content.ReadFromJsonAsync<List<ActivityType>>();
            return activityTypes;
        }
    }
}
