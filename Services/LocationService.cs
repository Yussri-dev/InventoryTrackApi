using InventoryTrackApi.Models;
using InventoryTrackApi.Repositories;
using InventoryTrackApi.Services.Interfaces;

namespace InventoryTrackApi.Services
{
    public class LocationService
    {
        private readonly IUnitOfWork _unitOfWork;
        public LocationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        //Get All Locations with Paination
        public async Task<IEnumerable<Location>> GetPagedLocationAsync(int pageNumber, int pageSize)
        {
            return await _unitOfWork.Locations.GetAllAsync(pageNumber, pageSize);
        }

        //Get a Location by Name
        public async Task<IEnumerable<Location>> GetLocationByNameAsync(string name)
        {
            return await _unitOfWork.Locations.GetByNameAsync(p => p.Name.Contains(name));
        }

        //Get a location By Id
        public async Task<Location> GetLocationByIdAsync(int id)
        {
            return await _unitOfWork.Locations.GetByIdAsync(id);
        }

        //Create a new Location
        public async Task CreateLocationAsync(Location location)
        {
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                bool exists = await _unitOfWork.Locations.ExistsAsync(p => p.Name == location.Name);

                if (exists)
                {
                    throw new InvalidOperationException("Location with the same Rate already exists.");
                }
                await _unitOfWork.Locations.CreateAsync(location);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
        }

        //Update an existing Location
        public async Task UpdateLocationAsync(Location location)
        {
            var existingLocation = await _unitOfWork.Locations.GetByIdAsync(location.LocationId);
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

            await _unitOfWork.Locations.UpdateAsync(existingLocation);
        }

        //Delete a product By Id
        public async Task DeleteLocationASync(int id)
        {
            await _unitOfWork.Locations.DeleteAsync(id);
        }
    }
}
