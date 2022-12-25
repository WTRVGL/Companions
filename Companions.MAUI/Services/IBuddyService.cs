using Companions.MAUI.Models.App;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Companions.MAUI.Services
{
    public interface IBuddyService
    {
        Task<Buddy> GetBuddyById(int id);
        Task<ObservableCollection<Buddy>> GetBuddies();
        Task<Buddy> AddBuddy(Buddy buddy);
        Buddy UpdateBuddy(Buddy buddy);
        bool DeleteBuddy(string id);

    }
}
