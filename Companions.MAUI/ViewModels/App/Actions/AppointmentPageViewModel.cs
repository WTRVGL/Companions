using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Companions.MAUI.Models.App;
using Companions.MAUI.Services;
using Companions.MAUI.Services.Models;
using Companions.MAUI.Views.App.Popups;
using Syncfusion.Maui.DataSource.Extensions;
using Syncfusion.Maui.ListView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Companions.MAUI.ViewModels.App.Actions
{
    public partial class AppointmentPageViewModel : BaseViewModel
    {
        private readonly IBuddyService _buddyService;
        private readonly IPlaceService _placeService;
        private readonly IGoogleService _googleService;
        private readonly IAppointmentService _appointmentService;

        public AppointmentPageViewModel(IBuddyService buddyService, IGoogleService googleService, IPlaceService placeService, IAppointmentService appointmentService)
        {
            _buddyService = buddyService;
            _googleService = googleService;
            _placeService = placeService;
            _appointmentService = appointmentService;

            GooglePlaces = new ObservableCollection<Place>();
            AppointmentDate = DateTime.Now.AddDays(1);

            Task.Run(FetchDataAsync).Wait();
        }


        [ObservableProperty]
        private Buddy _selectedBuddy;
        [ObservableProperty]
        private string _selectedAppointmentType;
        [ObservableProperty]
        private string _appointmentDescription;
        [ObservableProperty]
        private string _appointmentName;
        [ObservableProperty]
        private Place _selectedPlace;
        [ObservableProperty]
        private string _placeSearchQuery;
        [ObservableProperty]
        private string _placeSearchRange;
        [ObservableProperty]
        private string _selectedPlaceType;
        [ObservableProperty]
        private DateTime _appointmentDate;

        [ObservableProperty]
        private ObservableCollection<Buddy> _buddies;
        [ObservableProperty]
        private ObservableCollection<Place> _dbPlaces;
        [ObservableProperty]
        private ObservableCollection<Place> _googlePlaces;

        [RelayCommand]
        async void GoBack()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        [RelayCommand]
        async Task FetchDataAsync()
        {
            Buddies = await _buddyService.GetBuddies();
            DbPlaces = await _placeService.GetPlaces();
        }

        [RelayCommand]
        async void CreateAppointment()
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

        [RelayCommand]
        async void AddAppointment()
        {
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

                await _placeService.CreatePlace(place);

                SelectedPlace.Id = place.Id;
            }

            var appointment = new CreateAppointment
            {
                AppointmentDate = AppointmentDate,
                AppointmentName = AppointmentName,
                BuddyId = SelectedBuddy.Id,
                Description = AppointmentDescription,
                PlaceId = SelectedPlace.Id
            };

            var createdAppointment = await _appointmentService.CreateAppointment(appointment);

            //var endTime = DateTime.Now.AddMinutes(SelectedDuration).AddSeconds(5);

            ////Get Id of Walk Activity
            //var activityTypes = await _activityService.GetActivityTypes();
            //var walkActivityType = activityTypes.FirstOrDefault(a => a.Name == "Walk");

            //if (walkActivityType == null)
            //{
            //    await Application.Current.MainPage.DisplayAlert("Error", "Walk id not found", "Ok");
            //}

            //foreach (Buddy buddy in SelectedBuddies)
            //{
            //    var createActivity = new Activity
            //    {
            //        ActivityType = walkActivityType,
            //        EndDate = endTime,
            //        StartDate = DateTime.Now,
            //        BuddyId = buddy.Id,
            //    };

            //    var createdActivity = await _activityService.CreateActivity(createActivity);
            //}

            //Display notification and close
            await Application.Current.MainPage.DisplayAlert("Success", "Succesfully created Appointment", "Ok");
            await Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
