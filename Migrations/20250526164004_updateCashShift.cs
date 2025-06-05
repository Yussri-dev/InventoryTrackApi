using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryTrackApi.Migrations
{
    /// <inheritdoc />
    public partial class updateCashShift : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "CashShifts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "CashShifts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 5, 26, 16, 40, 0, 449, DateTimeKind.Utc).AddTicks(2765));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 5, 26, 16, 40, 0, 449, DateTimeKind.Utc).AddTicks(3155));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 5, 26, 16, 40, 0, 449, DateTimeKind.Utc).AddTicks(3156));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2025, 5, 26, 16, 40, 0, 449, DateTimeKind.Utc).AddTicks(3157));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2025, 5, 26, 16, 40, 0, 449, DateTimeKind.Utc).AddTicks(3158));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2025, 5, 26, 16, 40, 0, 449, DateTimeKind.Utc).AddTicks(3159));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2025, 5, 26, 16, 40, 0, 449, DateTimeKind.Utc).AddTicks(3159));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2025, 5, 26, 16, 40, 0, 449, DateTimeKind.Utc).AddTicks(3160));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 9,
                column: "DateCreated",
                value: new DateTime(2025, 5, 26, 16, 40, 0, 449, DateTimeKind.Utc).AddTicks(3161));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 10,
                column: "DateCreated",
                value: new DateTime(2025, 5, 26, 16, 40, 0, 449, DateTimeKind.Utc).AddTicks(3161));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 11,
                column: "DateCreated",
                value: new DateTime(2025, 5, 26, 16, 40, 0, 449, DateTimeKind.Utc).AddTicks(3162));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 12,
                column: "DateCreated",
                value: new DateTime(2025, 5, 26, 16, 40, 0, 449, DateTimeKind.Utc).AddTicks(3162));

            migrationBuilder.UpdateData(
                table: "Lines",
                keyColumn: "LineId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 5, 26, 16, 40, 0, 449, DateTimeKind.Utc).AddTicks(7128));

            migrationBuilder.UpdateData(
                table: "Lines",
                keyColumn: "LineId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 5, 26, 16, 40, 0, 449, DateTimeKind.Utc).AddTicks(7535));

            migrationBuilder.UpdateData(
                table: "Lines",
                keyColumn: "LineId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 5, 26, 16, 40, 0, 449, DateTimeKind.Utc).AddTicks(7536));

            migrationBuilder.UpdateData(
                table: "Lines",
                keyColumn: "LineId",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2025, 5, 26, 16, 40, 0, 449, DateTimeKind.Utc).AddTicks(7537));

            migrationBuilder.UpdateData(
                table: "Lines",
                keyColumn: "LineId",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2025, 5, 26, 16, 40, 0, 449, DateTimeKind.Utc).AddTicks(7537));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 5, 26, 18, 40, 0, 451, DateTimeKind.Local).AddTicks(7629), new DateTime(2025, 5, 26, 18, 40, 0, 451, DateTimeKind.Local).AddTicks(7888) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 5, 26, 18, 40, 0, 451, DateTimeKind.Local).AddTicks(8606), new DateTime(2025, 5, 26, 18, 40, 0, 451, DateTimeKind.Local).AddTicks(8608) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 5, 26, 18, 40, 0, 451, DateTimeKind.Local).AddTicks(8617), new DateTime(2025, 5, 26, 18, 40, 0, 451, DateTimeKind.Local).AddTicks(8618) });

            migrationBuilder.UpdateData(
                table: "Shelfs",
                keyColumn: "ShelfId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 5, 26, 16, 40, 0, 449, DateTimeKind.Utc).AddTicks(7992));

            migrationBuilder.UpdateData(
                table: "Shelfs",
                keyColumn: "ShelfId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 5, 26, 16, 40, 0, 449, DateTimeKind.Utc).AddTicks(8277));

            migrationBuilder.UpdateData(
                table: "Shelfs",
                keyColumn: "ShelfId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 5, 26, 16, 40, 0, 449, DateTimeKind.Utc).AddTicks(8277));

            migrationBuilder.UpdateData(
                table: "Taxes",
                keyColumn: "TaxId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 5, 26, 16, 40, 0, 449, DateTimeKind.Utc).AddTicks(8647));

            migrationBuilder.UpdateData(
                table: "Taxes",
                keyColumn: "TaxId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 5, 26, 16, 40, 0, 449, DateTimeKind.Utc).AddTicks(8877));

            migrationBuilder.UpdateData(
                table: "Taxes",
                keyColumn: "TaxId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 5, 26, 16, 40, 0, 449, DateTimeKind.Utc).AddTicks(8878));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "UnitId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 5, 26, 16, 40, 0, 449, DateTimeKind.Utc).AddTicks(9143));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "UnitId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 5, 26, 16, 40, 0, 449, DateTimeKind.Utc).AddTicks(9330));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "UnitId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 5, 26, 16, 40, 0, 449, DateTimeKind.Utc).AddTicks(9331));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "CashShifts");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "CashShifts");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 5, 14, 7, 48, 6, 265, DateTimeKind.Utc).AddTicks(558));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 5, 14, 7, 48, 6, 265, DateTimeKind.Utc).AddTicks(902));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 5, 14, 7, 48, 6, 265, DateTimeKind.Utc).AddTicks(903));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2025, 5, 14, 7, 48, 6, 265, DateTimeKind.Utc).AddTicks(903));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2025, 5, 14, 7, 48, 6, 265, DateTimeKind.Utc).AddTicks(904));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2025, 5, 14, 7, 48, 6, 265, DateTimeKind.Utc).AddTicks(905));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2025, 5, 14, 7, 48, 6, 265, DateTimeKind.Utc).AddTicks(905));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2025, 5, 14, 7, 48, 6, 265, DateTimeKind.Utc).AddTicks(906));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 9,
                column: "DateCreated",
                value: new DateTime(2025, 5, 14, 7, 48, 6, 265, DateTimeKind.Utc).AddTicks(907));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 10,
                column: "DateCreated",
                value: new DateTime(2025, 5, 14, 7, 48, 6, 265, DateTimeKind.Utc).AddTicks(908));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 11,
                column: "DateCreated",
                value: new DateTime(2025, 5, 14, 7, 48, 6, 265, DateTimeKind.Utc).AddTicks(908));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 12,
                column: "DateCreated",
                value: new DateTime(2025, 5, 14, 7, 48, 6, 265, DateTimeKind.Utc).AddTicks(909));

            migrationBuilder.UpdateData(
                table: "Lines",
                keyColumn: "LineId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 5, 14, 7, 48, 6, 265, DateTimeKind.Utc).AddTicks(5181));

            migrationBuilder.UpdateData(
                table: "Lines",
                keyColumn: "LineId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 5, 14, 7, 48, 6, 265, DateTimeKind.Utc).AddTicks(5486));

            migrationBuilder.UpdateData(
                table: "Lines",
                keyColumn: "LineId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 5, 14, 7, 48, 6, 265, DateTimeKind.Utc).AddTicks(5487));

            migrationBuilder.UpdateData(
                table: "Lines",
                keyColumn: "LineId",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2025, 5, 14, 7, 48, 6, 265, DateTimeKind.Utc).AddTicks(5488));

            migrationBuilder.UpdateData(
                table: "Lines",
                keyColumn: "LineId",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2025, 5, 14, 7, 48, 6, 265, DateTimeKind.Utc).AddTicks(5489));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 5, 14, 9, 48, 6, 267, DateTimeKind.Local).AddTicks(3734), new DateTime(2025, 5, 14, 9, 48, 6, 267, DateTimeKind.Local).AddTicks(3974) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 5, 14, 9, 48, 6, 267, DateTimeKind.Local).AddTicks(4659), new DateTime(2025, 5, 14, 9, 48, 6, 267, DateTimeKind.Local).AddTicks(4661) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 5, 14, 9, 48, 6, 267, DateTimeKind.Local).AddTicks(4669), new DateTime(2025, 5, 14, 9, 48, 6, 267, DateTimeKind.Local).AddTicks(4671) });

            migrationBuilder.UpdateData(
                table: "Shelfs",
                keyColumn: "ShelfId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 5, 14, 7, 48, 6, 265, DateTimeKind.Utc).AddTicks(5926));

            migrationBuilder.UpdateData(
                table: "Shelfs",
                keyColumn: "ShelfId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 5, 14, 7, 48, 6, 265, DateTimeKind.Utc).AddTicks(6128));

            migrationBuilder.UpdateData(
                table: "Shelfs",
                keyColumn: "ShelfId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 5, 14, 7, 48, 6, 265, DateTimeKind.Utc).AddTicks(6129));

            migrationBuilder.UpdateData(
                table: "Taxes",
                keyColumn: "TaxId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 5, 14, 7, 48, 6, 265, DateTimeKind.Utc).AddTicks(6483));

            migrationBuilder.UpdateData(
                table: "Taxes",
                keyColumn: "TaxId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 5, 14, 7, 48, 6, 265, DateTimeKind.Utc).AddTicks(6707));

            migrationBuilder.UpdateData(
                table: "Taxes",
                keyColumn: "TaxId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 5, 14, 7, 48, 6, 265, DateTimeKind.Utc).AddTicks(6718));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "UnitId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 5, 14, 7, 48, 6, 265, DateTimeKind.Utc).AddTicks(6972));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "UnitId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 5, 14, 7, 48, 6, 265, DateTimeKind.Utc).AddTicks(7133));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "UnitId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 5, 14, 7, 48, 6, 265, DateTimeKind.Utc).AddTicks(7134));
        }
    }
}
