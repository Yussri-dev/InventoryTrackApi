using System.IO;
using System.Linq.Expressions;

namespace InventoryTrackApi.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetByNameAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetByBarCodeAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetAllAsync(int pageNumber = 1, int pageSize = 10);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
        Task SoftDeleteAsync(int id);
        Task<Dictionary<string, decimal>> GetPricesAsync(int id);
        Task<decimal> GetQuantityAsync(int id);
        Task<int> CountAsync(Expression<Func<T, bool>> predicate);
        Task<int> CountAsync();
    }
}
