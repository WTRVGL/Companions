using CommunityToolkit.Mvvm.ComponentModel;
using Companions.MAUI.Models.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Companions.MAUI.ViewModels.App
{
    [QueryProperty("Buddy","Buddy")]
    public partial class BuddyDetailPageViewModel : BaseViewModel
    {
        [ObservableProperty]
        private Buddy _buddy;
    }

}
