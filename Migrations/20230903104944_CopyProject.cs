using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TistoryCategoryManager.Migrations
{
    /// <inheritdoc />
    public partial class CopyProject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_improvementCategories",
                table: "improvementCategories");

            migrationBuilder.RenameTable(
                name: "improvementCategories",
                newName: "ImprovementCategories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImprovementCategories",
                table: "ImprovementCategories",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "sp_HabitCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    KORCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    UsageStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Usage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OpenStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Open = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegistrationDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModificationDate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sp_HabitCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImprovementCategories",
                table: "ImprovementCategories");

            migrationBuilder.RenameTable(
                name: "ImprovementCategories",
                newName: "improvementCategories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_improvementCategories",
                table: "improvementCategories",
                column: "Id");
        }
    }
}
