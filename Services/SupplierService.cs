using InventoryTrackApi.Models;
using InventoryTrackApi.Repositories;
using InventoryTrackApi.Services.Interfaces;

namespace InventoryTrackApi.Services
{
    public class SupplierService
    {
        //private readonly IGenericRepository<Supplier> _supplierRepository;

        //public SupplierService(IGenericRepository<Supplier> supplierRepository)
        //{
        //    _supplierRepository = supplierRepository;
        //}

        private readonly IUnitOfWork _unitOfWork;
        public SupplierService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // Get All Suppliers
        public async Task<IEnumerable<Supplier>> GetPagedCutomersAsync(int pageNumber, int pageSize)
        {
            return await _unitOfWork.Suppliers.GetAllAsync(pageNumber, pageSize);
        }

        //Get a Supplier by Id
        public async Task<Supplier> GetSupplierByIdAsync(int id)
        {
            return await _unitOfWork.Suppliers.GetByIdAsync(id);
        }

        //Create a new Supplier
        public async Task CreateSupplierAsync(Supplier supplier)
        {
            bool exists = await _unitOfWork.Suppliers.ExistsAsync(p => p.Name == supplier.Name);

            if (exists)
            {
                throw new InvalidOperationException("Supplier with the same Rate already exists.");
            }
            await _unitOfWork.Suppliers.CreateAsync(supplier);
        }

        //Update a Supplier
        public async Task UpdateSupplierAsync(Supplier supplier)
        {
            var existingSupplier = await _unitOfWork.Suppliers.GetByIdAsync(supplier.SupplierId);
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

            await _unitOfWork.Suppliers.UpdateAsync(existingSupplier);
        }

        // Delete a Supplier
        public async Task DeleteSupplierAsync(int id)
        {
            await _unitOfWork.Suppliers.DeleteAsync(id);
        }

        //Get a Supplier by Name
        public async Task<IEnumerable<Supplier>> GetSupplierByNameAsync(string name)
        {
            //return await _productRepository.GetByNameAsync(p => EF.Functions.Like(p.Name, name));
            return await _unitOfWork.Suppliers.GetByNameAsync(p => p.Name.Contains(name));
        }
    }
}
