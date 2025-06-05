using InventoryTrackApi.Data;
using InventoryTrackApi.Models;
using InventoryTrackApi.Repositories;
using InventoryTrackApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;

namespace InventoryTrackApi.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly InventoryDbContext _context;
        private readonly IRepositoryFactory _factory;
        private IDbContextTransaction _transaction;
        private bool _disposed;
        public UnitOfWork(
            InventoryDbContext context,
            IRepositoryFactory factory)
        {
            _context = context;
            _factory = factory;
        }

        #region Generic Repositories
        public IGenericRepository<Sale> Sales => _factory.GetRepository<Sale>();
        public IGenericRepository<SalePayment> SalePayments => _factory.GetRepository<SalePayment>();
        public IGenericRepository<SaleItem> SaleItems => _factory.GetRepository<SaleItem>();
        public IGenericRepository<Product> Products => _factory.GetRepository<Product>();

        public IGenericRepository<Purchase> Purchases => _factory.GetRepository<Purchase>();
        public IGenericRepository<PurchasePayment> PurchasePayments => _factory.GetRepository<PurchasePayment>();
        public IGenericRepository<PurchaseItem> PurchaseItems => _factory.GetRepository<PurchaseItem>();
        public IGenericRepository<CashRegister> CashRegisters => _factory.GetRepository<CashRegister>();
        public IGenericRepository<CashShift> CashShifts => _factory.GetRepository<CashShift>();

        public IGenericRepository<CashTransaction> CashTransactions => _factory.GetRepository<CashTransaction>();
        public IGenericRepository<Category> Categories => _factory.GetRepository<Category>();
        public IGenericRepository<Customer> Customers => _factory.GetRepository<Customer>();

        public IGenericRepository<Employee> Employees => _factory.GetRepository<Employee>();
        public IGenericRepository<Line> Lines => _factory.GetRepository<Line>();
        public IGenericRepository<Location> Locations => _factory.GetRepository<Location>();

        public IGenericRepository<Shelf> Shelfs => _factory.GetRepository<Shelf>();

        public IGenericRepository<Unit> Units => _factory.GetRepository<Unit>();

        public IGenericRepository<Tax> Taxes => _factory.GetRepository<Tax>();

        public IGenericRepository<Return> Returns => _factory.GetRepository<Return>();

        public IGenericRepository<ReturnItem> ReturnItems => _factory.GetRepository<ReturnItem>();

        public IGenericRepository<ReturnPayment> ReturnPayments => _factory.GetRepository<ReturnPayment>();
        public IGenericRepository<InventoryMouvement> InventoryMouvements => _factory.GetRepository<InventoryMouvement>();
        public IGenericRepository<Inventory> Inventorys => _factory.GetRepository<Inventory>();
        public IGenericRepository<SaasClient> SaasClients => _factory.GetRepository<SaasClient>();
        public IGenericRepository<Supplier> Suppliers => _factory.GetRepository<Supplier>();
        public IGenericRepository<User> Users => _factory.GetRepository<User>();

        #endregion

        #region transactions

        public async Task BeginTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }
        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
            await _transaction.CommitAsync();
        }
        public async Task RollbackAsync()
        {
            await _transaction.RollbackAsync();
        }
        public void Dispose()
        {
            Dispose(true);
            _transaction?.Dispose();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }
            if (disposing)
            {
                _transaction?.Dispose();
                _context?.Dispose();

                if (_factory is IDisposable disposableFactory)
                {
                    disposableFactory.Dispose();
                }
            }

            _disposed = true;
        }
        #endregion
    }
}
