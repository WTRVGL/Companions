using Companions.MAUI.Models.App;
using Companions.MAUI.Services.Interface;
using Companions.MAUI.Services.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Companions.MAUI.Services.Implementation
{
    public class GoogleService : IGoogleService
    {
        private readonly string _apiKey;
        private readonly string _imageServiceBaseURL;
        private readonly HttpClient _httpClient;

        public GoogleService(IConfiguration config)
        {
            _apiKey = config.GetValue<string>("GoogleMapsBrowserKey");
            _imageServiceBaseURL = config.GetValue<string>("CompanionsImageBaseURL");
            _httpClient = new HttpClient();
        }

        public async Task<List<Place>> FetchPlaces(string searchQuery, double latitude, double longitude, int range)
        {
            var reqUrl = $"https://maps.googleapis.com/maps/api/place/nearbysearch/json" +
                $"?keyword={searchQuery}" +
                $"&location={latitude}%2C{longitude}" +
                $"&radius={range}" +
                $"&key={_apiKey}";

            var req = await _httpClient.GetAsync(reqUrl);
            var data = await req.Content.ReadFromJsonAsync<GooglePlaceResponse>();

            var places = new List<Place>();

            foreach (var item in data.Results)
            {
                var place = new Place
                {
                    Address = item.Vicinity,
                    Latitude = item.Geometry.Location.Lat,
                    Longitude = item.Geometry.Location.Lng,
                    Name = item.Name,
                };

                places.Add(place);
            }

            return places;
        }

        public async Task<string> UploadImage(Stream file)
        {
            HttpContent content = new StreamContent(file);
            var res = await _httpClient.PostAsync($"{_imageServiceBaseURL}/api/Image", content);
            return await res.Content.ReadAsStringAsync();
        }
    }
}
