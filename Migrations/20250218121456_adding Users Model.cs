using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryTrackApi.Migrations
{
    /// <inheritdoc />
    public partial class addingUsersModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "CashRegisterId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 2, 18, 12, 14, 42, 389, DateTimeKind.Utc).AddTicks(3534));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "CashRegisterId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 2, 18, 12, 14, 42, 389, DateTimeKind.Utc).AddTicks(3953));

            migrationBuilder.UpdateData(
                table: "CashShifts",
                keyColumn: "CashShiftId",
                keyValue: 1,
                columns: new[] { "DateCreated", "ShiftDate", "ShiftStart" },
                values: new object[] { new DateTime(2025, 2, 18, 12, 14, 42, 389, DateTimeKind.Utc).AddTicks(4302), new DateTime(2025, 2, 18, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 2, 18, 12, 14, 42, 389, DateTimeKind.Utc).AddTicks(4493) });

            migrationBuilder.UpdateData(
                table: "CashShifts",
                keyColumn: "CashShiftId",
                keyValue: 2,
                columns: new[] { "DateCreated", "ShiftDate", "ShiftStart" },
                values: new object[] { new DateTime(2025, 2, 18, 12, 14, 42, 389, DateTimeKind.Utc).AddTicks(5317), new DateTime(2025, 2, 19, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 2, 19, 12, 14, 42, 389, DateTimeKind.Utc).AddTicks(5338) });

            migrationBuilder.UpdateData(
                table: "CashTransactions",
                keyColumn: "CashTransactionId",
                keyValue: 1,
                columns: new[] { "DateCreated", "TransactionTime" },
                values: new object[] { new DateTime(2025, 2, 18, 12, 14, 42, 389, DateTimeKind.Utc).AddTicks(5748), new DateTime(2025, 2, 18, 12, 14, 42, 389, DateTimeKind.Utc).AddTicks(6119) });

            migrationBuilder.UpdateData(
                table: "CashTransactions",
                keyColumn: "CashTransactionId",
                keyValue: 2,
                columns: new[] { "DateCreated", "TransactionTime" },
                values: new object[] { new DateTime(2025, 2, 18, 12, 14, 42, 389, DateTimeKind.Utc).AddTicks(6290), new DateTime(2025, 2, 18, 11, 44, 42, 389, DateTimeKind.Utc).AddTicks(6292) });

            migrationBuilder.UpdateData(
                table: "CashTransactions",
                keyColumn: "CashTransactionId",
                keyValue: 3,
                columns: new[] { "DateCreated", "TransactionTime" },
                values: new object[] { new DateTime(2025, 2, 18, 12, 14, 42, 389, DateTimeKind.Utc).AddTicks(6299), new DateTime(2025, 2, 18, 11, 14, 42, 389, DateTimeKind.Utc).AddTicks(6300) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 2, 18, 12, 14, 42, 387, DateTimeKind.Utc).AddTicks(1450));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 2, 18, 12, 14, 42, 387, DateTimeKind.Utc).AddTicks(1780));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 2, 18, 12, 14, 42, 387, DateTimeKind.Utc).AddTicks(1782));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2025, 2, 18, 12, 14, 42, 387, DateTimeKind.Utc).AddTicks(1782));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2025, 2, 18, 12, 14, 42, 387, DateTimeKind.Utc).AddTicks(1783));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2025, 2, 18, 12, 14, 42, 387, DateTimeKind.Utc).AddTicks(1784));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2025, 2, 18, 12, 14, 42, 387, DateTimeKind.Utc).AddTicks(1785));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2025, 2, 18, 12, 14, 42, 387, DateTimeKind.Utc).AddTicks(1786));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 9,
                column: "DateCreated",
                value: new DateTime(2025, 2, 18, 12, 14, 42, 387, DateTimeKind.Utc).AddTicks(1786));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 10,
                column: "DateCreated",
                value: new DateTime(2025, 2, 18, 12, 14, 42, 387, DateTimeKind.Utc).AddTicks(1787));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 11,
                column: "DateCreated",
                value: new DateTime(2025, 2, 18, 12, 14, 42, 387, DateTimeKind.Utc).AddTicks(1788));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 12,
                column: "DateCreated",
                value: new DateTime(2025, 2, 18, 12, 14, 42, 387, DateTimeKind.Utc).AddTicks(1788));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 2, 18, 13, 14, 42, 389, DateTimeKind.Local).AddTicks(2887), new DateTime(2025, 2, 18, 13, 14, 42, 389, DateTimeKind.Local).AddTicks(3057) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 2, 18, 13, 14, 42, 389, DateTimeKind.Local).AddTicks(3228), new DateTime(2025, 2, 18, 13, 14, 42, 389, DateTimeKind.Local).AddTicks(3229) });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 2, 18, 12, 14, 42, 389, DateTimeKind.Utc).AddTicks(542));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 2, 18, 12, 14, 42, 389, DateTimeKind.Utc).AddTicks(1284));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 2, 18, 12, 14, 42, 389, DateTimeKind.Utc).AddTicks(1286));

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "InventoryId",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 2, 18, 13, 14, 42, 389, DateTimeKind.Local).AddTicks(6986), new DateTime(2025, 2, 18, 13, 14, 42, 389, DateTimeKind.Local).AddTicks(7179) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "InventoryId",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 2, 18, 13, 14, 42, 389, DateTimeKind.Local).AddTicks(7441), new DateTime(2025, 2, 18, 13, 14, 42, 389, DateTimeKind.Local).AddTicks(7442) });

            migrationBuilder.UpdateData(
                table: "InventoryMouvements",
                keyColumn: "InventoryMouvementId",
                keyValue: 1,
                columns: new[] { "DateCreated", "MouvementDate" },
                values: new object[] { new DateTime(2025, 2, 18, 12, 14, 42, 389, DateTimeKind.Utc).AddTicks(7902), new DateTime(2025, 2, 18, 13, 14, 42, 389, DateTimeKind.Local).AddTicks(8436) });

            migrationBuilder.UpdateData(
                table: "InventoryMouvements",
                keyColumn: "InventoryMouvementId",
                keyValue: 2,
                columns: new[] { "DateCreated", "MouvementDate" },
                values: new object[] { new DateTime(2025, 2, 18, 12, 14, 42, 389, DateTimeKind.Utc).AddTicks(8566), new DateTime(2025, 2, 18, 13, 14, 42, 389, DateTimeKind.Local).AddTicks(8587) });

            migrationBuilder.UpdateData(
                table: "InventoryMouvements",
                keyColumn: "InventoryMouvementId",
                keyValue: 3,
                columns: new[] { "DateCreated", "MouvementDate" },
                values: new object[] { new DateTime(2025, 2, 18, 12, 14, 42, 389, DateTimeKind.Utc).AddTicks(8591), new DateTime(2025, 2, 18, 13, 14, 42, 389, DateTimeKind.Local).AddTicks(8594) });

            migrationBuilder.UpdateData(
                table: "Lines",
                keyColumn: "LineId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 2, 18, 12, 14, 42, 387, DateTimeKind.Utc).AddTicks(2204));

            migrationBuilder.UpdateData(
                table: "Lines",
                keyColumn: "LineId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 2, 18, 12, 14, 42, 387, DateTimeKind.Utc).AddTicks(2430));

            migrationBuilder.UpdateData(
                table: "Lines",
                keyColumn: "LineId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 2, 18, 12, 14, 42, 387, DateTimeKind.Utc).AddTicks(2431));

            migrationBuilder.UpdateData(
                table: "Lines",
                keyColumn: "LineId",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2025, 2, 18, 12, 14, 42, 387, DateTimeKind.Utc).AddTicks(2432));

            migrationBuilder.UpdateData(
                table: "Lines",
                keyColumn: "LineId",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2025, 2, 18, 12, 14, 42, 387, DateTimeKind.Utc).AddTicks(2432));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 2, 18, 13, 14, 42, 388, DateTimeKind.Local).AddTicks(9703), new DateTime(2025, 2, 18, 13, 14, 42, 388, DateTimeKind.Local).AddTicks(9900) });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 2, 18, 13, 14, 42, 389, DateTimeKind.Local).AddTicks(138), new DateTime(2025, 2, 18, 13, 14, 42, 389, DateTimeKind.Local).AddTicks(140) });

            migrationBuilder.UpdateData(
                table: "ProductBatchs",
                keyColumn: "ProductBatchId",
                keyValue: 1,
                columns: new[] { "ExpirationDate", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 8, 18, 12, 14, 42, 389, DateTimeKind.Utc).AddTicks(9661), new DateTime(2025, 2, 8, 12, 14, 42, 391, DateTimeKind.Utc).AddTicks(7295) });

            migrationBuilder.UpdateData(
                table: "ProductBatchs",
                keyColumn: "ProductBatchId",
                keyValue: 2,
                columns: new[] { "ExpirationDate", "ReceivedDate" },
                values: new object[] { new DateTime(2026, 2, 18, 12, 14, 42, 391, DateTimeKind.Utc).AddTicks(7540), new DateTime(2025, 1, 29, 12, 14, 42, 391, DateTimeKind.Utc).AddTicks(7543) });

            migrationBuilder.UpdateData(
                table: "ProductBatchs",
                keyColumn: "ProductBatchId",
                keyValue: 3,
                column: "ReceivedDate",
                value: new DateTime(2025, 2, 13, 12, 14, 42, 391, DateTimeKind.Utc).AddTicks(7546));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 2, 18, 13, 14, 42, 388, DateTimeKind.Local).AddTicks(6786), new DateTime(2025, 2, 18, 13, 14, 42, 388, DateTimeKind.Local).AddTicks(7059) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 2, 18, 13, 14, 42, 388, DateTimeKind.Local).AddTicks(7721), new DateTime(2025, 2, 18, 13, 14, 42, 388, DateTimeKind.Local).AddTicks(7723) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 2, 18, 13, 14, 42, 388, DateTimeKind.Local).AddTicks(7749), new DateTime(2025, 2, 18, 13, 14, 42, 388, DateTimeKind.Local).AddTicks(7750) });

            migrationBuilder.UpdateData(
                table: "PurchaseItems",
                keyColumn: "PurchaseItemId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 2, 18, 12, 14, 42, 392, DateTimeKind.Utc).AddTicks(2447));

            migrationBuilder.UpdateData(
                table: "PurchaseItems",
                keyColumn: "PurchaseItemId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 2, 18, 12, 14, 42, 392, DateTimeKind.Utc).AddTicks(3208));

            migrationBuilder.UpdateData(
                table: "PurchaseItems",
                keyColumn: "PurchaseItemId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 2, 18, 12, 14, 42, 392, DateTimeKind.Utc).AddTicks(3211));

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: 1,
                columns: new[] { "DateCreated", "PurchaseDate" },
                values: new object[] { new DateTime(2025, 2, 18, 12, 14, 42, 391, DateTimeKind.Utc).AddTicks(8157), new DateTime(2025, 2, 8, 12, 14, 42, 391, DateTimeKind.Utc).AddTicks(8284) });

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: 2,
                columns: new[] { "DateCreated", "PurchaseDate" },
                values: new object[] { new DateTime(2025, 2, 18, 12, 14, 42, 392, DateTimeKind.Utc).AddTicks(1411), new DateTime(2025, 2, 13, 12, 14, 42, 392, DateTimeKind.Utc).AddTicks(1413) });

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: 3,
                columns: new[] { "DateCreated", "PurchaseDate" },
                values: new object[] { new DateTime(2025, 2, 18, 12, 14, 42, 392, DateTimeKind.Utc).AddTicks(1422), new DateTime(2025, 2, 18, 12, 14, 42, 392, DateTimeKind.Utc).AddTicks(1424) });

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: 4,
                columns: new[] { "DateCreated", "PurchaseDate" },
                values: new object[] { new DateTime(2025, 2, 18, 12, 14, 42, 392, DateTimeKind.Utc).AddTicks(1429), new DateTime(2025, 2, 18, 12, 14, 42, 392, DateTimeKind.Utc).AddTicks(1430) });

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: 5,
                columns: new[] { "DateCreated", "PurchaseDate" },
                values: new object[] { new DateTime(2025, 2, 18, 12, 14, 42, 392, DateTimeKind.Utc).AddTicks(1436), new DateTime(2025, 2, 18, 12, 14, 42, 392, DateTimeKind.Utc).AddTicks(1437) });

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: 6,
                columns: new[] { "DateCreated", "PurchaseDate" },
                values: new object[] { new DateTime(2025, 2, 18, 12, 14, 42, 392, DateTimeKind.Utc).AddTicks(1463), new DateTime(2025, 2, 18, 12, 14, 42, 392, DateTimeKind.Utc).AddTicks(1464) });

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: 7,
                columns: new[] { "DateCreated", "PurchaseDate" },
                values: new object[] { new DateTime(2025, 2, 18, 12, 14, 42, 392, DateTimeKind.Utc).AddTicks(1469), new DateTime(2025, 2, 18, 12, 14, 42, 392, DateTimeKind.Utc).AddTicks(1470) });

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: 8,
                columns: new[] { "DateCreated", "PurchaseDate" },
                values: new object[] { new DateTime(2025, 2, 18, 12, 14, 42, 392, DateTimeKind.Utc).AddTicks(1476), new DateTime(2025, 2, 18, 12, 14, 42, 392, DateTimeKind.Utc).AddTicks(1477) });

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: 9,
                columns: new[] { "DateCreated", "PurchaseDate" },
                values: new object[] { new DateTime(2025, 2, 18, 12, 14, 42, 392, DateTimeKind.Utc).AddTicks(1482), new DateTime(2025, 2, 18, 12, 14, 42, 392, DateTimeKind.Utc).AddTicks(1483) });

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: 10,
                columns: new[] { "DateCreated", "PurchaseDate" },
                values: new object[] { new DateTime(2025, 2, 18, 12, 14, 42, 392, DateTimeKind.Utc).AddTicks(1488), new DateTime(2025, 2, 18, 12, 14, 42, 392, DateTimeKind.Utc).AddTicks(1489) });

            migrationBuilder.UpdateData(
                table: "SaleItems",
                keyColumn: "SaleItemId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 2, 18, 12, 14, 42, 392, DateTimeKind.Utc).AddTicks(7822));

            migrationBuilder.UpdateData(
                table: "SaleItems",
                keyColumn: "SaleItemId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 2, 18, 12, 14, 42, 392, DateTimeKind.Utc).AddTicks(8537));

            migrationBuilder.UpdateData(
                table: "SaleItems",
                keyColumn: "SaleItemId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 2, 18, 12, 14, 42, 392, DateTimeKind.Utc).AddTicks(8540));

            migrationBuilder.UpdateData(
                table: "SaleItems",
                keyColumn: "SaleItemId",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2025, 2, 18, 12, 14, 42, 392, DateTimeKind.Utc).AddTicks(8542));

            migrationBuilder.UpdateData(
                table: "SaleItems",
                keyColumn: "SaleItemId",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2025, 2, 18, 12, 14, 42, 392, DateTimeKind.Utc).AddTicks(8544));

            migrationBuilder.UpdateData(
                table: "SaleItems",
                keyColumn: "SaleItemId",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2025, 2, 18, 12, 14, 42, 392, DateTimeKind.Utc).AddTicks(8546));

            migrationBuilder.UpdateData(
                table: "SaleItems",
                keyColumn: "SaleItemId",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2025, 2, 18, 12, 14, 42, 392, DateTimeKind.Utc).AddTicks(8558));

            migrationBuilder.UpdateData(
                table: "SaleItems",
                keyColumn: "SaleItemId",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2025, 2, 18, 12, 14, 42, 392, DateTimeKind.Utc).AddTicks(8560));

            migrationBuilder.UpdateData(
                table: "SaleItems",
                keyColumn: "SaleItemId",
                keyValue: 9,
                column: "DateCreated",
                value: new DateTime(2025, 2, 18, 12, 14, 42, 392, DateTimeKind.Utc).AddTicks(8562));

            migrationBuilder.UpdateData(
                table: "SaleItems",
                keyColumn: "SaleItemId",
                keyValue: 10,
                column: "DateCreated",
                value: new DateTime(2025, 2, 18, 12, 14, 42, 392, DateTimeKind.Utc).AddTicks(8565));

            migrationBuilder.UpdateData(
                table: "SalePayments",
                keyColumn: "SalePaymentId",
                keyValue: 1,
                columns: new[] { "DateCreated", "PaymentDate" },
                values: new object[] { new DateTime(2025, 2, 18, 12, 14, 42, 392, DateTimeKind.Utc).AddTicks(8916), new DateTime(2025, 2, 8, 12, 14, 42, 392, DateTimeKind.Utc).AddTicks(9110) });

            migrationBuilder.UpdateData(
                table: "SalePayments",
                keyColumn: "SalePaymentId",
                keyValue: 2,
                columns: new[] { "DateCreated", "PaymentDate" },
                values: new object[] { new DateTime(2025, 2, 18, 12, 14, 42, 392, DateTimeKind.Utc).AddTicks(9432), new DateTime(2025, 2, 13, 12, 14, 42, 392, DateTimeKind.Utc).AddTicks(9433) });

            migrationBuilder.UpdateData(
                table: "SalePayments",
                keyColumn: "SalePaymentId",
                keyValue: 3,
                columns: new[] { "DateCreated", "PaymentDate" },
                values: new object[] { new DateTime(2025, 2, 18, 12, 14, 42, 392, DateTimeKind.Utc).AddTicks(9435), new DateTime(2025, 2, 11, 12, 14, 42, 392, DateTimeKind.Utc).AddTicks(9436) });

            migrationBuilder.UpdateData(
                table: "SalePayments",
                keyColumn: "SalePaymentId",
                keyValue: 4,
                columns: new[] { "DateCreated", "PaymentDate" },
                values: new object[] { new DateTime(2025, 2, 18, 12, 14, 42, 392, DateTimeKind.Utc).AddTicks(9437), new DateTime(2025, 2, 15, 12, 14, 42, 392, DateTimeKind.Utc).AddTicks(9438) });

            migrationBuilder.UpdateData(
                table: "SalePayments",
                keyColumn: "SalePaymentId",
                keyValue: 5,
                columns: new[] { "DateCreated", "PaymentDate" },
                values: new object[] { new DateTime(2025, 2, 18, 12, 14, 42, 392, DateTimeKind.Utc).AddTicks(9439), new DateTime(2025, 2, 16, 12, 14, 42, 392, DateTimeKind.Utc).AddTicks(9440) });

            migrationBuilder.UpdateData(
                table: "SalePayments",
                keyColumn: "SalePaymentId",
                keyValue: 6,
                columns: new[] { "DateCreated", "PaymentDate" },
                values: new object[] { new DateTime(2025, 2, 18, 12, 14, 42, 392, DateTimeKind.Utc).AddTicks(9442), new DateTime(2025, 2, 17, 12, 14, 42, 392, DateTimeKind.Utc).AddTicks(9442) });

            migrationBuilder.UpdateData(
                table: "SalePayments",
                keyColumn: "SalePaymentId",
                keyValue: 7,
                columns: new[] { "DateCreated", "PaymentDate" },
                values: new object[] { new DateTime(2025, 2, 18, 12, 14, 42, 392, DateTimeKind.Utc).AddTicks(9444), new DateTime(2025, 2, 3, 12, 14, 42, 392, DateTimeKind.Utc).AddTicks(9444) });

            migrationBuilder.UpdateData(
                table: "SalePayments",
                keyColumn: "SalePaymentId",
                keyValue: 8,
                columns: new[] { "DateCreated", "PaymentDate" },
                values: new object[] { new DateTime(2025, 2, 18, 12, 14, 42, 392, DateTimeKind.Utc).AddTicks(9446), new DateTime(2025, 2, 8, 12, 14, 42, 392, DateTimeKind.Utc).AddTicks(9446) });

            migrationBuilder.UpdateData(
                table: "SalePayments",
                keyColumn: "SalePaymentId",
                keyValue: 9,
                columns: new[] { "DateCreated", "PaymentDate" },
                values: new object[] { new DateTime(2025, 2, 18, 12, 14, 42, 392, DateTimeKind.Utc).AddTicks(9448), new DateTime(2025, 2, 10, 12, 14, 42, 392, DateTimeKind.Utc).AddTicks(9448) });

            migrationBuilder.UpdateData(
                table: "SalePayments",
                keyColumn: "SalePaymentId",
                keyValue: 10,
                columns: new[] { "DateCreated", "PaymentDate" },
                values: new object[] { new DateTime(2025, 2, 18, 12, 14, 42, 392, DateTimeKind.Utc).AddTicks(9450), new DateTime(2025, 2, 18, 12, 14, 42, 392, DateTimeKind.Utc).AddTicks(9450) });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 2, 18, 12, 14, 42, 392, DateTimeKind.Utc).AddTicks(6687));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 2, 18, 12, 14, 42, 392, DateTimeKind.Utc).AddTicks(7357));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 2, 18, 12, 14, 42, 392, DateTimeKind.Utc).AddTicks(7361));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2025, 2, 18, 12, 14, 42, 392, DateTimeKind.Utc).AddTicks(7365));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2025, 2, 18, 12, 14, 42, 392, DateTimeKind.Utc).AddTicks(7368));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2025, 2, 18, 12, 14, 42, 392, DateTimeKind.Utc).AddTicks(7371));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2025, 2, 18, 12, 14, 42, 392, DateTimeKind.Utc).AddTicks(7374));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2025, 2, 18, 12, 14, 42, 392, DateTimeKind.Utc).AddTicks(7414));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 9,
                column: "DateCreated",
                value: new DateTime(2025, 2, 18, 12, 14, 42, 392, DateTimeKind.Utc).AddTicks(7417));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 10,
                column: "DateCreated",
                value: new DateTime(2025, 2, 18, 12, 14, 42, 392, DateTimeKind.Utc).AddTicks(7429));

            migrationBuilder.UpdateData(
                table: "Shelfs",
                keyColumn: "ShelfId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 2, 18, 12, 14, 42, 387, DateTimeKind.Utc).AddTicks(2729));

            migrationBuilder.UpdateData(
                table: "Shelfs",
                keyColumn: "ShelfId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 2, 18, 12, 14, 42, 387, DateTimeKind.Utc).AddTicks(2922));

            migrationBuilder.UpdateData(
                table: "Shelfs",
                keyColumn: "ShelfId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 2, 18, 12, 14, 42, 387, DateTimeKind.Utc).AddTicks(2923));

            migrationBuilder.UpdateData(
                table: "Supplier",
                keyColumn: "SupplierId",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 2, 18, 13, 14, 42, 385, DateTimeKind.Local).AddTicks(4075), new DateTime(2025, 2, 18, 13, 14, 42, 385, DateTimeKind.Local).AddTicks(4316) });

            migrationBuilder.UpdateData(
                table: "Supplier",
                keyColumn: "SupplierId",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 2, 18, 13, 14, 42, 385, DateTimeKind.Local).AddTicks(4503), new DateTime(2025, 2, 18, 13, 14, 42, 385, DateTimeKind.Local).AddTicks(4504) });

            migrationBuilder.UpdateData(
                table: "Supplier",
                keyColumn: "SupplierId",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 2, 18, 13, 14, 42, 385, DateTimeKind.Local).AddTicks(4510), new DateTime(2025, 2, 18, 13, 14, 42, 385, DateTimeKind.Local).AddTicks(4511) });

            migrationBuilder.UpdateData(
                table: "Supplier",
                keyColumn: "SupplierId",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 2, 18, 13, 14, 42, 385, DateTimeKind.Local).AddTicks(4516), new DateTime(2025, 2, 18, 13, 14, 42, 385, DateTimeKind.Local).AddTicks(4518) });

            migrationBuilder.UpdateData(
                table: "Supplier",
                keyColumn: "SupplierId",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 2, 18, 13, 14, 42, 385, DateTimeKind.Local).AddTicks(4560), new DateTime(2025, 2, 18, 13, 14, 42, 385, DateTimeKind.Local).AddTicks(4561) });

            migrationBuilder.UpdateData(
                table: "Supplier",
                keyColumn: "SupplierId",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 2, 18, 13, 14, 42, 385, DateTimeKind.Local).AddTicks(4565), new DateTime(2025, 2, 18, 13, 14, 42, 385, DateTimeKind.Local).AddTicks(4567) });

            migrationBuilder.UpdateData(
                table: "Supplier",
                keyColumn: "SupplierId",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 2, 18, 13, 14, 42, 385, DateTimeKind.Local).AddTicks(4571), new DateTime(2025, 2, 18, 13, 14, 42, 385, DateTimeKind.Local).AddTicks(4573) });

            migrationBuilder.UpdateData(
                table: "Supplier",
                keyColumn: "SupplierId",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 2, 18, 13, 14, 42, 385, DateTimeKind.Local).AddTicks(4588), new DateTime(2025, 2, 18, 13, 14, 42, 385, DateTimeKind.Local).AddTicks(4590) });

            migrationBuilder.UpdateData(
                table: "Supplier",
                keyColumn: "SupplierId",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 2, 18, 13, 14, 42, 385, DateTimeKind.Local).AddTicks(4594), new DateTime(2025, 2, 18, 13, 14, 42, 385, DateTimeKind.Local).AddTicks(4596) });

            migrationBuilder.UpdateData(
                table: "Supplier",
                keyColumn: "SupplierId",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 2, 18, 13, 14, 42, 385, DateTimeKind.Local).AddTicks(4600), new DateTime(2025, 2, 18, 13, 14, 42, 385, DateTimeKind.Local).AddTicks(4601) });

            migrationBuilder.UpdateData(
                table: "Taxes",
                keyColumn: "TaxId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 2, 18, 12, 14, 42, 387, DateTimeKind.Utc).AddTicks(3233));

            migrationBuilder.UpdateData(
                table: "Taxes",
                keyColumn: "TaxId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 2, 18, 12, 14, 42, 387, DateTimeKind.Utc).AddTicks(3491));

            migrationBuilder.UpdateData(
                table: "Taxes",
                keyColumn: "TaxId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 2, 18, 12, 14, 42, 387, DateTimeKind.Utc).AddTicks(3492));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "UnitId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 2, 18, 12, 14, 42, 387, DateTimeKind.Utc).AddTicks(3760));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "UnitId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 2, 18, 12, 14, 42, 387, DateTimeKind.Utc).AddTicks(3940));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "UnitId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 2, 18, 12, 14, 42, 387, DateTimeKind.Utc).AddTicks(3941));

            migrationBuilder.UpdateData(
                table: "purchasePayments",
                keyColumn: "PurchasePaymentId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 2, 18, 12, 14, 42, 392, DateTimeKind.Utc).AddTicks(3600));

            migrationBuilder.UpdateData(
                table: "purchasePayments",
                keyColumn: "PurchasePaymentId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 2, 18, 12, 14, 42, 392, DateTimeKind.Utc).AddTicks(6145));

            migrationBuilder.UpdateData(
                table: "purchasePayments",
                keyColumn: "PurchasePaymentId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 2, 18, 12, 14, 42, 392, DateTimeKind.Utc).AddTicks(6148));

            migrationBuilder.UpdateData(
                table: "purchasePayments",
                keyColumn: "PurchasePaymentId",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2025, 2, 18, 12, 14, 42, 392, DateTimeKind.Utc).AddTicks(6150));

            migrationBuilder.UpdateData(
                table: "purchasePayments",
                keyColumn: "PurchasePaymentId",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2025, 2, 18, 12, 14, 42, 392, DateTimeKind.Utc).AddTicks(6152));

            migrationBuilder.UpdateData(
                table: "purchasePayments",
                keyColumn: "PurchasePaymentId",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2025, 2, 18, 12, 14, 42, 392, DateTimeKind.Utc).AddTicks(6154));

            migrationBuilder.UpdateData(
                table: "purchasePayments",
                keyColumn: "PurchasePaymentId",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2025, 2, 18, 12, 14, 42, 392, DateTimeKind.Utc).AddTicks(6156));

            migrationBuilder.UpdateData(
                table: "purchasePayments",
                keyColumn: "PurchasePaymentId",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2025, 2, 18, 12, 14, 42, 392, DateTimeKind.Utc).AddTicks(6157));

            migrationBuilder.UpdateData(
                table: "purchasePayments",
                keyColumn: "PurchasePaymentId",
                keyValue: 9,
                column: "DateCreated",
                value: new DateTime(2025, 2, 18, 12, 14, 42, 392, DateTimeKind.Utc).AddTicks(6159));

            migrationBuilder.UpdateData(
                table: "purchasePayments",
                keyColumn: "PurchasePaymentId",
                keyValue: 10,
                column: "DateCreated",
                value: new DateTime(2025, 2, 18, 12, 14, 42, 392, DateTimeKind.Utc).AddTicks(6161));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "CashRegisterId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 2, 11, 18, 53, 37, 448, DateTimeKind.Utc).AddTicks(7833));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "CashRegisterId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 2, 11, 18, 53, 37, 448, DateTimeKind.Utc).AddTicks(9680));

            migrationBuilder.UpdateData(
                table: "CashShifts",
                keyColumn: "CashShiftId",
                keyValue: 1,
                columns: new[] { "DateCreated", "ShiftDate", "ShiftStart" },
                values: new object[] { new DateTime(2025, 2, 11, 18, 53, 37, 449, DateTimeKind.Utc).AddTicks(766), new DateTime(2025, 2, 11, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 2, 11, 18, 53, 37, 449, DateTimeKind.Utc).AddTicks(1649) });

            migrationBuilder.UpdateData(
                table: "CashShifts",
                keyColumn: "CashShiftId",
                keyValue: 2,
                columns: new[] { "DateCreated", "ShiftDate", "ShiftStart" },
                values: new object[] { new DateTime(2025, 2, 11, 18, 53, 37, 449, DateTimeKind.Utc).AddTicks(5030), new DateTime(2025, 2, 12, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 2, 12, 18, 53, 37, 449, DateTimeKind.Utc).AddTicks(5076) });

            migrationBuilder.UpdateData(
                table: "CashTransactions",
                keyColumn: "CashTransactionId",
                keyValue: 1,
                columns: new[] { "DateCreated", "TransactionTime" },
                values: new object[] { new DateTime(2025, 2, 11, 18, 53, 37, 449, DateTimeKind.Utc).AddTicks(6541), new DateTime(2025, 2, 11, 18, 53, 37, 449, DateTimeKind.Utc).AddTicks(8092) });

            migrationBuilder.UpdateData(
                table: "CashTransactions",
                keyColumn: "CashTransactionId",
                keyValue: 2,
                columns: new[] { "DateCreated", "TransactionTime" },
                values: new object[] { new DateTime(2025, 2, 11, 18, 53, 37, 449, DateTimeKind.Utc).AddTicks(8627), new DateTime(2025, 2, 11, 18, 23, 37, 449, DateTimeKind.Utc).AddTicks(8630) });

            migrationBuilder.UpdateData(
                table: "CashTransactions",
                keyColumn: "CashTransactionId",
                keyValue: 3,
                columns: new[] { "DateCreated", "TransactionTime" },
                values: new object[] { new DateTime(2025, 2, 11, 18, 53, 37, 449, DateTimeKind.Utc).AddTicks(8808), new DateTime(2025, 2, 11, 17, 53, 37, 449, DateTimeKind.Utc).AddTicks(8810) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 2, 11, 18, 53, 37, 444, DateTimeKind.Utc).AddTicks(7785));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 2, 11, 18, 53, 37, 444, DateTimeKind.Utc).AddTicks(8556));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 2, 11, 18, 53, 37, 444, DateTimeKind.Utc).AddTicks(8558));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2025, 2, 11, 18, 53, 37, 444, DateTimeKind.Utc).AddTicks(8559));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2025, 2, 11, 18, 53, 37, 444, DateTimeKind.Utc).AddTicks(8562));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2025, 2, 11, 18, 53, 37, 444, DateTimeKind.Utc).AddTicks(8563));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2025, 2, 11, 18, 53, 37, 444, DateTimeKind.Utc).AddTicks(8563));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2025, 2, 11, 18, 53, 37, 444, DateTimeKind.Utc).AddTicks(8564));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 9,
                column: "DateCreated",
                value: new DateTime(2025, 2, 11, 18, 53, 37, 444, DateTimeKind.Utc).AddTicks(8565));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 10,
                column: "DateCreated",
                value: new DateTime(2025, 2, 11, 18, 53, 37, 444, DateTimeKind.Utc).AddTicks(8566));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 11,
                column: "DateCreated",
                value: new DateTime(2025, 2, 11, 18, 53, 37, 444, DateTimeKind.Utc).AddTicks(8567));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 12,
                column: "DateCreated",
                value: new DateTime(2025, 2, 11, 18, 53, 37, 444, DateTimeKind.Utc).AddTicks(8567));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 2, 11, 19, 53, 37, 448, DateTimeKind.Local).AddTicks(5258), new DateTime(2025, 2, 11, 19, 53, 37, 448, DateTimeKind.Local).AddTicks(5923) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 2, 11, 19, 53, 37, 448, DateTimeKind.Local).AddTicks(6580), new DateTime(2025, 2, 11, 19, 53, 37, 448, DateTimeKind.Local).AddTicks(6582) });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 2, 11, 18, 53, 37, 447, DateTimeKind.Utc).AddTicks(7321));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 2, 11, 18, 53, 37, 447, DateTimeKind.Utc).AddTicks(9620));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 2, 11, 18, 53, 37, 447, DateTimeKind.Utc).AddTicks(9624));

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "InventoryId",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 2, 11, 19, 53, 37, 450, DateTimeKind.Local).AddTicks(1598), new DateTime(2025, 2, 11, 19, 53, 37, 450, DateTimeKind.Local).AddTicks(2475) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "InventoryId",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 2, 11, 19, 53, 37, 450, DateTimeKind.Local).AddTicks(3635), new DateTime(2025, 2, 11, 19, 53, 37, 450, DateTimeKind.Local).AddTicks(3638) });

            migrationBuilder.UpdateData(
                table: "InventoryMouvements",
                keyColumn: "InventoryMouvementId",
                keyValue: 1,
                columns: new[] { "DateCreated", "MouvementDate" },
                values: new object[] { new DateTime(2025, 2, 11, 18, 53, 37, 450, DateTimeKind.Utc).AddTicks(4689), new DateTime(2025, 2, 11, 19, 53, 37, 450, DateTimeKind.Local).AddTicks(6538) });

            migrationBuilder.UpdateData(
                table: "InventoryMouvements",
                keyColumn: "InventoryMouvementId",
                keyValue: 2,
                columns: new[] { "DateCreated", "MouvementDate" },
                values: new object[] { new DateTime(2025, 2, 11, 18, 53, 37, 450, DateTimeKind.Utc).AddTicks(6886), new DateTime(2025, 2, 11, 19, 53, 37, 450, DateTimeKind.Local).AddTicks(6889) });

            migrationBuilder.UpdateData(
                table: "InventoryMouvements",
                keyColumn: "InventoryMouvementId",
                keyValue: 3,
                columns: new[] { "DateCreated", "MouvementDate" },
                values: new object[] { new DateTime(2025, 2, 11, 18, 53, 37, 450, DateTimeKind.Utc).AddTicks(6894), new DateTime(2025, 2, 11, 19, 53, 37, 450, DateTimeKind.Local).AddTicks(6981) });

            migrationBuilder.UpdateData(
                table: "Lines",
                keyColumn: "LineId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 2, 11, 18, 53, 37, 444, DateTimeKind.Utc).AddTicks(9578));

            migrationBuilder.UpdateData(
                table: "Lines",
                keyColumn: "LineId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 2, 11, 18, 53, 37, 445, DateTimeKind.Utc).AddTicks(434));

            migrationBuilder.UpdateData(
                table: "Lines",
                keyColumn: "LineId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 2, 11, 18, 53, 37, 445, DateTimeKind.Utc).AddTicks(436));

            migrationBuilder.UpdateData(
                table: "Lines",
                keyColumn: "LineId",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2025, 2, 11, 18, 53, 37, 445, DateTimeKind.Utc).AddTicks(437));

            migrationBuilder.UpdateData(
                table: "Lines",
                keyColumn: "LineId",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2025, 2, 11, 18, 53, 37, 445, DateTimeKind.Utc).AddTicks(438));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 2, 11, 19, 53, 37, 447, DateTimeKind.Local).AddTicks(2610), new DateTime(2025, 2, 11, 19, 53, 37, 447, DateTimeKind.Local).AddTicks(3455) });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 2, 11, 19, 53, 37, 447, DateTimeKind.Local).AddTicks(4121), new DateTime(2025, 2, 11, 19, 53, 37, 447, DateTimeKind.Local).AddTicks(4123) });

            migrationBuilder.UpdateData(
                table: "ProductBatchs",
                keyColumn: "ProductBatchId",
                keyValue: 1,
                columns: new[] { "ExpirationDate", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 8, 11, 18, 53, 37, 450, DateTimeKind.Utc).AddTicks(9245), new DateTime(2025, 2, 1, 18, 53, 37, 451, DateTimeKind.Utc).AddTicks(3795) });

            migrationBuilder.UpdateData(
                table: "ProductBatchs",
                keyColumn: "ProductBatchId",
                keyValue: 2,
                columns: new[] { "ExpirationDate", "ReceivedDate" },
                values: new object[] { new DateTime(2026, 2, 11, 18, 53, 37, 451, DateTimeKind.Utc).AddTicks(4619), new DateTime(2025, 1, 22, 18, 53, 37, 451, DateTimeKind.Utc).AddTicks(4624) });

            migrationBuilder.UpdateData(
                table: "ProductBatchs",
                keyColumn: "ProductBatchId",
                keyValue: 3,
                column: "ReceivedDate",
                value: new DateTime(2025, 2, 6, 18, 53, 37, 451, DateTimeKind.Utc).AddTicks(4627));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 2, 11, 19, 53, 37, 446, DateTimeKind.Local).AddTicks(4100), new DateTime(2025, 2, 11, 19, 53, 37, 446, DateTimeKind.Local).AddTicks(4993) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 2, 11, 19, 53, 37, 446, DateTimeKind.Local).AddTicks(7734), new DateTime(2025, 2, 11, 19, 53, 37, 446, DateTimeKind.Local).AddTicks(7736) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 2, 11, 19, 53, 37, 446, DateTimeKind.Local).AddTicks(7748), new DateTime(2025, 2, 11, 19, 53, 37, 446, DateTimeKind.Local).AddTicks(7792) });

            migrationBuilder.UpdateData(
                table: "PurchaseItems",
                keyColumn: "PurchaseItemId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 2, 11, 18, 53, 37, 451, DateTimeKind.Utc).AddTicks(9533));

            migrationBuilder.UpdateData(
                table: "PurchaseItems",
                keyColumn: "PurchaseItemId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 2, 11, 18, 53, 37, 452, DateTimeKind.Utc).AddTicks(2354));

            migrationBuilder.UpdateData(
                table: "PurchaseItems",
                keyColumn: "PurchaseItemId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 2, 11, 18, 53, 37, 452, DateTimeKind.Utc).AddTicks(2360));

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: 1,
                columns: new[] { "DateCreated", "PurchaseDate" },
                values: new object[] { new DateTime(2025, 2, 11, 18, 53, 37, 451, DateTimeKind.Utc).AddTicks(5810), new DateTime(2025, 2, 1, 18, 53, 37, 451, DateTimeKind.Utc).AddTicks(6122) });

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: 2,
                columns: new[] { "DateCreated", "PurchaseDate" },
                values: new object[] { new DateTime(2025, 2, 11, 18, 53, 37, 451, DateTimeKind.Utc).AddTicks(8180), new DateTime(2025, 2, 6, 18, 53, 37, 451, DateTimeKind.Utc).AddTicks(8181) });

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: 3,
                columns: new[] { "DateCreated", "PurchaseDate" },
                values: new object[] { new DateTime(2025, 2, 11, 18, 53, 37, 451, DateTimeKind.Utc).AddTicks(8187), new DateTime(2025, 2, 11, 18, 53, 37, 451, DateTimeKind.Utc).AddTicks(8188) });

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: 4,
                columns: new[] { "DateCreated", "PurchaseDate" },
                values: new object[] { new DateTime(2025, 2, 11, 18, 53, 37, 451, DateTimeKind.Utc).AddTicks(8191), new DateTime(2025, 2, 11, 18, 53, 37, 451, DateTimeKind.Utc).AddTicks(8192) });

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: 5,
                columns: new[] { "DateCreated", "PurchaseDate" },
                values: new object[] { new DateTime(2025, 2, 11, 18, 53, 37, 451, DateTimeKind.Utc).AddTicks(8195), new DateTime(2025, 2, 11, 18, 53, 37, 451, DateTimeKind.Utc).AddTicks(8196) });

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: 6,
                columns: new[] { "DateCreated", "PurchaseDate" },
                values: new object[] { new DateTime(2025, 2, 11, 18, 53, 37, 451, DateTimeKind.Utc).AddTicks(8250), new DateTime(2025, 2, 11, 18, 53, 37, 451, DateTimeKind.Utc).AddTicks(8251) });

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: 7,
                columns: new[] { "DateCreated", "PurchaseDate" },
                values: new object[] { new DateTime(2025, 2, 11, 18, 53, 37, 451, DateTimeKind.Utc).AddTicks(8256), new DateTime(2025, 2, 11, 18, 53, 37, 451, DateTimeKind.Utc).AddTicks(8256) });

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: 8,
                columns: new[] { "DateCreated", "PurchaseDate" },
                values: new object[] { new DateTime(2025, 2, 11, 18, 53, 37, 451, DateTimeKind.Utc).AddTicks(8260), new DateTime(2025, 2, 11, 18, 53, 37, 451, DateTimeKind.Utc).AddTicks(8261) });

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: 9,
                columns: new[] { "DateCreated", "PurchaseDate" },
                values: new object[] { new DateTime(2025, 2, 11, 18, 53, 37, 451, DateTimeKind.Utc).AddTicks(8265), new DateTime(2025, 2, 11, 18, 53, 37, 451, DateTimeKind.Utc).AddTicks(8265) });

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: 10,
                columns: new[] { "DateCreated", "PurchaseDate" },
                values: new object[] { new DateTime(2025, 2, 11, 18, 53, 37, 451, DateTimeKind.Utc).AddTicks(8270), new DateTime(2025, 2, 11, 18, 53, 37, 451, DateTimeKind.Utc).AddTicks(8270) });

            migrationBuilder.UpdateData(
                table: "SaleItems",
                keyColumn: "SaleItemId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 2, 11, 18, 53, 37, 453, DateTimeKind.Utc).AddTicks(3880));

            migrationBuilder.UpdateData(
                table: "SaleItems",
                keyColumn: "SaleItemId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 2, 11, 18, 53, 37, 453, DateTimeKind.Utc).AddTicks(7408));

            migrationBuilder.UpdateData(
                table: "SaleItems",
                keyColumn: "SaleItemId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 2, 11, 18, 53, 37, 453, DateTimeKind.Utc).AddTicks(7414));

            migrationBuilder.UpdateData(
                table: "SaleItems",
                keyColumn: "SaleItemId",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2025, 2, 11, 18, 53, 37, 453, DateTimeKind.Utc).AddTicks(7418));

            migrationBuilder.UpdateData(
                table: "SaleItems",
                keyColumn: "SaleItemId",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2025, 2, 11, 18, 53, 37, 453, DateTimeKind.Utc).AddTicks(7420));

            migrationBuilder.UpdateData(
                table: "SaleItems",
                keyColumn: "SaleItemId",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2025, 2, 11, 18, 53, 37, 453, DateTimeKind.Utc).AddTicks(7423));

            migrationBuilder.UpdateData(
                table: "SaleItems",
                keyColumn: "SaleItemId",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2025, 2, 11, 18, 53, 37, 453, DateTimeKind.Utc).AddTicks(7474));

            migrationBuilder.UpdateData(
                table: "SaleItems",
                keyColumn: "SaleItemId",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2025, 2, 11, 18, 53, 37, 453, DateTimeKind.Utc).AddTicks(7477));

            migrationBuilder.UpdateData(
                table: "SaleItems",
                keyColumn: "SaleItemId",
                keyValue: 9,
                column: "DateCreated",
                value: new DateTime(2025, 2, 11, 18, 53, 37, 453, DateTimeKind.Utc).AddTicks(7479));

            migrationBuilder.UpdateData(
                table: "SaleItems",
                keyColumn: "SaleItemId",
                keyValue: 10,
                column: "DateCreated",
                value: new DateTime(2025, 2, 11, 18, 53, 37, 453, DateTimeKind.Utc).AddTicks(7481));

            migrationBuilder.UpdateData(
                table: "SalePayments",
                keyColumn: "SalePaymentId",
                keyValue: 1,
                columns: new[] { "DateCreated", "PaymentDate" },
                values: new object[] { new DateTime(2025, 2, 11, 18, 53, 37, 453, DateTimeKind.Utc).AddTicks(9132), new DateTime(2025, 2, 1, 18, 53, 37, 453, DateTimeKind.Utc).AddTicks(9942) });

            migrationBuilder.UpdateData(
                table: "SalePayments",
                keyColumn: "SalePaymentId",
                keyValue: 2,
                columns: new[] { "DateCreated", "PaymentDate" },
                values: new object[] { new DateTime(2025, 2, 11, 18, 53, 37, 454, DateTimeKind.Utc).AddTicks(941), new DateTime(2025, 2, 6, 18, 53, 37, 454, DateTimeKind.Utc).AddTicks(943) });

            migrationBuilder.UpdateData(
                table: "SalePayments",
                keyColumn: "SalePaymentId",
                keyValue: 3,
                columns: new[] { "DateCreated", "PaymentDate" },
                values: new object[] { new DateTime(2025, 2, 11, 18, 53, 37, 454, DateTimeKind.Utc).AddTicks(946), new DateTime(2025, 2, 4, 18, 53, 37, 454, DateTimeKind.Utc).AddTicks(947) });

            migrationBuilder.UpdateData(
                table: "SalePayments",
                keyColumn: "SalePaymentId",
                keyValue: 4,
                columns: new[] { "DateCreated", "PaymentDate" },
                values: new object[] { new DateTime(2025, 2, 11, 18, 53, 37, 454, DateTimeKind.Utc).AddTicks(949), new DateTime(2025, 2, 8, 18, 53, 37, 454, DateTimeKind.Utc).AddTicks(950) });

            migrationBuilder.UpdateData(
                table: "SalePayments",
                keyColumn: "SalePaymentId",
                keyValue: 5,
                columns: new[] { "DateCreated", "PaymentDate" },
                values: new object[] { new DateTime(2025, 2, 11, 18, 53, 37, 454, DateTimeKind.Utc).AddTicks(953), new DateTime(2025, 2, 9, 18, 53, 37, 454, DateTimeKind.Utc).AddTicks(954) });

            migrationBuilder.UpdateData(
                table: "SalePayments",
                keyColumn: "SalePaymentId",
                keyValue: 6,
                columns: new[] { "DateCreated", "PaymentDate" },
                values: new object[] { new DateTime(2025, 2, 11, 18, 53, 37, 454, DateTimeKind.Utc).AddTicks(956), new DateTime(2025, 2, 10, 18, 53, 37, 454, DateTimeKind.Utc).AddTicks(956) });

            migrationBuilder.UpdateData(
                table: "SalePayments",
                keyColumn: "SalePaymentId",
                keyValue: 7,
                columns: new[] { "DateCreated", "PaymentDate" },
                values: new object[] { new DateTime(2025, 2, 11, 18, 53, 37, 454, DateTimeKind.Utc).AddTicks(959), new DateTime(2025, 1, 27, 18, 53, 37, 454, DateTimeKind.Utc).AddTicks(959) });

            migrationBuilder.UpdateData(
                table: "SalePayments",
                keyColumn: "SalePaymentId",
                keyValue: 8,
                columns: new[] { "DateCreated", "PaymentDate" },
                values: new object[] { new DateTime(2025, 2, 11, 18, 53, 37, 454, DateTimeKind.Utc).AddTicks(961), new DateTime(2025, 2, 1, 18, 53, 37, 454, DateTimeKind.Utc).AddTicks(962) });

            migrationBuilder.UpdateData(
                table: "SalePayments",
                keyColumn: "SalePaymentId",
                keyValue: 9,
                columns: new[] { "DateCreated", "PaymentDate" },
                values: new object[] { new DateTime(2025, 2, 11, 18, 53, 37, 454, DateTimeKind.Utc).AddTicks(964), new DateTime(2025, 2, 3, 18, 53, 37, 454, DateTimeKind.Utc).AddTicks(964) });

            migrationBuilder.UpdateData(
                table: "SalePayments",
                keyColumn: "SalePaymentId",
                keyValue: 10,
                columns: new[] { "DateCreated", "PaymentDate" },
                values: new object[] { new DateTime(2025, 2, 11, 18, 53, 37, 454, DateTimeKind.Utc).AddTicks(966), new DateTime(2025, 2, 11, 18, 53, 37, 454, DateTimeKind.Utc).AddTicks(966) });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 2, 11, 18, 53, 37, 453, DateTimeKind.Utc).AddTicks(335));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 2, 11, 18, 53, 37, 453, DateTimeKind.Utc).AddTicks(2737));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 2, 11, 18, 53, 37, 453, DateTimeKind.Utc).AddTicks(2743));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2025, 2, 11, 18, 53, 37, 453, DateTimeKind.Utc).AddTicks(2747));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2025, 2, 11, 18, 53, 37, 453, DateTimeKind.Utc).AddTicks(2751));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2025, 2, 11, 18, 53, 37, 453, DateTimeKind.Utc).AddTicks(2755));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2025, 2, 11, 18, 53, 37, 453, DateTimeKind.Utc).AddTicks(2759));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2025, 2, 11, 18, 53, 37, 453, DateTimeKind.Utc).AddTicks(2763));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 9,
                column: "DateCreated",
                value: new DateTime(2025, 2, 11, 18, 53, 37, 453, DateTimeKind.Utc).AddTicks(2767));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 10,
                column: "DateCreated",
                value: new DateTime(2025, 2, 11, 18, 53, 37, 453, DateTimeKind.Utc).AddTicks(2796));

            migrationBuilder.UpdateData(
                table: "Shelfs",
                keyColumn: "ShelfId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 2, 11, 18, 53, 37, 445, DateTimeKind.Utc).AddTicks(1404));

            migrationBuilder.UpdateData(
                table: "Shelfs",
                keyColumn: "ShelfId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 2, 11, 18, 53, 37, 445, DateTimeKind.Utc).AddTicks(2390));

            migrationBuilder.UpdateData(
                table: "Shelfs",
                keyColumn: "ShelfId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 2, 11, 18, 53, 37, 445, DateTimeKind.Utc).AddTicks(2393));

            migrationBuilder.UpdateData(
                table: "Supplier",
                keyColumn: "SupplierId",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 2, 11, 19, 53, 37, 443, DateTimeKind.Local).AddTicks(4914), new DateTime(2025, 2, 11, 19, 53, 37, 443, DateTimeKind.Local).AddTicks(6119) });

            migrationBuilder.UpdateData(
                table: "Supplier",
                keyColumn: "SupplierId",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 2, 11, 19, 53, 37, 443, DateTimeKind.Local).AddTicks(7199), new DateTime(2025, 2, 11, 19, 53, 37, 443, DateTimeKind.Local).AddTicks(7201) });

            migrationBuilder.UpdateData(
                table: "Supplier",
                keyColumn: "SupplierId",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 2, 11, 19, 53, 37, 443, DateTimeKind.Local).AddTicks(7209), new DateTime(2025, 2, 11, 19, 53, 37, 443, DateTimeKind.Local).AddTicks(7212) });

            migrationBuilder.UpdateData(
                table: "Supplier",
                keyColumn: "SupplierId",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 2, 11, 19, 53, 37, 443, DateTimeKind.Local).AddTicks(7219), new DateTime(2025, 2, 11, 19, 53, 37, 443, DateTimeKind.Local).AddTicks(7221) });

            migrationBuilder.UpdateData(
                table: "Supplier",
                keyColumn: "SupplierId",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 2, 11, 19, 53, 37, 443, DateTimeKind.Local).AddTicks(7228), new DateTime(2025, 2, 11, 19, 53, 37, 443, DateTimeKind.Local).AddTicks(7230) });

            migrationBuilder.UpdateData(
                table: "Supplier",
                keyColumn: "SupplierId",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 2, 11, 19, 53, 37, 443, DateTimeKind.Local).AddTicks(7237), new DateTime(2025, 2, 11, 19, 53, 37, 443, DateTimeKind.Local).AddTicks(7239) });

            migrationBuilder.UpdateData(
                table: "Supplier",
                keyColumn: "SupplierId",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 2, 11, 19, 53, 37, 443, DateTimeKind.Local).AddTicks(7247), new DateTime(2025, 2, 11, 19, 53, 37, 443, DateTimeKind.Local).AddTicks(7249) });

            migrationBuilder.UpdateData(
                table: "Supplier",
                keyColumn: "SupplierId",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 2, 11, 19, 53, 37, 443, DateTimeKind.Local).AddTicks(7256), new DateTime(2025, 2, 11, 19, 53, 37, 443, DateTimeKind.Local).AddTicks(7258) });

            migrationBuilder.UpdateData(
                table: "Supplier",
                keyColumn: "SupplierId",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 2, 11, 19, 53, 37, 443, DateTimeKind.Local).AddTicks(7325), new DateTime(2025, 2, 11, 19, 53, 37, 443, DateTimeKind.Local).AddTicks(7327) });

            migrationBuilder.UpdateData(
                table: "Supplier",
                keyColumn: "SupplierId",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 2, 11, 19, 53, 37, 443, DateTimeKind.Local).AddTicks(7335), new DateTime(2025, 2, 11, 19, 53, 37, 443, DateTimeKind.Local).AddTicks(7337) });

            migrationBuilder.UpdateData(
                table: "Taxes",
                keyColumn: "TaxId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 2, 11, 18, 53, 37, 445, DateTimeKind.Utc).AddTicks(3418));

            migrationBuilder.UpdateData(
                table: "Taxes",
                keyColumn: "TaxId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 2, 11, 18, 53, 37, 445, DateTimeKind.Utc).AddTicks(4292));

            migrationBuilder.UpdateData(
                table: "Taxes",
                keyColumn: "TaxId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 2, 11, 18, 53, 37, 445, DateTimeKind.Utc).AddTicks(4338));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "UnitId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 2, 11, 18, 53, 37, 445, DateTimeKind.Utc).AddTicks(5226));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "UnitId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 2, 11, 18, 53, 37, 445, DateTimeKind.Utc).AddTicks(5831));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "UnitId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 2, 11, 18, 53, 37, 445, DateTimeKind.Utc).AddTicks(5832));

            migrationBuilder.UpdateData(
                table: "purchasePayments",
                keyColumn: "PurchasePaymentId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 2, 11, 18, 53, 37, 452, DateTimeKind.Utc).AddTicks(3560));

            migrationBuilder.UpdateData(
                table: "purchasePayments",
                keyColumn: "PurchasePaymentId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 2, 11, 18, 53, 37, 452, DateTimeKind.Utc).AddTicks(9003));

            migrationBuilder.UpdateData(
                table: "purchasePayments",
                keyColumn: "PurchasePaymentId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 2, 11, 18, 53, 37, 452, DateTimeKind.Utc).AddTicks(9008));

            migrationBuilder.UpdateData(
                table: "purchasePayments",
                keyColumn: "PurchasePaymentId",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2025, 2, 11, 18, 53, 37, 452, DateTimeKind.Utc).AddTicks(9010));

            migrationBuilder.UpdateData(
                table: "purchasePayments",
                keyColumn: "PurchasePaymentId",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2025, 2, 11, 18, 53, 37, 452, DateTimeKind.Utc).AddTicks(9012));

            migrationBuilder.UpdateData(
                table: "purchasePayments",
                keyColumn: "PurchasePaymentId",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2025, 2, 11, 18, 53, 37, 452, DateTimeKind.Utc).AddTicks(9014));

            migrationBuilder.UpdateData(
                table: "purchasePayments",
                keyColumn: "PurchasePaymentId",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2025, 2, 11, 18, 53, 37, 452, DateTimeKind.Utc).AddTicks(9016));

            migrationBuilder.UpdateData(
                table: "purchasePayments",
                keyColumn: "PurchasePaymentId",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2025, 2, 11, 18, 53, 37, 452, DateTimeKind.Utc).AddTicks(9019));

            migrationBuilder.UpdateData(
                table: "purchasePayments",
                keyColumn: "PurchasePaymentId",
                keyValue: 9,
                column: "DateCreated",
                value: new DateTime(2025, 2, 11, 18, 53, 37, 452, DateTimeKind.Utc).AddTicks(9021));

            migrationBuilder.UpdateData(
                table: "purchasePayments",
                keyColumn: "PurchasePaymentId",
                keyValue: 10,
                column: "DateCreated",
                value: new DateTime(2025, 2, 11, 18, 53, 37, 452, DateTimeKind.Utc).AddTicks(9023));
        }
    }
}
