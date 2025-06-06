﻿
using InventoryTrackApi.Data;
using InventoryTrackApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
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

        public async Task<IEnumerable<T>> GetPagedWithIncludesAsync(int pageNumber, int pageSize, params string[] includeProperties)
        {
            IQueryable<T> query = _dbSet;

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<IEnumerable<T>> GetPagedWithIncludesWithDateRangeAsync(DateTime startDate, DateTime endDate, params string[] includeProperties)
        {
            IQueryable<T> query = _dbSet;

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

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

            return await query.ToListAsync();
        }
        public async Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.AnyAsync(predicate);
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


        public async Task<decimal> CalculateSumAsync(
                Expression<Func<T, bool>> filter,
                Expression<Func<T, decimal>> selector)
        {
            if (filter == null)
            {
                throw new ArgumentNullException(nameof(filter), "The filter expression cannot be null.");
            }

            if (selector == null)
            {
                throw new ArgumentNullException(nameof(selector), "The selector expression cannot be null.");
            }

            return await _dbSet.Where(filter).SumAsync(selector);
        }

        public async Task<IEnumerable<T>> GetDataByDateRange(Expression<Func<T, bool>> filter)
        {
            if (filter == null)
            {
                throw new ArgumentNullException(nameof(filter), "The filter expression cannot be null.");
            }

            return await _dbSet.Where(filter).ToListAsync();


        }

        public async Task<IEnumerable<T>> GetByConditionAsync(Expression<Func<T, bool>> filter, params string[] includeProperties)
        {
            IQueryable<T> query = _dbSet;

            // Include related entities
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            // Apply the filter
            query = query.Where(filter);

            return await query.ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetWhereAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task<decimal> GetSumByPeriodAsync(
            Expression<Func<T, bool>> dateRangeFilter,
            Expression<Func<T, decimal>> selector)
        {
            IQueryable<T> query = _dbSet;
            query = query.Where(dateRangeFilter);
            return await query.SumAsync(selector);
        }

        public async Task<T> GetByDataConditionAsync(Expression<Func<T, bool>> filter, params string[] includeProperties)
        {
            var query = _dbSet.Where(filter).FirstOrDefaultAsync();


            return await query;
        }

        public async Task<T> GetByIdAsync(string id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
            {
                // You can replace this with a more specific custom exception
                throw new KeyNotFoundException($"Entity with ID {id} not found.");
            }

            return entity;
        }

        public async Task<T?> FindAsync(
             Expression<Func<T, bool>> predicate,
             Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null)
        {
            IQueryable<T> query = _dbSet;

            if (include != null)
            {
                query = include(query);
            }

            return await query.FirstOrDefaultAsync(predicate);
        }

    }
}
