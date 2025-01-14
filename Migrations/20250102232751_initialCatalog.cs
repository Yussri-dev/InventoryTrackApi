using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InventoryTrackApi.Migrations
{
    /// <inheritdoc />
    public partial class initialCatalog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreditLimit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AccountBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PhoneNumber1 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    PhoneNumber2 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Land = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActivate = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "Lines",
                columns: table => new
                {
                    LineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lines", x => x.LineId);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber1 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    PhoneNumber2 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Land = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActivated = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationId);
                });

            migrationBuilder.CreateTable(
                name: "Shelfs",
                columns: table => new
                {
                    ShelfId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shelfs", x => x.ShelfId);
                });

            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    SupplierId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber1 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    PhoneNumber2 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Land = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActivate = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.SupplierId);
                });

            migrationBuilder.CreateTable(
                name: "Taxes",
                columns: table => new
                {
                    TaxId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaxRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taxes", x => x.TaxId);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    UnitId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.UnitId);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    SaleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SaleDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    TvaAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AmountPaid = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DiscountPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.SaleId);
                    table.ForeignKey(
                        name: "FK_Sales_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sales_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CashRegisters",
                columns: table => new
                {
                    CashRegisterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    CashRegisterId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashRegisters", x => x.CashRegisterId);
                    table.ForeignKey(
                        name: "FK_CashRegisters_CashRegisters_CashRegisterId1",
                        column: x => x.CashRegisterId1,
                        principalTable: "CashRegisters",
                        principalColumn: "CashRegisterId");
                    table.ForeignKey(
                        name: "FK_CashRegisters_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CashRegisters_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InventoryMouvements",
                columns: table => new
                {
                    InventoryMouvementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    MouvementType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MouvementDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryMouvements", x => x.InventoryMouvementId);
                    table.ForeignKey(
                        name: "FK_InventoryMouvements_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Purchases",
                columns: table => new
                {
                    PurchaseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TvaAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AmountPaid = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchases", x => x.PurchaseId);
                    table.ForeignKey(
                        name: "FK_Purchases_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Purchases_Supplier_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Supplier",
                        principalColumn: "SupplierId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductUnitId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    MinStock = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaxStock = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PackUnitType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuantityStock = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QuantityPack = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Barcode = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    PurchasePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SalePrice1 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SalePrice2 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SalePrice3 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActivate = table.Column<bool>(type: "bit", nullable: false),
                    DiscountPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsSecondItemDiscountEligible = table.Column<bool>(type: "bit", nullable: false),
                    IsBuyThreeForFiveEligible = table.Column<bool>(type: "bit", nullable: false),
                    ShelfId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    UnitId = table.Column<int>(type: "int", nullable: false),
                    TaxId = table.Column<int>(type: "int", nullable: false),
                    LineId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Lines_LineId",
                        column: x => x.LineId,
                        principalTable: "Lines",
                        principalColumn: "LineId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Shelfs_ShelfId",
                        column: x => x.ShelfId,
                        principalTable: "Shelfs",
                        principalColumn: "ShelfId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Taxes_TaxId",
                        column: x => x.TaxId,
                        principalTable: "Taxes",
                        principalColumn: "TaxId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "UnitId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalePayments",
                columns: table => new
                {
                    SalePaymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SaleId = table.Column<int>(type: "int", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalePayments", x => x.SalePaymentId);
                    table.ForeignKey(
                        name: "FK_SalePayments_Sales_SaleId",
                        column: x => x.SaleId,
                        principalTable: "Sales",
                        principalColumn: "SaleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CashShifts",
                columns: table => new
                {
                    CashShiftId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShiftDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShiftStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShiftEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OpeningBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ClosingBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalSales = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalRefunds = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CashIn = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CashOut = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CashRegisterId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashShifts", x => x.CashShiftId);
                    table.ForeignKey(
                        name: "FK_CashShifts_CashRegisters_CashRegisterId",
                        column: x => x.CashRegisterId,
                        principalTable: "CashRegisters",
                        principalColumn: "CashRegisterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CashShifts_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId");
                });

            migrationBuilder.CreateTable(
                name: "purchasePayments",
                columns: table => new
                {
                    PurchasePaymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseId = table.Column<int>(type: "int", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_purchasePayments", x => x.PurchasePaymentId);
                    table.ForeignKey(
                        name: "FK_purchasePayments_Purchases_PurchaseId",
                        column: x => x.PurchaseId,
                        principalTable: "Purchases",
                        principalColumn: "PurchaseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    InventoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.InventoryId);
                    table.ForeignKey(
                        name: "FK_Inventory_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inventory_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InventoryMouvementProduct",
                columns: table => new
                {
                    InventoryMouvementsInventoryMouvementId = table.Column<int>(type: "int", nullable: false),
                    ProductsProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryMouvementProduct", x => new { x.InventoryMouvementsInventoryMouvementId, x.ProductsProductId });
                    table.ForeignKey(
                        name: "FK_InventoryMouvementProduct_InventoryMouvements_InventoryMouvementsInventoryMouvementId",
                        column: x => x.InventoryMouvementsInventoryMouvementId,
                        principalTable: "InventoryMouvements",
                        principalColumn: "InventoryMouvementId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InventoryMouvementProduct_Products_ProductsProductId",
                        column: x => x.ProductsProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductBatchs",
                columns: table => new
                {
                    ProductBatchId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BatchNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReceivedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductBatchs", x => x.ProductBatchId);
                    table.ForeignKey(
                        name: "FK_ProductBatchs_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseItems",
                columns: table => new
                {
                    PurchaseItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TaxAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseItems", x => x.PurchaseItemId);
                    table.ForeignKey(
                        name: "FK_PurchaseItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseItems_Purchases_PurchaseId",
                        column: x => x.PurchaseId,
                        principalTable: "Purchases",
                        principalColumn: "PurchaseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SaleItems",
                columns: table => new
                {
                    SaleItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SaleId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TaxAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TaxId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleItems", x => x.SaleItemId);
                    table.ForeignKey(
                        name: "FK_SaleItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SaleItems_Sales_SaleId",
                        column: x => x.SaleId,
                        principalTable: "Sales",
                        principalColumn: "SaleId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SaleItems_Taxes_TaxId",
                        column: x => x.TaxId,
                        principalTable: "Taxes",
                        principalColumn: "TaxId");
                });

            migrationBuilder.CreateTable(
                name: "CashTransactions",
                columns: table => new
                {
                    CashTransactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CashShiftId = table.Column<int>(type: "int", nullable: false),
                    TransactionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TransactionTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashTransactions", x => x.CashTransactionId);
                    table.ForeignKey(
                        name: "FK_CashTransactions_CashShifts_CashShiftId",
                        column: x => x.CashShiftId,
                        principalTable: "CashShifts",
                        principalColumn: "CashShiftId");
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, "Electronics" },
                    { 2, "Clothing" },
                    { 3, "Groceries" },
                    { 4, "Furniture" },
                    { 5, "Books" },
                    { 6, "Sacs" },
                    { 7, "Data" },
                    { 8, "Bread" },
                    { 9, "Jacket" },
                    { 10, "T-Shirts" },
                    { 11, "Jeans" },
                    { 12, "Mobile" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "AccountBalance", "Adresse", "City", "CreatedBy", "CreditLimit", "DateCreated", "DateModified", "Email", "IsActivate", "Land", "ModifiedBy", "Name", "PhoneNumber1", "PhoneNumber2" },
                values: new object[,]
                {
                    { 1, 200m, "123 Main Street", "Metropolis", "Admin", 1500m, new DateTime(2025, 1, 3, 0, 27, 46, 933, DateTimeKind.Local).AddTicks(6574), new DateTime(2025, 1, 3, 0, 27, 46, 933, DateTimeKind.Local).AddTicks(7261), "john.doe@example.com", true, "USA", "Admin", "John Doe", "1234567890", "0987654321" },
                    { 2, 0m, "456 Elm Street", "Gotham", "Admin", 2000m, new DateTime(2025, 1, 3, 0, 27, 46, 933, DateTimeKind.Local).AddTicks(8400), new DateTime(2025, 1, 3, 0, 27, 46, 933, DateTimeKind.Local).AddTicks(8405), "jane.smith@example.com", true, "USA", "Admin", "Jane Smith", "5551234567", "5557654321" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Email", "FirstName", "LastName", "PasswordHash", "Phone", "Role" },
                values: new object[,]
                {
                    { 1, "admin@example.com", "Admin", "User", "Admin@123", "123456789", "Administrator" },
                    { 2, "john.doe@example.com", "John", "Doe", "Password@123", "987654321", "Cashier" },
                    { 3, "jane.smith@example.com", "Jane", "Smith", "Manager@123", "1122334455", "Manager" }
                });

            migrationBuilder.InsertData(
                table: "Lines",
                columns: new[] { "LineId", "Name" },
                values: new object[,]
                {
                    { 1, "Electronics Line" },
                    { 2, "Clothing Line" },
                    { 3, "Grocery Line" },
                    { 4, "Furniture Line" },
                    { 5, "Toys Line" }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "LocationId", "Adresse", "City", "CreatedBy", "DateCreated", "DateModified", "Email", "IsActivated", "Land", "ModifiedBy", "Name", "PhoneNumber1", "PhoneNumber2" },
                values: new object[,]
                {
                    { 1, "123 Main Street", "Metropolis", "Admin", new DateTime(2025, 1, 3, 0, 27, 46, 932, DateTimeKind.Local).AddTicks(2363), new DateTime(2025, 1, 3, 0, 27, 46, 932, DateTimeKind.Local).AddTicks(2891), "headoffice@example.com", true, "Country A", "Admin", "Head Office", "123456789", "987654321" },
                    { 2, "456 Side Street", "Gotham", "Admin", new DateTime(2025, 1, 3, 0, 27, 46, 932, DateTimeKind.Local).AddTicks(3421), new DateTime(2025, 1, 3, 0, 27, 46, 932, DateTimeKind.Local).AddTicks(3423), "branchoffice@example.com", true, "Country B", "Admin", "Branch Office", "1122334455", "5566778899" }
                });

            migrationBuilder.InsertData(
                table: "Shelfs",
                columns: new[] { "ShelfId", "Name" },
                values: new object[,]
                {
                    { 1, "Shelf 1" },
                    { 2, "Shelf 2" },
                    { 3, "Shelf 3" }
                });

            migrationBuilder.InsertData(
                table: "Supplier",
                columns: new[] { "SupplierId", "Adresse", "City", "CreatedBy", "DateCreated", "DateModified", "Email", "IsActivate", "Land", "ModifiedBy", "Name", "PhoneNumber1", "PhoneNumber2" },
                values: new object[,]
                {
                    { 1, "123 Supplier Street", "City A", "Admin", new DateTime(2025, 1, 3, 0, 27, 46, 929, DateTimeKind.Local).AddTicks(6173), new DateTime(2025, 1, 3, 0, 27, 46, 929, DateTimeKind.Local).AddTicks(6763), "supplierA@example.com", true, "Country A", "Admin", "Supplier A", "1111111111", "2222222222" },
                    { 2, "456 Another Street", "City B", "Admin", new DateTime(2025, 1, 3, 0, 27, 46, 929, DateTimeKind.Local).AddTicks(7319), new DateTime(2025, 1, 3, 0, 27, 46, 929, DateTimeKind.Local).AddTicks(7322), "supplierB@example.com", true, "Country B", "Admin", "Supplier B", "3333333333", "4444444444" },
                    { 3, "789 Third Avenue", "City C", "Admin", new DateTime(2025, 1, 3, 0, 27, 46, 929, DateTimeKind.Local).AddTicks(7329), new DateTime(2025, 1, 3, 0, 27, 46, 929, DateTimeKind.Local).AddTicks(7331), "supplierC@example.com", false, "Country C", "Admin", "Supplier C", "5555555555", "6666666666" },
                    { 4, "1011 Fourth Avenue", "City D", "Admin", new DateTime(2025, 1, 3, 0, 27, 46, 929, DateTimeKind.Local).AddTicks(7339), new DateTime(2025, 1, 3, 0, 27, 46, 929, DateTimeKind.Local).AddTicks(7341), "supplierD@example.com", true, "Country D", "Admin", "Supplier D", "7777777777", "8888888888" },
                    { 5, "1213 Fifth Street", "City E", "Admin", new DateTime(2025, 1, 3, 0, 27, 46, 929, DateTimeKind.Local).AddTicks(7348), new DateTime(2025, 1, 3, 0, 27, 46, 929, DateTimeKind.Local).AddTicks(7350), "supplierE@example.com", false, "Country E", "Admin", "Supplier E", "9999999999", "1212121212" },
                    { 6, "1415 Sixth Lane", "City F", "Admin", new DateTime(2025, 1, 3, 0, 27, 46, 929, DateTimeKind.Local).AddTicks(7356), new DateTime(2025, 1, 3, 0, 27, 46, 929, DateTimeKind.Local).AddTicks(7358), "supplierF@example.com", true, "Country F", "Admin", "Supplier F", "3434343434", "5656565656" },
                    { 7, "1617 Seventh Road", "City G", "Admin", new DateTime(2025, 1, 3, 0, 27, 46, 929, DateTimeKind.Local).AddTicks(7365), new DateTime(2025, 1, 3, 0, 27, 46, 929, DateTimeKind.Local).AddTicks(7367), "supplierG@example.com", true, "Country G", "Admin", "Supplier G", "7878787878", "8989898989" },
                    { 8, "1819 Eighth Avenue", "City H", "Admin", new DateTime(2025, 1, 3, 0, 27, 46, 929, DateTimeKind.Local).AddTicks(7373), new DateTime(2025, 1, 3, 0, 27, 46, 929, DateTimeKind.Local).AddTicks(7406), "supplierH@example.com", false, "Country H", "Admin", "Supplier H", "2323232323", "4545454545" },
                    { 9, "2021 Ninth Boulevard", "City I", "Admin", new DateTime(2025, 1, 3, 0, 27, 46, 929, DateTimeKind.Local).AddTicks(7415), new DateTime(2025, 1, 3, 0, 27, 46, 929, DateTimeKind.Local).AddTicks(7417), "supplierI@example.com", true, "Country I", "Admin", "Supplier I", "6767676767", "8989898989" },
                    { 10, "2223 Tenth Parkway", "City J", "Admin", new DateTime(2025, 1, 3, 0, 27, 46, 929, DateTimeKind.Local).AddTicks(7423), new DateTime(2025, 1, 3, 0, 27, 46, 929, DateTimeKind.Local).AddTicks(7425), "supplierJ@example.com", true, "Country J", "Admin", "Supplier J", "1234123412", "5678567856" }
                });

            migrationBuilder.InsertData(
                table: "Taxes",
                columns: new[] { "TaxId", "TaxRate" },
                values: new object[,]
                {
                    { 1, 10m },
                    { 2, 20m },
                    { 3, 30m }
                });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "UnitId", "Name" },
                values: new object[,]
                {
                    { 1, "Unit 1" },
                    { 2, "Unit 2" },
                    { 3, "Unit 3" }
                });

            migrationBuilder.InsertData(
                table: "CashRegisters",
                columns: new[] { "CashRegisterId", "CashRegisterId1", "EmployeeId", "IsActive", "LocationId", "Name" },
                values: new object[,]
                {
                    { 1, null, 1, true, 1, "Main Register" },
                    { 2, null, 2, true, 2, "Secondary Register" }
                });

            migrationBuilder.InsertData(
                table: "InventoryMouvements",
                columns: new[] { "InventoryMouvementId", "LocationId", "MouvementDate", "MouvementType", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 1, 3, 0, 27, 46, 935, DateTimeKind.Local).AddTicks(7757), "Purchase", 1, 100m },
                    { 2, 1, new DateTime(2025, 1, 3, 0, 27, 46, 935, DateTimeKind.Local).AddTicks(8306), "Sale", 1, 10m },
                    { 3, 1, new DateTime(2025, 1, 3, 0, 27, 46, 935, DateTimeKind.Local).AddTicks(8358), "Return", 1, 10m }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Barcode", "CategoryId", "CreatedBy", "DateCreated", "DateModified", "DiscountPercentage", "ImageUrl", "IsActivate", "IsBuyThreeForFiveEligible", "IsSecondItemDiscountEligible", "LineId", "MaxStock", "MinStock", "ModifiedBy", "Name", "PackUnitType", "ProductUnitId", "PurchasePrice", "QuantityPack", "QuantityStock", "SalePrice1", "SalePrice2", "SalePrice3", "ShelfId", "TaxId", "UnitId" },
                values: new object[,]
                {
                    { 1, "1234567890123", 1, "Admin", new DateTime(2025, 1, 3, 0, 27, 46, 931, DateTimeKind.Local).AddTicks(6733), new DateTime(2025, 1, 3, 0, 27, 46, 931, DateTimeKind.Local).AddTicks(7263), 0m, "https://example.com/productA.jpg", true, false, false, 1, 100m, 10m, "Admin", "Product A", "Box", 1, 100.00m, 1m, 50m, 150.00m, 160.00m, 170.00m, 1, 1, 1 },
                    { 2, "2234567890123", 2, "Admin", new DateTime(2025, 1, 3, 0, 27, 46, 931, DateTimeKind.Local).AddTicks(8914), new DateTime(2025, 1, 3, 0, 27, 46, 931, DateTimeKind.Local).AddTicks(8917), 0m, "https://example.com/productB.jpg", true, false, false, 2, 5m, 5m, "Admin", "Product B", "Piece", 2, 50.00m, 1m, 30m, 70.00m, 75.00m, 80.00m, 2, 2, 2 },
                    { 3, "3234567890123", 3, "Admin", new DateTime(2025, 1, 3, 0, 27, 46, 931, DateTimeKind.Local).AddTicks(8960), new DateTime(2025, 1, 3, 0, 27, 46, 931, DateTimeKind.Local).AddTicks(8963), 0m, "https://example.com/productC.jpg", true, false, false, 3, 5m, 5m, "Admin", "Product C", "Piece", 3, 200.00m, 1m, 60m, 250.00m, 260.00m, 270.00m, 3, 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "PurchaseId", "AmountPaid", "EmployeeId", "PurchaseDate", "SupplierId", "TotalAmount", "TvaAmount" },
                values: new object[,]
                {
                    { 1, 300.00m, 1, new DateTime(2024, 12, 23, 23, 27, 46, 936, DateTimeKind.Utc).AddTicks(3495), 1, 550.00m, 50.00m },
                    { 2, 750.00m, 2, new DateTime(2024, 12, 28, 23, 27, 46, 936, DateTimeKind.Utc).AddTicks(5868), 2, 750.00m, 75.00m },
                    { 3, 150.00m, 3, new DateTime(2025, 1, 2, 23, 27, 46, 936, DateTimeKind.Utc).AddTicks(5874), 1, 325.00m, 25.00m },
                    { 4, 150.00m, 3, new DateTime(2025, 1, 2, 23, 27, 46, 936, DateTimeKind.Utc).AddTicks(5879), 1, 325.00m, 25.00m },
                    { 5, 150.00m, 3, new DateTime(2025, 1, 2, 23, 27, 46, 936, DateTimeKind.Utc).AddTicks(5882), 1, 325.00m, 25.00m },
                    { 6, 150.00m, 3, new DateTime(2025, 1, 2, 23, 27, 46, 936, DateTimeKind.Utc).AddTicks(5933), 1, 325.00m, 25.00m },
                    { 7, 150.00m, 3, new DateTime(2025, 1, 2, 23, 27, 46, 936, DateTimeKind.Utc).AddTicks(5937), 1, 325.00m, 25.00m },
                    { 8, 150.00m, 3, new DateTime(2025, 1, 2, 23, 27, 46, 936, DateTimeKind.Utc).AddTicks(5941), 1, 325.00m, 25.00m },
                    { 9, 150.00m, 3, new DateTime(2025, 1, 2, 23, 27, 46, 936, DateTimeKind.Utc).AddTicks(5945), 1, 325.00m, 25.00m },
                    { 10, 150.00m, 3, new DateTime(2025, 1, 2, 23, 27, 46, 936, DateTimeKind.Utc).AddTicks(5948), 1, 325.00m, 25.00m }
                });

            migrationBuilder.InsertData(
                table: "Sales",
                columns: new[] { "SaleId", "AmountPaid", "CustomerId", "DiscountPercentage", "EmployeeId", "SaleDate", "TotalAmount", "TvaAmount" },
                values: new object[,]
                {
                    { 1, 100.00m, 1, 0m, 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 120.00m, 20.00m },
                    { 2, 120.00m, 1, 0m, 1, new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 150.00m, 30.00m },
                    { 3, 150.00m, 1, 0m, 1, new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 200.00m, 25.00m },
                    { 4, 50.00m, 1, 0m, 1, new DateTime(2024, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 100.00m, 15.00m },
                    { 5, 200.00m, 1, 0m, 1, new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 300.00m, 50.00m },
                    { 6, 30.00m, 1, 0m, 1, new DateTime(2024, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 50.00m, 10.00m },
                    { 7, 180.00m, 1, 0m, 1, new DateTime(2024, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 250.00m, 40.00m },
                    { 8, 200.00m, 1, 0m, 1, new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 220.00m, 35.00m },
                    { 9, 230.00m, 1, 0m, 1, new DateTime(2024, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 270.00m, 45.00m },
                    { 10, 300.00m, 1, 0m, 1, new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 320.00m, 60.00m }
                });

            migrationBuilder.InsertData(
                table: "CashShifts",
                columns: new[] { "CashShiftId", "CashIn", "CashOut", "CashRegisterId", "ClosingBalance", "EmployeeId", "OpeningBalance", "ShiftDate", "ShiftEnd", "ShiftStart", "TotalRefunds", "TotalSales" },
                values: new object[,]
                {
                    { 1, 200m, 100m, 1, 1200m, 1, 1000m, new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2025, 1, 2, 23, 27, 46, 934, DateTimeKind.Utc).AddTicks(3763), 100m, 1500m },
                    { 2, 300m, 50m, 2, 1300m, 2, 1100m, new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2025, 1, 3, 23, 27, 46, 934, DateTimeKind.Utc).AddTicks(7034), 200m, 1600m }
                });

            migrationBuilder.InsertData(
                table: "Inventory",
                columns: new[] { "InventoryId", "CreatedBy", "DateCreated", "DateModified", "LocationId", "ModifiedBy", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { 1, "Admin", new DateTime(2025, 1, 3, 0, 27, 46, 935, DateTimeKind.Local).AddTicks(3778), new DateTime(2025, 1, 3, 0, 27, 46, 935, DateTimeKind.Local).AddTicks(4365), 1, "Admin", 1, 50m },
                    { 2, "Admin", new DateTime(2025, 1, 3, 0, 27, 46, 935, DateTimeKind.Local).AddTicks(5367), new DateTime(2025, 1, 3, 0, 27, 46, 935, DateTimeKind.Local).AddTicks(5371), 2, "Admin", 2, 20m }
                });

            migrationBuilder.InsertData(
                table: "ProductBatchs",
                columns: new[] { "ProductBatchId", "BatchNumber", "ExpirationDate", "ProductId", "Quantity", "ReceivedDate" },
                values: new object[,]
                {
                    { 1, "BATCH001", new DateTime(2025, 7, 2, 23, 27, 46, 936, DateTimeKind.Utc).AddTicks(877), 1, 100m, new DateTime(2024, 12, 23, 23, 27, 46, 936, DateTimeKind.Utc).AddTicks(1420) },
                    { 2, "BATCH002", new DateTime(2026, 1, 2, 23, 27, 46, 936, DateTimeKind.Utc).AddTicks(1993), 2, 200m, new DateTime(2024, 12, 13, 23, 27, 46, 936, DateTimeKind.Utc).AddTicks(1995) },
                    { 3, "BATCH003", null, 1, 50m, new DateTime(2024, 12, 28, 23, 27, 46, 936, DateTimeKind.Utc).AddTicks(1999) }
                });

            migrationBuilder.InsertData(
                table: "PurchaseItems",
                columns: new[] { "PurchaseItemId", "Discount", "Price", "ProductId", "PurchaseId", "Quantity", "TaxAmount", "Total" },
                values: new object[,]
                {
                    { 1, 2.00m, 20.00m, 1, 1, 10m, 1.80m, 199.80m },
                    { 2, 0m, 50.00m, 2, 1, 5m, 5.00m, 255.00m },
                    { 3, 5.00m, 15.00m, 3, 2, 20m, 4.50m, 299.50m }
                });

            migrationBuilder.InsertData(
                table: "SaleItems",
                columns: new[] { "SaleItemId", "Discount", "Price", "ProductId", "Quantity", "SaleId", "TaxAmount", "TaxId", "Total" },
                values: new object[,]
                {
                    { 1, 5.00m, 50.00m, 1, 2m, 1, 2.50m, null, 97.50m },
                    { 2, 10.00m, 100.00m, 1, 1m, 1, 5.00m, null, 95.00m },
                    { 3, 0.00m, 30.00m, 2, 3m, 2, 4.50m, null, 94.50m },
                    { 4, 10.00m, 20.00m, 2, 5m, 2, 2.00m, null, 92.00m },
                    { 5, 20.00m, 200.00m, 1, 1m, 3, 10.00m, null, 190.00m },
                    { 6, 15.00m, 150.00m, 1, 2m, 3, 12.00m, null, 297.00m },
                    { 7, 5.00m, 25.00m, 1, 4m, 4, 5.00m, null, 105.00m },
                    { 8, 0.00m, 10.00m, 1, 6m, 4, 3.00m, null, 63.00m },
                    { 9, 10.00m, 15.00m, 1, 10m, 5, 5.00m, null, 150.00m },
                    { 10, 20.00m, 300.00m, 1, 1m, 5, 15.00m, null, 295.00m }
                });

            migrationBuilder.InsertData(
                table: "SalePayments",
                columns: new[] { "SalePaymentId", "Amount", "PaymentDate", "PaymentType", "SaleId" },
                values: new object[,]
                {
                    { 1, 100.00m, new DateTime(2024, 12, 23, 23, 27, 46, 938, DateTimeKind.Utc).AddTicks(3576), "CASH", 1 },
                    { 2, 50.00m, new DateTime(2024, 12, 28, 23, 27, 46, 938, DateTimeKind.Utc).AddTicks(4984), "PARTIAL_PAYMENT", 1 },
                    { 3, 200.00m, new DateTime(2024, 12, 26, 23, 27, 46, 938, DateTimeKind.Utc).AddTicks(4988), "CREDIT", 2 },
                    { 4, 100.00m, new DateTime(2024, 12, 30, 23, 27, 46, 938, DateTimeKind.Utc).AddTicks(4991), "CASH", 2 },
                    { 5, 300.00m, new DateTime(2024, 12, 31, 23, 27, 46, 938, DateTimeKind.Utc).AddTicks(4993), "CASH", 3 },
                    { 6, 150.00m, new DateTime(2025, 1, 1, 23, 27, 46, 938, DateTimeKind.Utc).AddTicks(4994), "PARTIAL_PAYMENT", 3 },
                    { 7, 120.00m, new DateTime(2024, 12, 18, 23, 27, 46, 938, DateTimeKind.Utc).AddTicks(4996), "CREDIT", 4 },
                    { 8, 80.00m, new DateTime(2024, 12, 23, 23, 27, 46, 938, DateTimeKind.Utc).AddTicks(4998), "CASH", 4 },
                    { 9, 200.00m, new DateTime(2024, 12, 25, 23, 27, 46, 938, DateTimeKind.Utc).AddTicks(5000), "CREDIT", 5 },
                    { 10, 100.00m, new DateTime(2025, 1, 2, 23, 27, 46, 938, DateTimeKind.Utc).AddTicks(5002), "PARTIAL_PAYMENT", 5 }
                });

            migrationBuilder.InsertData(
                table: "purchasePayments",
                columns: new[] { "PurchasePaymentId", "Amount", "PaymentDate", "PaymentType", "PurchaseId" },
                values: new object[,]
                {
                    { 1, 500.00m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CreditCard", 1 },
                    { 2, 750.00m, new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cash", 2 },
                    { 3, 1000.00m, new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "BankTransfer", 3 },
                    { 4, 1250.00m, new DateTime(2024, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "CreditCard", 4 },
                    { 5, 1500.00m, new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cash", 5 },
                    { 6, 1750.00m, new DateTime(2024, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "BankTransfer", 6 },
                    { 7, 2000.00m, new DateTime(2024, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "CreditCard", 7 },
                    { 8, 2250.00m, new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cash", 8 },
                    { 9, 2500.00m, new DateTime(2024, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "BankTransfer", 9 },
                    { 10, 2750.00m, new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "CreditCard", 10 }
                });

            migrationBuilder.InsertData(
                table: "CashTransactions",
                columns: new[] { "CashTransactionId", "Amount", "CashShiftId", "Description", "TransactionTime", "TransactionType" },
                values: new object[,]
                {
                    { 1, 150.00m, 1, "Product Sale Transaction", new DateTime(2025, 1, 2, 23, 27, 46, 935, DateTimeKind.Utc).AddTicks(469), "Sale" },
                    { 2, -20.00m, 1, "Refund for Product X", new DateTime(2025, 1, 2, 22, 57, 46, 935, DateTimeKind.Utc).AddTicks(1220), "Refund" },
                    { 3, 500.00m, 2, "Deposit of additional cash", new DateTime(2025, 1, 2, 22, 27, 46, 935, DateTimeKind.Utc).AddTicks(1244), "Cash Deposit" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CashRegisters_CashRegisterId1",
                table: "CashRegisters",
                column: "CashRegisterId1");

            migrationBuilder.CreateIndex(
                name: "IX_CashRegisters_EmployeeId",
                table: "CashRegisters",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_CashRegisters_LocationId",
                table: "CashRegisters",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_CashShifts_CashRegisterId",
                table: "CashShifts",
                column: "CashRegisterId");

            migrationBuilder.CreateIndex(
                name: "IX_CashShifts_EmployeeId",
                table: "CashShifts",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_CashTransactions_CashShiftId",
                table: "CashTransactions",
                column: "CashShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Name",
                table: "Categories",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Name",
                table: "Customers",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_LocationId",
                table: "Inventory",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_ProductId",
                table: "Inventory",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryMouvementProduct_ProductsProductId",
                table: "InventoryMouvementProduct",
                column: "ProductsProductId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryMouvements_LocationId",
                table: "InventoryMouvements",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_Name",
                table: "Locations",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductBatchs_ProductId",
                table: "ProductBatchs",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Barcode",
                table: "Products",
                column: "Barcode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_LineId",
                table: "Products",
                column: "LineId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ShelfId",
                table: "Products",
                column: "ShelfId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_TaxId",
                table: "Products",
                column: "TaxId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_UnitId",
                table: "Products",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseItems_ProductId",
                table: "PurchaseItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseItems_PurchaseId",
                table: "PurchaseItems",
                column: "PurchaseId");

            migrationBuilder.CreateIndex(
                name: "IX_purchasePayments_PurchaseId",
                table: "purchasePayments",
                column: "PurchaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_EmployeeId",
                table: "Purchases",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_SupplierId",
                table: "Purchases",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleItems_ProductId",
                table: "SaleItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleItems_SaleId",
                table: "SaleItems",
                column: "SaleId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleItems_TaxId",
                table: "SaleItems",
                column: "TaxId");

            migrationBuilder.CreateIndex(
                name: "IX_SalePayments_SaleId",
                table: "SalePayments",
                column: "SaleId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_CustomerId",
                table: "Sales",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_EmployeeId",
                table: "Sales",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_Name",
                table: "Supplier",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CashTransactions");

            migrationBuilder.DropTable(
                name: "Inventory");

            migrationBuilder.DropTable(
                name: "InventoryMouvementProduct");

            migrationBuilder.DropTable(
                name: "ProductBatchs");

            migrationBuilder.DropTable(
                name: "PurchaseItems");

            migrationBuilder.DropTable(
                name: "purchasePayments");

            migrationBuilder.DropTable(
                name: "SaleItems");

            migrationBuilder.DropTable(
                name: "SalePayments");

            migrationBuilder.DropTable(
                name: "CashShifts");

            migrationBuilder.DropTable(
                name: "InventoryMouvements");

            migrationBuilder.DropTable(
                name: "Purchases");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "CashRegisters");

            migrationBuilder.DropTable(
                name: "Supplier");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Lines");

            migrationBuilder.DropTable(
                name: "Shelfs");

            migrationBuilder.DropTable(
                name: "Taxes");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
