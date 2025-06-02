using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Root.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class adSedd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Contact", "CreatedAt", "Email", "ModifiedAt", "ModifiedBy", "Password", "Type", "UserName" },
                values: new object[] { new Guid("edd7155e-5723-4bf9-bd43-e935823a7c0f"), "923679528", new DateTime(2025, 6, 1, 22, 4, 11, 139, DateTimeKind.Local).AddTicks(2571), "jucs@gmail.com", new DateTime(2025, 6, 1, 22, 4, 11, 139, DateTimeKind.Local).AddTicks(2583), null, "123456", 0, "Jucs" });

            migrationBuilder.InsertData(
                table: "Administrators",
                columns: new[] { "Id", "AcessLeves", "CreatedAt", "ModifiedAt", "ModifiedBy", "Name", "Role", "Surname", "UserId" },
                values: new object[] { new Guid("5d5629f7-cce5-43b3-8a7f-821c9c5fd0a2"), "[0]", new DateTime(2025, 6, 1, 22, 4, 11, 139, DateTimeKind.Local).AddTicks(2658), new DateTime(2025, 6, 1, 22, 4, 11, 139, DateTimeKind.Local).AddTicks(2658), null, "Juciano", null, "Silva", new Guid("edd7155e-5723-4bf9-bd43-e935823a7c0f") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Administrators",
                keyColumn: "Id",
                keyValue: new Guid("5d5629f7-cce5-43b3-8a7f-821c9c5fd0a2"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("edd7155e-5723-4bf9-bd43-e935823a7c0f"));
        }
    }
}
