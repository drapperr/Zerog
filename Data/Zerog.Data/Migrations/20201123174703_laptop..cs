using Microsoft.EntityFrameworkCore.Migrations;

namespace Zerog.Data.Migrations
{
    public partial class laptop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Laptops",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Discount",
                table: "Laptops",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Laptops");

            migrationBuilder.DropColumn(
                name: "Discount",
                table: "Laptops");
        }
    }
}
