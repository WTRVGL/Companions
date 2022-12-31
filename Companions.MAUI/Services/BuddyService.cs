using CommunityToolkit.Maui.Core.Extensions;
using Companions.MAUI.Models.App;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Companions.MAUI.Services
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

        public bool DeleteBuddy(string id)
        {
            return false;
        }

        public async Task<ObservableCollection<Buddy>> GetBuddies()
        {
            await EnsureAuthHeaders();

            var res = await _httpClient.GetAsync($"{_apiBaseURL}/api/Buddies");

            if (res.StatusCode == HttpStatusCode.Unauthorized) return null;

            var buddies = await res.Content.ReadFromJsonAsync<List<Buddy>>();
            return buddies.ToObservableCollection();
        }



        public Buddy UpdateBuddy(Buddy buddy)
        {
            throw new NotImplementedException();
        }
    }
}
