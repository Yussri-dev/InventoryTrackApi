using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.IO;
using System.Linq.Expressions;

namespace InventoryTrackApi.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        #region Entity
        Task<T> GetByIdAsync(int id);
        Task<T> GetByIdAsync(string id);
        Task<Dictionary<string, decimal>> GetPricesAsync(int id);
        Task<decimal> GetQuantityAsync(int id);
        Task<int> CountAsync(Expression<Func<T, bool>> predicate);
        Task<int> CountAsync();
        Task<decimal> CalculateSumAsync(Expression<Func<T, bool>> filter, Expression<Func<T, decimal>> selector);
        Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate);
        Task<decimal> GetSumByPeriodAsync(Expression<Func<T, bool>> dateRangeFilter, Expression<Func<T, decimal>> selector);

        #endregion

        #region IEnumerable
        Task<IEnumerable<T>> GetByNameAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetByBarCodeAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetAllAsync(int pageNumber = 1, int pageSize = 10);
        Task<IEnumerable<T>> GetAllByDateRangeAsync(DateTime startDate, DateTime endDate, int pageNumber, int pageSize);

        Task<IEnumerable<T>> GetDataByDateRange(Expression<Func<T, bool>> filter);
        Task<IEnumerable<T>> GetByConditionAsync(Expression<Func<T, bool>> filter, params string[] includeProperties);
        Task<T> GetByDataConditionAsync(Expression<Func<T, bool>> filter, params string[] includeProperties);

        Task<IEnumerable<T>> GetPagedWithIncludesAsync(int pageNumber, int pageSize, params string[] includeProperties);
        Task<IEnumerable<T>> GetPagedWithIncludesWithDateRangeAsync(DateTime startDate, DateTime endDate, params string[] includeProperties);
        Task<IEnumerable<T>> GetWhereAsync(Expression<Func<T, bool>> predicate);
        Task<T?> FindAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null);

        #endregion

        #region CRUD
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
        Task SoftDeleteAsync(int id);
        Task SaveChangesAsync();

        #endregion

    }
}
