using InventoryTrackApi.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryTrackApi.Data
{
    public class InventoryDbContext : DbContext
    {
        public InventoryDbContext(DbContextOptions<InventoryDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Category
            modelBuilder.Entity<Category>()
                .HasIndex(c => c.Name)
                .IsUnique();

            // Category
            modelBuilder.Entity<Location>()
                .HasIndex(c => c.Name)
                .IsUnique();

            // Customer
            modelBuilder.Entity<Customer>()
                .HasIndex(c => c.Name)
                .IsUnique();

            // Supplier
            modelBuilder.Entity<Supplier>()
                .HasIndex(c => c.Name)
                .IsUnique();

            // Employee
            modelBuilder.Entity<Employee>().Ignore(e => e.NameComplete);



            // InventoryMouvement
            modelBuilder.Entity<InventoryMouvement>()
                .Property(m => m.MouvementType)
                .HasConversion<string>();

            #region Product
            // Foreign Key between Product and Category
            modelBuilder.Entity<Product>()
                .HasOne(c => c.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(c => c.CategoryId);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Shelf)
                .WithMany(s => s.Products)
                .HasForeignKey(f => f.ShelfId);

            // Foreign Key Between Product and Line

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Line)
                .WithMany(s => s.Products)
                .HasForeignKey(f => f.LineId);


            modelBuilder.Entity<Product>()
                .HasOne(p => p.Tax)
                .WithMany(s => s.Products)
                .HasForeignKey(f => f.TaxId);


            modelBuilder.Entity<Product>()
                .HasOne(p => p.Unit)
                .WithMany(s => s.Products)
                .HasForeignKey(f => f.UnitId);

            modelBuilder.Entity<Product>()
               .HasMany(p => p.Inventories)
               .WithOne(i => i.Product)
               .HasForeignKey(f => f.ProductId);

            modelBuilder.Entity<Product>()
                .HasMany(p => p.ProductBatches)
                .WithOne(pb => pb.Product)
                .HasForeignKey(f => f.ProductId);
            #endregion

            #region Employee
            // Foreign Key Between CashRegister and Employee
            modelBuilder.Entity<Employee>()
                .HasMany(e => e.CashRegisters)
                .WithOne(c => c.Employee)
                .HasForeignKey(f => f.EmployeeId);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.CashShifts)
                .WithOne(cs => cs.Employee)
                .HasForeignKey(f => f.EmployeeId)
                .OnDelete(DeleteBehavior.NoAction);
            #endregion
            // Foreign Key Between CashRegister and Location
            modelBuilder.Entity<Location>()
                .HasMany(l => l.CashRegisters)
                .WithOne(c => c.Location)
                .HasForeignKey(f => f.LocationId);

            

            modelBuilder.Entity<CashRegister>()
                .HasMany(cr => cr.CashShifts)
                .WithOne(cs => cs.CashRegister)
                .HasForeignKey(f => f.CashRegisterId);


            modelBuilder.Entity<CashShift>()
                .HasMany(cs => cs.CashTransactions)
                .WithOne(ct => ct.CashShift)
                .HasForeignKey(f => f.CashShiftId)
                .OnDelete(DeleteBehavior.NoAction);

            // Foreign Key Between Location and Inventory
            modelBuilder.Entity<Location>()
                .HasMany(l => l.Inventories)
                .WithOne(i => i.Location)
                .HasForeignKey(f => f.LocationId);

            // Foreign Key between Location and InventoryMouvement
            modelBuilder.Entity<Location>()
                .HasMany(l => l.InventoryMouvements)
                .WithOne(im => im.Location)
                .HasForeignKey(f => f.LocationId);

            #region Purchase
            // Sale
            modelBuilder.Entity<Purchase>()
                .HasOne(s => s.Supplier)
                .WithMany(c => c.Purchases)
                .HasForeignKey(f => f.SupplierId)
                .OnDelete(DeleteBehavior.Restrict);



            modelBuilder.Entity<Purchase>()
                    .HasOne(s => s.Employee)
                    .WithMany(e => e.Purchases)
                    .HasForeignKey(f => f.EmployeeId)
                    .OnDelete(DeleteBehavior.Restrict);

            // Sale -> SaleItem
            modelBuilder.Entity<PurchaseItem>()
                .HasOne(si => si.Purchase)
                .WithMany(s => s.PurchaseItems)
                .HasForeignKey(si => si.PurchaseId)
                .OnDelete(DeleteBehavior.Restrict);

            // Product -> SaleItem
            modelBuilder.Entity<PurchaseItem>()
                .HasOne(si => si.Product)
                .WithMany(p => p.PurchaseItems)
                .HasForeignKey(si => si.ProductId)
                .OnDelete(DeleteBehavior.Restrict);



            // Sale Payment
            modelBuilder.Entity<PurchasePayment>()
                .HasOne(sp => sp.Purchase)
                .WithMany(s => s.PurchasePayments)
                .HasForeignKey(f => f.PurchaseId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion
            

            #region Sale
            // Sale
            modelBuilder.Entity<Sale>()
                .HasOne(s => s.Customer)
                .WithMany(c => c.Sales)
                .HasForeignKey(f => f.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);



            modelBuilder.Entity<Sale>()
                    .HasOne(s => s.Employee)
                    .WithMany(e => e.Sales)
                    .HasForeignKey(f => f.EmployeeId)
                    .OnDelete(DeleteBehavior.Restrict);

            // Sale -> SaleItem
            modelBuilder.Entity<SaleItem>()
                .HasOne(si => si.Sale)
                .WithMany(s => s.SaleItems)
                .HasForeignKey(si => si.SaleId)
                .OnDelete(DeleteBehavior.Restrict);

            // Product -> SaleItem
            modelBuilder.Entity<SaleItem>()
                .HasOne(si => si.Product)
                .WithMany(p => p.SaleItems)
                .HasForeignKey(si => si.ProductId)
                .OnDelete(DeleteBehavior.Restrict);



            // Sale Payment
            modelBuilder.Entity<SalePayment>()
                .HasOne(sp => sp.Sale)
                .WithMany(s => s.SalePayments)
                .HasForeignKey(f => f.SaleId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion

            #region Return
            // Sale
            modelBuilder.Entity<Return>()
                .HasOne(s => s.Customer)
                .WithMany(c => c.Returns)
                .HasForeignKey(f => f.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);



            modelBuilder.Entity<Return>()
                    .HasOne(s => s.Employee)
                    .WithMany(e => e.Returns)
                    .HasForeignKey(f => f.EmployeeId)
                    .OnDelete(DeleteBehavior.Restrict);

            // Sale -> SaleItem
            modelBuilder.Entity<ReturnItem>()
                .HasOne(si => si.Return)
                .WithMany(s => s.returnItems)
                .HasForeignKey(si => si.ReturnId)
                .OnDelete(DeleteBehavior.Restrict);

            // Product -> SaleItem
            modelBuilder.Entity<ReturnItem>()
                .HasOne(si => si.Product)
                .WithMany(p => p.ReturnItems)
                .HasForeignKey(si => si.ProductId)
                .OnDelete(DeleteBehavior.Restrict);



            // Sale Payment
            modelBuilder.Entity<ReturnPayment>()
                .HasOne(sp => sp.Return)
                .WithMany(s => s.ReturnPayments)
                .HasForeignKey(f => f.ReturnId)
                .OnDelete(DeleteBehavior.Restrict);

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


    }
}
