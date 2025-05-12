using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryTrackApi.Migrations
{
    /// <inheritdoc />
    public partial class AddApplicationUserDbSet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastLoginTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastLoginTime",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 5, 12, 20, 3, 57, 693, DateTimeKind.Utc).AddTicks(2278));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 5, 12, 20, 3, 57, 693, DateTimeKind.Utc).AddTicks(2628));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 5, 12, 20, 3, 57, 693, DateTimeKind.Utc).AddTicks(2629));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2025, 5, 12, 20, 3, 57, 693, DateTimeKind.Utc).AddTicks(2630));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2025, 5, 12, 20, 3, 57, 693, DateTimeKind.Utc).AddTicks(2630));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2025, 5, 12, 20, 3, 57, 693, DateTimeKind.Utc).AddTicks(2631));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2025, 5, 12, 20, 3, 57, 693, DateTimeKind.Utc).AddTicks(2632));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2025, 5, 12, 20, 3, 57, 693, DateTimeKind.Utc).AddTicks(2632));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 9,
                column: "DateCreated",
                value: new DateTime(2025, 5, 12, 20, 3, 57, 693, DateTimeKind.Utc).AddTicks(2633));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 10,
                column: "DateCreated",
                value: new DateTime(2025, 5, 12, 20, 3, 57, 693, DateTimeKind.Utc).AddTicks(2641));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 11,
                column: "DateCreated",
                value: new DateTime(2025, 5, 12, 20, 3, 57, 693, DateTimeKind.Utc).AddTicks(2642));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 12,
                column: "DateCreated",
                value: new DateTime(2025, 5, 12, 20, 3, 57, 693, DateTimeKind.Utc).AddTicks(2643));

            migrationBuilder.UpdateData(
                table: "Lines",
                keyColumn: "LineId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 5, 12, 20, 3, 57, 693, DateTimeKind.Utc).AddTicks(7666));

            migrationBuilder.UpdateData(
                table: "Lines",
                keyColumn: "LineId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 5, 12, 20, 3, 57, 693, DateTimeKind.Utc).AddTicks(7965));

            migrationBuilder.UpdateData(
                table: "Lines",
                keyColumn: "LineId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 5, 12, 20, 3, 57, 693, DateTimeKind.Utc).AddTicks(7966));

            migrationBuilder.UpdateData(
                table: "Lines",
                keyColumn: "LineId",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2025, 5, 12, 20, 3, 57, 693, DateTimeKind.Utc).AddTicks(7967));

            migrationBuilder.UpdateData(
                table: "Lines",
                keyColumn: "LineId",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2025, 5, 12, 20, 3, 57, 693, DateTimeKind.Utc).AddTicks(7968));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 5, 12, 22, 3, 57, 695, DateTimeKind.Local).AddTicks(8833), new DateTime(2025, 5, 12, 22, 3, 57, 695, DateTimeKind.Local).AddTicks(9027) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 5, 12, 22, 3, 57, 695, DateTimeKind.Local).AddTicks(9536), new DateTime(2025, 5, 12, 22, 3, 57, 695, DateTimeKind.Local).AddTicks(9537) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 5, 12, 22, 3, 57, 695, DateTimeKind.Local).AddTicks(9545), new DateTime(2025, 5, 12, 22, 3, 57, 695, DateTimeKind.Local).AddTicks(9546) });

            migrationBuilder.UpdateData(
                table: "Shelfs",
                keyColumn: "ShelfId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 5, 12, 20, 3, 57, 693, DateTimeKind.Utc).AddTicks(8401));

            migrationBuilder.UpdateData(
                table: "Shelfs",
                keyColumn: "ShelfId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 5, 12, 20, 3, 57, 693, DateTimeKind.Utc).AddTicks(8609));

            migrationBuilder.UpdateData(
                table: "Shelfs",
                keyColumn: "ShelfId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 5, 12, 20, 3, 57, 693, DateTimeKind.Utc).AddTicks(8610));

            migrationBuilder.UpdateData(
                table: "Taxes",
                keyColumn: "TaxId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 5, 12, 20, 3, 57, 693, DateTimeKind.Utc).AddTicks(8957));

            migrationBuilder.UpdateData(
                table: "Taxes",
                keyColumn: "TaxId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 5, 12, 20, 3, 57, 693, DateTimeKind.Utc).AddTicks(9201));

            migrationBuilder.UpdateData(
                table: "Taxes",
                keyColumn: "TaxId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 5, 12, 20, 3, 57, 693, DateTimeKind.Utc).AddTicks(9203));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "UnitId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 5, 12, 20, 3, 57, 693, DateTimeKind.Utc).AddTicks(9476));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "UnitId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 5, 12, 20, 3, 57, 693, DateTimeKind.Utc).AddTicks(9659));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "UnitId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 5, 12, 20, 3, 57, 693, DateTimeKind.Utc).AddTicks(9660));
        }
    }
}
