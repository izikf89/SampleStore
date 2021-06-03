using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication2.Migrations
{
    public partial class update10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_productImage_Prodact_ProductId1",
                table: "productImage");

            migrationBuilder.RenameColumn(
                name: "ProductId1",
                table: "productImage",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_productImage_ProductId1",
                table: "productImage",
                newName: "IX_productImage_ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_productImage_Prodact_ProductId",
                table: "productImage",
                column: "ProductId",
                principalTable: "Prodact",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_productImage_Prodact_ProductId",
                table: "productImage");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "productImage",
                newName: "ProductId1");

            migrationBuilder.RenameIndex(
                name: "IX_productImage_ProductId",
                table: "productImage",
                newName: "IX_productImage_ProductId1");

            migrationBuilder.AddForeignKey(
                name: "FK_productImage_Prodact_ProductId1",
                table: "productImage",
                column: "ProductId1",
                principalTable: "Prodact",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
