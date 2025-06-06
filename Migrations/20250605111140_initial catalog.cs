﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InventoryTrackApi.Migrations
{
    /// <inheritdoc />
    public partial class initialcatalog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastLoginTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Lines",
                columns: table => new
                {
                    LineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lines", x => x.LineId);
                });

            migrationBuilder.CreateTable(
                name: "SaasClients",
                columns: table => new
                {
                    SaasClientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SubscriptionType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubscriptionExpiration = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaasClients", x => x.SaasClientId);
                });

            migrationBuilder.CreateTable(
                name: "Shelfs",
                columns: table => new
                {
                    ShelfId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shelfs", x => x.ShelfId);
                });

            migrationBuilder.CreateTable(
                name: "Taxes",
                columns: table => new
                {
                    TaxId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaxRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.UnitId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    AmountPaid = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
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
                    IsActivate = table.Column<bool>(type: "bit", nullable: false),
                    SaasClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_Customers_SaasClients_SaasClientId",
                        column: x => x.SaasClientId,
                        principalTable: "SaasClients",
                        principalColumn: "SaasClientId",
                        onDelete: ReferentialAction.Restrict);
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
                    IsActivated = table.Column<bool>(type: "bit", nullable: false),
                    SaasClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationId);
                    table.ForeignKey(
                        name: "FK_Locations_SaasClients_SaasClientId",
                        column: x => x.SaasClientId,
                        principalTable: "SaasClients",
                        principalColumn: "SaasClientId",
                        onDelete: ReferentialAction.Cascade);
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
                    IsActivate = table.Column<bool>(type: "bit", nullable: false),
                    SaasClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.SupplierId);
                    table.ForeignKey(
                        name: "FK_Supplier_SaasClients_SaasClientId",
                        column: x => x.SaasClientId,
                        principalTable: "SaasClients",
                        principalColumn: "SaasClientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    SaasClientId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_SaasClients_SaasClientId",
                        column: x => x.SaasClientId,
                        principalTable: "SaasClients",
                        principalColumn: "SaasClientId",
                        onDelete: ReferentialAction.Cascade);
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Lines_LineId",
                        column: x => x.LineId,
                        principalTable: "Lines",
                        principalColumn: "LineId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Shelfs_ShelfId",
                        column: x => x.ShelfId,
                        principalTable: "Shelfs",
                        principalColumn: "ShelfId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Taxes_TaxId",
                        column: x => x.TaxId,
                        principalTable: "Taxes",
                        principalColumn: "TaxId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "UnitId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InventoryMouvements",
                columns: table => new
                {
                    InventoryMouvementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    MouvementType = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MouvementDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SaasClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryMouvements", x => x.InventoryMouvementId);
                    table.ForeignKey(
                        name: "FK_InventoryMouvements_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryMouvements_SaasClients_SaasClientId",
                        column: x => x.SaasClientId,
                        principalTable: "SaasClients",
                        principalColumn: "SaasClientId",
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SaasClientId = table.Column<int>(type: "int", nullable: false),
                    UserId1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashRegisters", x => x.CashRegisterId);
                    table.ForeignKey(
                        name: "FK_CashRegisters_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CashRegisters_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CashRegisters_SaasClients_SaasClientId",
                        column: x => x.SaasClientId,
                        principalTable: "SaasClients",
                        principalColumn: "SaasClientId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CashRegisters_Users_UserId1",
                        column: x => x.UserId1,
                        principalTable: "Users",
                        principalColumn: "Id");
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
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SaasClientId = table.Column<int>(type: "int", nullable: false),
                    UserId1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchases", x => x.PurchaseId);
                    table.ForeignKey(
                        name: "FK_Purchases_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Purchases_SaasClients_SaasClientId",
                        column: x => x.SaasClientId,
                        principalTable: "SaasClients",
                        principalColumn: "SaasClientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Purchases_Supplier_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Supplier",
                        principalColumn: "SupplierId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Purchases_Users_UserId1",
                        column: x => x.UserId1,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    SaleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SaleDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TvaAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AmountPaid = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DiscountPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SaasClientId = table.Column<int>(type: "int", nullable: false),
                    UserId1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.SaleId);
                    table.ForeignKey(
                        name: "FK_Sales_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sales_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sales_SaasClients_SaasClientId",
                        column: x => x.SaasClientId,
                        principalTable: "SaasClients",
                        principalColumn: "SaasClientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sales_Users_UserId1",
                        column: x => x.UserId1,
                        principalTable: "Users",
                        principalColumn: "Id");
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
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    SaasClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.InventoryId);
                    table.ForeignKey(
                        name: "FK_Inventory_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inventory_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inventory_SaasClients_SaasClientId",
                        column: x => x.SaasClientId,
                        principalTable: "SaasClients",
                        principalColumn: "SaasClientId",
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
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    PurchasePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SalePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
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
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CashRegisterId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SaasClientId = table.Column<int>(type: "int", nullable: false),
                    UserId1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashShifts", x => x.CashShiftId);
                    table.ForeignKey(
                        name: "FK_CashShifts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CashShifts_CashRegisters_CashRegisterId",
                        column: x => x.CashRegisterId,
                        principalTable: "CashRegisters",
                        principalColumn: "CashRegisterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CashShifts_SaasClients_SaasClientId",
                        column: x => x.SaasClientId,
                        principalTable: "SaasClients",
                        principalColumn: "SaasClientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CashShifts_Users_UserId1",
                        column: x => x.UserId1,
                        principalTable: "Users",
                        principalColumn: "Id");
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
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SaasClientId = table.Column<int>(type: "int", nullable: false)
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
                    table.ForeignKey(
                        name: "FK_PurchaseItems_SaasClients_SaasClientId",
                        column: x => x.SaasClientId,
                        principalTable: "SaasClients",
                        principalColumn: "SaasClientId",
                        onDelete: ReferentialAction.Cascade);
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
                    PaymentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SaasClientId = table.Column<int>(type: "int", nullable: false)
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
                    table.ForeignKey(
                        name: "FK_purchasePayments_SaasClients_SaasClientId",
                        column: x => x.SaasClientId,
                        principalTable: "SaasClients",
                        principalColumn: "SaasClientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Return",
                columns: table => new
                {
                    ReturnId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SaleId = table.Column<int>(type: "int", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RefundAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReturnMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SaasClientId = table.Column<int>(type: "int", nullable: false),
                    UserId1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Return", x => x.ReturnId);
                    table.ForeignKey(
                        name: "FK_Return_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Return_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Return_SaasClients_SaasClientId",
                        column: x => x.SaasClientId,
                        principalTable: "SaasClients",
                        principalColumn: "SaasClientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Return_Sales_SaleId",
                        column: x => x.SaleId,
                        principalTable: "Sales",
                        principalColumn: "SaleId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Return_Users_UserId1",
                        column: x => x.UserId1,
                        principalTable: "Users",
                        principalColumn: "Id");
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
                    ProfitMarge = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PurchasePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TaxAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SaasClientId = table.Column<int>(type: "int", nullable: false),
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
                        name: "FK_SaleItems_SaasClients_SaasClientId",
                        column: x => x.SaasClientId,
                        principalTable: "SaasClients",
                        principalColumn: "SaasClientId",
                        onDelete: ReferentialAction.Cascade);
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
                name: "SalePayments",
                columns: table => new
                {
                    SalePaymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SaleId = table.Column<int>(type: "int", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SaasClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalePayments", x => x.SalePaymentId);
                    table.ForeignKey(
                        name: "FK_SalePayments_SaasClients_SaasClientId",
                        column: x => x.SaasClientId,
                        principalTable: "SaasClients",
                        principalColumn: "SaasClientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalePayments_Sales_SaleId",
                        column: x => x.SaleId,
                        principalTable: "Sales",
                        principalColumn: "SaleId",
                        onDelete: ReferentialAction.Restrict);
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
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SaasClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashTransactions", x => x.CashTransactionId);
                    table.ForeignKey(
                        name: "FK_CashTransactions_CashShifts_CashShiftId",
                        column: x => x.CashShiftId,
                        principalTable: "CashShifts",
                        principalColumn: "CashShiftId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CashTransactions_SaasClients_SaasClientId",
                        column: x => x.SaasClientId,
                        principalTable: "SaasClients",
                        principalColumn: "SaasClientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReturnItem",
                columns: table => new
                {
                    ReturnItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReturnId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProfitMarge = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PurchasePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TaxAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RefundAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SaasClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReturnItem", x => x.ReturnItemId);
                    table.ForeignKey(
                        name: "FK_ReturnItem_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReturnItem_Return_ReturnId",
                        column: x => x.ReturnId,
                        principalTable: "Return",
                        principalColumn: "ReturnId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReturnItem_SaasClients_SaasClientId",
                        column: x => x.SaasClientId,
                        principalTable: "SaasClients",
                        principalColumn: "SaasClientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReturnPayment",
                columns: table => new
                {
                    ReturnPaymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReturnId = table.Column<int>(type: "int", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SaasClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReturnPayment", x => x.ReturnPaymentId);
                    table.ForeignKey(
                        name: "FK_ReturnPayment_Return_ReturnId",
                        column: x => x.ReturnId,
                        principalTable: "Return",
                        principalColumn: "ReturnId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReturnPayment_SaasClients_SaasClientId",
                        column: x => x.SaasClientId,
                        principalTable: "SaasClients",
                        principalColumn: "SaasClientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "DateCreated", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 6, 5, 11, 11, 36, 518, DateTimeKind.Utc).AddTicks(9634), "Electronics" },
                    { 2, new DateTime(2025, 6, 5, 11, 11, 36, 518, DateTimeKind.Utc).AddTicks(9963), "Clothing" },
                    { 3, new DateTime(2025, 6, 5, 11, 11, 36, 518, DateTimeKind.Utc).AddTicks(9964), "Groceries" },
                    { 4, new DateTime(2025, 6, 5, 11, 11, 36, 518, DateTimeKind.Utc).AddTicks(9964), "Furniture" },
                    { 5, new DateTime(2025, 6, 5, 11, 11, 36, 518, DateTimeKind.Utc).AddTicks(9965), "Books" },
                    { 6, new DateTime(2025, 6, 5, 11, 11, 36, 518, DateTimeKind.Utc).AddTicks(9966), "Sacs" },
                    { 7, new DateTime(2025, 6, 5, 11, 11, 36, 518, DateTimeKind.Utc).AddTicks(9966), "Data" },
                    { 8, new DateTime(2025, 6, 5, 11, 11, 36, 518, DateTimeKind.Utc).AddTicks(9967), "Bread" },
                    { 9, new DateTime(2025, 6, 5, 11, 11, 36, 518, DateTimeKind.Utc).AddTicks(9968), "Jacket" },
                    { 10, new DateTime(2025, 6, 5, 11, 11, 36, 518, DateTimeKind.Utc).AddTicks(9968), "T-Shirts" },
                    { 11, new DateTime(2025, 6, 5, 11, 11, 36, 518, DateTimeKind.Utc).AddTicks(9969), "Jeans" },
                    { 12, new DateTime(2025, 6, 5, 11, 11, 36, 518, DateTimeKind.Utc).AddTicks(9970), "Mobile" }
                });

            migrationBuilder.InsertData(
                table: "Lines",
                columns: new[] { "LineId", "DateCreated", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 6, 5, 11, 11, 36, 519, DateTimeKind.Utc).AddTicks(4995), "Electronics Line" },
                    { 2, new DateTime(2025, 6, 5, 11, 11, 36, 519, DateTimeKind.Utc).AddTicks(5327), "Clothing Line" },
                    { 3, new DateTime(2025, 6, 5, 11, 11, 36, 519, DateTimeKind.Utc).AddTicks(5328), "Grocery Line" },
                    { 4, new DateTime(2025, 6, 5, 11, 11, 36, 519, DateTimeKind.Utc).AddTicks(5328), "Furniture Line" },
                    { 5, new DateTime(2025, 6, 5, 11, 11, 36, 519, DateTimeKind.Utc).AddTicks(5329), "Toys Line" }
                });

            migrationBuilder.InsertData(
                table: "Shelfs",
                columns: new[] { "ShelfId", "DateCreated", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 6, 5, 11, 11, 36, 519, DateTimeKind.Utc).AddTicks(6159), "Shelf 1" },
                    { 2, new DateTime(2025, 6, 5, 11, 11, 36, 519, DateTimeKind.Utc).AddTicks(6358), "Shelf 2" },
                    { 3, new DateTime(2025, 6, 5, 11, 11, 36, 519, DateTimeKind.Utc).AddTicks(6359), "Shelf 3" }
                });

            migrationBuilder.InsertData(
                table: "Taxes",
                columns: new[] { "TaxId", "DateCreated", "TaxRate" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 6, 5, 11, 11, 36, 519, DateTimeKind.Utc).AddTicks(7174), 10m },
                    { 2, new DateTime(2025, 6, 5, 11, 11, 36, 519, DateTimeKind.Utc).AddTicks(8087), 20m },
                    { 3, new DateTime(2025, 6, 5, 11, 11, 36, 519, DateTimeKind.Utc).AddTicks(8088), 30m }
                });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "UnitId", "DateCreated", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 6, 5, 11, 11, 36, 519, DateTimeKind.Utc).AddTicks(8441), "Unit 1" },
                    { 2, new DateTime(2025, 6, 5, 11, 11, 36, 519, DateTimeKind.Utc).AddTicks(8628), "Unit 2" },
                    { 3, new DateTime(2025, 6, 5, 11, 11, 36, 519, DateTimeKind.Utc).AddTicks(8629), "Unit 3" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Barcode", "CategoryId", "CreatedBy", "DateCreated", "DateModified", "DiscountPercentage", "ImageUrl", "IsActivate", "IsBuyThreeForFiveEligible", "IsSecondItemDiscountEligible", "LineId", "MaxStock", "MinStock", "ModifiedBy", "Name", "PackUnitType", "ProductUnitId", "PurchasePrice", "QuantityPack", "QuantityStock", "SalePrice1", "SalePrice2", "SalePrice3", "ShelfId", "TaxId", "UnitId" },
                values: new object[,]
                {
                    { 1, "1234567890123", 1, "Admin", new DateTime(2025, 6, 5, 13, 11, 36, 523, DateTimeKind.Local).AddTicks(1388), new DateTime(2025, 6, 5, 13, 11, 36, 523, DateTimeKind.Local).AddTicks(1934), 0m, "https://example.com/productA.jpg", true, false, false, 1, 100m, 10m, "Admin", "Product A", "Box", 1, 100.00m, 1m, 50m, 150.00m, 160.00m, 170.00m, 1, 1, 1 },
                    { 2, "2234567890123", 2, "Admin", new DateTime(2025, 6, 5, 13, 11, 36, 523, DateTimeKind.Local).AddTicks(3552), new DateTime(2025, 6, 5, 13, 11, 36, 523, DateTimeKind.Local).AddTicks(3554), 0m, "https://example.com/productB.jpg", true, false, false, 2, 5m, 5m, "Admin", "Product B", "Piece", 2, 50.00m, 1m, 30m, 70.00m, 75.00m, 80.00m, 2, 2, 2 },
                    { 3, "3234567890123", 3, "Admin", new DateTime(2025, 6, 5, 13, 11, 36, 523, DateTimeKind.Local).AddTicks(3565), new DateTime(2025, 6, 5, 13, 11, 36, 523, DateTimeKind.Local).AddTicks(3567), 0m, "https://example.com/productC.jpg", true, false, false, 3, 5m, 5m, "Admin", "Product C", "Piece", 3, 200.00m, 1m, 60m, 250.00m, 260.00m, 270.00m, 3, 3, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CashRegisters_LocationId",
                table: "CashRegisters",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_CashRegisters_SaasClientId",
                table: "CashRegisters",
                column: "SaasClientId");

            migrationBuilder.CreateIndex(
                name: "IX_CashRegisters_UserId",
                table: "CashRegisters",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CashRegisters_UserId1",
                table: "CashRegisters",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_CashShifts_CashRegisterId",
                table: "CashShifts",
                column: "CashRegisterId");

            migrationBuilder.CreateIndex(
                name: "IX_CashShifts_SaasClientId",
                table: "CashShifts",
                column: "SaasClientId");

            migrationBuilder.CreateIndex(
                name: "IX_CashShifts_UserId",
                table: "CashShifts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CashShifts_UserId1",
                table: "CashShifts",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_CashTransactions_CashShiftId",
                table: "CashTransactions",
                column: "CashShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_CashTransactions_SaasClientId",
                table: "CashTransactions",
                column: "SaasClientId");

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
                name: "IX_Customers_SaasClientId",
                table: "Customers",
                column: "SaasClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_LocationId",
                table: "Inventory",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_ProductId",
                table: "Inventory",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_SaasClientId",
                table: "Inventory",
                column: "SaasClientId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryMouvementProduct_ProductsProductId",
                table: "InventoryMouvementProduct",
                column: "ProductsProductId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryMouvements_LocationId",
                table: "InventoryMouvements",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryMouvements_SaasClientId",
                table: "InventoryMouvements",
                column: "SaasClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Lines_Name",
                table: "Lines",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Locations_Name",
                table: "Locations",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Locations_SaasClientId",
                table: "Locations",
                column: "SaasClientId");

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
                name: "IX_PurchaseItems_SaasClientId",
                table: "PurchaseItems",
                column: "SaasClientId");

            migrationBuilder.CreateIndex(
                name: "IX_purchasePayments_PurchaseId",
                table: "purchasePayments",
                column: "PurchaseId");

            migrationBuilder.CreateIndex(
                name: "IX_purchasePayments_SaasClientId",
                table: "purchasePayments",
                column: "SaasClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_SaasClientId",
                table: "Purchases",
                column: "SaasClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_SupplierId",
                table: "Purchases",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_UserId",
                table: "Purchases",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_UserId1",
                table: "Purchases",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Return_CustomerId",
                table: "Return",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Return_SaasClientId",
                table: "Return",
                column: "SaasClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Return_SaleId",
                table: "Return",
                column: "SaleId");

            migrationBuilder.CreateIndex(
                name: "IX_Return_UserId",
                table: "Return",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Return_UserId1",
                table: "Return",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnItem_ProductId",
                table: "ReturnItem",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnItem_ReturnId",
                table: "ReturnItem",
                column: "ReturnId");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnItem_SaasClientId",
                table: "ReturnItem",
                column: "SaasClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnPayment_ReturnId",
                table: "ReturnPayment",
                column: "ReturnId");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnPayment_SaasClientId",
                table: "ReturnPayment",
                column: "SaasClientId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleItems_ProductId",
                table: "SaleItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleItems_SaasClientId",
                table: "SaleItems",
                column: "SaasClientId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleItems_SaleId",
                table: "SaleItems",
                column: "SaleId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleItems_TaxId",
                table: "SaleItems",
                column: "TaxId");

            migrationBuilder.CreateIndex(
                name: "IX_SalePayments_SaasClientId",
                table: "SalePayments",
                column: "SaasClientId");

            migrationBuilder.CreateIndex(
                name: "IX_SalePayments_SaleId",
                table: "SalePayments",
                column: "SaleId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_CustomerId",
                table: "Sales",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_SaasClientId",
                table: "Sales",
                column: "SaasClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_UserId",
                table: "Sales",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_UserId1",
                table: "Sales",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_Name",
                table: "Supplier",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_SaasClientId",
                table: "Supplier",
                column: "SaasClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_SaasClientId",
                table: "Users",
                column: "SaasClientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

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
                name: "ReturnItem");

            migrationBuilder.DropTable(
                name: "ReturnPayment");

            migrationBuilder.DropTable(
                name: "SaleItems");

            migrationBuilder.DropTable(
                name: "SalePayments");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "CashShifts");

            migrationBuilder.DropTable(
                name: "InventoryMouvements");

            migrationBuilder.DropTable(
                name: "Purchases");

            migrationBuilder.DropTable(
                name: "Return");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "CashRegisters");

            migrationBuilder.DropTable(
                name: "Supplier");

            migrationBuilder.DropTable(
                name: "Sales");

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
                name: "Locations");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "SaasClients");
        }
    }
}
