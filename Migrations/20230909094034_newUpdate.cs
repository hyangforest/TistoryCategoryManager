using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TistoryCategoryManager.Migrations
{
    /// <inheritdoc />
    public partial class newUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecordCategories");

            migrationBuilder.AddColumn<string>(
                name: "ENGCategoryName",
                table: "ImprovementCategories",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ENGCategoryName",
                table: "ImprovementCategories");

            migrationBuilder.CreateTable(
                name: "RecordCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ENGCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KORCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OpenStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    UsageStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecordCategories", x => x.Id);
                });
        }
    }
}
