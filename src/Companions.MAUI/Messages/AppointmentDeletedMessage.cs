using CommunityToolkit.Mvvm.Messaging.Messages;
using Companions.MAUI.Models.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Companions.MAUI.Messages
{
    public class AppointmentDeletedMessage : ValueChangedMessage<string>
    {
        public AppointmentDeletedMessage(string id) : base(id)
        {
        }
    }
}
