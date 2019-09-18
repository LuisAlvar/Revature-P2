using Microsoft.EntityFrameworkCore.Migrations;

namespace HypSuite.Data.Migrations
{
    public partial class migration13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Guests_Clients_HotelClientClientID",
                table: "Guests");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Clients_ClientID",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Guests_GuestID",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Clients_HotelClientClientID",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Locations_HotelsLocationLocationID",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Locations_LocationID",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Reservations_ReservationID1",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_HotelClientClientID",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_HotelsLocationLocationID",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Guests_HotelClientClientID",
                table: "Guests");

            migrationBuilder.DropColumn(
                name: "HotelClientClientID",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "HotelsLocationLocationID",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "HotelClientClientID",
                table: "Guests");

            migrationBuilder.RenameColumn(
                name: "ReservationID1",
                table: "Rooms",
                newName: "ReservationId");

            migrationBuilder.RenameColumn(
                name: "LocationID",
                table: "Rooms",
                newName: "LocationRefID");

            migrationBuilder.RenameIndex(
                name: "IX_Rooms_ReservationID1",
                table: "Rooms",
                newName: "IX_Rooms_ReservationId");

            migrationBuilder.RenameIndex(
                name: "IX_Rooms_LocationID",
                table: "Rooms",
                newName: "IX_Rooms_LocationRefID");

            migrationBuilder.RenameColumn(
                name: "ClientID",
                table: "Locations",
                newName: "ClientLocationsID");

            migrationBuilder.RenameIndex(
                name: "IX_Locations_ClientID",
                table: "Locations",
                newName: "IX_Locations_ClientLocationsID");

            migrationBuilder.AddColumn<int>(
                name: "ReservationID",
                table: "Rooms",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GuestID",
                table: "Reservations",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClientHistoryID",
                table: "Reservations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LocationID",
                table: "Reservations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ClientGuestsID",
                table: "Guests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ClientHistoryID",
                table: "Reservations",
                column: "ClientHistoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_LocationID",
                table: "Reservations",
                column: "LocationID");

            migrationBuilder.CreateIndex(
                name: "IX_Guests_ClientGuestsID",
                table: "Guests",
                column: "ClientGuestsID");

            migrationBuilder.AddForeignKey(
                name: "FK_Guests_Clients_ClientGuestsID",
                table: "Guests",
                column: "ClientGuestsID",
                principalTable: "Clients",
                principalColumn: "ClientID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Clients_ClientLocationsID",
                table: "Locations",
                column: "ClientLocationsID",
                principalTable: "Clients",
                principalColumn: "ClientID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Clients_ClientHistoryID",
                table: "Reservations",
                column: "ClientHistoryID",
                principalTable: "Clients",
                principalColumn: "ClientID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Guests_GuestID",
                table: "Reservations",
                column: "GuestID",
                principalTable: "Guests",
                principalColumn: "GuestID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Locations_LocationID",
                table: "Reservations",
                column: "LocationID",
                principalTable: "Locations",
                principalColumn: "LocationID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Locations_LocationRefID",
                table: "Rooms",
                column: "LocationRefID",
                principalTable: "Locations",
                principalColumn: "LocationID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Reservations_ReservationId",
                table: "Rooms",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "ReservationID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Guests_Clients_ClientGuestsID",
                table: "Guests");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Clients_ClientLocationsID",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Clients_ClientHistoryID",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Guests_GuestID",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Locations_LocationID",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Locations_LocationRefID",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Reservations_ReservationId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_ClientHistoryID",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_LocationID",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Guests_ClientGuestsID",
                table: "Guests");

            migrationBuilder.DropColumn(
                name: "ReservationID",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "ClientHistoryID",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "LocationID",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "ClientGuestsID",
                table: "Guests");

            migrationBuilder.RenameColumn(
                name: "ReservationId",
                table: "Rooms",
                newName: "ReservationID1");

            migrationBuilder.RenameColumn(
                name: "LocationRefID",
                table: "Rooms",
                newName: "LocationID");

            migrationBuilder.RenameIndex(
                name: "IX_Rooms_ReservationId",
                table: "Rooms",
                newName: "IX_Rooms_ReservationID1");

            migrationBuilder.RenameIndex(
                name: "IX_Rooms_LocationRefID",
                table: "Rooms",
                newName: "IX_Rooms_LocationID");

            migrationBuilder.RenameColumn(
                name: "ClientLocationsID",
                table: "Locations",
                newName: "ClientID");

            migrationBuilder.RenameIndex(
                name: "IX_Locations_ClientLocationsID",
                table: "Locations",
                newName: "IX_Locations_ClientID");

            migrationBuilder.AlterColumn<int>(
                name: "GuestID",
                table: "Reservations",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "HotelClientClientID",
                table: "Reservations",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HotelsLocationLocationID",
                table: "Reservations",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HotelClientClientID",
                table: "Guests",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_HotelClientClientID",
                table: "Reservations",
                column: "HotelClientClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_HotelsLocationLocationID",
                table: "Reservations",
                column: "HotelsLocationLocationID");

            migrationBuilder.CreateIndex(
                name: "IX_Guests_HotelClientClientID",
                table: "Guests",
                column: "HotelClientClientID");

            migrationBuilder.AddForeignKey(
                name: "FK_Guests_Clients_HotelClientClientID",
                table: "Guests",
                column: "HotelClientClientID",
                principalTable: "Clients",
                principalColumn: "ClientID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Clients_ClientID",
                table: "Locations",
                column: "ClientID",
                principalTable: "Clients",
                principalColumn: "ClientID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Guests_GuestID",
                table: "Reservations",
                column: "GuestID",
                principalTable: "Guests",
                principalColumn: "GuestID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Clients_HotelClientClientID",
                table: "Reservations",
                column: "HotelClientClientID",
                principalTable: "Clients",
                principalColumn: "ClientID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Locations_HotelsLocationLocationID",
                table: "Reservations",
                column: "HotelsLocationLocationID",
                principalTable: "Locations",
                principalColumn: "LocationID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Locations_LocationID",
                table: "Rooms",
                column: "LocationID",
                principalTable: "Locations",
                principalColumn: "LocationID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Reservations_ReservationID1",
                table: "Rooms",
                column: "ReservationID1",
                principalTable: "Reservations",
                principalColumn: "ReservationID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
