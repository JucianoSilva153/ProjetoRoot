using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Root.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Administrators",
                keyColumn: "Id",
                keyValue: new Guid("5d5629f7-cce5-43b3-8a7f-821c9c5fd0a2"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 6, 2, 12, 12, 29, 756, DateTimeKind.Local).AddTicks(1195), new DateTime(2025, 6, 2, 12, 12, 29, 756, DateTimeKind.Local).AddTicks(1196) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("edd7155e-5723-4bf9-bd43-e935823a7c0f"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 6, 2, 12, 12, 29, 756, DateTimeKind.Local).AddTicks(1082), new DateTime(2025, 6, 2, 12, 12, 29, 756, DateTimeKind.Local).AddTicks(1097) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Administrators",
                keyColumn: "Id",
                keyValue: new Guid("5d5629f7-cce5-43b3-8a7f-821c9c5fd0a2"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 6, 1, 22, 4, 11, 139, DateTimeKind.Local).AddTicks(2658), new DateTime(2025, 6, 1, 22, 4, 11, 139, DateTimeKind.Local).AddTicks(2658) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("edd7155e-5723-4bf9-bd43-e935823a7c0f"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 6, 1, 22, 4, 11, 139, DateTimeKind.Local).AddTicks(2571), new DateTime(2025, 6, 1, 22, 4, 11, 139, DateTimeKind.Local).AddTicks(2583) });
        }
    }
}
