using Microsoft.EntityFrameworkCore.Migrations;

namespace Zerog.Data.Migrations
{
    public partial class EditNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCounts_Laptops_LaptopId",
                table: "ProductCounts");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCounts_ShoppingCarts_CartId",
                table: "ProductCounts");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCarts_AspNetUsers_UserId",
                table: "ShoppingCarts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingCarts",
                table: "ShoppingCarts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductCounts",
                table: "ProductCounts");

            migrationBuilder.RenameTable(
                name: "ShoppingCarts",
                newName: "Carts");

            migrationBuilder.RenameTable(
                name: "ProductCounts",
                newName: "CartItems");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCarts_UserId",
                table: "Carts",
                newName: "IX_Carts_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCarts_IsDeleted",
                table: "Carts",
                newName: "IX_Carts_IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCounts_LaptopId",
                table: "CartItems",
                newName: "IX_CartItems_LaptopId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCounts_IsDeleted",
                table: "CartItems",
                newName: "IX_CartItems_IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCounts_CartId",
                table: "CartItems",
                newName: "IX_CartItems_CartId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Carts",
                table: "Carts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CartItems",
                table: "CartItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Carts_CartId",
                table: "CartItems",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Laptops_LaptopId",
                table: "CartItems",
                column: "LaptopId",
                principalTable: "Laptops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_AspNetUsers_UserId",
                table: "Carts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Carts_CartId",
                table: "CartItems");

            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Laptops_LaptopId",
                table: "CartItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Carts_AspNetUsers_UserId",
                table: "Carts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Carts",
                table: "Carts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CartItems",
                table: "CartItems");

            migrationBuilder.RenameTable(
                name: "Carts",
                newName: "ShoppingCarts");

            migrationBuilder.RenameTable(
                name: "CartItems",
                newName: "ProductCounts");

            migrationBuilder.RenameIndex(
                name: "IX_Carts_UserId",
                table: "ShoppingCarts",
                newName: "IX_ShoppingCarts_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Carts_IsDeleted",
                table: "ShoppingCarts",
                newName: "IX_ShoppingCarts_IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_CartItems_LaptopId",
                table: "ProductCounts",
                newName: "IX_ProductCounts_LaptopId");

            migrationBuilder.RenameIndex(
                name: "IX_CartItems_IsDeleted",
                table: "ProductCounts",
                newName: "IX_ProductCounts_IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_CartItems_CartId",
                table: "ProductCounts",
                newName: "IX_ProductCounts_CartId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingCarts",
                table: "ShoppingCarts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductCounts",
                table: "ProductCounts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCounts_Laptops_LaptopId",
                table: "ProductCounts",
                column: "LaptopId",
                principalTable: "Laptops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCounts_ShoppingCarts_CartId",
                table: "ProductCounts",
                column: "CartId",
                principalTable: "ShoppingCarts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCarts_AspNetUsers_UserId",
                table: "ShoppingCarts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
