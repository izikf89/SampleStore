using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication2.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_productImage_Prodact_ProdactProductId",
                table: "productImage");

            migrationBuilder.DropTable(
                name: "CategoryProdact");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "User");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "ProdactProductId",
                table: "productImage",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_productImage_ProdactProductId",
                table: "productImage",
                newName: "IX_productImage_ProductId");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Prodact",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Prodact",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Category",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "CategoryProduct",
                columns: table => new
                {
                    CategoriesCategoryId = table.Column<int>(type: "int", nullable: false),
                    ProdactsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryProduct", x => new { x.CategoriesCategoryId, x.ProdactsId });
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Category_CategoriesCategoryId",
                        column: x => x.CategoriesCategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Prodact_ProdactsId",
                        column: x => x.ProdactsId,
                        principalTable: "Prodact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryProduct_ProdactsId",
                table: "CategoryProduct",
                column: "ProdactsId");

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

            migrationBuilder.DropTable(
                name: "CategoryProduct");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "productImage",
                newName: "ProdactProductId");

            migrationBuilder.RenameIndex(
                name: "IX_productImage_ProductId",
                table: "productImage",
                newName: "IX_productImage_ProdactProductId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Prodact",
                newName: "ProductId");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "User",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "User",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Prodact",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Category",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "CategoryProdact",
                columns: table => new
                {
                    CategoriesCategoryId = table.Column<int>(type: "int", nullable: false),
                    ProdactsProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryProdact", x => new { x.CategoriesCategoryId, x.ProdactsProductId });
                    table.ForeignKey(
                        name: "FK_CategoryProdact_Category_CategoriesCategoryId",
                        column: x => x.CategoriesCategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryProdact_Prodact_ProdactsProductId",
                        column: x => x.ProdactsProductId,
                        principalTable: "Prodact",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryProdact_ProdactsProductId",
                table: "CategoryProdact",
                column: "ProdactsProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_productImage_Prodact_ProdactProductId",
                table: "productImage",
                column: "ProdactProductId",
                principalTable: "Prodact",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
