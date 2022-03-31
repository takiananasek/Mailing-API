using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClientApi.Migrations
{
    public partial class NM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Clients",
                newName: "ClientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "Clients",
                newName: "Id");
        }
    }
}
