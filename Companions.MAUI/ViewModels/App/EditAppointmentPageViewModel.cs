using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Companions.MAUI.Messages;
using Companions.MAUI.Models.App;
using Companions.MAUI.Services;
using Companions.MAUI.Services.Models;
using Companions.MAUI.Views.App.Popups;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Companions.MAUI.ViewModels.App
{
    [QueryProperty("Appointment", "Appointment")]
    public partial class EditAppointmentPageViewModel : BaseViewModel
    {
        private readonly IBuddyService _buddyService;
        private readonly IAppointmentService _appointmentService;
        private readonly IPlaceService _placeService;
        private readonly IGoogleService _googleService;

        public EditAppointmentPageViewModel(IBuddyService buddyService, IAppointmentService appointmentService, IPlaceService placeService, IGoogleService googleService)
        {
            _buddyService = buddyService;
            _appointmentService = appointmentService;
            _placeService = placeService;
            _googleService = googleService;

            GooglePlaces = new ObservableCollection<Place>();

            Task.Run(async () => await FetchDataAsync()).Wait();
        }

        [ObservableProperty]
        private Appointment _appointment;
        [ObservableProperty]
        private Buddy _selectedBuddy;
        [ObservableProperty]
        private Place _selectedPlace;
        [ObservableProperty]
        private string _selectedAppointmentType;
        [ObservableProperty]
        private string _appointmentDescription;
        [ObservableProperty]
        private string _appointmentName;
        [ObservableProperty]
        private string _placeSearchQuery;
        [ObservableProperty]
        private string _placeSearchRange;
        [ObservableProperty]
        private string _selectedPlaceType;
        [ObservableProperty]
        private DateTime _appointmentDate;
        [ObservableProperty]
        private TimeSpan _selectedTime;


        [ObservableProperty]
        private ObservableCollection<Buddy> _buddies;
        [ObservableProperty]
        private ObservableCollection<Place> _DbPlaces;
        [ObservableProperty]
        private ObservableCollection<Place> _googlePlaces;


        [RelayCommand]
        async void GoBack()
        {
            //Update hour
            var newDate = new DateTime(
                Appointment.AppointmentDate.Year, 
                Appointment.AppointmentDate.Month, 
                Appointment.AppointmentDate.Day, 
                SelectedTime.Hours,
                SelectedTime.Minutes,
                SelectedTime.Seconds);

            Appointment.AppointmentDate = newDate;


            //Update appointment in db

            if (SelectedPlace.Id == null)
            {
                //create new
                var place = new CreatePlace
                {
                    Id = Guid.NewGuid().ToString(),
                    Address = SelectedPlace.Address,
                    Description = SelectedPlaceType,
                    Latitude = SelectedPlace.Latitude,
                    Longitude = SelectedPlace.Longitude,
                    Name = SelectedPlace.Name
                };

                SelectedPlace = await _placeService.CreatePlace(place);
            }



            var appointment = new Appointment
            {
                Id = Appointment.Id,
                AppointmentDate = Appointment.AppointmentDate,
                AppointmentName = Appointment.AppointmentName,
                BuddyId = Appointment.BuddyId,
                Description = Appointment.Description,
                Place = Appointment.Place
            };

            var updatedAppointment = _appointmentService.UpdateAppointment(appointment);
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        [RelayCommand]
        async void BuddySelected()
        {
            Appointment.Buddy = _selectedBuddy;
            Appointment.BuddyId = _selectedBuddy.Id;
        }

        [RelayCommand]
        async Task FetchDataAsync()
        {
            Buddies = await _buddyService.GetBuddies();
            DbPlaces = await _placeService.GetPlaces();
        }

        [RelayCommand]
        async Task CreatePlace()
        {
            var popup = new CreatePlacePopup();
            Shell.Current.ShowPopup(popup);
        }

        [RelayCommand]
        async void GoogleSearchAppointment()
        {
            GeolocationRequest request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
            Location location = await Geolocation.Default.GetLocationAsync(request);

            //Convert string to double, then round it up and then convert to int. I love spaghetti.
            var searchRangeInMeters = Convert.ToInt32(Math.Round(Convert.ToDouble(PlaceSearchRange)));
            var searchRangeInKilometers = searchRangeInMeters * 1000;

            var uriEncodedSearchQuery = Uri.EscapeDataString(PlaceSearchQuery);
            var places = await _googleService.FetchPlaces(uriEncodedSearchQuery, location.Latitude, location.Longitude, searchRangeInKilometers);
            GooglePlaces = places.ToObservableCollection();

        }

        partial void OnAppointmentChanged(Appointment appointment)
        {
            SelectedPlace = Appointment.Place;
            SelectedTime = Appointment.AppointmentDate.TimeOfDay;
        }
    }
}
