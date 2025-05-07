using InventoryTrackApi.Models;
using InventoryTrackApi.Repositories;

namespace InventoryTrackApi.Services
{
    public class TaxService
    {
        private readonly IGenericRepository<Tax> _taxRepository;

        // Constructor to inject the repository
        public TaxService(IGenericRepository<Tax> taxRepository)
        {
            _taxRepository = taxRepository;
        }
        // Get all taxs with pagination
        public async Task<IEnumerable<Tax>> GetPagedTaxs(int pageNumber, int pageSize)
        {
            return await _taxRepository.GetAllAsync(pageNumber, pageSize);
        }

        //Get a product by Name
        public async Task<IEnumerable<Tax>> GetTaxByRateAsync(decimal taxe)
        {
            //return await _productRepository.GetByNameAsync(p => EF.Functions.Like(p.Name, name));
            return await _taxRepository.GetByNameAsync(p => p.TaxRate.ToString().Contains(taxe.ToString()));
        }

        // Get a tax by ID
        public async Task<Tax> GetTaxByIdAsync(int id)
        {
            return await _taxRepository.GetByIdAsync(id);
        }

        // Create a new tax
        public async Task CreateTaxAsync(Tax tax)
        {
            bool exists = await _taxRepository.ExistsAsync(p => p.TaxRate == tax.TaxRate);

            if (exists)
            {
                throw new InvalidOperationException("Tax with the same Rate already exists.");
            }

            await _taxRepository.CreateAsync(tax);
        }

        // Update an existing tax
        public async Task UpdateTaxAsync(Tax tax)
        {
            var existingTax = await _taxRepository.GetByIdAsync(tax.TaxId);
            if (existingTax == null)
            {
                throw new InvalidOperationException("Tax Not Found");
            }

            existingTax.TaxRate = tax.TaxRate;

            await _taxRepository.UpdateAsync(existingTax);
        }

        // Delete a tax by ID
        public async Task DeleteTaxAsync(int id)
        {
            await _taxRepository.DeleteAsync(id);
        }
    }
}
