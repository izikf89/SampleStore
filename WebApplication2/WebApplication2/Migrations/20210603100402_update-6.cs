using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication2.Migrations
{
    public partial class update6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prodact_Order_OrderId",
                table: "Prodact");

            migrationBuilder.DropIndex(
                name: "IX_Prodact_OrderId",
                table: "Prodact");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Prodact");

            migrationBuilder.CreateTable(
                name: "OrderProduct",
                columns: table => new
                {
                    OrdersId = table.Column<int>(type: "int", nullable: false),
                    ProdactsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProduct", x => new { x.OrdersId, x.ProdactsId });
                    table.ForeignKey(
                        name: "FK_OrderProduct_Order_OrdersId",
                        column: x => x.OrdersId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderProduct_Prodact_ProdactsId",
                        column: x => x.ProdactsId,
                        principalTable: "Prodact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_ProdactsId",
                table: "OrderProduct",
                column: "ProdactsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderProduct");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Prodact",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Prodact_OrderId",
                table: "Prodact",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prodact_Order_OrderId",
                table: "Prodact",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
