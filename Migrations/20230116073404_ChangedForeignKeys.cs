using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimplyHorsePower.Migrations
{
    /// <inheritdoc />
    public partial class ChangedForeignKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MakeName",
                table: "Products",
                newName: "MakeId");

            migrationBuilder.RenameColumn(
                name: "CategoryName",
                table: "Products",
                newName: "CategoryId");

            migrationBuilder.RenameColumn(
                name: "CategoryID",
                table: "Categories",
                newName: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MakeId",
                table: "Products",
                newName: "MakeName");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Products",
                newName: "CategoryName");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Categories",
                newName: "CategoryID");
        }
    }
}
