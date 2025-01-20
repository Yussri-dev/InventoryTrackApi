using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryTrackApi.Migrations
{
    /// <inheritdoc />
    public partial class AddingDateCreatedToModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Units",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Taxes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Shelfs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Sales",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "SalePayments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "SaleItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Purchases",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "purchasePayments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "PurchaseItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Lines",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "InventoryMouvements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Employees",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "CashTransactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "CashShifts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "CashRegisters",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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
                columns: new[] { "DateCreated", "ShiftDate", "ShiftStart" },
                values: new object[] { new DateTime(2025, 1, 20, 18, 0, 34, 356, DateTimeKind.Utc).AddTicks(7937), new DateTime(2025, 1, 20, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 20, 18, 0, 34, 357, DateTimeKind.Utc).AddTicks(6) });

            migrationBuilder.UpdateData(
                table: "CashShifts",
                keyColumn: "CashShiftId",
                keyValue: 2,
                columns: new[] { "DateCreated", "ShiftDate", "ShiftStart" },
                values: new object[] { new DateTime(2025, 1, 20, 18, 0, 34, 358, DateTimeKind.Utc).AddTicks(3388), new DateTime(2025, 1, 21, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 21, 18, 0, 34, 358, DateTimeKind.Utc).AddTicks(3547) });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Taxes");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Shelfs");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "SalePayments");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "SaleItems");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "purchasePayments");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "PurchaseItems");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Lines");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "InventoryMouvements");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "CashTransactions");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "CashShifts");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "CashRegisters");

            migrationBuilder.UpdateData(
                table: "CashShifts",
                keyColumn: "CashShiftId",
                keyValue: 1,
                columns: new[] { "ShiftDate", "ShiftStart" },
                values: new object[] { new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 2, 23, 27, 46, 934, DateTimeKind.Utc).AddTicks(3763) });

            migrationBuilder.UpdateData(
                table: "CashShifts",
                keyColumn: "CashShiftId",
                keyValue: 2,
                columns: new[] { "ShiftDate", "ShiftStart" },
                values: new object[] { new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 3, 23, 27, 46, 934, DateTimeKind.Utc).AddTicks(7034) });

            migrationBuilder.UpdateData(
                table: "CashTransactions",
                keyColumn: "CashTransactionId",
                keyValue: 1,
                column: "TransactionTime",
                value: new DateTime(2025, 1, 2, 23, 27, 46, 935, DateTimeKind.Utc).AddTicks(469));

            migrationBuilder.UpdateData(
                table: "CashTransactions",
                keyColumn: "CashTransactionId",
                keyValue: 2,
                column: "TransactionTime",
                value: new DateTime(2025, 1, 2, 22, 57, 46, 935, DateTimeKind.Utc).AddTicks(1220));

            migrationBuilder.UpdateData(
                table: "CashTransactions",
                keyColumn: "CashTransactionId",
                keyValue: 3,
                column: "TransactionTime",
                value: new DateTime(2025, 1, 2, 22, 27, 46, 935, DateTimeKind.Utc).AddTicks(1244));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 1, 3, 0, 27, 46, 933, DateTimeKind.Local).AddTicks(6574), new DateTime(2025, 1, 3, 0, 27, 46, 933, DateTimeKind.Local).AddTicks(7261) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 1, 3, 0, 27, 46, 933, DateTimeKind.Local).AddTicks(8400), new DateTime(2025, 1, 3, 0, 27, 46, 933, DateTimeKind.Local).AddTicks(8405) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "InventoryId",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 1, 3, 0, 27, 46, 935, DateTimeKind.Local).AddTicks(3778), new DateTime(2025, 1, 3, 0, 27, 46, 935, DateTimeKind.Local).AddTicks(4365) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "InventoryId",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 1, 3, 0, 27, 46, 935, DateTimeKind.Local).AddTicks(5367), new DateTime(2025, 1, 3, 0, 27, 46, 935, DateTimeKind.Local).AddTicks(5371) });

            migrationBuilder.UpdateData(
                table: "InventoryMouvements",
                keyColumn: "InventoryMouvementId",
                keyValue: 1,
                column: "MouvementDate",
                value: new DateTime(2025, 1, 3, 0, 27, 46, 935, DateTimeKind.Local).AddTicks(7757));

            migrationBuilder.UpdateData(
                table: "InventoryMouvements",
                keyColumn: "InventoryMouvementId",
                keyValue: 2,
                column: "MouvementDate",
                value: new DateTime(2025, 1, 3, 0, 27, 46, 935, DateTimeKind.Local).AddTicks(8306));

            migrationBuilder.UpdateData(
                table: "InventoryMouvements",
                keyColumn: "InventoryMouvementId",
                keyValue: 3,
                column: "MouvementDate",
                value: new DateTime(2025, 1, 3, 0, 27, 46, 935, DateTimeKind.Local).AddTicks(8358));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 1, 3, 0, 27, 46, 932, DateTimeKind.Local).AddTicks(2363), new DateTime(2025, 1, 3, 0, 27, 46, 932, DateTimeKind.Local).AddTicks(2891) });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 1, 3, 0, 27, 46, 932, DateTimeKind.Local).AddTicks(3421), new DateTime(2025, 1, 3, 0, 27, 46, 932, DateTimeKind.Local).AddTicks(3423) });

            migrationBuilder.UpdateData(
                table: "ProductBatchs",
                keyColumn: "ProductBatchId",
                keyValue: 1,
                columns: new[] { "ExpirationDate", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 7, 2, 23, 27, 46, 936, DateTimeKind.Utc).AddTicks(877), new DateTime(2024, 12, 23, 23, 27, 46, 936, DateTimeKind.Utc).AddTicks(1420) });

            migrationBuilder.UpdateData(
                table: "ProductBatchs",
                keyColumn: "ProductBatchId",
                keyValue: 2,
                columns: new[] { "ExpirationDate", "ReceivedDate" },
                values: new object[] { new DateTime(2026, 1, 2, 23, 27, 46, 936, DateTimeKind.Utc).AddTicks(1993), new DateTime(2024, 12, 13, 23, 27, 46, 936, DateTimeKind.Utc).AddTicks(1995) });

            migrationBuilder.UpdateData(
                table: "ProductBatchs",
                keyColumn: "ProductBatchId",
                keyValue: 3,
                column: "ReceivedDate",
                value: new DateTime(2024, 12, 28, 23, 27, 46, 936, DateTimeKind.Utc).AddTicks(1999));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 1, 3, 0, 27, 46, 931, DateTimeKind.Local).AddTicks(6733), new DateTime(2025, 1, 3, 0, 27, 46, 931, DateTimeKind.Local).AddTicks(7263) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 1, 3, 0, 27, 46, 931, DateTimeKind.Local).AddTicks(8914), new DateTime(2025, 1, 3, 0, 27, 46, 931, DateTimeKind.Local).AddTicks(8917) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 1, 3, 0, 27, 46, 931, DateTimeKind.Local).AddTicks(8960), new DateTime(2025, 1, 3, 0, 27, 46, 931, DateTimeKind.Local).AddTicks(8963) });

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: 1,
                column: "PurchaseDate",
                value: new DateTime(2024, 12, 23, 23, 27, 46, 936, DateTimeKind.Utc).AddTicks(3495));

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: 2,
                column: "PurchaseDate",
                value: new DateTime(2024, 12, 28, 23, 27, 46, 936, DateTimeKind.Utc).AddTicks(5868));

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: 3,
                column: "PurchaseDate",
                value: new DateTime(2025, 1, 2, 23, 27, 46, 936, DateTimeKind.Utc).AddTicks(5874));

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: 4,
                column: "PurchaseDate",
                value: new DateTime(2025, 1, 2, 23, 27, 46, 936, DateTimeKind.Utc).AddTicks(5879));

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: 5,
                column: "PurchaseDate",
                value: new DateTime(2025, 1, 2, 23, 27, 46, 936, DateTimeKind.Utc).AddTicks(5882));

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: 6,
                column: "PurchaseDate",
                value: new DateTime(2025, 1, 2, 23, 27, 46, 936, DateTimeKind.Utc).AddTicks(5933));

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: 7,
                column: "PurchaseDate",
                value: new DateTime(2025, 1, 2, 23, 27, 46, 936, DateTimeKind.Utc).AddTicks(5937));

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: 8,
                column: "PurchaseDate",
                value: new DateTime(2025, 1, 2, 23, 27, 46, 936, DateTimeKind.Utc).AddTicks(5941));

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: 9,
                column: "PurchaseDate",
                value: new DateTime(2025, 1, 2, 23, 27, 46, 936, DateTimeKind.Utc).AddTicks(5945));

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: 10,
                column: "PurchaseDate",
                value: new DateTime(2025, 1, 2, 23, 27, 46, 936, DateTimeKind.Utc).AddTicks(5948));

            migrationBuilder.UpdateData(
                table: "SalePayments",
                keyColumn: "SalePaymentId",
                keyValue: 1,
                column: "PaymentDate",
                value: new DateTime(2024, 12, 23, 23, 27, 46, 938, DateTimeKind.Utc).AddTicks(3576));

            migrationBuilder.UpdateData(
                table: "SalePayments",
                keyColumn: "SalePaymentId",
                keyValue: 2,
                column: "PaymentDate",
                value: new DateTime(2024, 12, 28, 23, 27, 46, 938, DateTimeKind.Utc).AddTicks(4984));

            migrationBuilder.UpdateData(
                table: "SalePayments",
                keyColumn: "SalePaymentId",
                keyValue: 3,
                column: "PaymentDate",
                value: new DateTime(2024, 12, 26, 23, 27, 46, 938, DateTimeKind.Utc).AddTicks(4988));

            migrationBuilder.UpdateData(
                table: "SalePayments",
                keyColumn: "SalePaymentId",
                keyValue: 4,
                column: "PaymentDate",
                value: new DateTime(2024, 12, 30, 23, 27, 46, 938, DateTimeKind.Utc).AddTicks(4991));

            migrationBuilder.UpdateData(
                table: "SalePayments",
                keyColumn: "SalePaymentId",
                keyValue: 5,
                column: "PaymentDate",
                value: new DateTime(2024, 12, 31, 23, 27, 46, 938, DateTimeKind.Utc).AddTicks(4993));

            migrationBuilder.UpdateData(
                table: "SalePayments",
                keyColumn: "SalePaymentId",
                keyValue: 6,
                column: "PaymentDate",
                value: new DateTime(2025, 1, 1, 23, 27, 46, 938, DateTimeKind.Utc).AddTicks(4994));

            migrationBuilder.UpdateData(
                table: "SalePayments",
                keyColumn: "SalePaymentId",
                keyValue: 7,
                column: "PaymentDate",
                value: new DateTime(2024, 12, 18, 23, 27, 46, 938, DateTimeKind.Utc).AddTicks(4996));

            migrationBuilder.UpdateData(
                table: "SalePayments",
                keyColumn: "SalePaymentId",
                keyValue: 8,
                column: "PaymentDate",
                value: new DateTime(2024, 12, 23, 23, 27, 46, 938, DateTimeKind.Utc).AddTicks(4998));

            migrationBuilder.UpdateData(
                table: "SalePayments",
                keyColumn: "SalePaymentId",
                keyValue: 9,
                column: "PaymentDate",
                value: new DateTime(2024, 12, 25, 23, 27, 46, 938, DateTimeKind.Utc).AddTicks(5000));

            migrationBuilder.UpdateData(
                table: "SalePayments",
                keyColumn: "SalePaymentId",
                keyValue: 10,
                column: "PaymentDate",
                value: new DateTime(2025, 1, 2, 23, 27, 46, 938, DateTimeKind.Utc).AddTicks(5002));

            migrationBuilder.UpdateData(
                table: "Supplier",
                keyColumn: "SupplierId",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 1, 3, 0, 27, 46, 929, DateTimeKind.Local).AddTicks(6173), new DateTime(2025, 1, 3, 0, 27, 46, 929, DateTimeKind.Local).AddTicks(6763) });

            migrationBuilder.UpdateData(
                table: "Supplier",
                keyColumn: "SupplierId",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 1, 3, 0, 27, 46, 929, DateTimeKind.Local).AddTicks(7319), new DateTime(2025, 1, 3, 0, 27, 46, 929, DateTimeKind.Local).AddTicks(7322) });

            migrationBuilder.UpdateData(
                table: "Supplier",
                keyColumn: "SupplierId",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 1, 3, 0, 27, 46, 929, DateTimeKind.Local).AddTicks(7329), new DateTime(2025, 1, 3, 0, 27, 46, 929, DateTimeKind.Local).AddTicks(7331) });

            migrationBuilder.UpdateData(
                table: "Supplier",
                keyColumn: "SupplierId",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 1, 3, 0, 27, 46, 929, DateTimeKind.Local).AddTicks(7339), new DateTime(2025, 1, 3, 0, 27, 46, 929, DateTimeKind.Local).AddTicks(7341) });

            migrationBuilder.UpdateData(
                table: "Supplier",
                keyColumn: "SupplierId",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 1, 3, 0, 27, 46, 929, DateTimeKind.Local).AddTicks(7348), new DateTime(2025, 1, 3, 0, 27, 46, 929, DateTimeKind.Local).AddTicks(7350) });

            migrationBuilder.UpdateData(
                table: "Supplier",
                keyColumn: "SupplierId",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 1, 3, 0, 27, 46, 929, DateTimeKind.Local).AddTicks(7356), new DateTime(2025, 1, 3, 0, 27, 46, 929, DateTimeKind.Local).AddTicks(7358) });

            migrationBuilder.UpdateData(
                table: "Supplier",
                keyColumn: "SupplierId",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 1, 3, 0, 27, 46, 929, DateTimeKind.Local).AddTicks(7365), new DateTime(2025, 1, 3, 0, 27, 46, 929, DateTimeKind.Local).AddTicks(7367) });

            migrationBuilder.UpdateData(
                table: "Supplier",
                keyColumn: "SupplierId",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 1, 3, 0, 27, 46, 929, DateTimeKind.Local).AddTicks(7373), new DateTime(2025, 1, 3, 0, 27, 46, 929, DateTimeKind.Local).AddTicks(7406) });

            migrationBuilder.UpdateData(
                table: "Supplier",
                keyColumn: "SupplierId",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 1, 3, 0, 27, 46, 929, DateTimeKind.Local).AddTicks(7415), new DateTime(2025, 1, 3, 0, 27, 46, 929, DateTimeKind.Local).AddTicks(7417) });

            migrationBuilder.UpdateData(
                table: "Supplier",
                keyColumn: "SupplierId",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 1, 3, 0, 27, 46, 929, DateTimeKind.Local).AddTicks(7423), new DateTime(2025, 1, 3, 0, 27, 46, 929, DateTimeKind.Local).AddTicks(7425) });
        }
    }
}
