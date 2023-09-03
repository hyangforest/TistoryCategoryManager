using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TistoryCategoryManager.Migrations
{
    /// <inheritdoc />
    public partial class CopyProjectNewVersion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "sp_HabitCategories",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_sp_HabitCategories",
                table: "sp_HabitCategories",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_sp_HabitCategories",
                table: "sp_HabitCategories");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "sp_HabitCategories",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");
        }
    }
}
