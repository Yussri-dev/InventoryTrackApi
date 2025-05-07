using InventoryTrackApi.Models;
using InventoryTrackApi.Repositories;

namespace InventoryTrackApi.Services
{
    public class ProductBatchService
    {
        private readonly IGenericRepository<ProductBatch> _productBatchRepository;

        public ProductBatchService(IGenericRepository<ProductBatch> productBatchRepository)
        {
            _productBatchRepository = productBatchRepository;
        }

        // Get All Product Batch With Pagination
        public async Task<IEnumerable<ProductBatch>> GetPagedProductBatchAsync(int pageNumber, int pageSize)
        {
            return await _productBatchRepository.GetAllAsync(pageNumber, pageSize);
        }

        //Get Product Batch By Id
        public async Task<ProductBatch> GetProductBatchByIdAsync(int id)
        {
            return await _productBatchRepository.GetByIdAsync(id);
        }

        //Create a Product Batch By Id
        public async Task CreateProductBatchAsync(ProductBatch productBatch)
        {
            await _productBatchRepository.CreateAsync(productBatch);
        }

        //Update an Existing Product Batch By Id

        public async Task UpdateProductBatchAsync(ProductBatch productBatch)
        {
            var existingBatch = await _productBatchRepository.GetByIdAsync(productBatch.ProductBatchId);
            if (existingBatch == null)
            {
                throw new InvalidOperationException("Product Batch Not Found");
            }
            existingBatch.BatchNumber = productBatch.BatchNumber;
            existingBatch.Quantity = productBatch.Quantity;
            existingBatch.ExpirationDate = productBatch.ExpirationDate;
            existingBatch.ReceivedDate = productBatch.ReceivedDate;

            await _productBatchRepository.UpdateAsync(existingBatch);
        }

        //Update Quantity In Products
        public async Task<ProductBatch> UpdateProductBatchQuantityAsync(int id, decimal quantityUpdated)
        {
            var existingProduct = await _productBatchRepository.GetByIdAsync(id);

            if (existingProduct == null)
            {
                throw new InvalidOperationException("Product Batch not found.");
            }

            existingProduct.Quantity += quantityUpdated;

            await _productBatchRepository.UpdateAsync(existingProduct);

            return existingProduct;
        }

        //Delete a product Batch By Id
        public async Task DeleteProductBatchAsync(int id)
        {
            await _productBatchRepository.DeleteAsync(id);
        }
    }
}
