﻿using Companions.MAUI.Models.App;
using Companions.MAUI.Services.Models;

namespace Companions.MAUI.Services
{
    public interface IActivityService
    {
        Task<Activity> CreateActivity(Activity activity);
        Task<List<ActivityType>> GetActivityTypes();
    }
}