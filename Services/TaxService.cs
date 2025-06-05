using InventoryTrackApi.Models;
using InventoryTrackApi.Repositories;
using InventoryTrackApi.Services.Interfaces;

namespace InventoryTrackApi.Services
{
    public class TaxService
    {
        //private readonly IGenericRepository<Tax> _taxRepository;

        //// Constructor to inject the repository
        //public TaxService(IGenericRepository<Tax> taxRepository)
        //{
        //    _taxRepository = taxRepository;
        //}

        private readonly IUnitOfWork _unitOfWork;

        public TaxService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // Get all taxs with pagination
        public async Task<IEnumerable<Tax>> GetPagedTaxs(int pageNumber, int pageSize)
        {
            return await _unitOfWork.Taxes.GetAllAsync(pageNumber, pageSize);
        }

        //Get a product by Name
        public async Task<IEnumerable<Tax>> GetTaxByRateAsync(decimal taxe)
        {
            //return await _productRepository.GetByNameAsync(p => EF.Functions.Like(p.Name, name));
            return await _unitOfWork.Taxes.GetByNameAsync(p => p.TaxRate.ToString().Contains(taxe.ToString()));
        }

        // Get a tax by ID
        public async Task<Tax> GetTaxByIdAsync(int id)
        {
            return await _unitOfWork.Taxes.GetByIdAsync(id);
        }

        // Create a new tax
        public async Task CreateTaxAsync(Tax tax)
        {
            bool exists = await _unitOfWork.Taxes.ExistsAsync(p => p.TaxRate == tax.TaxRate);

            if (exists)
            {
                throw new InvalidOperationException("Tax with the same Rate already exists.");
            }

            await _unitOfWork.Taxes.CreateAsync(tax);
        }

        // Update an existing tax
        public async Task UpdateTaxAsync(Tax tax)
        {
            var existingTax = await _unitOfWork.Taxes.GetByIdAsync(tax.TaxId);
            if (existingTax == null)
            {
                throw new InvalidOperationException("Tax Not Found");
            }

            existingTax.TaxRate = tax.TaxRate;

            await _unitOfWork.Taxes.UpdateAsync(existingTax);
        }

        // Delete a tax by ID
        public async Task DeleteTaxAsync(int id)
        {
            await _unitOfWork.Taxes.DeleteAsync(id);
        }
    }
}
