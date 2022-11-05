using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Companions.MAUI.Models.App;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Companions.MAUI.ViewModels.App
{
    public partial class HomePageViewModel : BaseViewModel
    {
        [ObservableProperty]
        private ObservableCollection<Buddy> _buddies;

        [RelayCommand]
        async void Click()
        {

        }

        public HomePageViewModel()
        {
            _buddies = new ObservableCollection<Buddy>()
            {
                new Buddy { Name = "Bassie", Age = 6, Race = "Mixed", ImageURL = "https://i.imgur.com/848igAJ.jpg"},
                new Buddy { Name = "Ori", Age = 4, Race = "Mixed", ImageURL="https://i.imgur.com/UUzY06O.png"}
            };
        }
    }
}
