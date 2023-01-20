using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimplyHorsePower.Migrations
{
    /// <inheritdoc />
    public partial class CHangedImagesToStringLocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MainProductImage",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductGalleryByte",
                table: "productGalleryImages");

            migrationBuilder.AddColumn<string>(
                name: "MainProductImageLocation",
                table: "Products",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ProductGalleryImageLoation",
                table: "productGalleryImages",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MainProductImageLocation",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductGalleryImageLoation",
                table: "productGalleryImages");

            migrationBuilder.AddColumn<byte[]>(
                name: "MainProductImage",
                table: "Products",
                type: "longblob",
                nullable: false);

            migrationBuilder.AddColumn<byte[]>(
                name: "ProductGalleryByte",
                table: "productGalleryImages",
                type: "longblob",
                nullable: false);
        }
    }
}
