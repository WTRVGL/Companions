using Companions.MAUI.Models.App;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Companions.MAUI.Services
{
    public class InMemoryBuddyService : IBuddyService
    {
        private readonly List<FeedProduct> _feedProducts;
        private readonly List<ActivityType> _activityTypes;
        private readonly ObservableCollection<Buddy> _buddies;
        private readonly List<Activity> _activities;
        private readonly List<FeedingSchedule> _feedingSchedules;

        public InMemoryBuddyService()
        {
            #region Add mock data to lists

            _activityTypes = new List<ActivityType>() {
                new ActivityType { Name = "Walk" },
                new ActivityType { Name= "Feeding" }
            };

            _feedProducts = new List<FeedProduct>
            {
                new FeedProduct { BrandName = "Hill's", Name = "Science Plan Adult No Grain Medium", ProductURL = "https://shop-cdn-m.mediazs.com/bilder/hills/science/plan/adult/no/grain/medium/met/kip/0/800/4_new_project_0.jpg" },
                new FeedProduct { BrandName = "Hill's", Name = "Science Plan Adult Perfect Digestion", ProductURL = "https://shop-cdn-m.mediazs.com/bilder/hills/science/plan/adult/perfect/digestion/medium/breed/hondenvoer/1/800/thumbnail_18__1.jpg" },
                new FeedProduct { BrandName = "Hill's", Name = "Science Plan Adult Healthy Mobility Small", ProductURL = "https://shop-cdn-m.mediazs.com/bilder/hills/science/plan/adult/healthy/mobility/small/mini/met/kip/hondenvoer/8/800/7_new_project_8.jpg" },
                new FeedProduct { BrandName = "Royal Canin", Name = "Maxi Adult", ProductURL = "https://shop-cdn-m.mediazs.com/bilder/royal/canin/maxi/adult/hondenvoer/8/800/80729_pla_royalcanin_maxiadult_15kg_hs_01_8.jpg" },
                new FeedProduct { BrandName = "Rocco", Name = "Classic", ProductURL = "https://shop-cdn-m.mediazs.com/bilder/rocco/classic/x/g/8/800/28021_pla_megapack_rocc_classic_rindpur_400g_hs_01_8.jpg" },
                new FeedProduct { BrandName = "Whiskas", Name = "1+ Rund", ProductURL = "https://shop-cdn-m.mediazs.com/bilder/korting/whiskas/droogvoer/7/800/908518_7.jpg" },
            };

            _feedingSchedules = new List<FeedingSchedule>
            {
                new FeedingSchedule { Amount = 100, FeedProduct = _feedProducts[0], TimeOfDay = "Morning"},
                new FeedingSchedule { Amount = 100, FeedProduct = _feedProducts[0], TimeOfDay = "Evening"},

                new FeedingSchedule { Amount = 80, FeedProduct = _feedProducts[1], TimeOfDay = "Morning"},
                new FeedingSchedule { Amount = 80, FeedProduct = _feedProducts[1], TimeOfDay = "Evening"},

                new FeedingSchedule { Amount = 120, FeedProduct = _feedProducts[4], TimeOfDay = "Morning"},
                new FeedingSchedule { Amount = 800, FeedProduct = _feedProducts[5], TimeOfDay = "Evening"},
            };

            _activities = new List<Activity>
            {
                new Activity { ActivityType = _activityTypes.FirstOrDefault(a => a.Name == "Walk"), StartDate = new DateTime(2022,11,01,08,15,00), EndDate = new DateTime(2022,11,01,09,31,00) },
                new Activity { ActivityType = _activityTypes.FirstOrDefault(a => a.Name == "Feeding"), StartDate = new DateTime(2022,11,01,12,00,00), EndDate = new DateTime(2022,11,01,12,31,00) },
                new Activity { ActivityType = _activityTypes.FirstOrDefault(a => a.Name == "Walk"), StartDate = new DateTime(2022,11,01,16,15,00), EndDate = new DateTime(2022,11,01,16,42,00) },
                new Activity { ActivityType = _activityTypes.FirstOrDefault(a => a.Name == "Walk"), StartDate = new DateTime(2022,11,02,09,15,00), EndDate = new DateTime(2022,11,02,09,51,00) },
                new Activity { ActivityType = _activityTypes.FirstOrDefault(a => a.Name == "Feeding"), StartDate = new DateTime(2022,11,02,13,15,00), EndDate = new DateTime(2022,11,02,14,03,00) },
                new Activity { ActivityType = _activityTypes.FirstOrDefault(a => a.Name == "Walk"), StartDate = new DateTime(2022,11,02,16,15,00), EndDate = new DateTime(2022,11,02,17,02,00) },
                new Activity { ActivityType = _activityTypes.FirstOrDefault(a => a.Name == "Walk"), StartDate = new DateTime(2022,11,02,20,15,00), EndDate = new DateTime(2022,11,02,21,01,00) },
                new Activity { ActivityType = _activityTypes.FirstOrDefault(a => a.Name == "Feeding"), StartDate = new DateTime(2022,11,03,08,30,00), EndDate = new DateTime(2022,11,03,09,02,00) },
                new Activity { ActivityType = _activityTypes.FirstOrDefault(a => a.Name == "Walk"), StartDate = new DateTime(2022,11,03,12,15,00), EndDate = new DateTime(2022,11,03,12,31,00) },
                new Activity { ActivityType = _activityTypes.FirstOrDefault(a => a.Name == "Walk"), StartDate = new DateTime(2022,11,03,15,15,00), EndDate = new DateTime(2022,11,03,15,44,00) },
                new Activity { ActivityType = _activityTypes.FirstOrDefault(a => a.Name == "Feeding"), StartDate = new DateTime(2022,11,03,20,15,00), EndDate = new DateTime(2022,11,03,20,41,00) },
                new Activity { ActivityType = _activityTypes.FirstOrDefault(a => a.Name == "Walk"), StartDate = new DateTime(2022,11,03,23,15,00), EndDate = new DateTime(2022,11,03,23,34,00) },
            }.OrderByDescending(x => x.StartDate).ToList();

            _buddies = new ObservableCollection<Buddy>()
            {
                new Buddy {
                    Id = "1",
                    Name = "Bassie",
                    Age = 6,
                    Race = "Mixed",
                    Gender= "M",
                    Weight = 6,
                    ImageURL = "https://i.imgur.com/GJe4t90.jpg",
                    Activities = _activities.GetRange(0, _activities.Count),
                    FeedingSchedules = _feedingSchedules.GetRange(0, 2),
                },
                new Buddy {
                    Id = "2",
                    Name = "Ori",
                    Age = 4,
                    Race = "Mixed",
                    Weight = 5,
                    Gender = "M",
                    ImageURL="https://i.imgur.com/UUzY06O.png",
                    Activities = _activities.GetRange(0, _activities.Count),
                    FeedingSchedules = _feedingSchedules.GetRange(2, 2)
                },
                new Buddy {
                    Id = "3",
                    Name = "Robot",
                    Age = 4,
                    Race = "Tabby",
                    Gender = "M",
                    Weight = 3,
                    ImageURL="https://i.imgur.com/Z0J26m6.png",
                    Activities = _activities.Where(x => x.ActivityType.Name == "Feeding").ToList(),
                    FeedingSchedules = _feedingSchedules.GetRange(4, 2)
                }
            };


            #endregion
        }
        public ObservableCollection<Buddy> GetBuddies()
        {
            return _buddies;
        }
    }
}
