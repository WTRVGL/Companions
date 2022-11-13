namespace Companions.Domain
{
    public class ActivityType : Entity
    {
        public List<Activity> Activities { get; set; }
        public string ActivityTypeName { get; set; }
    }
}