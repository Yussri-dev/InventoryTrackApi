using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryTrackApi.Migrations
{
    /// <inheritdoc />
    public partial class AddingProfitMargeAndPurchasePriceToSaleItemsModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "ProfitMarge",
                table: "SaleItems",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PurchasePrice",
                table: "SaleItems",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "CashRegisterId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 1, 26, 10, 57, 52, 15, DateTimeKind.Utc).AddTicks(1825));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "CashRegisterId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 1, 26, 10, 57, 52, 15, DateTimeKind.Utc).AddTicks(3657));

            migrationBuilder.UpdateData(
                table: "CashShifts",
                keyColumn: "CashShiftId",
                keyValue: 1,
                columns: new[] { "DateCreated", "ShiftDate", "ShiftStart" },
                values: new object[] { new DateTime(2025, 1, 26, 10, 57, 52, 15, DateTimeKind.Utc).AddTicks(4737), new DateTime(2025, 1, 26, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 26, 10, 57, 52, 15, DateTimeKind.Utc).AddTicks(5556) });

            migrationBuilder.UpdateData(
                table: "CashShifts",
                keyColumn: "CashShiftId",
                keyValue: 2,
                columns: new[] { "DateCreated", "ShiftDate", "ShiftStart" },
                values: new object[] { new DateTime(2025, 1, 26, 10, 57, 52, 15, DateTimeKind.Utc).AddTicks(9073), new DateTime(2025, 1, 27, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 27, 10, 57, 52, 15, DateTimeKind.Utc).AddTicks(9132) });

            migrationBuilder.UpdateData(
                table: "CashTransactions",
                keyColumn: "CashTransactionId",
                keyValue: 1,
                columns: new[] { "DateCreated", "TransactionTime" },
                values: new object[] { new DateTime(2025, 1, 26, 10, 57, 52, 16, DateTimeKind.Utc).AddTicks(889), new DateTime(2025, 1, 26, 10, 57, 52, 16, DateTimeKind.Utc).AddTicks(2549) });

            migrationBuilder.UpdateData(
                table: "CashTransactions",
                keyColumn: "CashTransactionId",
                keyValue: 2,
                columns: new[] { "DateCreated", "TransactionTime" },
                values: new object[] { new DateTime(2025, 1, 26, 10, 57, 52, 16, DateTimeKind.Utc).AddTicks(3330), new DateTime(2025, 1, 26, 10, 27, 52, 16, DateTimeKind.Utc).AddTicks(3334) });

            migrationBuilder.UpdateData(
                table: "CashTransactions",
                keyColumn: "CashTransactionId",
                keyValue: 3,
                columns: new[] { "DateCreated", "TransactionTime" },
                values: new object[] { new DateTime(2025, 1, 26, 10, 57, 52, 16, DateTimeKind.Utc).AddTicks(3409), new DateTime(2025, 1, 26, 9, 57, 52, 16, DateTimeKind.Utc).AddTicks(3412) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 1, 26, 10, 57, 52, 10, DateTimeKind.Utc).AddTicks(6792));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 1, 26, 10, 57, 52, 10, DateTimeKind.Utc).AddTicks(7789));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 1, 26, 10, 57, 52, 10, DateTimeKind.Utc).AddTicks(7792));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2025, 1, 26, 10, 57, 52, 10, DateTimeKind.Utc).AddTicks(7793));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2025, 1, 26, 10, 57, 52, 10, DateTimeKind.Utc).AddTicks(7794));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2025, 1, 26, 10, 57, 52, 10, DateTimeKind.Utc).AddTicks(7795));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2025, 1, 26, 10, 57, 52, 10, DateTimeKind.Utc).AddTicks(7796));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2025, 1, 26, 10, 57, 52, 10, DateTimeKind.Utc).AddTicks(7798));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 9,
                column: "DateCreated",
                value: new DateTime(2025, 1, 26, 10, 57, 52, 10, DateTimeKind.Utc).AddTicks(7799));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 10,
                column: "DateCreated",
                value: new DateTime(2025, 1, 26, 10, 57, 52, 10, DateTimeKind.Utc).AddTicks(7800));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 11,
                column: "DateCreated",
                value: new DateTime(2025, 1, 26, 10, 57, 52, 10, DateTimeKind.Utc).AddTicks(7801));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 12,
                column: "DateCreated",
                value: new DateTime(2025, 1, 26, 10, 57, 52, 10, DateTimeKind.Utc).AddTicks(7850));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 1, 26, 11, 57, 52, 14, DateTimeKind.Local).AddTicks(8711), new DateTime(2025, 1, 26, 11, 57, 52, 14, DateTimeKind.Local).AddTicks(9665) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 1, 26, 11, 57, 52, 15, DateTimeKind.Local).AddTicks(672), new DateTime(2025, 1, 26, 11, 57, 52, 15, DateTimeKind.Local).AddTicks(675) });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 1, 26, 10, 57, 52, 13, DateTimeKind.Utc).AddTicks(9933));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 1, 26, 10, 57, 52, 14, DateTimeKind.Utc).AddTicks(2576));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 1, 26, 10, 57, 52, 14, DateTimeKind.Utc).AddTicks(2581));

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "InventoryId",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 1, 26, 11, 57, 52, 16, DateTimeKind.Local).AddTicks(6360), new DateTime(2025, 1, 26, 11, 57, 52, 16, DateTimeKind.Local).AddTicks(7154) });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "InventoryId",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 1, 26, 11, 57, 52, 16, DateTimeKind.Local).AddTicks(8270), new DateTime(2025, 1, 26, 11, 57, 52, 16, DateTimeKind.Local).AddTicks(8273) });

            migrationBuilder.UpdateData(
                table: "InventoryMouvements",
                keyColumn: "InventoryMouvementId",
                keyValue: 1,
                columns: new[] { "DateCreated", "MouvementDate" },
                values: new object[] { new DateTime(2025, 1, 26, 10, 57, 52, 16, DateTimeKind.Utc).AddTicks(9714), new DateTime(2025, 1, 26, 11, 57, 52, 17, DateTimeKind.Local).AddTicks(3260) });

            migrationBuilder.UpdateData(
                table: "InventoryMouvements",
                keyColumn: "InventoryMouvementId",
                keyValue: 2,
                columns: new[] { "DateCreated", "MouvementDate" },
                values: new object[] { new DateTime(2025, 1, 26, 10, 57, 52, 17, DateTimeKind.Utc).AddTicks(3782), new DateTime(2025, 1, 26, 11, 57, 52, 17, DateTimeKind.Local).AddTicks(3787) });

            migrationBuilder.UpdateData(
                table: "InventoryMouvements",
                keyColumn: "InventoryMouvementId",
                keyValue: 3,
                columns: new[] { "DateCreated", "MouvementDate" },
                values: new object[] { new DateTime(2025, 1, 26, 10, 57, 52, 17, DateTimeKind.Utc).AddTicks(3792), new DateTime(2025, 1, 26, 11, 57, 52, 17, DateTimeKind.Local).AddTicks(3795) });

            migrationBuilder.UpdateData(
                table: "Lines",
                keyColumn: "LineId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 1, 26, 10, 57, 52, 11, DateTimeKind.Utc).AddTicks(1419));

            migrationBuilder.UpdateData(
                table: "Lines",
                keyColumn: "LineId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 1, 26, 10, 57, 52, 11, DateTimeKind.Utc).AddTicks(2394));

            migrationBuilder.UpdateData(
                table: "Lines",
                keyColumn: "LineId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 1, 26, 10, 57, 52, 11, DateTimeKind.Utc).AddTicks(2397));

            migrationBuilder.UpdateData(
                table: "Lines",
                keyColumn: "LineId",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2025, 1, 26, 10, 57, 52, 11, DateTimeKind.Utc).AddTicks(2399));

            migrationBuilder.UpdateData(
                table: "Lines",
                keyColumn: "LineId",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2025, 1, 26, 10, 57, 52, 11, DateTimeKind.Utc).AddTicks(2400));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 1, 26, 11, 57, 52, 13, DateTimeKind.Local).AddTicks(6098), new DateTime(2025, 1, 26, 11, 57, 52, 13, DateTimeKind.Local).AddTicks(6883) });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 1, 26, 11, 57, 52, 13, DateTimeKind.Local).AddTicks(8312), new DateTime(2025, 1, 26, 11, 57, 52, 13, DateTimeKind.Local).AddTicks(8315) });

            migrationBuilder.UpdateData(
                table: "ProductBatchs",
                keyColumn: "ProductBatchId",
                keyValue: 1,
                columns: new[] { "ExpirationDate", "ReceivedDate" },
                values: new object[] { new DateTime(2025, 7, 26, 10, 57, 52, 17, DateTimeKind.Utc).AddTicks(6622), new DateTime(2025, 1, 16, 10, 57, 52, 18, DateTimeKind.Utc).AddTicks(1217) });

            migrationBuilder.UpdateData(
                table: "ProductBatchs",
                keyColumn: "ProductBatchId",
                keyValue: 2,
                columns: new[] { "ExpirationDate", "ReceivedDate" },
                values: new object[] { new DateTime(2026, 1, 26, 10, 57, 52, 18, DateTimeKind.Utc).AddTicks(2169), new DateTime(2025, 1, 6, 10, 57, 52, 18, DateTimeKind.Utc).AddTicks(2176) });

            migrationBuilder.UpdateData(
                table: "ProductBatchs",
                keyColumn: "ProductBatchId",
                keyValue: 3,
                column: "ReceivedDate",
                value: new DateTime(2025, 1, 21, 10, 57, 52, 18, DateTimeKind.Utc).AddTicks(2181));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 1, 26, 11, 57, 52, 12, DateTimeKind.Local).AddTicks(7357), new DateTime(2025, 1, 26, 11, 57, 52, 12, DateTimeKind.Local).AddTicks(8148) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 1, 26, 11, 57, 52, 13, DateTimeKind.Local).AddTicks(995), new DateTime(2025, 1, 26, 11, 57, 52, 13, DateTimeKind.Local).AddTicks(998) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 1, 26, 11, 57, 52, 13, DateTimeKind.Local).AddTicks(1016), new DateTime(2025, 1, 26, 11, 57, 52, 13, DateTimeKind.Local).AddTicks(1019) });

            migrationBuilder.UpdateData(
                table: "PurchaseItems",
                keyColumn: "PurchaseItemId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 1, 26, 10, 57, 52, 18, DateTimeKind.Utc).AddTicks(8887));

            migrationBuilder.UpdateData(
                table: "PurchaseItems",
                keyColumn: "PurchaseItemId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 1, 26, 10, 57, 52, 19, DateTimeKind.Utc).AddTicks(2091));

            migrationBuilder.UpdateData(
                table: "PurchaseItems",
                keyColumn: "PurchaseItemId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 1, 26, 10, 57, 52, 19, DateTimeKind.Utc).AddTicks(2100));

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: 1,
                columns: new[] { "DateCreated", "PurchaseDate" },
                values: new object[] { new DateTime(2025, 1, 26, 10, 57, 52, 18, DateTimeKind.Utc).AddTicks(3824), new DateTime(2025, 1, 16, 10, 57, 52, 18, DateTimeKind.Utc).AddTicks(4303) });

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: 2,
                columns: new[] { "DateCreated", "PurchaseDate" },
                values: new object[] { new DateTime(2025, 1, 26, 10, 57, 52, 18, DateTimeKind.Utc).AddTicks(7392), new DateTime(2025, 1, 21, 10, 57, 52, 18, DateTimeKind.Utc).AddTicks(7475) });

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: 3,
                columns: new[] { "DateCreated", "PurchaseDate" },
                values: new object[] { new DateTime(2025, 1, 26, 10, 57, 52, 18, DateTimeKind.Utc).AddTicks(7488), new DateTime(2025, 1, 26, 10, 57, 52, 18, DateTimeKind.Utc).AddTicks(7489) });

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: 4,
                columns: new[] { "DateCreated", "PurchaseDate" },
                values: new object[] { new DateTime(2025, 1, 26, 10, 57, 52, 18, DateTimeKind.Utc).AddTicks(7494), new DateTime(2025, 1, 26, 10, 57, 52, 18, DateTimeKind.Utc).AddTicks(7495) });

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: 5,
                columns: new[] { "DateCreated", "PurchaseDate" },
                values: new object[] { new DateTime(2025, 1, 26, 10, 57, 52, 18, DateTimeKind.Utc).AddTicks(7501), new DateTime(2025, 1, 26, 10, 57, 52, 18, DateTimeKind.Utc).AddTicks(7502) });

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: 6,
                columns: new[] { "DateCreated", "PurchaseDate" },
                values: new object[] { new DateTime(2025, 1, 26, 10, 57, 52, 18, DateTimeKind.Utc).AddTicks(7508), new DateTime(2025, 1, 26, 10, 57, 52, 18, DateTimeKind.Utc).AddTicks(7509) });

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: 7,
                columns: new[] { "DateCreated", "PurchaseDate" },
                values: new object[] { new DateTime(2025, 1, 26, 10, 57, 52, 18, DateTimeKind.Utc).AddTicks(7515), new DateTime(2025, 1, 26, 10, 57, 52, 18, DateTimeKind.Utc).AddTicks(7516) });

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: 8,
                columns: new[] { "DateCreated", "PurchaseDate" },
                values: new object[] { new DateTime(2025, 1, 26, 10, 57, 52, 18, DateTimeKind.Utc).AddTicks(7522), new DateTime(2025, 1, 26, 10, 57, 52, 18, DateTimeKind.Utc).AddTicks(7523) });

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: 9,
                columns: new[] { "DateCreated", "PurchaseDate" },
                values: new object[] { new DateTime(2025, 1, 26, 10, 57, 52, 18, DateTimeKind.Utc).AddTicks(7529), new DateTime(2025, 1, 26, 10, 57, 52, 18, DateTimeKind.Utc).AddTicks(7530) });

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: 10,
                columns: new[] { "DateCreated", "PurchaseDate" },
                values: new object[] { new DateTime(2025, 1, 26, 10, 57, 52, 18, DateTimeKind.Utc).AddTicks(7535), new DateTime(2025, 1, 26, 10, 57, 52, 18, DateTimeKind.Utc).AddTicks(7536) });

            migrationBuilder.UpdateData(
                table: "SaleItems",
                keyColumn: "SaleItemId",
                keyValue: 1,
                columns: new[] { "DateCreated", "ProfitMarge", "PurchasePrice" },
                values: new object[] { new DateTime(2025, 1, 26, 10, 57, 52, 20, DateTimeKind.Utc).AddTicks(7362), 0m, 0m });

            migrationBuilder.UpdateData(
                table: "SaleItems",
                keyColumn: "SaleItemId",
                keyValue: 2,
                columns: new[] { "DateCreated", "ProfitMarge", "PurchasePrice" },
                values: new object[] { new DateTime(2025, 1, 26, 10, 57, 52, 21, DateTimeKind.Utc).AddTicks(563), 0m, 0m });

            migrationBuilder.UpdateData(
                table: "SaleItems",
                keyColumn: "SaleItemId",
                keyValue: 3,
                columns: new[] { "DateCreated", "ProfitMarge", "PurchasePrice" },
                values: new object[] { new DateTime(2025, 1, 26, 10, 57, 52, 21, DateTimeKind.Utc).AddTicks(571), 0m, 0m });

            migrationBuilder.UpdateData(
                table: "SaleItems",
                keyColumn: "SaleItemId",
                keyValue: 4,
                columns: new[] { "DateCreated", "ProfitMarge", "PurchasePrice" },
                values: new object[] { new DateTime(2025, 1, 26, 10, 57, 52, 21, DateTimeKind.Utc).AddTicks(629), 0m, 0m });

            migrationBuilder.UpdateData(
                table: "SaleItems",
                keyColumn: "SaleItemId",
                keyValue: 5,
                columns: new[] { "DateCreated", "ProfitMarge", "PurchasePrice" },
                values: new object[] { new DateTime(2025, 1, 26, 10, 57, 52, 21, DateTimeKind.Utc).AddTicks(634), 0m, 0m });

            migrationBuilder.UpdateData(
                table: "SaleItems",
                keyColumn: "SaleItemId",
                keyValue: 6,
                columns: new[] { "DateCreated", "ProfitMarge", "PurchasePrice" },
                values: new object[] { new DateTime(2025, 1, 26, 10, 57, 52, 21, DateTimeKind.Utc).AddTicks(638), 0m, 0m });

            migrationBuilder.UpdateData(
                table: "SaleItems",
                keyColumn: "SaleItemId",
                keyValue: 7,
                columns: new[] { "DateCreated", "ProfitMarge", "PurchasePrice" },
                values: new object[] { new DateTime(2025, 1, 26, 10, 57, 52, 21, DateTimeKind.Utc).AddTicks(641), 0m, 0m });

            migrationBuilder.UpdateData(
                table: "SaleItems",
                keyColumn: "SaleItemId",
                keyValue: 8,
                columns: new[] { "DateCreated", "ProfitMarge", "PurchasePrice" },
                values: new object[] { new DateTime(2025, 1, 26, 10, 57, 52, 21, DateTimeKind.Utc).AddTicks(646), 0m, 0m });

            migrationBuilder.UpdateData(
                table: "SaleItems",
                keyColumn: "SaleItemId",
                keyValue: 9,
                columns: new[] { "DateCreated", "ProfitMarge", "PurchasePrice" },
                values: new object[] { new DateTime(2025, 1, 26, 10, 57, 52, 21, DateTimeKind.Utc).AddTicks(650), 0m, 0m });

            migrationBuilder.UpdateData(
                table: "SaleItems",
                keyColumn: "SaleItemId",
                keyValue: 10,
                columns: new[] { "DateCreated", "ProfitMarge", "PurchasePrice" },
                values: new object[] { new DateTime(2025, 1, 26, 10, 57, 52, 21, DateTimeKind.Utc).AddTicks(656), 0m, 0m });

            migrationBuilder.UpdateData(
                table: "SalePayments",
                keyColumn: "SalePaymentId",
                keyValue: 1,
                columns: new[] { "DateCreated", "PaymentDate" },
                values: new object[] { new DateTime(2025, 1, 26, 10, 57, 52, 21, DateTimeKind.Utc).AddTicks(3345), new DateTime(2025, 1, 16, 10, 57, 52, 21, DateTimeKind.Utc).AddTicks(4718) });

            migrationBuilder.UpdateData(
                table: "SalePayments",
                keyColumn: "SalePaymentId",
                keyValue: 2,
                columns: new[] { "DateCreated", "PaymentDate" },
                values: new object[] { new DateTime(2025, 1, 26, 10, 57, 52, 21, DateTimeKind.Utc).AddTicks(8950), new DateTime(2025, 1, 21, 10, 57, 52, 21, DateTimeKind.Utc).AddTicks(8957) });

            migrationBuilder.UpdateData(
                table: "SalePayments",
                keyColumn: "SalePaymentId",
                keyValue: 3,
                columns: new[] { "DateCreated", "PaymentDate" },
                values: new object[] { new DateTime(2025, 1, 26, 10, 57, 52, 21, DateTimeKind.Utc).AddTicks(8967), new DateTime(2025, 1, 19, 10, 57, 52, 21, DateTimeKind.Utc).AddTicks(8968) });

            migrationBuilder.UpdateData(
                table: "SalePayments",
                keyColumn: "SalePaymentId",
                keyValue: 4,
                columns: new[] { "DateCreated", "PaymentDate" },
                values: new object[] { new DateTime(2025, 1, 26, 10, 57, 52, 21, DateTimeKind.Utc).AddTicks(8971), new DateTime(2025, 1, 23, 10, 57, 52, 21, DateTimeKind.Utc).AddTicks(8972) });

            migrationBuilder.UpdateData(
                table: "SalePayments",
                keyColumn: "SalePaymentId",
                keyValue: 5,
                columns: new[] { "DateCreated", "PaymentDate" },
                values: new object[] { new DateTime(2025, 1, 26, 10, 57, 52, 21, DateTimeKind.Utc).AddTicks(8975), new DateTime(2025, 1, 24, 10, 57, 52, 21, DateTimeKind.Utc).AddTicks(8976) });

            migrationBuilder.UpdateData(
                table: "SalePayments",
                keyColumn: "SalePaymentId",
                keyValue: 6,
                columns: new[] { "DateCreated", "PaymentDate" },
                values: new object[] { new DateTime(2025, 1, 26, 10, 57, 52, 21, DateTimeKind.Utc).AddTicks(8979), new DateTime(2025, 1, 25, 10, 57, 52, 21, DateTimeKind.Utc).AddTicks(8980) });

            migrationBuilder.UpdateData(
                table: "SalePayments",
                keyColumn: "SalePaymentId",
                keyValue: 7,
                columns: new[] { "DateCreated", "PaymentDate" },
                values: new object[] { new DateTime(2025, 1, 26, 10, 57, 52, 21, DateTimeKind.Utc).AddTicks(8983), new DateTime(2025, 1, 11, 10, 57, 52, 21, DateTimeKind.Utc).AddTicks(8984) });

            migrationBuilder.UpdateData(
                table: "SalePayments",
                keyColumn: "SalePaymentId",
                keyValue: 8,
                columns: new[] { "DateCreated", "PaymentDate" },
                values: new object[] { new DateTime(2025, 1, 26, 10, 57, 52, 21, DateTimeKind.Utc).AddTicks(8987), new DateTime(2025, 1, 16, 10, 57, 52, 21, DateTimeKind.Utc).AddTicks(9549) });

            migrationBuilder.UpdateData(
                table: "SalePayments",
                keyColumn: "SalePaymentId",
                keyValue: 9,
                columns: new[] { "DateCreated", "PaymentDate" },
                values: new object[] { new DateTime(2025, 1, 26, 10, 57, 52, 21, DateTimeKind.Utc).AddTicks(9571), new DateTime(2025, 1, 18, 10, 57, 52, 21, DateTimeKind.Utc).AddTicks(9575) });

            migrationBuilder.UpdateData(
                table: "SalePayments",
                keyColumn: "SalePaymentId",
                keyValue: 10,
                columns: new[] { "DateCreated", "PaymentDate" },
                values: new object[] { new DateTime(2025, 1, 26, 10, 57, 52, 21, DateTimeKind.Utc).AddTicks(9581), new DateTime(2025, 1, 26, 10, 57, 52, 21, DateTimeKind.Utc).AddTicks(9583) });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 1, 26, 10, 57, 52, 20, DateTimeKind.Utc).AddTicks(2608));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 1, 26, 10, 57, 52, 20, DateTimeKind.Utc).AddTicks(5638));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 1, 26, 10, 57, 52, 20, DateTimeKind.Utc).AddTicks(5647));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2025, 1, 26, 10, 57, 52, 20, DateTimeKind.Utc).AddTicks(5653));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2025, 1, 26, 10, 57, 52, 20, DateTimeKind.Utc).AddTicks(5659));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2025, 1, 26, 10, 57, 52, 20, DateTimeKind.Utc).AddTicks(5666));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2025, 1, 26, 10, 57, 52, 20, DateTimeKind.Utc).AddTicks(5728));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2025, 1, 26, 10, 57, 52, 20, DateTimeKind.Utc).AddTicks(5733));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 9,
                column: "DateCreated",
                value: new DateTime(2025, 1, 26, 10, 57, 52, 20, DateTimeKind.Utc).AddTicks(5739));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 10,
                column: "DateCreated",
                value: new DateTime(2025, 1, 26, 10, 57, 52, 20, DateTimeKind.Utc).AddTicks(5744));

            migrationBuilder.UpdateData(
                table: "Shelfs",
                keyColumn: "ShelfId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 1, 26, 10, 57, 52, 11, DateTimeKind.Utc).AddTicks(3876));

            migrationBuilder.UpdateData(
                table: "Shelfs",
                keyColumn: "ShelfId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 1, 26, 10, 57, 52, 11, DateTimeKind.Utc).AddTicks(4744));

            migrationBuilder.UpdateData(
                table: "Shelfs",
                keyColumn: "ShelfId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 1, 26, 10, 57, 52, 11, DateTimeKind.Utc).AddTicks(4746));

            migrationBuilder.UpdateData(
                table: "Supplier",
                keyColumn: "SupplierId",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 1, 26, 11, 57, 52, 9, DateTimeKind.Local).AddTicks(2596), new DateTime(2025, 1, 26, 11, 57, 52, 9, DateTimeKind.Local).AddTicks(3502) });

            migrationBuilder.UpdateData(
                table: "Supplier",
                keyColumn: "SupplierId",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 1, 26, 11, 57, 52, 9, DateTimeKind.Local).AddTicks(4331), new DateTime(2025, 1, 26, 11, 57, 52, 9, DateTimeKind.Local).AddTicks(4334) });

            migrationBuilder.UpdateData(
                table: "Supplier",
                keyColumn: "SupplierId",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 1, 26, 11, 57, 52, 9, DateTimeKind.Local).AddTicks(4346), new DateTime(2025, 1, 26, 11, 57, 52, 9, DateTimeKind.Local).AddTicks(4349) });

            migrationBuilder.UpdateData(
                table: "Supplier",
                keyColumn: "SupplierId",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 1, 26, 11, 57, 52, 9, DateTimeKind.Local).AddTicks(4428), new DateTime(2025, 1, 26, 11, 57, 52, 9, DateTimeKind.Local).AddTicks(4432) });

            migrationBuilder.UpdateData(
                table: "Supplier",
                keyColumn: "SupplierId",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 1, 26, 11, 57, 52, 9, DateTimeKind.Local).AddTicks(4444), new DateTime(2025, 1, 26, 11, 57, 52, 9, DateTimeKind.Local).AddTicks(4447) });

            migrationBuilder.UpdateData(
                table: "Supplier",
                keyColumn: "SupplierId",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 1, 26, 11, 57, 52, 9, DateTimeKind.Local).AddTicks(4456), new DateTime(2025, 1, 26, 11, 57, 52, 9, DateTimeKind.Local).AddTicks(4459) });

            migrationBuilder.UpdateData(
                table: "Supplier",
                keyColumn: "SupplierId",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 1, 26, 11, 57, 52, 9, DateTimeKind.Local).AddTicks(4470), new DateTime(2025, 1, 26, 11, 57, 52, 9, DateTimeKind.Local).AddTicks(4473) });

            migrationBuilder.UpdateData(
                table: "Supplier",
                keyColumn: "SupplierId",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 1, 26, 11, 57, 52, 9, DateTimeKind.Local).AddTicks(4482), new DateTime(2025, 1, 26, 11, 57, 52, 9, DateTimeKind.Local).AddTicks(4485) });

            migrationBuilder.UpdateData(
                table: "Supplier",
                keyColumn: "SupplierId",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 1, 26, 11, 57, 52, 9, DateTimeKind.Local).AddTicks(4494), new DateTime(2025, 1, 26, 11, 57, 52, 9, DateTimeKind.Local).AddTicks(4497) });

            migrationBuilder.UpdateData(
                table: "Supplier",
                keyColumn: "SupplierId",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 1, 26, 11, 57, 52, 9, DateTimeKind.Local).AddTicks(4506), new DateTime(2025, 1, 26, 11, 57, 52, 9, DateTimeKind.Local).AddTicks(4509) });

            migrationBuilder.UpdateData(
                table: "Taxes",
                keyColumn: "TaxId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 1, 26, 10, 57, 52, 11, DateTimeKind.Utc).AddTicks(5933));

            migrationBuilder.UpdateData(
                table: "Taxes",
                keyColumn: "TaxId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 1, 26, 10, 57, 52, 11, DateTimeKind.Utc).AddTicks(6879));

            migrationBuilder.UpdateData(
                table: "Taxes",
                keyColumn: "TaxId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 1, 26, 10, 57, 52, 11, DateTimeKind.Utc).AddTicks(6884));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "UnitId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 1, 26, 10, 57, 52, 11, DateTimeKind.Utc).AddTicks(8001));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "UnitId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 1, 26, 10, 57, 52, 11, DateTimeKind.Utc).AddTicks(8839));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "UnitId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 1, 26, 10, 57, 52, 11, DateTimeKind.Utc).AddTicks(8842));

            migrationBuilder.UpdateData(
                table: "purchasePayments",
                keyColumn: "PurchasePaymentId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 1, 26, 10, 57, 52, 19, DateTimeKind.Utc).AddTicks(3365));

            migrationBuilder.UpdateData(
                table: "purchasePayments",
                keyColumn: "PurchasePaymentId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 1, 26, 10, 57, 52, 20, DateTimeKind.Utc).AddTicks(22));

            migrationBuilder.UpdateData(
                table: "purchasePayments",
                keyColumn: "PurchasePaymentId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 1, 26, 10, 57, 52, 20, DateTimeKind.Utc).AddTicks(33));

            migrationBuilder.UpdateData(
                table: "purchasePayments",
                keyColumn: "PurchasePaymentId",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2025, 1, 26, 10, 57, 52, 20, DateTimeKind.Utc).AddTicks(38));

            migrationBuilder.UpdateData(
                table: "purchasePayments",
                keyColumn: "PurchasePaymentId",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2025, 1, 26, 10, 57, 52, 20, DateTimeKind.Utc).AddTicks(41));

            migrationBuilder.UpdateData(
                table: "purchasePayments",
                keyColumn: "PurchasePaymentId",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2025, 1, 26, 10, 57, 52, 20, DateTimeKind.Utc).AddTicks(45));

            migrationBuilder.UpdateData(
                table: "purchasePayments",
                keyColumn: "PurchasePaymentId",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2025, 1, 26, 10, 57, 52, 20, DateTimeKind.Utc).AddTicks(140));

            migrationBuilder.UpdateData(
                table: "purchasePayments",
                keyColumn: "PurchasePaymentId",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2025, 1, 26, 10, 57, 52, 20, DateTimeKind.Utc).AddTicks(144));

            migrationBuilder.UpdateData(
                table: "purchasePayments",
                keyColumn: "PurchasePaymentId",
                keyValue: 9,
                column: "DateCreated",
                value: new DateTime(2025, 1, 26, 10, 57, 52, 20, DateTimeKind.Utc).AddTicks(249));

            migrationBuilder.UpdateData(
                table: "purchasePayments",
                keyColumn: "PurchasePaymentId",
                keyValue: 10,
                column: "DateCreated",
                value: new DateTime(2025, 1, 26, 10, 57, 52, 20, DateTimeKind.Utc).AddTicks(255));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfitMarge",
                table: "SaleItems");

            migrationBuilder.DropColumn(
                name: "PurchasePrice",
                table: "SaleItems");

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
                columns: new[] { "DateCreated", "ShiftDate", "ShiftStart" },
                values: new object[] { new DateTime(2025, 1, 20, 21, 25, 55, 220, DateTimeKind.Utc).AddTicks(5580), new DateTime(2025, 1, 20, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 20, 21, 25, 55, 220, DateTimeKind.Utc).AddTicks(6672) });

            migrationBuilder.UpdateData(
                table: "CashShifts",
                keyColumn: "CashShiftId",
                keyValue: 2,
                columns: new[] { "DateCreated", "ShiftDate", "ShiftStart" },
                values: new object[] { new DateTime(2025, 1, 20, 21, 25, 55, 221, DateTimeKind.Utc).AddTicks(1749), new DateTime(2025, 1, 21, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 21, 21, 25, 55, 221, DateTimeKind.Utc).AddTicks(1834) });

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
        }
    }
}
