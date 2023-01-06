using Companions.MAUI.Models.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Companions.MAUI.Selectors
{
    /// <summary>
    /// DataTemplateSelector for possible Activities
    /// </summary>
    public class BuddyOverviewSelector : DataTemplateSelector
    {
        public DataTemplate WalkTemplate { get; set; }
        public DataTemplate FeedingTemplate { get; set; }
        public DataTemplate WeightTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var activity = (Activity)item;

            switch (activity.ActivityType.Name)
            {
                case "Feeding":
                    return FeedingTemplate;
                case "Walk":
                    return WalkTemplate;
                case "Weight":
                    return WeightTemplate;
                default:
                    throw new NotImplementedException();
            }

        }
    }
}
