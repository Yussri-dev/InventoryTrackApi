using InventoryTrackApi.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryTrackApi.Data
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
           // //seed Supplier
           // modelBuilder.Entity<Supplier>().HasData(
           //    new Supplier { SupplierId = 1, Name = "Supplier A", PhoneNumber1 = "1111111111", PhoneNumber2 = "2222222222", Email = "supplierA@example.com", Adresse = "123 Supplier Street", City = "City A", Land = "Country A", CreatedBy = "Admin", DateCreated = DateTime.Now, ModifiedBy = "Admin", DateModified = DateTime.Now, IsActivate = true },
           //    new Supplier { SupplierId = 2, Name = "Supplier B", PhoneNumber1 = "3333333333", PhoneNumber2 = "4444444444", Email = "supplierB@example.com", Adresse = "456 Another Street", City = "City B", Land = "Country B", CreatedBy = "Admin", DateCreated = DateTime.Now, ModifiedBy = "Admin", DateModified = DateTime.Now, IsActivate = true },
           //    new Supplier { SupplierId = 3, Name = "Supplier C", PhoneNumber1 = "5555555555", PhoneNumber2 = "6666666666", Email = "supplierC@example.com", Adresse = "789 Third Avenue", City = "City C", Land = "Country C", CreatedBy = "Admin", DateCreated = DateTime.Now, ModifiedBy = "Admin", DateModified = DateTime.Now, IsActivate = false },
           //    new Supplier { SupplierId = 4, Name = "Supplier D", PhoneNumber1 = "7777777777", PhoneNumber2 = "8888888888", Email = "supplierD@example.com", Adresse = "1011 Fourth Avenue", City = "City D", Land = "Country D", CreatedBy = "Admin", DateCreated = DateTime.Now, ModifiedBy = "Admin", DateModified = DateTime.Now, IsActivate = true },
           //    new Supplier { SupplierId = 5, Name = "Supplier E", PhoneNumber1 = "9999999999", PhoneNumber2 = "1212121212", Email = "supplierE@example.com", Adresse = "1213 Fifth Street", City = "City E", Land = "Country E", CreatedBy = "Admin", DateCreated = DateTime.Now, ModifiedBy = "Admin", DateModified = DateTime.Now, IsActivate = false },
           //    new Supplier { SupplierId = 6, Name = "Supplier F", PhoneNumber1 = "3434343434", PhoneNumber2 = "5656565656", Email = "supplierF@example.com", Adresse = "1415 Sixth Lane", City = "City F", Land = "Country F", CreatedBy = "Admin", DateCreated = DateTime.Now, ModifiedBy = "Admin", DateModified = DateTime.Now, IsActivate = true },
           //    new Supplier { SupplierId = 7, Name = "Supplier G", PhoneNumber1 = "7878787878", PhoneNumber2 = "8989898989", Email = "supplierG@example.com", Adresse = "1617 Seventh Road", City = "City G", Land = "Country G", CreatedBy = "Admin", DateCreated = DateTime.Now, ModifiedBy = "Admin", DateModified = DateTime.Now, IsActivate = true },
           //    new Supplier { SupplierId = 8, Name = "Supplier H", PhoneNumber1 = "2323232323", PhoneNumber2 = "4545454545", Email = "supplierH@example.com", Adresse = "1819 Eighth Avenue", City = "City H", Land = "Country H", CreatedBy = "Admin", DateCreated = DateTime.Now, ModifiedBy = "Admin", DateModified = DateTime.Now, IsActivate = false },
           //    new Supplier { SupplierId = 9, Name = "Supplier I", PhoneNumber1 = "6767676767", PhoneNumber2 = "8989898989", Email = "supplierI@example.com", Adresse = "2021 Ninth Boulevard", City = "City I", Land = "Country I", CreatedBy = "Admin", DateCreated = DateTime.Now, ModifiedBy = "Admin", DateModified = DateTime.Now, IsActivate = true },
           //    new Supplier { SupplierId = 10, Name = "Supplier J", PhoneNumber1 = "1234123412", PhoneNumber2 = "5678567856", Email = "supplierJ@example.com", Adresse = "2223 Tenth Parkway", City = "City J", Land = "Country J", CreatedBy = "Admin", DateCreated = DateTime.Now, ModifiedBy = "Admin", DateModified = DateTime.Now, IsActivate = true }
           //);

            // Seeding Category data
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Electronics" },
                new Category { CategoryId = 2, Name = "Clothing" },
                new Category { CategoryId = 3, Name = "Groceries" },
                new Category { CategoryId = 4, Name = "Furniture" },
                new Category { CategoryId = 5, Name = "Books" },
                new Category { CategoryId = 6, Name = "Sacs" },
                new Category { CategoryId = 7, Name = "Data" },
                new Category { CategoryId = 8, Name = "Bread" },
                new Category { CategoryId = 9, Name = "Jacket" },
                new Category { CategoryId = 10, Name = "T-Shirts" },
                new Category { CategoryId = 11, Name = "Jeans" },
                new Category { CategoryId = 12, Name = "Mobile" }
            );

            // Seeding Line data
            modelBuilder.Entity<Line>().HasData(
                new Line { LineId = 1, Name = "Electronics Line" },
                new Line { LineId = 2, Name = "Clothing Line" },
                new Line { LineId = 3, Name = "Grocery Line" },
                new Line { LineId = 4, Name = "Furniture Line" },
                new Line { LineId = 5, Name = "Toys Line" }
            );

            //seeding Shelf data
            modelBuilder.Entity<Shelf>().HasData(
                new Shelf { ShelfId = 1, Name = "Shelf 1" },
                new Shelf { ShelfId = 2, Name = "Shelf 2" },
                new Shelf { ShelfId = 3, Name = "Shelf 3" }
            );

            //seeding Tax data
            modelBuilder.Entity<Tax>().HasData(
                new Tax { TaxId = 1, TaxRate = 10 },
                new Tax { TaxId = 2, TaxRate = 20 },
                new Tax { TaxId = 3, TaxRate = 30 }
            );

            //seeding Unit data
            modelBuilder.Entity<Unit>().HasData(
                new Unit { UnitId = 1, Name = "Unit 1" },
                new Unit { UnitId = 2, Name = "Unit 2" },
                new Unit { UnitId = 3, Name = "Unit 3" }
            );

            //seeding Product data
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ProductId = 1,
                    ProductUnitId = 1,
                    Name = "Product A",
                    MinStock = 10,
                    MaxStock = 100,
                    PackUnitType = "Box",
                    QuantityStock = 50,
                    QuantityPack = 1,
                    Barcode = "1234567890123",
                    PurchasePrice = 100.00m,
                    SalePrice1 = 150.00m,
                    SalePrice2 = 160.00m,
                    SalePrice3 = 170.00m,
                    ImageUrl = "https://example.com/productA.jpg",
                    CreatedBy = "Admin",
                    DateCreated = DateTime.Now,
                    ModifiedBy = "Admin",
                    DateModified = DateTime.Now,
                    IsActivate = true,
                    ShelfId = 1,
                    CategoryId = 1,
                    UnitId = 1,
                    TaxId = 1,
                    LineId = 1
                },
                new Product
                {
                    ProductId = 2,
                    ProductUnitId = 2,
                    Name = "Product B",
                    MinStock = 5,
                    MaxStock = 5,
                    PackUnitType = "Piece",
                    QuantityStock = 30,
                    QuantityPack = 1,
                    Barcode = "2234567890123",
                    PurchasePrice = 50.00m,
                    SalePrice1 = 70.00m,
                    SalePrice2 = 75.00m,
                    SalePrice3 = 80.00m,
                    ImageUrl = "https://example.com/productB.jpg",
                    CreatedBy = "Admin",
                    DateCreated = DateTime.Now,
                    ModifiedBy = "Admin",
                    DateModified = DateTime.Now,
                    IsActivate = true,
                    ShelfId = 2,
                    CategoryId = 2,
                    UnitId = 2,
                    TaxId = 2,
                    LineId = 2
                },
                new Product
                {
                    ProductId = 3,
                    ProductUnitId = 3,
                    Name = "Product C",
                    MinStock = 5,
                    MaxStock = 5,
                    PackUnitType = "Piece",
                    QuantityStock = 60,
                    QuantityPack = 1,
                    Barcode = "3234567890123",
                    PurchasePrice = 200.00m,
                    SalePrice1 = 250.00m,
                    SalePrice2 = 260.00m,
                    SalePrice3 = 270.00m,
                    ImageUrl = "https://example.com/productC.jpg",
                    CreatedBy = "Admin",
                    DateCreated = DateTime.Now,
                    ModifiedBy = "Admin",
                    DateModified = DateTime.Now,
                    IsActivate = true,
                    ShelfId = 3,
                    CategoryId = 3,
                    UnitId = 3,
                    TaxId = 3,
                    LineId = 3
                }
            );

            /*
            //seeding Location data 
            modelBuilder.Entity<Location>().HasData(
                new Location
                {
                    LocationId = 1,
                    Name = "Head Office",
                    PhoneNumber1 = "123456789",
                    PhoneNumber2 = "987654321",
                    Email = "headoffice@example.com",
                    Adresse = "123 Main Street",
                    City = "Metropolis",
                    Land = "Country A",
                    CreatedBy = "Admin",
                    DateCreated = DateTime.Now,
                    ModifiedBy = "Admin",
                    DateModified = DateTime.Now,
                    IsActivated = true
                },
                new Location
            {
                LocationId = 2,
                Name = "Branch Office",
                PhoneNumber1 = "1122334455",
                PhoneNumber2 = "5566778899",
                Email = "branchoffice@example.com",
                Adresse = "456 Side Street",
                City = "Gotham",
                Land = "Country B",
                CreatedBy = "Admin",
                DateCreated = DateTime.Now,
                ModifiedBy = "Admin",
                DateModified = DateTime.Now,
                IsActivated = true
            }
            );

            //seeding Employee data
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    EmployeeId = 1,
                    FirstName = "Admin",
                    LastName = "User",
                    //NameComplete = 
                    Role = "Administrator",
                    Phone = "123456789",
                    Email = "admin@example.com",
                    PasswordHash = "Admin@123", //BCrypt.Net.BCrypt.HashPassword("Admin@123"), 
                    // Utilisez une librairie de hachage
                },
                new Employee
                {
                    EmployeeId = 2,
                    FirstName = "John",
                    LastName = "Doe",
                    Role = "Cashier",
                    Phone = "987654321",
                    Email = "john.doe@example.com",
                    PasswordHash = "Password@123",
                    //BCrypt.Net.BCrypt.HashPassword("Password@123"),
                },
                new Employee
                {
                    EmployeeId = 3,
                    FirstName = "Jane",
                    LastName = "Smith",
                    Role = "Manager",
                    Phone = "1122334455",
                    Email = "jane.smith@example.com",
                    PasswordHash = "Manager@123",
                    //BCrypt.Net.BCrypt.HashPassword("Manager@123"),
                }
            );

            //seeding Customer Data
            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    CustomerId = 1,
                    Name = "John Doe",
                    CreditLimit = 1500m,
                    AccountBalance = 200m,
                    PhoneNumber1 = "1234567890",
                    PhoneNumber2 = "0987654321",
                    Email = "john.doe@example.com",
                    Adresse = "123 Main Street",
                    City = "Metropolis",
                    Land = "USA",
                    CreatedBy = "Admin",
                    DateCreated = DateTime.Now,
                    ModifiedBy = "Admin",
                    DateModified = DateTime.Now,
                    IsActivate = true
                },
                new Customer
                {
                    CustomerId = 2,
                    Name = "Jane Smith",
                    CreditLimit = 2000m,
                    AccountBalance = 0m,
                    PhoneNumber1 = "5551234567",
                    PhoneNumber2 = "5557654321",
                    Email = "jane.smith@example.com",
                    Adresse = "456 Elm Street",
                    City = "Gotham",
                    Land = "USA",
                    CreatedBy = "Admin",
                    DateCreated = DateTime.Now,
                    ModifiedBy = "Admin",
                    DateModified = DateTime.Now,
                    IsActivate = true
                }
    );

            //seeding Cash Register data
            modelBuilder.Entity<CashRegister>().HasData(
               new CashRegister
               {
                   CashRegisterId = 1,
                   Name = "Main Register",
                   IsActive = true,
                   LocationId = 1,
                   EmployeeId = 1
               },
               new CashRegister
               {
                   CashRegisterId = 2,
                   Name = "Secondary Register",
                   IsActive = true,
                   LocationId = 2,
                   EmployeeId = 2
               }
            );

            //seeding CashShift Data 
            modelBuilder.Entity<CashShift>().HasData(
                new CashShift
                {
                    CashShiftId = 1,
                    ShiftDate = DateTime.UtcNow.Date,
                    ShiftStart = DateTime.UtcNow,
                    OpeningBalance = 1000m,
                    ClosingBalance = 1200m,
                    TotalSales = 1500m,
                    TotalRefunds = 100m,
                    CashIn = 200m,
                    CashOut = 100m,
                    CashRegisterId = 1,  // Make sure you have a CashRegister with Id 1 in the seed data
                    EmployeeId = 1       // Make sure you have an Employee with Id 1 in the seed data
                },
                new CashShift
                {
                    CashShiftId = 2,
                    ShiftDate = DateTime.UtcNow.Date.AddDays(1),
                    ShiftStart = DateTime.UtcNow.AddDays(1),
                    OpeningBalance = 1100m,
                    ClosingBalance = 1300m,
                    TotalSales = 1600m,
                    TotalRefunds = 200m,
                    CashIn = 300m,
                    CashOut = 50m,
                    CashRegisterId = 2,  // Make sure you have a CashRegister with Id 2 in the seed data
                    EmployeeId = 2       // Make sure you have an Employee with Id 2 in the seed data
                }
            );

            // Seed CashTransaction data
            modelBuilder.Entity<CashTransaction>().HasData(
                new CashTransaction
                {
                    CashTransactionId = 1,
                    CashShiftId = 1, // Ensure CashShiftId 1 exists in the CashShift table
                    TransactionType = "Sale",
                    Amount = 150.00m,
                    TransactionTime = DateTime.UtcNow,
                    Description = "Product Sale Transaction"
                },
                new CashTransaction
                {
                    CashTransactionId = 2,
                    CashShiftId = 1,
                    TransactionType = "Refund",
                    Amount = -20.00m,
                    TransactionTime = DateTime.UtcNow.AddMinutes(-30),
                    Description = "Refund for Product X"
                },
                new CashTransaction
                {
                    CashTransactionId = 3,
                    CashShiftId = 2, // Ensure CashShiftId 2 exists in the CashShift table
                    TransactionType = "Cash Deposit",
                    Amount = 500.00m,
                    TransactionTime = DateTime.UtcNow.AddHours(-1),
                    Description = "Deposit of additional cash"
                }
            );
            
            // Seed Inventory data
            modelBuilder.Entity<Inventory>().HasData(
                new Inventory
                {
                    InventoryId = 1,
                    Quantity = 50,
                    CreatedBy = "Admin",
                    DateCreated = DateTime.Now,
                    ModifiedBy = "Admin",
                    DateModified = DateTime.Now,
                    LocationId = 1,
                    ProductId = 1
                },
                new Inventory
                {
                    InventoryId = 2,
                    Quantity = 20,
                    CreatedBy = "Admin",
                    DateCreated = DateTime.Now,
                    ModifiedBy = "Admin",
                    DateModified = DateTime.Now,
                    LocationId = 2,
                    ProductId = 2
                }
            );

            //Seed Inventory Mouvement Data
            modelBuilder.Entity<InventoryMouvement>().HasData(
                new InventoryMouvement
                {
                    InventoryMouvementId = 1,
                    ProductId = 1,
                    LocationId = 1,
                    MouvementType = MouvementType.Purchase,
                    Quantity = 100,
                    MouvementDate = DateTime.Now
                },
                new InventoryMouvement
                {
                    InventoryMouvementId = 2,
                    ProductId = 1,
                    LocationId = 1,
                    MouvementType = MouvementType.Sale,
                    Quantity = 10,
                    MouvementDate = DateTime.Now
                },
                new InventoryMouvement
                {
                    InventoryMouvementId = 3,
                    ProductId = 1,
                    LocationId = 1,
                    MouvementType = MouvementType.Return,
                    Quantity = 10,
                    MouvementDate = DateTime.Now
                }
            );

            //seed Product Batch Data
            modelBuilder.Entity<ProductBatch>().HasData(
               new ProductBatch
               {
                   ProductBatchId = 1,
                   BatchNumber = "BATCH001",
                   Quantity = 100,
                   ExpirationDate = DateTime.UtcNow.AddMonths(6), // 6 months from now
                   ReceivedDate = DateTime.UtcNow.AddDays(-10), // Received 10 days ago
                   ProductId = 1 // Assume a Product with ID 1 exists
               },
               new ProductBatch
               {
                   ProductBatchId = 2,
                   BatchNumber = "BATCH002",
                   Quantity = 200,
                   ExpirationDate = DateTime.UtcNow.AddMonths(12), // 1 year from now
                   ReceivedDate = DateTime.UtcNow.AddDays(-20), // Received 20 days ago
                   ProductId = 2 // Assume a Product with ID 2 exists
               },
               new ProductBatch
               {
                   ProductBatchId = 3,
                   BatchNumber = "BATCH003",
                   Quantity = 50,
                   ExpirationDate = null, // No expiration date (optional)
                   ReceivedDate = DateTime.UtcNow.AddDays(-5), // Received 5 days ago
                   ProductId = 1 // Another batch for Product ID 1
               }
           );

            //seed Purchase Data
            modelBuilder.Entity<Purchase>().HasData(
                new Purchase
                {
                    PurchaseId = 1,
                    PurchaseDate = DateTime.UtcNow.AddDays(-10), // 10 days ago
                    TvaAmount = 50.00m, // Example TVA amount
                    TotalAmount = 550.00m, // Total amount for the purchase
                    AmountPaid = 300.00m, // Amount paid
                    SupplierId = 1, // Assume a Supplier with ID 1 exists
                    EmployeeId = 1 // Assume an Employee with ID 1 exists
                },
                new Purchase
                {
                    PurchaseId = 2,
                    PurchaseDate = DateTime.UtcNow.AddDays(-5), // 5 days ago
                    TvaAmount = 75.00m, // Example TVA amount
                    TotalAmount = 750.00m, // Total amount for the purchase
                    AmountPaid = 750.00m, // Fully paid
                    SupplierId = 2, // Assume a Supplier with ID 2 exists
                    EmployeeId = 2 // Assume an Employee with ID 2 exists
                },
                new Purchase
                {
                    PurchaseId = 3,
                    PurchaseDate = DateTime.UtcNow, // Today
                    TvaAmount = 25.00m, // Example TVA amount
                    TotalAmount = 325.00m, // Total amount for the purchase
                    AmountPaid = 150.00m, // Partially paid
                    SupplierId = 1, // Assume a Supplier with ID 1 exists
                    EmployeeId = 3 // Assume an Employee with ID 3 exists
                },
                new Purchase
                {
                    PurchaseId = 4,
                    PurchaseDate = DateTime.UtcNow, // Today
                    TvaAmount = 25.00m, // Example TVA amount
                    TotalAmount = 325.00m, // Total amount for the purchase
                    AmountPaid = 150.00m, // Partially paid
                    SupplierId = 1, // Assume a Supplier with ID 1 exists
                    EmployeeId = 3 // Assume an Employee with ID 3 exists
                },
                new Purchase
                {
                    PurchaseId = 5,
                    PurchaseDate = DateTime.UtcNow, // Today
                    TvaAmount = 25.00m, // Example TVA amount
                    TotalAmount = 325.00m, // Total amount for the purchase
                    AmountPaid = 150.00m, // Partially paid
                    SupplierId = 1, // Assume a Supplier with ID 1 exists
                    EmployeeId = 3 // Assume an Employee with ID 3 exists
                },
                new Purchase
                {
                    PurchaseId = 6,
                    PurchaseDate = DateTime.UtcNow, // Today
                    TvaAmount = 25.00m, // Example TVA amount
                    TotalAmount = 325.00m, // Total amount for the purchase
                    AmountPaid = 150.00m, // Partially paid
                    SupplierId = 1, // Assume a Supplier with ID 1 exists
                    EmployeeId = 3 // Assume an Employee with ID 3 exists
                },
                new Purchase
                {
                    PurchaseId = 7,
                    PurchaseDate = DateTime.UtcNow, // Today
                    TvaAmount = 25.00m, // Example TVA amount
                    TotalAmount = 325.00m, // Total amount for the purchase
                    AmountPaid = 150.00m, // Partially paid
                    SupplierId = 1, // Assume a Supplier with ID 1 exists
                    EmployeeId = 3 // Assume an Employee with ID 3 exists
                },
                new Purchase
                {
                    PurchaseId = 8,
                    PurchaseDate = DateTime.UtcNow, // Today
                    TvaAmount = 25.00m, // Example TVA amount
                    TotalAmount = 325.00m, // Total amount for the purchase
                    AmountPaid = 150.00m, // Partially paid
                    SupplierId = 1, // Assume a Supplier with ID 1 exists
                    EmployeeId = 3 // Assume an Employee with ID 3 exists
                },
                new Purchase
                {
                    PurchaseId = 9,
                    PurchaseDate = DateTime.UtcNow, // Today
                    TvaAmount = 25.00m, // Example TVA amount
                    TotalAmount = 325.00m, // Total amount for the purchase
                    AmountPaid = 150.00m, // Partially paid
                    SupplierId = 1, // Assume a Supplier with ID 1 exists
                    EmployeeId = 3 // Assume an Employee with ID 3 exists
                },
                new Purchase
                {
                    PurchaseId = 10,
                    PurchaseDate = DateTime.UtcNow, // Today
                    TvaAmount = 25.00m, // Example TVA amount
                    TotalAmount = 325.00m, // Total amount for the purchase
                    AmountPaid = 150.00m, // Partially paid
                    SupplierId = 1, // Assume a Supplier with ID 1 exists
                    EmployeeId = 3 // Assume an Employee with ID 3 exists
                }
            );

            //seed Purchase Item Data
            modelBuilder.Entity<PurchaseItem>().HasData(
                new PurchaseItem
                {
                    PurchaseItemId = 1,
                    PurchaseId = 1, // Assuming a Purchase with ID 1 exists
                    ProductId = 1,  // Assuming a Product with ID 1 exists
                    Quantity = 10,
                    Price = 20.00m,
                    Discount = 2.00m,
                    TaxAmount = 1.80m,
                    Total = (10 * 20.00m) - 2.00m + 1.80m
                },
                new PurchaseItem
                {
                    PurchaseItemId = 2,
                    PurchaseId = 1, // Same Purchase as above
                    ProductId = 2,  // Assuming a Product with ID 2 exists
                    Quantity = 5,
                    Price = 50.00m,
                    Discount = 0m,
                    TaxAmount = 5.00m,
                    Total = (5 * 50.00m) + 5.00m
                },
                new PurchaseItem
                {
                    PurchaseItemId = 3,
                    PurchaseId = 2, // Assuming a Purchase with ID 2 exists
                    ProductId = 3,  // Assuming a Product with ID 3 exists
                    Quantity = 20,
                    Price = 15.00m,
                    Discount = 5.00m,
                    TaxAmount = 4.50m,
                    Total = (20 * 15.00m) - 5.00m + 4.50m
                }
            );

            //seed Purchase Payments data
            modelBuilder.Entity<PurchasePayment>().HasData(
               new PurchasePayment
               {
                   PurchasePaymentId = 1,
                   PurchaseId = 1,
                   PaymentDate = new DateTime(2024, 1, 1),
                   Amount = 500.00m,
                   PaymentType = "CreditCard"
               },
               new PurchasePayment
               {
                   PurchasePaymentId = 2,
                   PurchaseId = 2,
                   PaymentDate = new DateTime(2024, 1, 2),
                   Amount = 750.00m,
                   PaymentType = "Cash"
               },
               new PurchasePayment
               {
                   PurchasePaymentId = 3,
                   PurchaseId = 3,
                   PaymentDate = new DateTime(2024, 1, 3),
                   Amount = 1000.00m,
                   PaymentType = "BankTransfer"
               },
               new PurchasePayment
               {
                   PurchasePaymentId = 4,
                   PurchaseId = 4,
                   PaymentDate = new DateTime(2024, 1, 4),
                   Amount = 1250.00m,
                   PaymentType = "CreditCard"
               },
               new PurchasePayment
               {
                   PurchasePaymentId = 5,
                   PurchaseId = 5,
                   PaymentDate = new DateTime(2024, 1, 5),
                   Amount = 1500.00m,
                   PaymentType = "Cash"
               },
               new PurchasePayment
               {
                   PurchasePaymentId = 6,
                   PurchaseId = 6,
                   PaymentDate = new DateTime(2024, 1, 6),
                   Amount = 1750.00m,
                   PaymentType = "BankTransfer"
               },
               new PurchasePayment
               {
                   PurchasePaymentId = 7,
                   PurchaseId = 7,
                   PaymentDate = new DateTime(2024, 1, 7),
                   Amount = 2000.00m,
                   PaymentType = "CreditCard"
               },
               new PurchasePayment
               {
                   PurchasePaymentId = 8,
                   PurchaseId = 8,
                   PaymentDate = new DateTime(2024, 1, 8),
                   Amount = 2250.00m,
                   PaymentType = "Cash"
               },
               new PurchasePayment
               {
                   PurchasePaymentId = 9,
                   PurchaseId = 9,
                   PaymentDate = new DateTime(2024, 1, 9),
                   Amount = 2500.00m,
                   PaymentType = "BankTransfer"
               },
               new PurchasePayment
               {
                   PurchasePaymentId = 10,
                   PurchaseId = 10,
                   PaymentDate = new DateTime(2024, 1, 10),
                   Amount = 2750.00m,
                   PaymentType = "CreditCard"
               }
           );

            //seed Sale data
            modelBuilder.Entity<Sale>().HasData(
                new Sale
                {
                    SaleId = 1,
                    SaleDate = new DateTime(2024, 1, 1),
                    CustomerId = 1,
                    EmployeeId = 1,
                    TvaAmount = 20.00m,
                    TotalAmount = 120.00m,
                    AmountPaid = 100.00m
                },
                new Sale
                {
                    SaleId = 2,
                    SaleDate = new DateTime(2024, 1, 2),
                    CustomerId = 1,
                    EmployeeId = 1,
                    TvaAmount = 30.00m,
                    TotalAmount = 150.00m,
                    AmountPaid = 120.00m
                },
                new Sale
                {
                    SaleId = 3,
                    SaleDate = new DateTime(2024, 1, 3),
                    CustomerId = 1,
                    EmployeeId = 1,
                    TvaAmount = 25.00m,
                    TotalAmount = 200.00m,
                    AmountPaid = 150.00m
                },
                new Sale
                {
                    SaleId = 4,
                    SaleDate = new DateTime(2024, 1, 4),
                    CustomerId = 1,
                    EmployeeId = 1,
                    TvaAmount = 15.00m,
                    TotalAmount = 100.00m,
                    AmountPaid = 50.00m
                },
                new Sale
                {
                    SaleId = 5,
                    SaleDate = new DateTime(2024, 1, 5),
                    CustomerId = 1,
                    EmployeeId = 1,
                    TvaAmount = 50.00m,
                    TotalAmount = 300.00m,
                    AmountPaid = 200.00m
                },
                new Sale
                {
                    SaleId = 6,
                    SaleDate = new DateTime(2024, 1, 6),
                    CustomerId = 1,
                    EmployeeId = 1,
                    TvaAmount = 10.00m,
                    TotalAmount = 50.00m,
                    AmountPaid = 30.00m
                },
                new Sale
                {
                    SaleId = 7,
                    SaleDate = new DateTime(2024, 1, 7),
                    CustomerId = 1,
                    EmployeeId = 1,
                    TvaAmount = 40.00m,
                    TotalAmount = 250.00m,
                    AmountPaid = 180.00m
                },
                new Sale
                {
                    SaleId = 8,
                    SaleDate = new DateTime(2024, 1, 8),
                    CustomerId = 1,
                    EmployeeId = 1,
                    TvaAmount = 35.00m,
                    TotalAmount = 220.00m,
                    AmountPaid = 200.00m
                },
                new Sale
                {
                    SaleId = 9,
                    SaleDate = new DateTime(2024, 1, 9),
                    CustomerId = 1,
                    EmployeeId = 1,
                    TvaAmount = 45.00m,
                    TotalAmount = 270.00m,
                    AmountPaid = 230.00m
                },
                new Sale
                {
                    SaleId = 10,
                    SaleDate = new DateTime(2024, 1, 10),
                    CustomerId = 1,
                    EmployeeId = 1,
                    TvaAmount = 60.00m,
                    TotalAmount = 320.00m,
                    AmountPaid = 300.00m
                }
            );

            //seed saleItem data
            modelBuilder.Entity<SaleItem>().HasData(
                new SaleItem
                {
                    SaleItemId = 1,
                    SaleId = 1,
                    ProductId = 1,
                    Quantity = 2,
                    Price = 50.00m,
                    Discount = 5.00m,
                    TaxAmount = 2.50m,
                    Total = 97.50m // (Quantity * Price - Discount + TaxAmount)
                },
                new SaleItem
                {
                    SaleItemId = 2,
                    SaleId = 1,
                    ProductId = 1,
                    Quantity = 1,
                    Price = 100.00m,
                    Discount = 10.00m,
                    TaxAmount = 5.00m,
                    Total = 95.00m
                },
                new SaleItem
                {
                    SaleItemId = 3,
                    SaleId = 2,
                    ProductId = 2,
                    Quantity = 3,
                    Price = 30.00m,
                    Discount = 0.00m,
                    TaxAmount = 4.50m,
                    Total = 94.50m
                },
                new SaleItem
                {
                    SaleItemId = 4,
                    SaleId = 2,
                    ProductId = 2,
                    Quantity = 5,
                    Price = 20.00m,
                    Discount = 10.00m,
                    TaxAmount = 2.00m,
                    Total = 92.00m
                },
                new SaleItem
                {
                    SaleItemId = 5,
                    SaleId = 3,
                    ProductId = 1,
                    Quantity = 1,
                    Price = 200.00m,
                    Discount = 20.00m,
                    TaxAmount = 10.00m,
                    Total = 190.00m
                },
                new SaleItem
                {
                    SaleItemId = 6,
                    SaleId = 3,
                    ProductId = 1,
                    Quantity = 2,
                    Price = 150.00m,
                    Discount = 15.00m,
                    TaxAmount = 12.00m,
                    Total = 297.00m
                },
                new SaleItem
                {
                    SaleItemId = 7,
                    SaleId = 4,
                    ProductId = 1,
                    Quantity = 4,
                    Price = 25.00m,
                    Discount = 5.00m,
                    TaxAmount = 5.00m,
                    Total = 105.00m
                },
                new SaleItem
                {
                    SaleItemId = 8,
                    SaleId = 4,
                    ProductId = 1,
                    Quantity = 6,
                    Price = 10.00m,
                    Discount = 0.00m,
                    TaxAmount = 3.00m,
                    Total = 63.00m
                },
                new SaleItem
                {
                    SaleItemId = 9,
                    SaleId = 5,
                    ProductId = 1,
                    Quantity = 10,
                    Price = 15.00m,
                    Discount = 10.00m,
                    TaxAmount = 5.00m,
                    Total = 150.00m
                },
                new SaleItem
                {
                    SaleItemId = 10,
                    SaleId = 5,
                    ProductId = 1,
                    Quantity = 1,
                    Price = 300.00m,
                    Discount = 20.00m,
                    TaxAmount = 15.00m,
                    Total = 295.00m
                }
            );

            //seed SalePayment
            modelBuilder.Entity<SalePayment>().HasData(
                new SalePayment
                {
                    SalePaymentId = 1,
                    SaleId = 1,
                    PaymentDate = DateTime.UtcNow.AddDays(-10),
                    Amount = 100.00m,
                    PaymentType = "CASH"
                },
                new SalePayment
                {
                    SalePaymentId = 2,
                    SaleId = 1,
                    PaymentDate = DateTime.UtcNow.AddDays(-5),
                    Amount = 50.00m,
                    PaymentType = "PARTIAL_PAYMENT"
                },
                new SalePayment
                {
                    SalePaymentId = 3,
                    SaleId = 2,
                    PaymentDate = DateTime.UtcNow.AddDays(-7),
                    Amount = 200.00m,
                    PaymentType = "CREDIT"
                },
                new SalePayment
                {
                    SalePaymentId = 4,
                    SaleId = 2,
                    PaymentDate = DateTime.UtcNow.AddDays(-3),
                    Amount = 100.00m,
                    PaymentType = "CASH"
                },
                new SalePayment
                {
                    SalePaymentId = 5,
                    SaleId = 3,
                    PaymentDate = DateTime.UtcNow.AddDays(-2),
                    Amount = 300.00m,
                    PaymentType = "CASH"
                },
                new SalePayment
                {
                    SalePaymentId = 6,
                    SaleId = 3,
                    PaymentDate = DateTime.UtcNow.AddDays(-1),
                    Amount = 150.00m,
                    PaymentType = "PARTIAL_PAYMENT"
                },
                new SalePayment
                {
                    SalePaymentId = 7,
                    SaleId = 4,
                    PaymentDate = DateTime.UtcNow.AddDays(-15),
                    Amount = 120.00m,
                    PaymentType = "CREDIT"
                },
                new SalePayment
                {
                    SalePaymentId = 8,
                    SaleId = 4,
                    PaymentDate = DateTime.UtcNow.AddDays(-10),
                    Amount = 80.00m,
                    PaymentType = "CASH"
                },
                new SalePayment
                {
                    SalePaymentId = 9,
                    SaleId = 5,
                    PaymentDate = DateTime.UtcNow.AddDays(-8),
                    Amount = 200.00m,
                    PaymentType = "CREDIT"
                },
                new SalePayment
                {
                    SalePaymentId = 10,
                    SaleId = 5,
                    PaymentDate = DateTime.UtcNow,
                    Amount = 100.00m,
                    PaymentType = "PARTIAL_PAYMENT"
                }
            );
            */
        }
    }
}
