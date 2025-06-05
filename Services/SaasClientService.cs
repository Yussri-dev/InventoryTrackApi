using InventoryTrackApi.Models;
using InventoryTrackApi.Repositories;
using InventoryTrackApi.Services.Interfaces;

namespace InventoryTrackApi.Services
{
    public class SaasClientService
    {
        //private readonly IGenericRepository<SaasClient> _saasRepository;

        //// Constructor to inject the repository
        //public SaasClientService(IGenericRepository<SaasClient> saasRepository)
        //{
        //    _saasRepository = saasRepository;
        //}

        private readonly IUnitOfWork _unitOfWork;
        public SaasClientService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // Get all saass with pagination
        public async Task<IEnumerable<SaasClient>> GetPagedSaass(int pageNumber, int pageSize)
        {
            return await _unitOfWork.SaasClients.GetAllAsync(pageNumber, pageSize);
        }

        //Get a product by Name
        public async Task<IEnumerable<SaasClient>> GetSaasClientByNameAsync(string name)
        {
            return await _unitOfWork.SaasClients.GetByNameAsync(p => p.Name.Contains(name));
        }

        // Get a saas by ID
        public async Task<SaasClient> GetSaasClientByIdAsync(int id)
        {
            return await _unitOfWork.SaasClients.GetByIdAsync(id);
        }

        // Create a new saas
        public async Task CreateSaasClientAsync(SaasClient saas)
        {
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                bool exists = await _unitOfWork.SaasClients.ExistsAsync(p => p.Name == saas.Name ||
                p.Email == saas.Email);

                if (exists)
                {
                    throw new InvalidOperationException("Saas Client with the same Rate already exists.");
                }
                await _unitOfWork.SaasClients.CreateAsync(saas);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
        }

        // Update an existing saas
        public async Task UpdateSaasClientAsync(SaasClient saas)
        {
            var existingSaas = await _unitOfWork.SaasClients.GetByIdAsync(saas.SaasClientId);
            if (existingSaas == null)
            {
                throw new InvalidOperationException("Saas Not Found");
            }
            existingSaas.Name = saas.Name;

            await _unitOfWork.SaasClients.UpdateAsync(existingSaas);
        }

        // Delete a saas by ID
        public async Task DeleteSaasClientAsync(int id)
        {
            await _unitOfWork.SaasClients.DeleteAsync(id);
        }
    }
}
