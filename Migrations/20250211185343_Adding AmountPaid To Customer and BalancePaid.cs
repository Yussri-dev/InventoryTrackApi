using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryTrackApi.Migrations
{
    /// <inheritdoc />
    public partial class AddingAmountPaidToCustomerandBalancePaid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "AmountPaid",
                table: "Customers",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

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
                columns: new[] { "AmountPaid", "DateCreated", "DateModified" },
                values: new object[] { 0m, new DateTime(2025, 2, 11, 19, 53, 37, 448, DateTimeKind.Local).AddTicks(5258), new DateTime(2025, 2, 11, 19, 53, 37, 448, DateTimeKind.Local).AddTicks(5923) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2,
                columns: new[] { "AmountPaid", "DateCreated", "DateModified" },
                values: new object[] { 0m, new DateTime(2025, 2, 11, 19, 53, 37, 448, DateTimeKind.Local).AddTicks(6580), new DateTime(2025, 2, 11, 19, 53, 37, 448, DateTimeKind.Local).AddTicks(6582) });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AmountPaid",
                table: "Customers");

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
                column: "DateCreated",
                value: new DateTime(2025, 1, 26, 10, 57, 52, 20, DateTimeKind.Utc).AddTicks(7362));

            migrationBuilder.UpdateData(
                table: "SaleItems",
                keyColumn: "SaleItemId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 1, 26, 10, 57, 52, 21, DateTimeKind.Utc).AddTicks(563));

            migrationBuilder.UpdateData(
                table: "SaleItems",
                keyColumn: "SaleItemId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 1, 26, 10, 57, 52, 21, DateTimeKind.Utc).AddTicks(571));

            migrationBuilder.UpdateData(
                table: "SaleItems",
                keyColumn: "SaleItemId",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2025, 1, 26, 10, 57, 52, 21, DateTimeKind.Utc).AddTicks(629));

            migrationBuilder.UpdateData(
                table: "SaleItems",
                keyColumn: "SaleItemId",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2025, 1, 26, 10, 57, 52, 21, DateTimeKind.Utc).AddTicks(634));

            migrationBuilder.UpdateData(
                table: "SaleItems",
                keyColumn: "SaleItemId",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2025, 1, 26, 10, 57, 52, 21, DateTimeKind.Utc).AddTicks(638));

            migrationBuilder.UpdateData(
                table: "SaleItems",
                keyColumn: "SaleItemId",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2025, 1, 26, 10, 57, 52, 21, DateTimeKind.Utc).AddTicks(641));

            migrationBuilder.UpdateData(
                table: "SaleItems",
                keyColumn: "SaleItemId",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2025, 1, 26, 10, 57, 52, 21, DateTimeKind.Utc).AddTicks(646));

            migrationBuilder.UpdateData(
                table: "SaleItems",
                keyColumn: "SaleItemId",
                keyValue: 9,
                column: "DateCreated",
                value: new DateTime(2025, 1, 26, 10, 57, 52, 21, DateTimeKind.Utc).AddTicks(650));

            migrationBuilder.UpdateData(
                table: "SaleItems",
                keyColumn: "SaleItemId",
                keyValue: 10,
                column: "DateCreated",
                value: new DateTime(2025, 1, 26, 10, 57, 52, 21, DateTimeKind.Utc).AddTicks(656));

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
    }
}
