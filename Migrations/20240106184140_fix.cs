using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace oshopAPI.Migrations
{
    public partial class fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Products",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Products",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Products",
                newName: "imageUrl");

            migrationBuilder.RenameColumn(
                name: "IdCategory",
                table: "Products",
                newName: "category");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "title",
                table: "Products",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "Products",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "imageUrl",
                table: "Products",
                newName: "ImageUrl");

            migrationBuilder.RenameColumn(
                name: "category",
                table: "Products",
                newName: "IdCategory");
        }
    }
}
