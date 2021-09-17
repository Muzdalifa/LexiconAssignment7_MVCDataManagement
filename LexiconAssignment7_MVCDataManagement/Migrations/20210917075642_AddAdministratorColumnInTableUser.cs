using Microsoft.EntityFrameworkCore.Migrations;

namespace LexiconAssignment7_MVCDataManagement.Migrations
{
    public partial class AddAdministratorColumnInTableUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAdministarator",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAdministarator",
                table: "AspNetUsers");
        }
    }
}
