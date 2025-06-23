using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Root.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addedClientIdOnCustomPackage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CustomPackageClientId",
                table: "Packages",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.UpdateData(
                table: "Administrators",
                keyColumn: "Id",
                keyValue: new Guid("5d5629f7-cce5-43b3-8a7f-821c9c5fd0a2"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 6, 16, 21, 35, 3, 171, DateTimeKind.Local).AddTicks(7761), new DateTime(2025, 6, 16, 21, 35, 3, 171, DateTimeKind.Local).AddTicks(7762) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("edd7155e-5723-4bf9-bd43-e935823a7c0f"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2025, 6, 16, 21, 35, 3, 171, DateTimeKind.Local).AddTicks(7508), new DateTime(2025, 6, 16, 21, 35, 3, 171, DateTimeKind.Local).AddTicks(7538) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomPackageClientId",
                table: "Packages");

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
    }
}
