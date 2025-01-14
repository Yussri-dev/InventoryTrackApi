using InventoryTrackApi.Models;
using InventoryTrackApi.Repositories;

namespace InventoryTrackApi.Services
{
    public class SupplierService
    {
        private readonly IGenericRepository<Supplier> _supplierRepository;

        public SupplierService(IGenericRepository<Supplier> supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        // Get All Suppliers
        public async Task<IEnumerable<Supplier>> GetPagedCutomersAsync(int pageNumber, int pageSize)
        {
            return await _supplierRepository.GetAllAsync(pageNumber, pageSize);
        }

        //Get a Supplier by Id
        public async Task<Supplier> GetSupplierByIdAsync(int id)
        {
            return await _supplierRepository.GetByIdAsync(id);
        }

        //Create a new Supplier
        public async Task CreateSupplierAsync(Supplier supplier)
        {
            await _supplierRepository.CreateAsync(supplier);
        }

        //Update a Supplier
        public async Task UpdateSupplierAsync(Supplier supplier)
        {
            var existingSupplier = await _supplierRepository.GetByIdAsync(supplier.SupplierId);
            if (existingSupplier == null)
            {
                throw new InvalidOperationException("Supplier Not Found");
            }
            existingSupplier.Name = supplier.Name;
            existingSupplier.PhoneNumber1 = supplier.PhoneNumber1;
            existingSupplier.PhoneNumber2 = supplier.PhoneNumber2;
            existingSupplier.Email = supplier.Email;
            existingSupplier.Adresse = supplier.Adresse;
            existingSupplier.City = supplier.City;
            existingSupplier.Land = supplier.Land;
            existingSupplier.ModifiedBy = supplier.ModifiedBy;
            existingSupplier.DateModified = supplier.DateModified;
            existingSupplier.IsActivate = supplier.IsActivate;

            await _supplierRepository.UpdateAsync(existingSupplier);
        }

        // Delete a Supplier
        public async Task DeleteSupplierAsync(int id)
        {
            await _supplierRepository.DeleteAsync(id);
        }

        //Get a Supplier by Name
        public async Task<IEnumerable<Supplier>> GetSupplierByNameAsync(string name)
        {
            //return await _productRepository.GetByNameAsync(p => EF.Functions.Like(p.Name, name));
            return await _supplierRepository.GetByNameAsync(p => p.Name.Contains(name));
        }
    }
}
