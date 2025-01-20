using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryTrackApi.Migrations
{
    /// <inheritdoc />
    public partial class Addingreturns_returnItems_returnPaymentModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Return",
                columns: table => new
                {
                    ReturnId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SaleId = table.Column<int>(type: "int", nullable: false),
                    returnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RefundAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReturnMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Return", x => x.ReturnId);
                    table.ForeignKey(
                        name: "FK_Return_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Return_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Return_Sales_SaleId",
                        column: x => x.SaleId,
                        principalTable: "Sales",
                        principalColumn: "SaleId",
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
                    RefundAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                });

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "CashRegisterId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 21, 25, 55, 219, DateTimeKind.Utc).AddTicks(9791));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "CashRegisterId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 21, 25, 55, 220, DateTimeKind.Utc).AddTicks(3745));

            migrationBuilder.UpdateData(
                table: "CashShifts",
                keyColumn: "CashShiftId",
                keyValue: 1,
                columns: new[] { "DateCreated", "ShiftStart" },
                values: new object[] { new DateTime(2025, 1, 20, 21, 25, 55, 220, DateTimeKind.Utc).AddTicks(5580), new DateTime(2025, 1, 20, 21, 25, 55, 220, DateTimeKind.Utc).AddTicks(6672) });

            migrationBuilder.UpdateData(
                table: "CashShifts",
                keyColumn: "CashShiftId",
                keyValue: 2,
                columns: new[] { "DateCreated", "ShiftStart" },
                values: new object[] { new DateTime(2025, 1, 20, 21, 25, 55, 221, DateTimeKind.Utc).AddTicks(1749), new DateTime(2025, 1, 21, 21, 25, 55, 221, DateTimeKind.Utc).AddTicks(1834) });

            migrationBuilder.UpdateData(
                table: "CashTransactions",
                keyColumn: "CashTransactionId",
                keyValue: 1,
                columns: new[] { "DateCreated", "TransactionTime" },
                values: new object[] { new DateTime(2025, 1, 20, 21, 25, 55, 221, DateTimeKind.Utc).AddTicks(5296), new DateTime(2025, 1, 20, 21, 25, 55, 221, DateTimeKind.Utc).AddTicks(7553) });

            migrationBuilder.UpdateData(
                table: "CashTransactions",
                keyColumn: "CashTransactionId",
                keyValue: 2,
                columns: new[] { "DateCreated", "TransactionTime" },
                values: new object[] { new DateTime(2025, 1, 20, 21, 25, 55, 221, DateTimeKind.Utc).AddTicks(8594), new DateTime(2025, 1, 20, 20, 55, 55, 221, DateTimeKind.Utc).AddTicks(8600) });

            migrationBuilder.UpdateData(
                table: "CashTransactions",
                keyColumn: "CashTransactionId",
                keyValue: 3,
                columns: new[] { "DateCreated", "TransactionTime" },
                values: new object[] { new DateTime(2025, 1, 20, 21, 25, 55, 221, DateTimeKind.Utc).AddTicks(8659), new DateTime(2025, 1, 20, 20, 25, 55, 221, DateTimeKind.Utc).AddTicks(8661) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 21, 25, 55, 214, DateTimeKind.Utc).AddTicks(456));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 21, 25, 55, 214, DateTimeKind.Utc).AddTicks(1495));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 21, 25, 55, 214, DateTimeKind.Utc).AddTicks(1497));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 21, 25, 55, 214, DateTimeKind.Utc).AddTicks(1499));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 21, 25, 55, 214, DateTimeKind.Utc).AddTicks(1500));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 21, 25, 55, 214, DateTimeKind.Utc).AddTicks(1502));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 21, 25, 55, 214, DateTimeKind.Utc).AddTicks(1503));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 21, 25, 55, 214, DateTimeKind.Utc).AddTicks(1504));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 9,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 21, 25, 55, 214, DateTimeKind.Utc).AddTicks(1505));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 10,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 21, 25, 55, 214, DateTimeKind.Utc).AddTicks(1506));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 11,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 21, 25, 55, 214, DateTimeKind.Utc).AddTicks(1507));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 12,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 21, 25, 55, 214, DateTimeKind.Utc).AddTicks(1509));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 1, 20, 22, 25, 55, 219, DateTimeKind.Local).AddTicks(5472), new DateTime(2025, 1, 20, 22, 25, 55, 219, DateTimeKind.Local).AddTicks(6517) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 1, 20, 22, 25, 55, 219, DateTimeKind.Local).AddTicks(7815), new DateTime(2025, 1, 20, 22, 25, 55, 219, DateTimeKind.Local).AddTicks(7819) });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 21, 25, 55, 218, DateTimeKind.Utc).AddTicks(1343));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 21, 25, 55, 218, DateTimeKind.Utc).AddTicks(6496));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 21, 25, 55, 218, DateTimeKind.Utc).AddTicks(6507));

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "InventoryId",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 1, 20, 22, 25, 55, 222, DateTimeKind.Local).AddTicks(3283), new DateTime(2025, 1, 20, 22, 25, 55, 222, DateTimeKind.Local).AddTicks(4309) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "InventoryId",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 1, 20, 22, 25, 55, 222, DateTimeKind.Local).AddTicks(5911), new DateTime(2025, 1, 20, 22, 25, 55, 222, DateTimeKind.Local).AddTicks(5918) });

            migrationBuilder.UpdateData(
                table: "InventoryMouvements",
                keyColumn: "InventoryMouvementId",
                keyValue: 1,
                columns: new[] { "DateCreated", "MouvementDate" },
                values: new object[] { new DateTime(2025, 1, 20, 21, 25, 55, 222, DateTimeKind.Utc).AddTicks(8107), new DateTime(2025, 1, 20, 22, 25, 55, 223, DateTimeKind.Local).AddTicks(654) });

            migrationBuilder.UpdateData(
                table: "InventoryMouvements",
                keyColumn: "InventoryMouvementId",
                keyValue: 2,
                columns: new[] { "DateCreated", "MouvementDate" },
                values: new object[] { new DateTime(2025, 1, 20, 21, 25, 55, 223, DateTimeKind.Utc).AddTicks(1282), new DateTime(2025, 1, 20, 22, 25, 55, 223, DateTimeKind.Local).AddTicks(1288) });

            migrationBuilder.UpdateData(
                table: "InventoryMouvements",
                keyColumn: "InventoryMouvementId",
                keyValue: 3,
                columns: new[] { "DateCreated", "MouvementDate" },
                values: new object[] { new DateTime(2025, 1, 20, 21, 25, 55, 223, DateTimeKind.Utc).AddTicks(1300), new DateTime(2025, 1, 20, 22, 25, 55, 223, DateTimeKind.Local).AddTicks(1455) });

            migrationBuilder.UpdateData(
                table: "Lines",
                keyColumn: "LineId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 21, 25, 55, 214, DateTimeKind.Utc).AddTicks(4002));

            migrationBuilder.UpdateData(
                table: "Lines",
                keyColumn: "LineId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 21, 25, 55, 214, DateTimeKind.Utc).AddTicks(4918));

            migrationBuilder.UpdateData(
                table: "Lines",
                keyColumn: "LineId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 21, 25, 55, 214, DateTimeKind.Utc).AddTicks(4920));

            migrationBuilder.UpdateData(
                table: "Lines",
                keyColumn: "LineId",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 21, 25, 55, 214, DateTimeKind.Utc).AddTicks(4922));

            migrationBuilder.UpdateData(
                table: "Lines",
                keyColumn: "LineId",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 21, 25, 55, 214, DateTimeKind.Utc).AddTicks(4923));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 1, 20, 22, 25, 55, 217, DateTimeKind.Local).AddTicks(7574), new DateTime(2025, 1, 20, 22, 25, 55, 217, DateTimeKind.Local).AddTicks(8512) });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 1, 20, 22, 25, 55, 217, DateTimeKind.Local).AddTicks(9363), new DateTime(2025, 1, 20, 22, 25, 55, 217, DateTimeKind.Local).AddTicks(9366) });

            migrationBuilder.UpdateData(
                table: "ProductBatchs",
                keyColumn: "ProductBatchId",
                keyValue: 1,
                columns: new[] { "ExpirationDate", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 7, 20, 21, 25, 55, 223, DateTimeKind.Utc).AddTicks(5725), new DateTime(2025, 1, 10, 21, 25, 55, 224, DateTimeKind.Utc).AddTicks(1102) });

            migrationBuilder.UpdateData(
                table: "ProductBatchs",
                keyColumn: "ProductBatchId",
                keyValue: 2,
                columns: new[] { "ExpirationDate", "ReceivedDate" },
                values: new object[] { new DateTime(2026, 1, 20, 21, 25, 55, 224, DateTimeKind.Utc).AddTicks(2683), new DateTime(2024, 12, 31, 21, 25, 55, 224, DateTimeKind.Utc).AddTicks(2690) });

            migrationBuilder.UpdateData(
                table: "ProductBatchs",
                keyColumn: "ProductBatchId",
                keyValue: 3,
                column: "ReceivedDate",
                value: new DateTime(2025, 1, 15, 21, 25, 55, 224, DateTimeKind.Utc).AddTicks(2695));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 1, 20, 22, 25, 55, 216, DateTimeKind.Local).AddTicks(4999), new DateTime(2025, 1, 20, 22, 25, 55, 216, DateTimeKind.Local).AddTicks(6179) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 1, 20, 22, 25, 55, 217, DateTimeKind.Local).AddTicks(32), new DateTime(2025, 1, 20, 22, 25, 55, 217, DateTimeKind.Local).AddTicks(35) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 1, 20, 22, 25, 55, 217, DateTimeKind.Local).AddTicks(52), new DateTime(2025, 1, 20, 22, 25, 55, 217, DateTimeKind.Local).AddTicks(129) });

            migrationBuilder.UpdateData(
                table: "PurchaseItems",
                keyColumn: "PurchaseItemId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 21, 25, 55, 225, DateTimeKind.Utc).AddTicks(1267));

            migrationBuilder.UpdateData(
                table: "PurchaseItems",
                keyColumn: "PurchaseItemId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 21, 25, 55, 225, DateTimeKind.Utc).AddTicks(6009));

            migrationBuilder.UpdateData(
                table: "PurchaseItems",
                keyColumn: "PurchaseItemId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 21, 25, 55, 225, DateTimeKind.Utc).AddTicks(6023));

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: 1,
                columns: new[] { "DateCreated", "PurchaseDate" },
                values: new object[] { new DateTime(2025, 1, 20, 21, 25, 55, 224, DateTimeKind.Utc).AddTicks(5037), new DateTime(2025, 1, 10, 21, 25, 55, 224, DateTimeKind.Utc).AddTicks(5667) });

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: 2,
                columns: new[] { "DateCreated", "PurchaseDate" },
                values: new object[] { new DateTime(2025, 1, 20, 21, 25, 55, 224, DateTimeKind.Utc).AddTicks(9109), new DateTime(2025, 1, 15, 21, 25, 55, 224, DateTimeKind.Utc).AddTicks(9113) });

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: 3,
                columns: new[] { "DateCreated", "PurchaseDate" },
                values: new object[] { new DateTime(2025, 1, 20, 21, 25, 55, 224, DateTimeKind.Utc).AddTicks(9123), new DateTime(2025, 1, 20, 21, 25, 55, 224, DateTimeKind.Utc).AddTicks(9125) });

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: 4,
                columns: new[] { "DateCreated", "PurchaseDate" },
                values: new object[] { new DateTime(2025, 1, 20, 21, 25, 55, 224, DateTimeKind.Utc).AddTicks(9130), new DateTime(2025, 1, 20, 21, 25, 55, 224, DateTimeKind.Utc).AddTicks(9131) });

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: 5,
                columns: new[] { "DateCreated", "PurchaseDate" },
                values: new object[] { new DateTime(2025, 1, 20, 21, 25, 55, 224, DateTimeKind.Utc).AddTicks(9136), new DateTime(2025, 1, 20, 21, 25, 55, 224, DateTimeKind.Utc).AddTicks(9137) });

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: 6,
                columns: new[] { "DateCreated", "PurchaseDate" },
                values: new object[] { new DateTime(2025, 1, 20, 21, 25, 55, 224, DateTimeKind.Utc).AddTicks(9262), new DateTime(2025, 1, 20, 21, 25, 55, 224, DateTimeKind.Utc).AddTicks(9263) });

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: 7,
                columns: new[] { "DateCreated", "PurchaseDate" },
                values: new object[] { new DateTime(2025, 1, 20, 21, 25, 55, 224, DateTimeKind.Utc).AddTicks(9269), new DateTime(2025, 1, 20, 21, 25, 55, 224, DateTimeKind.Utc).AddTicks(9270) });

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: 8,
                columns: new[] { "DateCreated", "PurchaseDate" },
                values: new object[] { new DateTime(2025, 1, 20, 21, 25, 55, 224, DateTimeKind.Utc).AddTicks(9274), new DateTime(2025, 1, 20, 21, 25, 55, 224, DateTimeKind.Utc).AddTicks(9275) });

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: 9,
                columns: new[] { "DateCreated", "PurchaseDate" },
                values: new object[] { new DateTime(2025, 1, 20, 21, 25, 55, 224, DateTimeKind.Utc).AddTicks(9280), new DateTime(2025, 1, 20, 21, 25, 55, 224, DateTimeKind.Utc).AddTicks(9281) });

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: 10,
                columns: new[] { "DateCreated", "PurchaseDate" },
                values: new object[] { new DateTime(2025, 1, 20, 21, 25, 55, 224, DateTimeKind.Utc).AddTicks(9285), new DateTime(2025, 1, 20, 21, 25, 55, 224, DateTimeKind.Utc).AddTicks(9286) });

            migrationBuilder.UpdateData(
                table: "SaleItems",
                keyColumn: "SaleItemId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 21, 25, 55, 227, DateTimeKind.Utc).AddTicks(1031));

            migrationBuilder.UpdateData(
                table: "SaleItems",
                keyColumn: "SaleItemId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 21, 25, 55, 227, DateTimeKind.Utc).AddTicks(6732));

            migrationBuilder.UpdateData(
                table: "SaleItems",
                keyColumn: "SaleItemId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 21, 25, 55, 227, DateTimeKind.Utc).AddTicks(6750));

            migrationBuilder.UpdateData(
                table: "SaleItems",
                keyColumn: "SaleItemId",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 21, 25, 55, 227, DateTimeKind.Utc).AddTicks(6757));

            migrationBuilder.UpdateData(
                table: "SaleItems",
                keyColumn: "SaleItemId",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 21, 25, 55, 227, DateTimeKind.Utc).AddTicks(6760));

            migrationBuilder.UpdateData(
                table: "SaleItems",
                keyColumn: "SaleItemId",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 21, 25, 55, 227, DateTimeKind.Utc).AddTicks(6764));

            migrationBuilder.UpdateData(
                table: "SaleItems",
                keyColumn: "SaleItemId",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 21, 25, 55, 227, DateTimeKind.Utc).AddTicks(6845));

            migrationBuilder.UpdateData(
                table: "SaleItems",
                keyColumn: "SaleItemId",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 21, 25, 55, 227, DateTimeKind.Utc).AddTicks(6848));

            migrationBuilder.UpdateData(
                table: "SaleItems",
                keyColumn: "SaleItemId",
                keyValue: 9,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 21, 25, 55, 227, DateTimeKind.Utc).AddTicks(6852));

            migrationBuilder.UpdateData(
                table: "SaleItems",
                keyColumn: "SaleItemId",
                keyValue: 10,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 21, 25, 55, 227, DateTimeKind.Utc).AddTicks(6857));

            migrationBuilder.UpdateData(
                table: "SalePayments",
                keyColumn: "SalePaymentId",
                keyValue: 1,
                columns: new[] { "DateCreated", "PaymentDate" },
                values: new object[] { new DateTime(2025, 1, 20, 21, 25, 55, 227, DateTimeKind.Utc).AddTicks(9363), new DateTime(2025, 1, 10, 21, 25, 55, 228, DateTimeKind.Utc).AddTicks(373) });

            migrationBuilder.UpdateData(
                table: "SalePayments",
                keyColumn: "SalePaymentId",
                keyValue: 2,
                columns: new[] { "DateCreated", "PaymentDate" },
                values: new object[] { new DateTime(2025, 1, 20, 21, 25, 55, 228, DateTimeKind.Utc).AddTicks(2120), new DateTime(2025, 1, 15, 21, 25, 55, 228, DateTimeKind.Utc).AddTicks(2129) });

            migrationBuilder.UpdateData(
                table: "SalePayments",
                keyColumn: "SalePaymentId",
                keyValue: 3,
                columns: new[] { "DateCreated", "PaymentDate" },
                values: new object[] { new DateTime(2025, 1, 20, 21, 25, 55, 228, DateTimeKind.Utc).AddTicks(2132), new DateTime(2025, 1, 13, 21, 25, 55, 228, DateTimeKind.Utc).AddTicks(2134) });

            migrationBuilder.UpdateData(
                table: "SalePayments",
                keyColumn: "SalePaymentId",
                keyValue: 4,
                columns: new[] { "DateCreated", "PaymentDate" },
                values: new object[] { new DateTime(2025, 1, 20, 21, 25, 55, 228, DateTimeKind.Utc).AddTicks(2137), new DateTime(2025, 1, 17, 21, 25, 55, 228, DateTimeKind.Utc).AddTicks(2138) });

            migrationBuilder.UpdateData(
                table: "SalePayments",
                keyColumn: "SalePaymentId",
                keyValue: 5,
                columns: new[] { "DateCreated", "PaymentDate" },
                values: new object[] { new DateTime(2025, 1, 20, 21, 25, 55, 228, DateTimeKind.Utc).AddTicks(2144), new DateTime(2025, 1, 18, 21, 25, 55, 228, DateTimeKind.Utc).AddTicks(2145) });

            migrationBuilder.UpdateData(
                table: "SalePayments",
                keyColumn: "SalePaymentId",
                keyValue: 6,
                columns: new[] { "DateCreated", "PaymentDate" },
                values: new object[] { new DateTime(2025, 1, 20, 21, 25, 55, 228, DateTimeKind.Utc).AddTicks(2147), new DateTime(2025, 1, 19, 21, 25, 55, 228, DateTimeKind.Utc).AddTicks(2147) });

            migrationBuilder.UpdateData(
                table: "SalePayments",
                keyColumn: "SalePaymentId",
                keyValue: 7,
                columns: new[] { "DateCreated", "PaymentDate" },
                values: new object[] { new DateTime(2025, 1, 20, 21, 25, 55, 228, DateTimeKind.Utc).AddTicks(2152), new DateTime(2025, 1, 5, 21, 25, 55, 228, DateTimeKind.Utc).AddTicks(2153) });

            migrationBuilder.UpdateData(
                table: "SalePayments",
                keyColumn: "SalePaymentId",
                keyValue: 8,
                columns: new[] { "DateCreated", "PaymentDate" },
                values: new object[] { new DateTime(2025, 1, 20, 21, 25, 55, 228, DateTimeKind.Utc).AddTicks(2159), new DateTime(2025, 1, 10, 21, 25, 55, 228, DateTimeKind.Utc).AddTicks(2160) });

            migrationBuilder.UpdateData(
                table: "SalePayments",
                keyColumn: "SalePaymentId",
                keyValue: 9,
                columns: new[] { "DateCreated", "PaymentDate" },
                values: new object[] { new DateTime(2025, 1, 20, 21, 25, 55, 228, DateTimeKind.Utc).AddTicks(2161), new DateTime(2025, 1, 12, 21, 25, 55, 228, DateTimeKind.Utc).AddTicks(2162) });

            migrationBuilder.UpdateData(
                table: "SalePayments",
                keyColumn: "SalePaymentId",
                keyValue: 10,
                columns: new[] { "DateCreated", "PaymentDate" },
                values: new object[] { new DateTime(2025, 1, 20, 21, 25, 55, 228, DateTimeKind.Utc).AddTicks(2165), new DateTime(2025, 1, 20, 21, 25, 55, 228, DateTimeKind.Utc).AddTicks(2166) });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 21, 25, 55, 226, DateTimeKind.Utc).AddTicks(4114));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 21, 25, 55, 226, DateTimeKind.Utc).AddTicks(8821));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 21, 25, 55, 226, DateTimeKind.Utc).AddTicks(8841));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 21, 25, 55, 226, DateTimeKind.Utc).AddTicks(8857));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 21, 25, 55, 226, DateTimeKind.Utc).AddTicks(8868));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 21, 25, 55, 226, DateTimeKind.Utc).AddTicks(8873));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 21, 25, 55, 226, DateTimeKind.Utc).AddTicks(8878));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 21, 25, 55, 226, DateTimeKind.Utc).AddTicks(8883));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 9,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 21, 25, 55, 226, DateTimeKind.Utc).AddTicks(8891));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 10,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 21, 25, 55, 226, DateTimeKind.Utc).AddTicks(8907));

            migrationBuilder.UpdateData(
                table: "Shelfs",
                keyColumn: "ShelfId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 21, 25, 55, 214, DateTimeKind.Utc).AddTicks(6712));

            migrationBuilder.UpdateData(
                table: "Shelfs",
                keyColumn: "ShelfId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 21, 25, 55, 214, DateTimeKind.Utc).AddTicks(7700));

            migrationBuilder.UpdateData(
                table: "Shelfs",
                keyColumn: "ShelfId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 21, 25, 55, 214, DateTimeKind.Utc).AddTicks(7703));

            migrationBuilder.UpdateData(
                table: "Supplier",
                keyColumn: "SupplierId",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 1, 20, 22, 25, 55, 211, DateTimeKind.Local).AddTicks(9337), new DateTime(2025, 1, 20, 22, 25, 55, 212, DateTimeKind.Local).AddTicks(493) });

            migrationBuilder.UpdateData(
                table: "Supplier",
                keyColumn: "SupplierId",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 1, 20, 22, 25, 55, 212, DateTimeKind.Local).AddTicks(1739), new DateTime(2025, 1, 20, 22, 25, 55, 212, DateTimeKind.Local).AddTicks(1742) });

            migrationBuilder.UpdateData(
                table: "Supplier",
                keyColumn: "SupplierId",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 1, 20, 22, 25, 55, 212, DateTimeKind.Local).AddTicks(1752), new DateTime(2025, 1, 20, 22, 25, 55, 212, DateTimeKind.Local).AddTicks(1755) });

            migrationBuilder.UpdateData(
                table: "Supplier",
                keyColumn: "SupplierId",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 1, 20, 22, 25, 55, 212, DateTimeKind.Local).AddTicks(1765), new DateTime(2025, 1, 20, 22, 25, 55, 212, DateTimeKind.Local).AddTicks(1768) });

            migrationBuilder.UpdateData(
                table: "Supplier",
                keyColumn: "SupplierId",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 1, 20, 22, 25, 55, 212, DateTimeKind.Local).AddTicks(1778), new DateTime(2025, 1, 20, 22, 25, 55, 212, DateTimeKind.Local).AddTicks(1781) });

            migrationBuilder.UpdateData(
                table: "Supplier",
                keyColumn: "SupplierId",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 1, 20, 22, 25, 55, 212, DateTimeKind.Local).AddTicks(1791), new DateTime(2025, 1, 20, 22, 25, 55, 212, DateTimeKind.Local).AddTicks(1794) });

            migrationBuilder.UpdateData(
                table: "Supplier",
                keyColumn: "SupplierId",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 1, 20, 22, 25, 55, 212, DateTimeKind.Local).AddTicks(1804), new DateTime(2025, 1, 20, 22, 25, 55, 212, DateTimeKind.Local).AddTicks(1807) });

            migrationBuilder.UpdateData(
                table: "Supplier",
                keyColumn: "SupplierId",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 1, 20, 22, 25, 55, 212, DateTimeKind.Local).AddTicks(1816), new DateTime(2025, 1, 20, 22, 25, 55, 212, DateTimeKind.Local).AddTicks(1818) });

            migrationBuilder.UpdateData(
                table: "Supplier",
                keyColumn: "SupplierId",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 1, 20, 22, 25, 55, 212, DateTimeKind.Local).AddTicks(1931), new DateTime(2025, 1, 20, 22, 25, 55, 212, DateTimeKind.Local).AddTicks(1934) });

            migrationBuilder.UpdateData(
                table: "Supplier",
                keyColumn: "SupplierId",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 1, 20, 22, 25, 55, 212, DateTimeKind.Local).AddTicks(1945), new DateTime(2025, 1, 20, 22, 25, 55, 212, DateTimeKind.Local).AddTicks(1948) });

            migrationBuilder.UpdateData(
                table: "Taxes",
                keyColumn: "TaxId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 21, 25, 55, 214, DateTimeKind.Utc).AddTicks(9338));

            migrationBuilder.UpdateData(
                table: "Taxes",
                keyColumn: "TaxId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 21, 25, 55, 215, DateTimeKind.Utc).AddTicks(453));

            migrationBuilder.UpdateData(
                table: "Taxes",
                keyColumn: "TaxId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 21, 25, 55, 215, DateTimeKind.Utc).AddTicks(457));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "UnitId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 21, 25, 55, 215, DateTimeKind.Utc).AddTicks(1990));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "UnitId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 21, 25, 55, 215, DateTimeKind.Utc).AddTicks(3098));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "UnitId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 21, 25, 55, 215, DateTimeKind.Utc).AddTicks(3100));

            migrationBuilder.UpdateData(
                table: "purchasePayments",
                keyColumn: "PurchasePaymentId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 21, 25, 55, 225, DateTimeKind.Utc).AddTicks(8169));

            migrationBuilder.UpdateData(
                table: "purchasePayments",
                keyColumn: "PurchasePaymentId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 21, 25, 55, 226, DateTimeKind.Utc).AddTicks(1174));

            migrationBuilder.UpdateData(
                table: "purchasePayments",
                keyColumn: "PurchasePaymentId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 21, 25, 55, 226, DateTimeKind.Utc).AddTicks(1183));

            migrationBuilder.UpdateData(
                table: "purchasePayments",
                keyColumn: "PurchasePaymentId",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 21, 25, 55, 226, DateTimeKind.Utc).AddTicks(1186));

            migrationBuilder.UpdateData(
                table: "purchasePayments",
                keyColumn: "PurchasePaymentId",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 21, 25, 55, 226, DateTimeKind.Utc).AddTicks(1188));

            migrationBuilder.UpdateData(
                table: "purchasePayments",
                keyColumn: "PurchasePaymentId",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 21, 25, 55, 226, DateTimeKind.Utc).AddTicks(1190));

            migrationBuilder.UpdateData(
                table: "purchasePayments",
                keyColumn: "PurchasePaymentId",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 21, 25, 55, 226, DateTimeKind.Utc).AddTicks(1192));

            migrationBuilder.UpdateData(
                table: "purchasePayments",
                keyColumn: "PurchasePaymentId",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 21, 25, 55, 226, DateTimeKind.Utc).AddTicks(1194));

            migrationBuilder.UpdateData(
                table: "purchasePayments",
                keyColumn: "PurchasePaymentId",
                keyValue: 9,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 21, 25, 55, 226, DateTimeKind.Utc).AddTicks(1196));

            migrationBuilder.UpdateData(
                table: "purchasePayments",
                keyColumn: "PurchasePaymentId",
                keyValue: 10,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 21, 25, 55, 226, DateTimeKind.Utc).AddTicks(1199));

            migrationBuilder.CreateIndex(
                name: "IX_Return_CustomerId",
                table: "Return",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Return_EmployeeId",
                table: "Return",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Return_SaleId",
                table: "Return",
                column: "SaleId");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnItem_ProductId",
                table: "ReturnItem",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnItem_ReturnId",
                table: "ReturnItem",
                column: "ReturnId");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnPayment_ReturnId",
                table: "ReturnPayment",
                column: "ReturnId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReturnItem");

            migrationBuilder.DropTable(
                name: "ReturnPayment");

            migrationBuilder.DropTable(
                name: "Return");

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "CashRegisterId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 18, 0, 34, 355, DateTimeKind.Utc).AddTicks(8638));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "CashRegisterId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 18, 0, 34, 356, DateTimeKind.Utc).AddTicks(3920));

            migrationBuilder.UpdateData(
                table: "CashShifts",
                keyColumn: "CashShiftId",
                keyValue: 1,
                columns: new[] { "DateCreated", "ShiftStart" },
                values: new object[] { new DateTime(2025, 1, 20, 18, 0, 34, 356, DateTimeKind.Utc).AddTicks(7937), new DateTime(2025, 1, 20, 18, 0, 34, 357, DateTimeKind.Utc).AddTicks(6) });

            migrationBuilder.UpdateData(
                table: "CashShifts",
                keyColumn: "CashShiftId",
                keyValue: 2,
                columns: new[] { "DateCreated", "ShiftStart" },
                values: new object[] { new DateTime(2025, 1, 20, 18, 0, 34, 358, DateTimeKind.Utc).AddTicks(3388), new DateTime(2025, 1, 21, 18, 0, 34, 358, DateTimeKind.Utc).AddTicks(3547) });

            migrationBuilder.UpdateData(
                table: "CashTransactions",
                keyColumn: "CashTransactionId",
                keyValue: 1,
                columns: new[] { "DateCreated", "TransactionTime" },
                values: new object[] { new DateTime(2025, 1, 20, 18, 0, 34, 359, DateTimeKind.Utc).AddTicks(745), new DateTime(2025, 1, 20, 18, 0, 34, 359, DateTimeKind.Utc).AddTicks(4876) });

            migrationBuilder.UpdateData(
                table: "CashTransactions",
                keyColumn: "CashTransactionId",
                keyValue: 2,
                columns: new[] { "DateCreated", "TransactionTime" },
                values: new object[] { new DateTime(2025, 1, 20, 18, 0, 34, 359, DateTimeKind.Utc).AddTicks(7248), new DateTime(2025, 1, 20, 17, 30, 34, 359, DateTimeKind.Utc).AddTicks(7263) });

            migrationBuilder.UpdateData(
                table: "CashTransactions",
                keyColumn: "CashTransactionId",
                keyValue: 3,
                columns: new[] { "DateCreated", "TransactionTime" },
                values: new object[] { new DateTime(2025, 1, 20, 18, 0, 34, 359, DateTimeKind.Utc).AddTicks(7328), new DateTime(2025, 1, 20, 17, 0, 34, 359, DateTimeKind.Utc).AddTicks(7331) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 18, 0, 34, 328, DateTimeKind.Utc).AddTicks(3512));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 18, 0, 34, 328, DateTimeKind.Utc).AddTicks(5470));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 18, 0, 34, 328, DateTimeKind.Utc).AddTicks(5482));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 18, 0, 34, 328, DateTimeKind.Utc).AddTicks(5491));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 18, 0, 34, 328, DateTimeKind.Utc).AddTicks(5492));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 18, 0, 34, 328, DateTimeKind.Utc).AddTicks(5493));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 18, 0, 34, 328, DateTimeKind.Utc).AddTicks(5495));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 18, 0, 34, 328, DateTimeKind.Utc).AddTicks(5497));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 9,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 18, 0, 34, 328, DateTimeKind.Utc).AddTicks(5498));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 10,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 18, 0, 34, 328, DateTimeKind.Utc).AddTicks(5499));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 11,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 18, 0, 34, 328, DateTimeKind.Utc).AddTicks(5501));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 12,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 18, 0, 34, 328, DateTimeKind.Utc).AddTicks(5502));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 1, 20, 19, 0, 34, 355, DateTimeKind.Local).AddTicks(1247), new DateTime(2025, 1, 20, 19, 0, 34, 355, DateTimeKind.Local).AddTicks(3152) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 1, 20, 19, 0, 34, 355, DateTimeKind.Local).AddTicks(4983), new DateTime(2025, 1, 20, 19, 0, 34, 355, DateTimeKind.Local).AddTicks(4989) });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 18, 0, 34, 352, DateTimeKind.Utc).AddTicks(6068));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 18, 0, 34, 353, DateTimeKind.Utc).AddTicks(3155));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 18, 0, 34, 353, DateTimeKind.Utc).AddTicks(3181));

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "InventoryId",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 1, 20, 19, 0, 34, 360, DateTimeKind.Local).AddTicks(4593), new DateTime(2025, 1, 20, 19, 0, 34, 360, DateTimeKind.Local).AddTicks(8075) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "InventoryId",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 1, 20, 19, 0, 34, 361, DateTimeKind.Local).AddTicks(457), new DateTime(2025, 1, 20, 19, 0, 34, 361, DateTimeKind.Local).AddTicks(475) });

            migrationBuilder.UpdateData(
                table: "InventoryMouvements",
                keyColumn: "InventoryMouvementId",
                keyValue: 1,
                columns: new[] { "DateCreated", "MouvementDate" },
                values: new object[] { new DateTime(2025, 1, 20, 18, 0, 34, 361, DateTimeKind.Utc).AddTicks(3393), new DateTime(2025, 1, 20, 19, 0, 34, 361, DateTimeKind.Local).AddTicks(7364) });

            migrationBuilder.UpdateData(
                table: "InventoryMouvements",
                keyColumn: "InventoryMouvementId",
                keyValue: 2,
                columns: new[] { "DateCreated", "MouvementDate" },
                values: new object[] { new DateTime(2025, 1, 20, 18, 0, 34, 361, DateTimeKind.Utc).AddTicks(8505), new DateTime(2025, 1, 20, 19, 0, 34, 361, DateTimeKind.Local).AddTicks(8513) });

            migrationBuilder.UpdateData(
                table: "InventoryMouvements",
                keyColumn: "InventoryMouvementId",
                keyValue: 3,
                columns: new[] { "DateCreated", "MouvementDate" },
                values: new object[] { new DateTime(2025, 1, 20, 18, 0, 34, 361, DateTimeKind.Utc).AddTicks(8611), new DateTime(2025, 1, 20, 19, 0, 34, 361, DateTimeKind.Local).AddTicks(8616) });

            migrationBuilder.UpdateData(
                table: "Lines",
                keyColumn: "LineId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 18, 0, 34, 328, DateTimeKind.Utc).AddTicks(8857));

            migrationBuilder.UpdateData(
                table: "Lines",
                keyColumn: "LineId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 18, 0, 34, 329, DateTimeKind.Utc).AddTicks(520));

            migrationBuilder.UpdateData(
                table: "Lines",
                keyColumn: "LineId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 18, 0, 34, 329, DateTimeKind.Utc).AddTicks(523));

            migrationBuilder.UpdateData(
                table: "Lines",
                keyColumn: "LineId",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 18, 0, 34, 329, DateTimeKind.Utc).AddTicks(525));

            migrationBuilder.UpdateData(
                table: "Lines",
                keyColumn: "LineId",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 18, 0, 34, 329, DateTimeKind.Utc).AddTicks(526));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 1, 20, 19, 0, 34, 351, DateTimeKind.Local).AddTicks(8114), new DateTime(2025, 1, 20, 19, 0, 34, 351, DateTimeKind.Local).AddTicks(9723) });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 1, 20, 19, 0, 34, 352, DateTimeKind.Local).AddTicks(1353), new DateTime(2025, 1, 20, 19, 0, 34, 352, DateTimeKind.Local).AddTicks(1357) });

            migrationBuilder.UpdateData(
                table: "ProductBatchs",
                keyColumn: "ProductBatchId",
                keyValue: 1,
                columns: new[] { "ExpirationDate", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 7, 20, 18, 0, 34, 362, DateTimeKind.Utc).AddTicks(3957), new DateTime(2025, 1, 10, 18, 0, 34, 362, DateTimeKind.Utc).AddTicks(9889) });

            migrationBuilder.UpdateData(
                table: "ProductBatchs",
                keyColumn: "ProductBatchId",
                keyValue: 2,
                columns: new[] { "ExpirationDate", "ReceivedDate" },
                values: new object[] { new DateTime(2026, 1, 20, 18, 0, 34, 363, DateTimeKind.Utc).AddTicks(1676), new DateTime(2024, 12, 31, 18, 0, 34, 363, DateTimeKind.Utc).AddTicks(1688) });

            migrationBuilder.UpdateData(
                table: "ProductBatchs",
                keyColumn: "ProductBatchId",
                keyValue: 3,
                column: "ReceivedDate",
                value: new DateTime(2025, 1, 15, 18, 0, 34, 363, DateTimeKind.Utc).AddTicks(1696));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 1, 20, 19, 0, 34, 347, DateTimeKind.Local).AddTicks(999), new DateTime(2025, 1, 20, 19, 0, 34, 348, DateTimeKind.Local).AddTicks(9186) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 1, 20, 19, 0, 34, 349, DateTimeKind.Local).AddTicks(9192), new DateTime(2025, 1, 20, 19, 0, 34, 349, DateTimeKind.Local).AddTicks(9199) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 1, 20, 19, 0, 34, 349, DateTimeKind.Local).AddTicks(9422), new DateTime(2025, 1, 20, 19, 0, 34, 349, DateTimeKind.Local).AddTicks(9429) });

            migrationBuilder.UpdateData(
                table: "PurchaseItems",
                keyColumn: "PurchaseItemId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 18, 0, 34, 365, DateTimeKind.Utc).AddTicks(1892));

            migrationBuilder.UpdateData(
                table: "PurchaseItems",
                keyColumn: "PurchaseItemId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 18, 0, 34, 366, DateTimeKind.Utc).AddTicks(940));

            migrationBuilder.UpdateData(
                table: "PurchaseItems",
                keyColumn: "PurchaseItemId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 18, 0, 34, 366, DateTimeKind.Utc).AddTicks(984));

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: 1,
                columns: new[] { "DateCreated", "PurchaseDate" },
                values: new object[] { new DateTime(2025, 1, 20, 18, 0, 34, 363, DateTimeKind.Utc).AddTicks(5328), new DateTime(2025, 1, 10, 18, 0, 34, 363, DateTimeKind.Utc).AddTicks(6282) });

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: 2,
                columns: new[] { "DateCreated", "PurchaseDate" },
                values: new object[] { new DateTime(2025, 1, 20, 18, 0, 34, 364, DateTimeKind.Utc).AddTicks(8300), new DateTime(2025, 1, 15, 18, 0, 34, 364, DateTimeKind.Utc).AddTicks(8312) });

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: 3,
                columns: new[] { "DateCreated", "PurchaseDate" },
                values: new object[] { new DateTime(2025, 1, 20, 18, 0, 34, 364, DateTimeKind.Utc).AddTicks(8326), new DateTime(2025, 1, 20, 18, 0, 34, 364, DateTimeKind.Utc).AddTicks(8328) });

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: 4,
                columns: new[] { "DateCreated", "PurchaseDate" },
                values: new object[] { new DateTime(2025, 1, 20, 18, 0, 34, 364, DateTimeKind.Utc).AddTicks(8338), new DateTime(2025, 1, 20, 18, 0, 34, 364, DateTimeKind.Utc).AddTicks(8339) });

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: 5,
                columns: new[] { "DateCreated", "PurchaseDate" },
                values: new object[] { new DateTime(2025, 1, 20, 18, 0, 34, 364, DateTimeKind.Utc).AddTicks(8346), new DateTime(2025, 1, 20, 18, 0, 34, 364, DateTimeKind.Utc).AddTicks(8347) });

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: 6,
                columns: new[] { "DateCreated", "PurchaseDate" },
                values: new object[] { new DateTime(2025, 1, 20, 18, 0, 34, 364, DateTimeKind.Utc).AddTicks(8471), new DateTime(2025, 1, 20, 18, 0, 34, 364, DateTimeKind.Utc).AddTicks(8473) });

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: 7,
                columns: new[] { "DateCreated", "PurchaseDate" },
                values: new object[] { new DateTime(2025, 1, 20, 18, 0, 34, 364, DateTimeKind.Utc).AddTicks(8481), new DateTime(2025, 1, 20, 18, 0, 34, 364, DateTimeKind.Utc).AddTicks(8482) });

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: 8,
                columns: new[] { "DateCreated", "PurchaseDate" },
                values: new object[] { new DateTime(2025, 1, 20, 18, 0, 34, 364, DateTimeKind.Utc).AddTicks(8490), new DateTime(2025, 1, 20, 18, 0, 34, 364, DateTimeKind.Utc).AddTicks(8491) });

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: 9,
                columns: new[] { "DateCreated", "PurchaseDate" },
                values: new object[] { new DateTime(2025, 1, 20, 18, 0, 34, 364, DateTimeKind.Utc).AddTicks(8501), new DateTime(2025, 1, 20, 18, 0, 34, 364, DateTimeKind.Utc).AddTicks(8502) });

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: 10,
                columns: new[] { "DateCreated", "PurchaseDate" },
                values: new object[] { new DateTime(2025, 1, 20, 18, 0, 34, 364, DateTimeKind.Utc).AddTicks(8510), new DateTime(2025, 1, 20, 18, 0, 34, 364, DateTimeKind.Utc).AddTicks(8511) });

            migrationBuilder.UpdateData(
                table: "SaleItems",
                keyColumn: "SaleItemId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 18, 0, 34, 368, DateTimeKind.Utc).AddTicks(9813));

            migrationBuilder.UpdateData(
                table: "SaleItems",
                keyColumn: "SaleItemId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 18, 0, 34, 369, DateTimeKind.Utc).AddTicks(6755));

            migrationBuilder.UpdateData(
                table: "SaleItems",
                keyColumn: "SaleItemId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 18, 0, 34, 369, DateTimeKind.Utc).AddTicks(6772));

            migrationBuilder.UpdateData(
                table: "SaleItems",
                keyColumn: "SaleItemId",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 18, 0, 34, 369, DateTimeKind.Utc).AddTicks(6779));

            migrationBuilder.UpdateData(
                table: "SaleItems",
                keyColumn: "SaleItemId",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 18, 0, 34, 369, DateTimeKind.Utc).AddTicks(6783));

            migrationBuilder.UpdateData(
                table: "SaleItems",
                keyColumn: "SaleItemId",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 18, 0, 34, 369, DateTimeKind.Utc).AddTicks(6787));

            migrationBuilder.UpdateData(
                table: "SaleItems",
                keyColumn: "SaleItemId",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 18, 0, 34, 369, DateTimeKind.Utc).AddTicks(6881));

            migrationBuilder.UpdateData(
                table: "SaleItems",
                keyColumn: "SaleItemId",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 18, 0, 34, 369, DateTimeKind.Utc).AddTicks(6886));

            migrationBuilder.UpdateData(
                table: "SaleItems",
                keyColumn: "SaleItemId",
                keyValue: 9,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 18, 0, 34, 369, DateTimeKind.Utc).AddTicks(6891));

            migrationBuilder.UpdateData(
                table: "SaleItems",
                keyColumn: "SaleItemId",
                keyValue: 10,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 18, 0, 34, 369, DateTimeKind.Utc).AddTicks(6895));

            migrationBuilder.UpdateData(
                table: "SalePayments",
                keyColumn: "SalePaymentId",
                keyValue: 1,
                columns: new[] { "DateCreated", "PaymentDate" },
                values: new object[] { new DateTime(2025, 1, 20, 18, 0, 34, 370, DateTimeKind.Utc).AddTicks(711), new DateTime(2025, 1, 10, 18, 0, 34, 370, DateTimeKind.Utc).AddTicks(2428) });

            migrationBuilder.UpdateData(
                table: "SalePayments",
                keyColumn: "SalePaymentId",
                keyValue: 2,
                columns: new[] { "DateCreated", "PaymentDate" },
                values: new object[] { new DateTime(2025, 1, 20, 18, 0, 34, 370, DateTimeKind.Utc).AddTicks(6122), new DateTime(2025, 1, 15, 18, 0, 34, 370, DateTimeKind.Utc).AddTicks(6132) });

            migrationBuilder.UpdateData(
                table: "SalePayments",
                keyColumn: "SalePaymentId",
                keyValue: 3,
                columns: new[] { "DateCreated", "PaymentDate" },
                values: new object[] { new DateTime(2025, 1, 20, 18, 0, 34, 370, DateTimeKind.Utc).AddTicks(6144), new DateTime(2025, 1, 13, 18, 0, 34, 370, DateTimeKind.Utc).AddTicks(6146) });

            migrationBuilder.UpdateData(
                table: "SalePayments",
                keyColumn: "SalePaymentId",
                keyValue: 4,
                columns: new[] { "DateCreated", "PaymentDate" },
                values: new object[] { new DateTime(2025, 1, 20, 18, 0, 34, 370, DateTimeKind.Utc).AddTicks(6150), new DateTime(2025, 1, 17, 18, 0, 34, 370, DateTimeKind.Utc).AddTicks(6151) });

            migrationBuilder.UpdateData(
                table: "SalePayments",
                keyColumn: "SalePaymentId",
                keyValue: 5,
                columns: new[] { "DateCreated", "PaymentDate" },
                values: new object[] { new DateTime(2025, 1, 20, 18, 0, 34, 370, DateTimeKind.Utc).AddTicks(6154), new DateTime(2025, 1, 18, 18, 0, 34, 370, DateTimeKind.Utc).AddTicks(6156) });

            migrationBuilder.UpdateData(
                table: "SalePayments",
                keyColumn: "SalePaymentId",
                keyValue: 6,
                columns: new[] { "DateCreated", "PaymentDate" },
                values: new object[] { new DateTime(2025, 1, 20, 18, 0, 34, 370, DateTimeKind.Utc).AddTicks(6159), new DateTime(2025, 1, 19, 18, 0, 34, 370, DateTimeKind.Utc).AddTicks(6161) });

            migrationBuilder.UpdateData(
                table: "SalePayments",
                keyColumn: "SalePaymentId",
                keyValue: 7,
                columns: new[] { "DateCreated", "PaymentDate" },
                values: new object[] { new DateTime(2025, 1, 20, 18, 0, 34, 370, DateTimeKind.Utc).AddTicks(6165), new DateTime(2025, 1, 5, 18, 0, 34, 370, DateTimeKind.Utc).AddTicks(6166) });

            migrationBuilder.UpdateData(
                table: "SalePayments",
                keyColumn: "SalePaymentId",
                keyValue: 8,
                columns: new[] { "DateCreated", "PaymentDate" },
                values: new object[] { new DateTime(2025, 1, 20, 18, 0, 34, 370, DateTimeKind.Utc).AddTicks(6169), new DateTime(2025, 1, 10, 18, 0, 34, 370, DateTimeKind.Utc).AddTicks(6171) });

            migrationBuilder.UpdateData(
                table: "SalePayments",
                keyColumn: "SalePaymentId",
                keyValue: 9,
                columns: new[] { "DateCreated", "PaymentDate" },
                values: new object[] { new DateTime(2025, 1, 20, 18, 0, 34, 370, DateTimeKind.Utc).AddTicks(6174), new DateTime(2025, 1, 12, 18, 0, 34, 370, DateTimeKind.Utc).AddTicks(6175) });

            migrationBuilder.UpdateData(
                table: "SalePayments",
                keyColumn: "SalePaymentId",
                keyValue: 10,
                columns: new[] { "DateCreated", "PaymentDate" },
                values: new object[] { new DateTime(2025, 1, 20, 18, 0, 34, 370, DateTimeKind.Utc).AddTicks(6179), new DateTime(2025, 1, 20, 18, 0, 34, 370, DateTimeKind.Utc).AddTicks(6180) });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 18, 0, 34, 368, DateTimeKind.Utc).AddTicks(1290));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 18, 0, 34, 368, DateTimeKind.Utc).AddTicks(6407));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 18, 0, 34, 368, DateTimeKind.Utc).AddTicks(6434));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 18, 0, 34, 368, DateTimeKind.Utc).AddTicks(6459));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 18, 0, 34, 368, DateTimeKind.Utc).AddTicks(6483));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 18, 0, 34, 368, DateTimeKind.Utc).AddTicks(6507));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 18, 0, 34, 368, DateTimeKind.Utc).AddTicks(6532));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 18, 0, 34, 368, DateTimeKind.Utc).AddTicks(6684));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 9,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 18, 0, 34, 368, DateTimeKind.Utc).AddTicks(6697));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 10,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 18, 0, 34, 368, DateTimeKind.Utc).AddTicks(6789));

            migrationBuilder.UpdateData(
                table: "Shelfs",
                keyColumn: "ShelfId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 18, 0, 34, 329, DateTimeKind.Utc).AddTicks(3740));

            migrationBuilder.UpdateData(
                table: "Shelfs",
                keyColumn: "ShelfId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 18, 0, 34, 329, DateTimeKind.Utc).AddTicks(5399));

            migrationBuilder.UpdateData(
                table: "Shelfs",
                keyColumn: "ShelfId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 18, 0, 34, 329, DateTimeKind.Utc).AddTicks(5404));

            migrationBuilder.UpdateData(
                table: "Supplier",
                keyColumn: "SupplierId",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 1, 20, 19, 0, 34, 326, DateTimeKind.Local).AddTicks(1857), new DateTime(2025, 1, 20, 19, 0, 34, 326, DateTimeKind.Local).AddTicks(3186) });

            migrationBuilder.UpdateData(
                table: "Supplier",
                keyColumn: "SupplierId",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 1, 20, 19, 0, 34, 326, DateTimeKind.Local).AddTicks(4386), new DateTime(2025, 1, 20, 19, 0, 34, 326, DateTimeKind.Local).AddTicks(4392) });

            migrationBuilder.UpdateData(
                table: "Supplier",
                keyColumn: "SupplierId",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 1, 20, 19, 0, 34, 326, DateTimeKind.Local).AddTicks(4413), new DateTime(2025, 1, 20, 19, 0, 34, 326, DateTimeKind.Local).AddTicks(4418) });

            migrationBuilder.UpdateData(
                table: "Supplier",
                keyColumn: "SupplierId",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 1, 20, 19, 0, 34, 326, DateTimeKind.Local).AddTicks(4435), new DateTime(2025, 1, 20, 19, 0, 34, 326, DateTimeKind.Local).AddTicks(4440) });

            migrationBuilder.UpdateData(
                table: "Supplier",
                keyColumn: "SupplierId",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 1, 20, 19, 0, 34, 326, DateTimeKind.Local).AddTicks(4587), new DateTime(2025, 1, 20, 19, 0, 34, 326, DateTimeKind.Local).AddTicks(4593) });

            migrationBuilder.UpdateData(
                table: "Supplier",
                keyColumn: "SupplierId",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 1, 20, 19, 0, 34, 326, DateTimeKind.Local).AddTicks(4612), new DateTime(2025, 1, 20, 19, 0, 34, 326, DateTimeKind.Local).AddTicks(4617) });

            migrationBuilder.UpdateData(
                table: "Supplier",
                keyColumn: "SupplierId",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 1, 20, 19, 0, 34, 326, DateTimeKind.Local).AddTicks(4634), new DateTime(2025, 1, 20, 19, 0, 34, 326, DateTimeKind.Local).AddTicks(4639) });

            migrationBuilder.UpdateData(
                table: "Supplier",
                keyColumn: "SupplierId",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 1, 20, 19, 0, 34, 326, DateTimeKind.Local).AddTicks(4657), new DateTime(2025, 1, 20, 19, 0, 34, 326, DateTimeKind.Local).AddTicks(4724) });

            migrationBuilder.UpdateData(
                table: "Supplier",
                keyColumn: "SupplierId",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 1, 20, 19, 0, 34, 326, DateTimeKind.Local).AddTicks(4743), new DateTime(2025, 1, 20, 19, 0, 34, 326, DateTimeKind.Local).AddTicks(4748) });

            migrationBuilder.UpdateData(
                table: "Supplier",
                keyColumn: "SupplierId",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 1, 20, 19, 0, 34, 326, DateTimeKind.Local).AddTicks(4766), new DateTime(2025, 1, 20, 19, 0, 34, 326, DateTimeKind.Local).AddTicks(4771) });

            migrationBuilder.UpdateData(
                table: "Taxes",
                keyColumn: "TaxId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 18, 0, 34, 329, DateTimeKind.Utc).AddTicks(8274));

            migrationBuilder.UpdateData(
                table: "Taxes",
                keyColumn: "TaxId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 18, 0, 34, 330, DateTimeKind.Utc).AddTicks(949));

            migrationBuilder.UpdateData(
                table: "Taxes",
                keyColumn: "TaxId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 18, 0, 34, 330, DateTimeKind.Utc).AddTicks(1060));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "UnitId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 18, 0, 34, 330, DateTimeKind.Utc).AddTicks(4541));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "UnitId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 18, 0, 34, 331, DateTimeKind.Utc).AddTicks(7257));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "UnitId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 18, 0, 34, 331, DateTimeKind.Utc).AddTicks(7275));

            migrationBuilder.UpdateData(
                table: "purchasePayments",
                keyColumn: "PurchasePaymentId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 18, 0, 34, 366, DateTimeKind.Utc).AddTicks(8231));

            migrationBuilder.UpdateData(
                table: "purchasePayments",
                keyColumn: "PurchasePaymentId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 18, 0, 34, 367, DateTimeKind.Utc).AddTicks(8215));

            migrationBuilder.UpdateData(
                table: "purchasePayments",
                keyColumn: "PurchasePaymentId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 18, 0, 34, 367, DateTimeKind.Utc).AddTicks(8234));

            migrationBuilder.UpdateData(
                table: "purchasePayments",
                keyColumn: "PurchasePaymentId",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 18, 0, 34, 367, DateTimeKind.Utc).AddTicks(8239));

            migrationBuilder.UpdateData(
                table: "purchasePayments",
                keyColumn: "PurchasePaymentId",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 18, 0, 34, 367, DateTimeKind.Utc).AddTicks(8242));

            migrationBuilder.UpdateData(
                table: "purchasePayments",
                keyColumn: "PurchasePaymentId",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 18, 0, 34, 367, DateTimeKind.Utc).AddTicks(8247));

            migrationBuilder.UpdateData(
                table: "purchasePayments",
                keyColumn: "PurchasePaymentId",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 18, 0, 34, 367, DateTimeKind.Utc).AddTicks(8251));

            migrationBuilder.UpdateData(
                table: "purchasePayments",
                keyColumn: "PurchasePaymentId",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 18, 0, 34, 367, DateTimeKind.Utc).AddTicks(8254));

            migrationBuilder.UpdateData(
                table: "purchasePayments",
                keyColumn: "PurchasePaymentId",
                keyValue: 9,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 18, 0, 34, 367, DateTimeKind.Utc).AddTicks(8258));

            migrationBuilder.UpdateData(
                table: "purchasePayments",
                keyColumn: "PurchasePaymentId",
                keyValue: 10,
                column: "DateCreated",
                value: new DateTime(2025, 1, 20, 18, 0, 34, 367, DateTimeKind.Utc).AddTicks(8262));
        }
    }
}
