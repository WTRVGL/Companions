using CommunityToolkit.Maui.Core.Extensions;
using Companions.MAUI.Models.App;
using Companions.MAUI.Services.Interface;
using Companions.MAUI.Services.Models;
using Microsoft.Extensions.Configuration;
using Syncfusion.Maui.Scheduler;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Companions.MAUI.Services.Implementation
{
    public class PlaceService : IPlaceService
    {
        private readonly HttpClient _httpClient;

        private readonly string _apiBaseURL;
        public PlaceService(IConfiguration config)
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

            _apiBaseURL = config.GetValue<string>("CompanionsAPIBaseURL");
        }

        private async Task EnsureAuthHeaders()
        {
            //Check if headers present
            if (_httpClient.DefaultRequestHeaders.Authorization != null) return;

            var jwt = await SecureStorage.GetAsync("JWT");
            _httpClient.DefaultRequestHeaders.Add("Authorization", jwt);
        }

        public async Task<Place> CreatePlace(CreatePlace place)
        {
            await EnsureAuthHeaders();

            var res = await _httpClient.PostAsJsonAsync($"{_apiBaseURL}/api/Places/", place);

            var createdPlace = await res.Content.ReadFromJsonAsync<Place>();
            return createdPlace;
        }

        public async Task<ObservableCollection<Place>> GetPlaces()
        {
            await EnsureAuthHeaders();

            var res = await _httpClient.GetAsync($"{_apiBaseURL}/api/Places");

            var places = await res.Content.ReadFromJsonAsync<ObservableCollection<Place>>();
            return places;
        }

        public async Task<Place> GetPlaceById(string placeId)
        {
            await EnsureAuthHeaders();

            var res = await _httpClient.GetAsync($"{_apiBaseURL}/api/Places/{placeId}");

            var place = await res.Content.ReadFromJsonAsync<Place>();
            return place;
        }
    }
}
