using InventoryTrackApi.Models;
using InventoryTrackApi.Repositories;

namespace InventoryTrackApi.Services.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Sale> Sales { get; }
        IGenericRepository<SaleItem> SaleItems { get; }
        IGenericRepository<SalePayment> SalePayments { get; }

        IGenericRepository<Purchase> Purchases { get; }
        IGenericRepository<PurchaseItem> PurchaseItems { get; }
        IGenericRepository<PurchasePayment> PurchasePayments { get; }

        IGenericRepository<Return> Returns { get; }
        IGenericRepository<ReturnItem> ReturnItems { get; }
        IGenericRepository<ReturnPayment> ReturnPayments { get; }

        IGenericRepository<CashRegister> CashRegisters { get; }
        IGenericRepository<CashShift> CashShifts { get; }
        IGenericRepository<CashTransaction> CashTransactions { get; }

        IGenericRepository<Customer> Customers { get; }
        IGenericRepository<Supplier> Suppliers { get; }
        IGenericRepository<Employee> Employees { get; }

        IGenericRepository<Product> Products { get; }
        IGenericRepository<Category> Categories { get; }
        IGenericRepository<Line> Lines { get; }
        IGenericRepository<Location> Locations { get; }
        IGenericRepository<Shelf> Shelfs { get; }
        IGenericRepository<Unit> Units { get; }
        IGenericRepository<Tax> Taxes { get; }
        IGenericRepository<InventoryMouvement> InventoryMouvements { get; }
        IGenericRepository<Inventory> Inventorys { get; }
        IGenericRepository<SaasClient> SaasClients { get; }
        IGenericRepository<User> Users { get; }
        Task BeginTransactionAsync();
        Task CommitAsync();
        Task RollbackAsync();
    }
}
