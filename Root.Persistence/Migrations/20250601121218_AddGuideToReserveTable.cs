using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Root.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddGuideToReserveTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "GuideId",
                table: "Reserves",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Reserves_GuideId",
                table: "Reserves",
                column: "GuideId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reserves_Guides_GuideId",
                table: "Reserves",
                column: "GuideId",
                principalTable: "Guides",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reserves_Guides_GuideId",
                table: "Reserves");

            migrationBuilder.DropIndex(
                name: "IX_Reserves_GuideId",
                table: "Reserves");

            migrationBuilder.DropColumn(
                name: "GuideId",
                table: "Reserves");
        }
    }
}
