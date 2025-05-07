using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryTrackApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSaleItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 3, 13, 22, 35, 56, 552, DateTimeKind.Utc).AddTicks(7160));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 3, 13, 22, 35, 56, 552, DateTimeKind.Utc).AddTicks(7558));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 3, 13, 22, 35, 56, 552, DateTimeKind.Utc).AddTicks(7560));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2025, 3, 13, 22, 35, 56, 552, DateTimeKind.Utc).AddTicks(7561));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2025, 3, 13, 22, 35, 56, 552, DateTimeKind.Utc).AddTicks(7561));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2025, 3, 13, 22, 35, 56, 552, DateTimeKind.Utc).AddTicks(7562));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2025, 3, 13, 22, 35, 56, 552, DateTimeKind.Utc).AddTicks(7563));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2025, 3, 13, 22, 35, 56, 552, DateTimeKind.Utc).AddTicks(7564));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 9,
                column: "DateCreated",
                value: new DateTime(2025, 3, 13, 22, 35, 56, 552, DateTimeKind.Utc).AddTicks(7565));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 10,
                column: "DateCreated",
                value: new DateTime(2025, 3, 13, 22, 35, 56, 552, DateTimeKind.Utc).AddTicks(7566));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 11,
                column: "DateCreated",
                value: new DateTime(2025, 3, 13, 22, 35, 56, 552, DateTimeKind.Utc).AddTicks(7566));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 12,
                column: "DateCreated",
                value: new DateTime(2025, 3, 13, 22, 35, 56, 552, DateTimeKind.Utc).AddTicks(7576));

            migrationBuilder.UpdateData(
                table: "Lines",
                keyColumn: "LineId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 3, 13, 22, 35, 56, 553, DateTimeKind.Utc).AddTicks(2426));

            migrationBuilder.UpdateData(
                table: "Lines",
                keyColumn: "LineId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 3, 13, 22, 35, 56, 553, DateTimeKind.Utc).AddTicks(2769));

            migrationBuilder.UpdateData(
                table: "Lines",
                keyColumn: "LineId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 3, 13, 22, 35, 56, 553, DateTimeKind.Utc).AddTicks(2770));

            migrationBuilder.UpdateData(
                table: "Lines",
                keyColumn: "LineId",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2025, 3, 13, 22, 35, 56, 553, DateTimeKind.Utc).AddTicks(2771));

            migrationBuilder.UpdateData(
                table: "Lines",
                keyColumn: "LineId",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2025, 3, 13, 22, 35, 56, 553, DateTimeKind.Utc).AddTicks(2772));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 3, 13, 23, 35, 56, 555, DateTimeKind.Local).AddTicks(5556), new DateTime(2025, 3, 13, 23, 35, 56, 555, DateTimeKind.Local).AddTicks(5789) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 3, 13, 23, 35, 56, 555, DateTimeKind.Local).AddTicks(6425), new DateTime(2025, 3, 13, 23, 35, 56, 555, DateTimeKind.Local).AddTicks(6427) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 3, 13, 23, 35, 56, 555, DateTimeKind.Local).AddTicks(6437), new DateTime(2025, 3, 13, 23, 35, 56, 555, DateTimeKind.Local).AddTicks(6439) });

            migrationBuilder.UpdateData(
                table: "Shelfs",
                keyColumn: "ShelfId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 3, 13, 22, 35, 56, 553, DateTimeKind.Utc).AddTicks(3220));

            migrationBuilder.UpdateData(
                table: "Shelfs",
                keyColumn: "ShelfId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 3, 13, 22, 35, 56, 553, DateTimeKind.Utc).AddTicks(3447));

            migrationBuilder.UpdateData(
                table: "Shelfs",
                keyColumn: "ShelfId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 3, 13, 22, 35, 56, 553, DateTimeKind.Utc).AddTicks(3448));

            migrationBuilder.UpdateData(
                table: "Taxes",
                keyColumn: "TaxId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 3, 13, 22, 35, 56, 553, DateTimeKind.Utc).AddTicks(3807));

            migrationBuilder.UpdateData(
                table: "Taxes",
                keyColumn: "TaxId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 3, 13, 22, 35, 56, 553, DateTimeKind.Utc).AddTicks(4104));

            migrationBuilder.UpdateData(
                table: "Taxes",
                keyColumn: "TaxId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 3, 13, 22, 35, 56, 553, DateTimeKind.Utc).AddTicks(4105));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "UnitId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 3, 13, 22, 35, 56, 553, DateTimeKind.Utc).AddTicks(4432));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "UnitId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 3, 13, 22, 35, 56, 553, DateTimeKind.Utc).AddTicks(4641));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "UnitId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 3, 13, 22, 35, 56, 553, DateTimeKind.Utc).AddTicks(4642));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 3, 12, 22, 42, 33, 225, DateTimeKind.Utc).AddTicks(4681));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 3, 12, 22, 42, 33, 225, DateTimeKind.Utc).AddTicks(5084));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 3, 12, 22, 42, 33, 225, DateTimeKind.Utc).AddTicks(5085));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2025, 3, 12, 22, 42, 33, 225, DateTimeKind.Utc).AddTicks(5086));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2025, 3, 12, 22, 42, 33, 225, DateTimeKind.Utc).AddTicks(5087));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2025, 3, 12, 22, 42, 33, 225, DateTimeKind.Utc).AddTicks(5088));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2025, 3, 12, 22, 42, 33, 225, DateTimeKind.Utc).AddTicks(5089));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2025, 3, 12, 22, 42, 33, 225, DateTimeKind.Utc).AddTicks(5089));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 9,
                column: "DateCreated",
                value: new DateTime(2025, 3, 12, 22, 42, 33, 225, DateTimeKind.Utc).AddTicks(5090));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 10,
                column: "DateCreated",
                value: new DateTime(2025, 3, 12, 22, 42, 33, 225, DateTimeKind.Utc).AddTicks(5091));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 11,
                column: "DateCreated",
                value: new DateTime(2025, 3, 12, 22, 42, 33, 225, DateTimeKind.Utc).AddTicks(5092));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 12,
                column: "DateCreated",
                value: new DateTime(2025, 3, 12, 22, 42, 33, 225, DateTimeKind.Utc).AddTicks(5093));

            migrationBuilder.UpdateData(
                table: "Lines",
                keyColumn: "LineId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 3, 12, 22, 42, 33, 225, DateTimeKind.Utc).AddTicks(9672));

            migrationBuilder.UpdateData(
                table: "Lines",
                keyColumn: "LineId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 3, 12, 22, 42, 33, 226, DateTimeKind.Utc).AddTicks(9));

            migrationBuilder.UpdateData(
                table: "Lines",
                keyColumn: "LineId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 3, 12, 22, 42, 33, 226, DateTimeKind.Utc).AddTicks(10));

            migrationBuilder.UpdateData(
                table: "Lines",
                keyColumn: "LineId",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2025, 3, 12, 22, 42, 33, 226, DateTimeKind.Utc).AddTicks(11));

            migrationBuilder.UpdateData(
                table: "Lines",
                keyColumn: "LineId",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2025, 3, 12, 22, 42, 33, 226, DateTimeKind.Utc).AddTicks(12));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 3, 12, 23, 42, 33, 227, DateTimeKind.Local).AddTicks(9777), new DateTime(2025, 3, 12, 23, 42, 33, 228, DateTimeKind.Local).AddTicks(1) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 3, 12, 23, 42, 33, 228, DateTimeKind.Local).AddTicks(624), new DateTime(2025, 3, 12, 23, 42, 33, 228, DateTimeKind.Local).AddTicks(626) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 3, 12, 23, 42, 33, 228, DateTimeKind.Local).AddTicks(635), new DateTime(2025, 3, 12, 23, 42, 33, 228, DateTimeKind.Local).AddTicks(636) });

            migrationBuilder.UpdateData(
                table: "Shelfs",
                keyColumn: "ShelfId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 3, 12, 22, 42, 33, 226, DateTimeKind.Utc).AddTicks(451));

            migrationBuilder.UpdateData(
                table: "Shelfs",
                keyColumn: "ShelfId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 3, 12, 22, 42, 33, 226, DateTimeKind.Utc).AddTicks(680));

            migrationBuilder.UpdateData(
                table: "Shelfs",
                keyColumn: "ShelfId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 3, 12, 22, 42, 33, 226, DateTimeKind.Utc).AddTicks(681));

            migrationBuilder.UpdateData(
                table: "Taxes",
                keyColumn: "TaxId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 3, 12, 22, 42, 33, 226, DateTimeKind.Utc).AddTicks(1088));

            migrationBuilder.UpdateData(
                table: "Taxes",
                keyColumn: "TaxId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 3, 12, 22, 42, 33, 226, DateTimeKind.Utc).AddTicks(1381));

            migrationBuilder.UpdateData(
                table: "Taxes",
                keyColumn: "TaxId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 3, 12, 22, 42, 33, 226, DateTimeKind.Utc).AddTicks(1400));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "UnitId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 3, 12, 22, 42, 33, 226, DateTimeKind.Utc).AddTicks(1745));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "UnitId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 3, 12, 22, 42, 33, 226, DateTimeKind.Utc).AddTicks(1956));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "UnitId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 3, 12, 22, 42, 33, 226, DateTimeKind.Utc).AddTicks(1957));
        }
    }
}
