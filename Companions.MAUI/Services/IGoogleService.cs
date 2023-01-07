using Companions.MAUI.Models.App;
using Companions.MAUI.Services.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Companions.MAUI.Services
{
    public interface IGoogleService
    {
        Task<List<Place>> FetchPlaces(string searchQuery, double latitude, double longitude, int range);
        Task<string> UploadImage(Stream file);
    }
}
