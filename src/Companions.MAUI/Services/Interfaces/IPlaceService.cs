using Companions.MAUI.Models.App;
using Companions.MAUI.Services.Models;
using System.Collections.ObjectModel;

namespace Companions.MAUI.Services.Interface
{
    public interface IPlaceService
    {
        Task<Place> CreatePlace(CreatePlace place);
        Task<ObservableCollection<Place>> GetPlaces();
        Task<Place> GetPlaceById(string placeId);
    }
}