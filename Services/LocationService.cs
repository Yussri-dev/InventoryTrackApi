using InventoryTrackApi.Models;
using InventoryTrackApi.Repositories;

namespace InventoryTrackApi.Services
{
    public class LocationService
    {
        private readonly IGenericRepository<Location> _locationRepository;

        public LocationService(IGenericRepository<Location> locationRepository)
        {
            _locationRepository = locationRepository;
        }

        //Get All Locations with Paination
        public async Task<IEnumerable<Location>> GetPagedLocationAsync(int pageNumber, int pageSize)
        {
            return await _locationRepository.GetAllAsync(pageNumber, pageSize);
        }

        //Get a Location by Name
        public async Task<IEnumerable<Location>> GetLocationByNameAsync(string name)
        {
            return await _locationRepository.GetByNameAsync(p => p.Name.Contains(name));
        }

        //Get a location By Id
        public async Task<Location> GetLocationByIdAsync(int id)
        {
            return await _locationRepository.GetByIdAsync(id);
        }

        //Create a new Location
        public async Task CreateLocationAsync(Location location)
        {
            bool exists = await _locationRepository.ExistsAsync(p => p.Name == location.Name);

            if (exists)
            {
                throw new InvalidOperationException("Location with the same Rate already exists.");
            }
            await _locationRepository.CreateAsync(location);
        }

        //Update an existing Location
        public async Task UpdateLocationAsync(Location location)
        {
            var existingLocation = await _locationRepository.GetByIdAsync(location.LocationId);
            if (existingLocation == null)
            {
                throw new InvalidOperationException("Location Not Found");
            }
            existingLocation.Name = location.Name;
            existingLocation.PhoneNumber1 = location.PhoneNumber1;
            existingLocation.PhoneNumber2 = location.PhoneNumber2;
            existingLocation.Email = location.Email;
            existingLocation.Adresse = location.Adresse;
            existingLocation.City = location.City;
            existingLocation.Land = location.Land;
            existingLocation.IsActivated = location.IsActivated;
            existingLocation.ModifiedBy = location.ModifiedBy;
            existingLocation.DateModified = location.DateModified;
            existingLocation.SaasClientId = location.SaasClientId;

            await _locationRepository.UpdateAsync(existingLocation);
        }

        //Delete a product By Id
        public async Task DeleteLocationASync(int id)
        {
            await _locationRepository.DeleteAsync(id);
        }
    }
}
