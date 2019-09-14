using Microsoft.EntityFrameworkCore.Migrations;

namespace HypSuite.Data.Migrations
{
    public partial class seventh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Clients_HotelClientClientID",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Locations_HotelClientClientID",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "HotelClientClientID",
                table: "Locations");

            migrationBuilder.AddColumn<int>(
                name: "ClientID",
                table: "Locations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Locations_ClientID",
                table: "Locations",
                column: "ClientID");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Clients_ClientID",
                table: "Locations",
                column: "ClientID",
                principalTable: "Clients",
                principalColumn: "ClientID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Clients_ClientID",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Locations_ClientID",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "ClientID",
                table: "Locations");

            migrationBuilder.AddColumn<int>(
                name: "HotelClientClientID",
                table: "Locations",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Locations_HotelClientClientID",
                table: "Locations",
                column: "HotelClientClientID");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Clients_HotelClientClientID",
                table: "Locations",
                column: "HotelClientClientID",
                principalTable: "Clients",
                principalColumn: "ClientID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
