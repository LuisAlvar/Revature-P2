using Microsoft.EntityFrameworkCore.Migrations;

namespace HypSuite.Data.Migrations
{
    public partial class migration11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Guests");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Guests");

            migrationBuilder.AddColumn<int>(
                name: "PartySize",
                table: "Guests",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PartySize",
                table: "Guests");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Guests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Guests",
                nullable: true);
        }
    }
}
