
using InventoryTrackApi.Data;
using InventoryTrackApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace InventoryTrackApi.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly InventoryDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(InventoryDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = _context.Set<T>();
            _context.Database.EnsureCreated();
        }

        // Gets all records with optional pagination and filtering
        public async Task<IEnumerable<T>> GetAllAsync(int pageNumber = 1, int pageSize = 10)
        {
            // Ensure pageSize is positive and reasonable
            pageSize = pageSize > 0 ? pageSize : 10;
            pageNumber = pageNumber > 0 ? pageNumber : 1;

            return await _dbSet.Skip((pageNumber - 1) * pageSize)
                               .Take(pageSize)
                               .ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllByDateRangeAsync(DateTime startDate, DateTime endDate, int pageNumber, int pageSize)
        {
            pageSize = pageSize > 0 ? pageSize : 10;
            pageNumber = pageNumber > 0 ? pageNumber : 1;

            // Check if the entity has a DateCreated property
            var query = _dbSet.AsQueryable();
            var parameter = Expression.Parameter(typeof(T), "entity");
            var property = Expression.Property(parameter, "DateCreated");
            var lambda = Expression.Lambda<Func<T, bool>>(
                Expression.AndAlso(
                    Expression.GreaterThanOrEqual(property, Expression.Constant(startDate)),
                    Expression.LessThanOrEqual(property, Expression.Constant(endDate))
                ),
                parameter
            );

            query = query.Where(lambda);

            return await query.Skip((pageNumber - 1) * pageSize)
                              .Take(pageSize)
                              .ToListAsync();
        }

        // Gets a single record by ID, or throws a custom exception if not found
        public async Task<T> GetByIdAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
            {
                // You can replace this with a more specific custom exception
                throw new KeyNotFoundException($"Entity with ID {id} not found.");
            }

            return entity;
        }

        //// Gets a single record by Name, or throws a custom exception if not found
        public async Task<IEnumerable<T>> GetByNameAsync(Expression<Func<T, bool>> predicate)
        {
            var entities = await _dbSet.Where(predicate).ToListAsync();
            if (entities == null)
            {
                throw new KeyNotFoundException("Entity with the name criteria not found.");
            }
            return entities;
        }

        //// Gets a single record by Name, or throws a custom exception if not found
        public async Task<IEnumerable<T>> GetByBarCodeAsync(Expression<Func<T, bool>> predicate)
        {
            var entities = await _dbSet.Where(predicate).ToListAsync();
            if (entities == null)
            {
                throw new KeyNotFoundException("Entity with the name criteria not found.");
            }
            return entities;
        }
        // Create a new entity and save to the database
        public async Task CreateAsync(T entity)
        {
            try
            {
                await _dbSet.AddAsync(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Handle exceptions gracefully, e.g., logging
                throw new InvalidOperationException("Error creating entity", ex);
            }
        }

        // Update an existing entity in the database
        //public async Task UpdateAsync(T entity)
        //{
        //    _context.Set<T>().Update(entity);
        //    await _context.SaveChangesAsync();

        //}
        public async Task UpdateAsync(T entity)
        {
            try
            {
                //_dbSet.Entry(entity).State = EntityState.Modified;
                _dbSet.Update(entity);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                // Handle concurrency issues
                throw new InvalidOperationException("Concurrency error during update", ex);
            }
            catch (Exception ex)
            {
                // General error handling
                throw new InvalidOperationException("Error updating entity", ex);
            }
        }


        //public async Task UpdateAsync(T entity)
        //{
        //    try
        //    {
        //        // Check if the entity is already tracked
        //        var trackedEntity = _dbSet.Local.FirstOrDefault(e => e == entity ||
        //            _context.Entry(e).Property("Id").CurrentValue == _context.Entry(entity).Property("Id").CurrentValue);

        //        if (trackedEntity != null)
        //        {
        //            // Update the tracked entity
        //            _context.Entry(trackedEntity).CurrentValues.SetValues(entity);
        //        }
        //        else
        //        {
        //            // Attach and mark the entity as modified
        //            _dbSet.Attach(entity);
        //            _context.Entry(entity).State = EntityState.Modified;
        //        }

        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException ex)
        //    {
        //        // Handle concurrency issues (log, retry, etc.)
        //        throw new InvalidOperationException("Concurrency error during update", ex);
        //    }
        //    catch (Exception ex)
        //    {
        //        // General error handling
        //        throw new InvalidOperationException("Error updating entity", ex);
        //    }
        //}

        // Deletes an entity by ID (soft delete can be implemented here if needed)
        public async Task DeleteAsync(int id)
        {
            try
            {
                var entity = await GetByIdAsync(id); // This could be optimized by directly deleting by ID
                if (entity != null)
                {
                    _dbSet.Remove(entity);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new KeyNotFoundException($"Entity with ID {id} not found.");
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions such as entity not found or database errors
                throw new InvalidOperationException("Error deleting entity", ex);
            }
        }

        // Optional method for soft deletes (marking an entity as deleted without physically removing it)
        public async Task SoftDeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                // entity.IsDeleted = true;
                _dbSet.Update(entity);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Entity with ID {id} not found.");
            }
        }


        // Get all prices for a specific product by ID as a dictionary
        public async Task<Dictionary<string, decimal>> GetPricesAsync(int idProduit)
        {
            var product = await _dbSet.OfType<Product>().FirstOrDefaultAsync(p => p.ProductId == idProduit);

            if (product == null)
            {
                throw new ArgumentException("Product not found.");
            }

            var prices = new Dictionary<string, decimal>
            {
                { "SalePrice1", product.SalePrice1 },
                { "SalePrice2", product.SalePrice2 },
                { "SalePrice3", product.SalePrice3 },
                { "PurchasePrice", product.PurchasePrice }
            };

            return prices;
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> predicate)
        {
            if (predicate == null)
            {
                return await _dbSet.CountAsync();
            }
            return await _dbSet.CountAsync(predicate);
        }

        public async Task<int> CountAsync()
        {
            return await _dbSet.CountAsync();

        }

        
        public async Task<decimal> GetQuantityAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
            {
                throw new KeyNotFoundException($"Entity with ID {id} not found.");
            }

            // return entity QuantityStock
            return (entity as Product)?.QuantityStock ?? throw new InvalidOperationException("Invalid entity type for quantity retrieval.");
        }

        

    }
}
