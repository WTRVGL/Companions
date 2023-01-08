using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Companions.MAUI.Models.App
{
    public class Buddy : ObservableObject
    {

        private string _name;
        private string _race;
        private string _gender;
        private string _imageURL;

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public string ImageURL
        {
            get => _imageURL;
            set => SetProperty(ref _imageURL, value);
        }
        public string Race
        {
            get => _race;
            set => SetProperty(ref _race, value);
        }
        public string Gender
        {
            get => _gender;
            set => SetProperty(ref _gender, value);
        }

        public string Id { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<BuddyWeight> BuddyWeights { get; set; }
        public List<Activity> Activities { get; set; }
        public List<FeedingSchedule> FeedingSchedules { get; set; }
        public List<Image> Images { get; set; }


    }
}
