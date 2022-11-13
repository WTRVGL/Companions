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
        public ObservableCollection<Buddy> GetBuddies()
        {
            var activityTypes = new List<ActivityType>() { 
                new ActivityType { Name = "Walk" }, 
                new ActivityType { Name= "Feeding" } 
            };

            var buddies = new ObservableCollection<Buddy>()
            {
                new Buddy { 
                    Name = "Bassie", 
                    Age = 6, 
                    Race = "Mixed", 
                    Gender= "M", 
                    Weight = 6, 
                    ImageURL = "https://i.imgur.com/GJe4t90.jpg",
                    Activities = new List<Activity>{ 
                        new Activity { ActivityType = activityTypes.FirstOrDefault(a => a.Name == "Walk"), StartDate = new DateTime(2022,11,01,13,15,00), EndDate = new DateTime(2022,11,01,14,40,00) },
                        new Activity { ActivityType = activityTypes.FirstOrDefault(a => a.Name == "Walk"), StartDate = new DateTime(2022,11,01,07,00,00), EndDate = new DateTime(2022,11,01,07,30,00) },
                    }
                },
                new Buddy { Name = "Ori", Age = 4, Race = "Mixed", Weight = 5, Gender = "M", ImageURL="https://i.imgur.com/UUzY06O.png"},
                new Buddy { Name = "Robot", Age = 4, Race = "Tabby",Gender = "M", Weight = 3,ImageURL="https://i.imgur.com/Z0J26m6.png"},
            };

            return buddies;
        }
    }
}
