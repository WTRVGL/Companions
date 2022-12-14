using CommunityToolkit.Maui.Core.Extensions;
using Companions.MAUI.Models.App;
using Companions.MAUI.Services.Interface;
using Companions.MAUI.Services.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Image = Companions.MAUI.Models.App.Image;

namespace Companions.MAUI.Services.Implementation
{
    public class BuddyService : IBuddyService
    {
        private readonly HttpClient _httpClient;

        private readonly string _apiBaseURL;

        public BuddyService(IConfiguration config)
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

            _apiBaseURL = config.GetValue<string>("CompanionsAPIBaseURL");


        }

        public async Task<Buddy> GetBuddyById(string id)
        {
            await EnsureAuthHeaders();

            var res = await _httpClient.GetAsync(_apiBaseURL);
            var buddy = res.Content.ReadFromJsonAsync<Buddy>();

            // //
            return new Buddy();
        }

        private async Task EnsureAuthHeaders()
        {
            //Check if headers present
            if (_httpClient.DefaultRequestHeaders.Authorization != null) return;

            var jwt = await SecureStorage.GetAsync("JWT");

            _httpClient.DefaultRequestHeaders.Add("Authorization", jwt);
        }

        public async Task<Buddy> AddBuddy(Buddy buddy)
        {
            var res = await _httpClient.PostAsJsonAsync($"{_apiBaseURL}/api/buddy", buddy);

            var buddies = await res.Content.ReadFromJsonAsync<List<Buddy>>();
            //
            return new Buddy();
        }

        public async Task<bool> DeleteBuddy(string id)
        {
            await EnsureAuthHeaders();

            var res = await _httpClient.DeleteAsync($"{_apiBaseURL}/api/Buddy/{id}");
            var deleted = await res.Content.ReadFromJsonAsync<bool>();

            return deleted;
        }

        public async Task<ObservableCollection<Buddy>> GetBuddies()
        {
            await EnsureAuthHeaders();

            var res = await _httpClient.GetAsync($"{_apiBaseURL}/api/Buddies");

            if (res.StatusCode == HttpStatusCode.Unauthorized) return null;

            var buddies = await res.Content.ReadFromJsonAsync<List<Buddy>>();
            return buddies.ToObservableCollection();
        }



        public async Task<Buddy> UpdateBuddy(Buddy buddy)
        {
            await EnsureAuthHeaders();

            var req = new UpdateBuddyRequest
            {
                Id = buddy.Id,
                Gender = buddy.Gender,
                Name = buddy.Name,
                Race = buddy.Race,
                BuddyWeights = buddy.BuddyWeights,
                ImageURL = buddy.ImageURL
            };

            var res = await _httpClient.PutAsJsonAsync($"{_apiBaseURL}/api/Buddy", req);
            var updatedBuddy = await res.Content.ReadFromJsonAsync<Buddy>();


            return updatedBuddy;
        }

        public async Task<BuddyWeight> AddBuddyWeight(BuddyWeight buddyWeight)
        {
            await EnsureAuthHeaders();

            string buddyId = buddyWeight.BuddyId;

            var req = new BuddyWeight
            {
                BuddyId = buddyId,
                DateWeighed = buddyWeight.DateWeighed,
                Weight = buddyWeight.Weight,
            };

            var res = await _httpClient.PostAsJsonAsync($"{_apiBaseURL}/api/Buddy/{buddyId}", req);
            var createdBuddyWeight = await res.Content.ReadFromJsonAsync<BuddyWeight>();

            return createdBuddyWeight;
        }

        public async Task<Image> AddImage(Image image)
        {
            await EnsureAuthHeaders();
            var res = await _httpClient.PostAsJsonAsync($"{_apiBaseURL}/api/Buddy/{image.BuddyId}/Image", image);
            return await res.Content.ReadFromJsonAsync<Image>();

        }
    }
}

