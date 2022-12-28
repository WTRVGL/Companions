using Companions.Domain;

namespace Companions.API.Services
{
    public class PlaceService : IPlaceService
    {
        private readonly AppDbContext _db;

        public PlaceService(AppDbContext db)
        {
            _db = db;
        }

        public Place CreatePlace(Place place)
        {
            _db.Places.Add(place);
            return place;
        }

        public bool DeletePlace(string id)
        {
            var place = _db.Appointments.First(b => b.Id == id);
            if (place == null) return false;

            _db.Appointments.Remove(place);
            _db.SaveChanges();
            return true;
        }

        public List<Place> GetAllPlaces()
        {
            return _db.Places.ToList();
        }

        public Place GetPlaceById(string id)
        {
            var place = _db.Places.FirstOrDefault(a => a.Id == id);
            if (place == null) return null;
            return place;
        }

        public Place UpdatePlace(Place place)
        {
            var placeToBeUpdated = _db.Places.FirstOrDefault(a => a.Id == place.Id);
            if (place == null) return null;
            placeToBeUpdated = place;
            _db.SaveChanges();
            return placeToBeUpdated;
        }
    }
}
