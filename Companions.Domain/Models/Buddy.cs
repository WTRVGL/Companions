using System.ComponentModel.DataAnnotations;

namespace Companions.Domain
{
    public class Buddy : Entity
    {
        public string Name { get; set; }
        public string ImageURL { get; set; }
        public DateTime DateOfBirth { get; set; }

        [Required]
        public Species Species { get; set; }

        [Required]
        public Account Account { get; set; }

        public List<BuddyWeight> BuddyWeights { get; set; }
        public List<Activity> Activities { get; set; }
        public List<Appointment> Appointments { get; set; }
        public List<Vaccination> Vaccinations { get; set; }
        public List<FeedingSchedule> FeedingSchedules { get; set; }


    }
}
