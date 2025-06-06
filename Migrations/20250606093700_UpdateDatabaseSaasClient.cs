using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryTrackApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabaseSaasClient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SaasClientId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 6, 6, 9, 36, 55, 410, DateTimeKind.Utc).AddTicks(3754));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 6, 6, 9, 36, 55, 410, DateTimeKind.Utc).AddTicks(4073));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 6, 6, 9, 36, 55, 410, DateTimeKind.Utc).AddTicks(4074));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2025, 6, 6, 9, 36, 55, 410, DateTimeKind.Utc).AddTicks(4074));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2025, 6, 6, 9, 36, 55, 410, DateTimeKind.Utc).AddTicks(4075));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2025, 6, 6, 9, 36, 55, 410, DateTimeKind.Utc).AddTicks(4076));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2025, 6, 6, 9, 36, 55, 410, DateTimeKind.Utc).AddTicks(4076));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2025, 6, 6, 9, 36, 55, 410, DateTimeKind.Utc).AddTicks(4077));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 9,
                column: "DateCreated",
                value: new DateTime(2025, 6, 6, 9, 36, 55, 410, DateTimeKind.Utc).AddTicks(4078));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 10,
                column: "DateCreated",
                value: new DateTime(2025, 6, 6, 9, 36, 55, 410, DateTimeKind.Utc).AddTicks(4078));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 11,
                column: "DateCreated",
                value: new DateTime(2025, 6, 6, 9, 36, 55, 410, DateTimeKind.Utc).AddTicks(4079));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 12,
                column: "DateCreated",
                value: new DateTime(2025, 6, 6, 9, 36, 55, 410, DateTimeKind.Utc).AddTicks(4079));

            migrationBuilder.UpdateData(
                table: "Lines",
                keyColumn: "LineId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 6, 6, 9, 36, 55, 410, DateTimeKind.Utc).AddTicks(7758));

            migrationBuilder.UpdateData(
                table: "Lines",
                keyColumn: "LineId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 6, 6, 9, 36, 55, 410, DateTimeKind.Utc).AddTicks(8028));

            migrationBuilder.UpdateData(
                table: "Lines",
                keyColumn: "LineId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 6, 6, 9, 36, 55, 410, DateTimeKind.Utc).AddTicks(8029));

            migrationBuilder.UpdateData(
                table: "Lines",
                keyColumn: "LineId",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2025, 6, 6, 9, 36, 55, 410, DateTimeKind.Utc).AddTicks(8029));

            migrationBuilder.UpdateData(
                table: "Lines",
                keyColumn: "LineId",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2025, 6, 6, 9, 36, 55, 410, DateTimeKind.Utc).AddTicks(8030));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 6, 6, 11, 36, 55, 412, DateTimeKind.Local).AddTicks(9142), new DateTime(2025, 6, 6, 11, 36, 55, 412, DateTimeKind.Local).AddTicks(9354) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 6, 6, 11, 36, 55, 412, DateTimeKind.Local).AddTicks(9933), new DateTime(2025, 6, 6, 11, 36, 55, 412, DateTimeKind.Local).AddTicks(9934) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 6, 6, 11, 36, 55, 412, DateTimeKind.Local).AddTicks(9942), new DateTime(2025, 6, 6, 11, 36, 55, 412, DateTimeKind.Local).AddTicks(9943) });

            migrationBuilder.UpdateData(
                table: "Shelfs",
                keyColumn: "ShelfId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 6, 6, 9, 36, 55, 410, DateTimeKind.Utc).AddTicks(8449));

            migrationBuilder.UpdateData(
                table: "Shelfs",
                keyColumn: "ShelfId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 6, 6, 9, 36, 55, 410, DateTimeKind.Utc).AddTicks(8656));

            migrationBuilder.UpdateData(
                table: "Shelfs",
                keyColumn: "ShelfId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 6, 6, 9, 36, 55, 410, DateTimeKind.Utc).AddTicks(8657));

            migrationBuilder.UpdateData(
                table: "Taxes",
                keyColumn: "TaxId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 6, 6, 9, 36, 55, 410, DateTimeKind.Utc).AddTicks(8992));

            migrationBuilder.UpdateData(
                table: "Taxes",
                keyColumn: "TaxId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 6, 6, 9, 36, 55, 410, DateTimeKind.Utc).AddTicks(9222));

            migrationBuilder.UpdateData(
                table: "Taxes",
                keyColumn: "TaxId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 6, 6, 9, 36, 55, 410, DateTimeKind.Utc).AddTicks(9224));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "UnitId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 6, 6, 9, 36, 55, 410, DateTimeKind.Utc).AddTicks(9480));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "UnitId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 6, 6, 9, 36, 55, 410, DateTimeKind.Utc).AddTicks(9651));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "UnitId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 6, 6, 9, 36, 55, 410, DateTimeKind.Utc).AddTicks(9652));

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_SaasClientId",
                table: "AspNetUsers",
                column: "SaasClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_SaasClients_SaasClientId",
                table: "AspNetUsers",
                column: "SaasClientId",
                principalTable: "SaasClients",
                principalColumn: "SaasClientId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_SaasClients_SaasClientId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_SaasClientId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SaasClientId",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 6, 5, 11, 11, 36, 518, DateTimeKind.Utc).AddTicks(9634));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 6, 5, 11, 11, 36, 518, DateTimeKind.Utc).AddTicks(9963));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 6, 5, 11, 11, 36, 518, DateTimeKind.Utc).AddTicks(9964));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2025, 6, 5, 11, 11, 36, 518, DateTimeKind.Utc).AddTicks(9964));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2025, 6, 5, 11, 11, 36, 518, DateTimeKind.Utc).AddTicks(9965));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2025, 6, 5, 11, 11, 36, 518, DateTimeKind.Utc).AddTicks(9966));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2025, 6, 5, 11, 11, 36, 518, DateTimeKind.Utc).AddTicks(9966));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2025, 6, 5, 11, 11, 36, 518, DateTimeKind.Utc).AddTicks(9967));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 9,
                column: "DateCreated",
                value: new DateTime(2025, 6, 5, 11, 11, 36, 518, DateTimeKind.Utc).AddTicks(9968));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 10,
                column: "DateCreated",
                value: new DateTime(2025, 6, 5, 11, 11, 36, 518, DateTimeKind.Utc).AddTicks(9968));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 11,
                column: "DateCreated",
                value: new DateTime(2025, 6, 5, 11, 11, 36, 518, DateTimeKind.Utc).AddTicks(9969));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 12,
                column: "DateCreated",
                value: new DateTime(2025, 6, 5, 11, 11, 36, 518, DateTimeKind.Utc).AddTicks(9970));

            migrationBuilder.UpdateData(
                table: "Lines",
                keyColumn: "LineId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 6, 5, 11, 11, 36, 519, DateTimeKind.Utc).AddTicks(4995));

            migrationBuilder.UpdateData(
                table: "Lines",
                keyColumn: "LineId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 6, 5, 11, 11, 36, 519, DateTimeKind.Utc).AddTicks(5327));

            migrationBuilder.UpdateData(
                table: "Lines",
                keyColumn: "LineId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 6, 5, 11, 11, 36, 519, DateTimeKind.Utc).AddTicks(5328));

            migrationBuilder.UpdateData(
                table: "Lines",
                keyColumn: "LineId",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2025, 6, 5, 11, 11, 36, 519, DateTimeKind.Utc).AddTicks(5328));

            migrationBuilder.UpdateData(
                table: "Lines",
                keyColumn: "LineId",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2025, 6, 5, 11, 11, 36, 519, DateTimeKind.Utc).AddTicks(5329));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 6, 5, 13, 11, 36, 523, DateTimeKind.Local).AddTicks(1388), new DateTime(2025, 6, 5, 13, 11, 36, 523, DateTimeKind.Local).AddTicks(1934) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 6, 5, 13, 11, 36, 523, DateTimeKind.Local).AddTicks(3552), new DateTime(2025, 6, 5, 13, 11, 36, 523, DateTimeKind.Local).AddTicks(3554) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 6, 5, 13, 11, 36, 523, DateTimeKind.Local).AddTicks(3565), new DateTime(2025, 6, 5, 13, 11, 36, 523, DateTimeKind.Local).AddTicks(3567) });

            migrationBuilder.UpdateData(
                table: "Shelfs",
                keyColumn: "ShelfId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 6, 5, 11, 11, 36, 519, DateTimeKind.Utc).AddTicks(6159));

            migrationBuilder.UpdateData(
                table: "Shelfs",
                keyColumn: "ShelfId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 6, 5, 11, 11, 36, 519, DateTimeKind.Utc).AddTicks(6358));

            migrationBuilder.UpdateData(
                table: "Shelfs",
                keyColumn: "ShelfId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 6, 5, 11, 11, 36, 519, DateTimeKind.Utc).AddTicks(6359));

            migrationBuilder.UpdateData(
                table: "Taxes",
                keyColumn: "TaxId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 6, 5, 11, 11, 36, 519, DateTimeKind.Utc).AddTicks(7174));

            migrationBuilder.UpdateData(
                table: "Taxes",
                keyColumn: "TaxId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 6, 5, 11, 11, 36, 519, DateTimeKind.Utc).AddTicks(8087));

            migrationBuilder.UpdateData(
                table: "Taxes",
                keyColumn: "TaxId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 6, 5, 11, 11, 36, 519, DateTimeKind.Utc).AddTicks(8088));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "UnitId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 6, 5, 11, 11, 36, 519, DateTimeKind.Utc).AddTicks(8441));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "UnitId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 6, 5, 11, 11, 36, 519, DateTimeKind.Utc).AddTicks(8628));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "UnitId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 6, 5, 11, 11, 36, 519, DateTimeKind.Utc).AddTicks(8629));
        }
    }
}
