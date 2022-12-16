﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Companions.MAUI.Models.App;
using Companions.MAUI.Services;
using Companions.MAUI.Views.App;
using Companions.MAUI.Views.App.BuddyDetail;
using Syncfusion.Maui.ListView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItemTappedEventArgs = Syncfusion.Maui.ListView.ItemTappedEventArgs;

namespace Companions.MAUI.ViewModels.App
{
    public partial class HomePageViewModel : BaseViewModel
    {
        private readonly IBuddyService _buddyService;

        [ObservableProperty]
        private bool _isRefreshing;

        [ObservableProperty]
        private ObservableCollection<Buddy> _buddies;

        [ObservableProperty]
        private ObservableCollection<Appointment> _appointments;

        [RelayCommand]
        async void Refresh()
        {
            await Shell.Current.GoToAsync(nameof(HomePage),false);
            var previousPage = Application.Current.MainPage.Navigation.NavigationStack.LastOrDefault();
            Application.Current.MainPage.Navigation.RemovePage(previousPage);
            IsRefreshing = false;
        }


        [RelayCommand]
        async void OpenBuddyDetail(Buddy buddy)
        {
            await Shell.Current.GoToAsync(nameof(BuddyDetailPage),
                new Dictionary<string, object>
                {
                    {"Buddy",buddy }
                });
        }

        [RelayCommand]
        async void OpenAppointmentDetail(ItemTappedEventArgs args)
        {
            var appointment = (Appointment)args.DataItem;

            await Shell.Current.GoToAsync(nameof(AppointmentDetailPage),
                new Dictionary<string, object>
                {
                    {"Appointment", appointment}
                });
        }

        public HomePageViewModel(IBuddyService buddyservice)
        {
            _buddyService = buddyservice;
            _buddies = _buddyService.GetBuddies();

            _appointments = new ObservableCollection<Appointment>()
            {
                new Appointment {
                    AppointmentName = "CPV Vaccinatie", 
                    BuddyName = "Ori", 
                    AppointmentDate = new DateTime(2022,12,24,15,30,00),
                    Description = "Tweede herhalingsprik voor CPV. Nog één vaccinatiemoment vereist tot volledige immunisatie",
                    BuddyURL = "https://i.imgur.com/UUzY06O.png",
                    LocationName = "DAC Prinsenhof"
                },
                new Appointment {
                    AppointmentName = "Jaarlijkse checkup", 
                    BuddyName = "Bassie", 
                    Description = "Routine checkup ter controle gewicht en voedings.",
                    AppointmentDate = new DateTime(2022,12,24,15,30,00),
                    LocationName = "DAC Prinsenhof",
                    BuddyURL = "https://i.imgur.com/GJe4t90.jpg"
                },
            };
        }

    }
}
