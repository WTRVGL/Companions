using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Companions.MAUI.Models.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Companions.MAUI.ViewModels.App
{
    public partial class HomePageViewModel : BaseViewModel
    {
        [ObservableProperty]
        private List<Buddy> _buddies;

        [RelayCommand]
        async void Click()
        {

        }

        public HomePageViewModel()
        {
            _buddies = new List<Buddy>()
            {
                new Buddy { Name = "Bassie"},
                new Buddy { Name = "Ori"}
            };
        }
    }
}
