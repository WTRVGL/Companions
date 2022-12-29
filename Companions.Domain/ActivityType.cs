namespace Companions.Domain
{
    public class ActivityType : Entity
    {
        public List<Activity> Activities { get; set; }
        public string Name { get; set; }
    }
}