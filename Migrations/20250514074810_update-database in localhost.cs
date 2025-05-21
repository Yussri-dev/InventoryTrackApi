using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryTrackApi.Migrations
{
    /// <inheritdoc />
    public partial class updatedatabaseinlocalhost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 5, 12, 22, 1, 27, 347, DateTimeKind.Utc).AddTicks(8889));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 5, 12, 22, 1, 27, 347, DateTimeKind.Utc).AddTicks(9225));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 5, 12, 22, 1, 27, 347, DateTimeKind.Utc).AddTicks(9226));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2025, 5, 12, 22, 1, 27, 347, DateTimeKind.Utc).AddTicks(9226));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2025, 5, 12, 22, 1, 27, 347, DateTimeKind.Utc).AddTicks(9227));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2025, 5, 12, 22, 1, 27, 347, DateTimeKind.Utc).AddTicks(9228));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2025, 5, 12, 22, 1, 27, 347, DateTimeKind.Utc).AddTicks(9228));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2025, 5, 12, 22, 1, 27, 347, DateTimeKind.Utc).AddTicks(9229));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 9,
                column: "DateCreated",
                value: new DateTime(2025, 5, 12, 22, 1, 27, 347, DateTimeKind.Utc).AddTicks(9229));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 10,
                column: "DateCreated",
                value: new DateTime(2025, 5, 12, 22, 1, 27, 347, DateTimeKind.Utc).AddTicks(9230));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 11,
                column: "DateCreated",
                value: new DateTime(2025, 5, 12, 22, 1, 27, 347, DateTimeKind.Utc).AddTicks(9231));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 12,
                column: "DateCreated",
                value: new DateTime(2025, 5, 12, 22, 1, 27, 347, DateTimeKind.Utc).AddTicks(9231));

            migrationBuilder.UpdateData(
                table: "Lines",
                keyColumn: "LineId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 5, 12, 22, 1, 27, 348, DateTimeKind.Utc).AddTicks(3265));

            migrationBuilder.UpdateData(
                table: "Lines",
                keyColumn: "LineId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 5, 12, 22, 1, 27, 348, DateTimeKind.Utc).AddTicks(3543));

            migrationBuilder.UpdateData(
                table: "Lines",
                keyColumn: "LineId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 5, 12, 22, 1, 27, 348, DateTimeKind.Utc).AddTicks(3544));

            migrationBuilder.UpdateData(
                table: "Lines",
                keyColumn: "LineId",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2025, 5, 12, 22, 1, 27, 348, DateTimeKind.Utc).AddTicks(3544));

            migrationBuilder.UpdateData(
                table: "Lines",
                keyColumn: "LineId",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2025, 5, 12, 22, 1, 27, 348, DateTimeKind.Utc).AddTicks(3545));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 5, 13, 0, 1, 27, 366, DateTimeKind.Local).AddTicks(8286), new DateTime(2025, 5, 13, 0, 1, 27, 366, DateTimeKind.Local).AddTicks(8471) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 5, 13, 0, 1, 27, 366, DateTimeKind.Local).AddTicks(9105), new DateTime(2025, 5, 13, 0, 1, 27, 366, DateTimeKind.Local).AddTicks(9107) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 5, 13, 0, 1, 27, 366, DateTimeKind.Local).AddTicks(9115), new DateTime(2025, 5, 13, 0, 1, 27, 366, DateTimeKind.Local).AddTicks(9117) });

            migrationBuilder.UpdateData(
                table: "Shelfs",
                keyColumn: "ShelfId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 5, 12, 22, 1, 27, 348, DateTimeKind.Utc).AddTicks(3957));

            migrationBuilder.UpdateData(
                table: "Shelfs",
                keyColumn: "ShelfId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 5, 12, 22, 1, 27, 348, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "Shelfs",
                keyColumn: "ShelfId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 5, 12, 22, 1, 27, 348, DateTimeKind.Utc).AddTicks(4146));

            migrationBuilder.UpdateData(
                table: "Taxes",
                keyColumn: "TaxId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 5, 12, 22, 1, 27, 348, DateTimeKind.Utc).AddTicks(4507));

            migrationBuilder.UpdateData(
                table: "Taxes",
                keyColumn: "TaxId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 5, 12, 22, 1, 27, 348, DateTimeKind.Utc).AddTicks(4767));

            migrationBuilder.UpdateData(
                table: "Taxes",
                keyColumn: "TaxId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 5, 12, 22, 1, 27, 348, DateTimeKind.Utc).AddTicks(4780));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "UnitId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 5, 12, 22, 1, 27, 348, DateTimeKind.Utc).AddTicks(5047));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "UnitId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 5, 12, 22, 1, 27, 348, DateTimeKind.Utc).AddTicks(5225));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "UnitId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 5, 12, 22, 1, 27, 348, DateTimeKind.Utc).AddTicks(5226));
        }
    }
}
