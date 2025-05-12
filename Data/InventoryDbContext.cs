using InventoryTrackApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace InventoryTrackApi.Data
{
    public class InventoryDbContext : IdentityDbContext<IdentityUser>

    //DbContext
    {
        public InventoryDbContext(DbContextOptions<InventoryDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Category, Location, Customer, Supplier

            // Ensuring unique names
            modelBuilder.Entity<Category>()
                .HasIndex(c => c.Name)
                .IsUnique();

            // Ensuring unique names
            modelBuilder.Entity<Line>()
                .HasIndex(c => c.Name)
                .IsUnique();

            modelBuilder.Entity<Location>()
                .HasIndex(l => l.Name)
                .IsUnique();

            modelBuilder.Entity<Supplier>()
                .HasIndex(s => s.Name)
                .IsUnique();

            // Consider removing uniqueness from Customer.Name if duplicates are allowed
            modelBuilder.Entity<Customer>()
                .HasIndex(c => c.Name)
                .IsUnique();

            // Foreign key constraint for Customer -> SaasClient
            modelBuilder.Entity<Customer>()
                .HasOne(c => c.SaasClient)
                .WithMany(s => s.Customers)
                .HasForeignKey(c => c.SaasClientId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion

            #region Product Relationships

            // Product → Category (Required)
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent accidental deletion

            // Product → Shelf (Optional if some products might not be placed on shelves)
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Shelf)
                .WithMany(s => s.Products)
                .HasForeignKey(p => p.ShelfId)
                .OnDelete(DeleteBehavior.Restrict); // Keeps product if shelf is deleted

            // Product → Line (Optional if not all products belong to a line)
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Line)
                .WithMany(l => l.Products)
                .HasForeignKey(p => p.LineId)
                .OnDelete(DeleteBehavior.Restrict);

            // Product → Tax (Required)
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Tax)
                .WithMany(t => t.Products)
                .HasForeignKey(p => p.TaxId)
                .OnDelete(DeleteBehavior.Restrict); // Prevents deleting tax category if associated with products

            #endregion

            #region Employee Relationships

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.CashRegisters)
                .WithOne(c => c.Employee)
                .HasForeignKey(c => c.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict); // Prevents accidental deletion of Employee affecting CashRegisters

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.CashShifts)
                .WithOne(cs => cs.Employee)
                .HasForeignKey(cs => cs.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict); // Ensures Employee deletion doesn’t affect shifts

            #endregion

            #region Cash Register and Location

            // CashRegister → SaasClient (Required)
            modelBuilder.Entity<CashRegister>()
                .HasOne(c => c.SaasClient)
                .WithMany(s => s.CashRegisters)
                .HasForeignKey(c => c.SaasClientId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascading delete

            // CashRegister → Location (Required)
            modelBuilder.Entity<CashRegister>()
                .HasOne(c => c.Location)
                .WithMany(l => l.CashRegisters)
                .HasForeignKey(c => c.LocationId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascading delete

            // CashRegister → Employee (Optional)
            modelBuilder.Entity<CashRegister>()
                .HasOne(c => c.Employee)
                .WithMany(e => e.CashRegisters)
                .HasForeignKey(c => c.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict); // Allows unregistering an employee without deleting CashRegister

            #endregion

            #region Cash Shift and Cash Transaction

            // CashShift → CashTransaction (Required)
            modelBuilder.Entity<CashShift>()
                .HasMany(cs => cs.CashTransactions)
                .WithOne(ct => ct.CashShift)
                .HasForeignKey(ct => ct.CashShiftId)
                .OnDelete(DeleteBehavior.Restrict); // Ensures cash transactions are deleted if the shift is removed

            #endregion

            #region Inventory Relationships

            modelBuilder.Entity<InventoryMouvement>()
                .HasOne(im => im.SaasClient)
                .WithMany(sc => sc.InventoryMouvements)
                .HasForeignKey(im => im.SaasClientId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

            modelBuilder.Entity<InventoryMouvement>()
                .HasOne(im => im.Location)
                .WithMany(l => l.InventoryMouvements)
                .HasForeignKey(im => im.LocationId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

            // Foreign Key Between Location and Inventory
            modelBuilder.Entity<Location>()
                .HasMany(l => l.Inventories)
                .WithOne(i => i.Location)
                .HasForeignKey(i => i.LocationId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

            #endregion

            #region Purchase and Sale Relationships

            // Purchase Relationships
            modelBuilder.Entity<Purchase>()
                .HasOne(p => p.Supplier)
                .WithMany(s => s.Purchases)
                .HasForeignKey(p => p.SupplierId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Purchase>()
                .HasOne(p => p.Employee)
                .WithMany(e => e.Purchases)
                .HasForeignKey(p => p.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PurchaseItem>()
                .HasOne(pi => pi.Purchase)
                .WithMany(p => p.PurchaseItems)
                .HasForeignKey(pi => pi.PurchaseId)
                .OnDelete(DeleteBehavior.Restrict); // Ensures purchase items are removed if a purchase is deleted

            modelBuilder.Entity<PurchaseItem>()
                .HasOne(pi => pi.Product)
                .WithMany(p => p.PurchaseItems)
                .HasForeignKey(pi => pi.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PurchasePayment>()
                .HasOne(pp => pp.Purchase)
                .WithMany(p => p.PurchasePayments)
                .HasForeignKey(pp => pp.PurchaseId)
                .OnDelete(DeleteBehavior.Restrict); // Ensures payments are removed if purchase is deleted

            #endregion

            #region Product and Unit Relationship

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Unit)
                .WithMany(u => u.Products)
                .HasForeignKey(p => p.UnitId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent deletion of Unit affecting Products

            #endregion

            #region Sale Relationships

            // Sale Relationships
            modelBuilder.Entity<Sale>()
                .HasOne(s => s.Customer)
                .WithMany(c => c.Sales)
                .HasForeignKey(s => s.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Sale>()
                .HasOne(s => s.Employee)
                .WithMany(e => e.Sales)
                .HasForeignKey(s => s.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SaleItem>()
                .HasOne(si => si.Sale)
                .WithMany(s => s.SaleItems)
                .HasForeignKey(si => si.SaleId)
                .OnDelete(DeleteBehavior.Restrict); // Ensures sale items are removed if sale is deleted

            modelBuilder.Entity<SaleItem>()
                .HasOne(si => si.Product)
                .WithMany(p => p.SaleItems)
                .HasForeignKey(si => si.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SalePayment>()
                .HasOne(sp => sp.Sale)
                .WithMany(s => s.SalePayments)
                .HasForeignKey(sp => sp.SaleId)
                .OnDelete(DeleteBehavior.Restrict); // Ensures payments are removed if sale is deleted

            #endregion

            #region Return Relationships

            // Return Relationships
            modelBuilder.Entity<Return>()
                .HasOne(r => r.Customer)
                .WithMany(c => c.Returns)
                .HasForeignKey(r => r.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Return>()
                .HasOne(r => r.Employee)
                .WithMany(e => e.Returns)
                .HasForeignKey(r => r.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ReturnItem>()
                .HasOne(ri => ri.Return)
                .WithMany(r => r.ReturnItems)
                .HasForeignKey(ri => ri.ReturnId)
                .OnDelete(DeleteBehavior.Restrict); // Ensures return items are deleted when return is deleted

            modelBuilder.Entity<ReturnItem>()
                .HasOne(ri => ri.Product)
                .WithMany(p => p.ReturnItems)
                .HasForeignKey(ri => ri.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ReturnPayment>()
                .HasOne(rp => rp.Return)
                .WithMany(r => r.ReturnPayments)
                .HasForeignKey(rp => rp.ReturnId)
                .OnDelete(DeleteBehavior.Restrict); // Ensures return payments are deleted when return is deleted

            // Sale relationship: restrict cascading delete
            modelBuilder.Entity<Return>()
                .HasOne(r => r.Sale)
                .WithMany(s => s.Returns)
                .HasForeignKey(r => r.SaleId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascading delete on SaleId

            #endregion

            // Seeding data from ModelBuilderExtensions (if defined)
            modelBuilder.Seed();
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Shelf> Shelfs { get; set; }
        public DbSet<Line> Lines { get; set; }
        public DbSet<Tax> Taxes { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<CashRegister> CashRegisters { get; set; }
        public DbSet<CashShift> CashShifts { get; set; }
        public DbSet<CashTransaction> CashTransactions { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<InventoryMouvement> InventoryMouvements { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<ProductBatch> ProductBatchs { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<PurchaseItem> PurchaseItems { get; set; }
        public DbSet<PurchasePayment> purchasePayments { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleItem> SaleItems { get; set; }
        public DbSet<SalePayment> SalePayments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<SaasClient> SaasClients { get; set; }

    }
}
