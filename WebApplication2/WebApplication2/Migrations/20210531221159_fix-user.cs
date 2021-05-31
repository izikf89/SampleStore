using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication2.Migrations
{
    public partial class fixuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "type",
                table: "User",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "User",
                newName: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "User",
                newName: "type");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "User",
                newName: "name");
        }
    }
}
