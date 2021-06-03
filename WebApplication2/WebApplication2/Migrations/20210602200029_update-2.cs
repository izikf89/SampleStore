using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication2.Migrations
{
    public partial class update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_productImage_Prodact_ProductId",
                table: "productImage");

            migrationBuilder.DropIndex(
                name: "IX_productImage_ProductId",
                table: "productImage");

            migrationBuilder.AlterColumn<string>(
                name: "ProductId",
                table: "productImage",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductId1",
                table: "productImage",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "imgPath",
                table: "Category",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_productImage_ProductId1",
                table: "productImage",
                column: "ProductId1");

            migrationBuilder.AddForeignKey(
                name: "FK_productImage_Prodact_ProductId1",
                table: "productImage",
                column: "ProductId1",
                principalTable: "Prodact",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_productImage_Prodact_ProductId1",
                table: "productImage");

            migrationBuilder.DropIndex(
                name: "IX_productImage_ProductId1",
                table: "productImage");

            migrationBuilder.DropColumn(
                name: "ProductId1",
                table: "productImage");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "productImage",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "imgPath",
                table: "Category",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_productImage_ProductId",
                table: "productImage",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_productImage_Prodact_ProductId",
                table: "productImage",
                column: "ProductId",
                principalTable: "Prodact",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
