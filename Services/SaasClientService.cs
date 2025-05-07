using InventoryTrackApi.Models;
using InventoryTrackApi.Repositories;

namespace InventoryTrackApi.Services
{
    public class SaasClientService
    {
        private readonly IGenericRepository<SaasClient> _saasRepository;

        // Constructor to inject the repository
        public SaasClientService(IGenericRepository<SaasClient> saasRepository)
        {
            _saasRepository = saasRepository;
        }
        // Get all saass with pagination
        public async Task<IEnumerable<SaasClient>> GetPagedSaass(int pageNumber, int pageSize)
        {
            return await _saasRepository.GetAllAsync(pageNumber, pageSize);
        }

        //Get a product by Name
        public async Task<IEnumerable<SaasClient>> GetSaasClientByNameAsync(string name)
        {
            return await _saasRepository.GetByNameAsync(p => p.Name.Contains(name));
        }

        // Get a saas by ID
        public async Task<SaasClient> GetSaasClientByIdAsync(int id)
        {
            return await _saasRepository.GetByIdAsync(id);
        }

        // Create a new saas
        public async Task CreateSaasClientAsync(SaasClient saas)
        {
            bool exists = await _saasRepository.ExistsAsync(p => p.Name == saas.Name ||
            p.Email == saas.Email);

            if (exists)
            {
                throw new InvalidOperationException("Saas Client with the same Rate already exists.");
            }
            await _saasRepository.CreateAsync(saas);
        }

        // Update an existing saas
        public async Task UpdateSaasClientAsync(SaasClient saas)
        {
            var existingSaas = await _saasRepository.GetByIdAsync(saas.SaasClientId);
            if (existingSaas == null)
            {
                throw new InvalidOperationException("Saas Not Found");
            }
            existingSaas.Name = saas.Name;

            await _saasRepository.UpdateAsync(existingSaas);
        }

        // Delete a saas by ID
        public async Task DeleteSaasClientAsync(int id)
        {
            await _saasRepository.DeleteAsync(id);
        }
    }
}
