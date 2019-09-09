using Microsoft.EntityFrameworkCore.Migrations;

namespace HypSuite.Data.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Locations_LocationID",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "NumberOfFloors",
                table: "Locations");

            migrationBuilder.AlterColumn<int>(
                name: "LocationID",
                table: "Rooms",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Clients",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Clients",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Locations_LocationID",
                table: "Rooms",
                column: "LocationID",
                principalTable: "Locations",
                principalColumn: "LocationID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Locations_LocationID",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Clients");

            migrationBuilder.AlterColumn<int>(
                name: "LocationID",
                table: "Rooms",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "NumberOfFloors",
                table: "Locations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Locations_LocationID",
                table: "Rooms",
                column: "LocationID",
                principalTable: "Locations",
                principalColumn: "LocationID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
