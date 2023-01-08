using Companions.API.Models;
using Companions.Domain;

namespace Companions.API.Services
{
    public interface IPlaceService
    {
        Place GetPlaceById(string id);
        List<Place> GetAllPlaces();
        Place CreatePlace(Place place);
        Place UpdatePlace(Place place);
        bool DeletePlace(string id);
    }
}
