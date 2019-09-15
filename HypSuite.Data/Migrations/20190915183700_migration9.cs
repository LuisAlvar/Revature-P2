using Microsoft.EntityFrameworkCore.Migrations;

namespace HypSuite.Data.Migrations
{
    public partial class migration9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Guest_Clients_HotelClientClientID",
                table: "Guest");

            migrationBuilder.DropForeignKey(
                name: "FK_Guest_Reservation_ReservationID",
                table: "Guest");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Clients_HotelClientClientID",
                table: "Reservation");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Locations_HotelsLocationLocationID",
                table: "Reservation");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Reservation_ReservationID",
                table: "Rooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservation",
                table: "Reservation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Guest",
                table: "Guest");

            migrationBuilder.DropIndex(
                name: "IX_Guest_ReservationID",
                table: "Guest");

            migrationBuilder.RenameTable(
                name: "Reservation",
                newName: "Reservations");

            migrationBuilder.RenameTable(
                name: "Guest",
                newName: "Guests");

            migrationBuilder.RenameColumn(
                name: "ReservationID",
                table: "Rooms",
                newName: "ReservationID1");

            migrationBuilder.RenameIndex(
                name: "IX_Rooms_ReservationID",
                table: "Rooms",
                newName: "IX_Rooms_ReservationID1");

            migrationBuilder.RenameIndex(
                name: "IX_Reservation_HotelsLocationLocationID",
                table: "Reservations",
                newName: "IX_Reservations_HotelsLocationLocationID");

            migrationBuilder.RenameIndex(
                name: "IX_Reservation_HotelClientClientID",
                table: "Reservations",
                newName: "IX_Reservations_HotelClientClientID");

            migrationBuilder.RenameIndex(
                name: "IX_Guest_HotelClientClientID",
                table: "Guests",
                newName: "IX_Guests_HotelClientClientID");

            migrationBuilder.AddColumn<int>(
                name: "CustomerGuestID",
                table: "Reservations",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GuestID",
                table: "Reservations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reservations",
                table: "Reservations",
                column: "ReservationID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Guests",
                table: "Guests",
                column: "GuestID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_CustomerGuestID",
                table: "Reservations",
                column: "CustomerGuestID");

            migrationBuilder.AddForeignKey(
                name: "FK_Guests_Clients_HotelClientClientID",
                table: "Guests",
                column: "HotelClientClientID",
                principalTable: "Clients",
                principalColumn: "ClientID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Guests_CustomerGuestID",
                table: "Reservations",
                column: "CustomerGuestID",
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
                name: "FK_Rooms_Reservations_ReservationID1",
                table: "Rooms",
                column: "ReservationID1",
                principalTable: "Reservations",
                principalColumn: "ReservationID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Guests_Clients_HotelClientClientID",
                table: "Guests");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Guests_CustomerGuestID",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Clients_HotelClientClientID",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Locations_HotelsLocationLocationID",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Reservations_ReservationID1",
                table: "Rooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservations",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_CustomerGuestID",
                table: "Reservations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Guests",
                table: "Guests");

            migrationBuilder.DropColumn(
                name: "CustomerGuestID",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "GuestID",
                table: "Reservations");

            migrationBuilder.RenameTable(
                name: "Reservations",
                newName: "Reservation");

            migrationBuilder.RenameTable(
                name: "Guests",
                newName: "Guest");

            migrationBuilder.RenameColumn(
                name: "ReservationID1",
                table: "Rooms",
                newName: "ReservationID");

            migrationBuilder.RenameIndex(
                name: "IX_Rooms_ReservationID1",
                table: "Rooms",
                newName: "IX_Rooms_ReservationID");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_HotelsLocationLocationID",
                table: "Reservation",
                newName: "IX_Reservation_HotelsLocationLocationID");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_HotelClientClientID",
                table: "Reservation",
                newName: "IX_Reservation_HotelClientClientID");

            migrationBuilder.RenameIndex(
                name: "IX_Guests_HotelClientClientID",
                table: "Guest",
                newName: "IX_Guest_HotelClientClientID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reservation",
                table: "Reservation",
                column: "ReservationID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Guest",
                table: "Guest",
                column: "GuestID");

            migrationBuilder.CreateIndex(
                name: "IX_Guest_ReservationID",
                table: "Guest",
                column: "ReservationID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Guest_Clients_HotelClientClientID",
                table: "Guest",
                column: "HotelClientClientID",
                principalTable: "Clients",
                principalColumn: "ClientID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Guest_Reservation_ReservationID",
                table: "Guest",
                column: "ReservationID",
                principalTable: "Reservation",
                principalColumn: "ReservationID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Clients_HotelClientClientID",
                table: "Reservation",
                column: "HotelClientClientID",
                principalTable: "Clients",
                principalColumn: "ClientID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Locations_HotelsLocationLocationID",
                table: "Reservation",
                column: "HotelsLocationLocationID",
                principalTable: "Locations",
                principalColumn: "LocationID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Reservation_ReservationID",
                table: "Rooms",
                column: "ReservationID",
                principalTable: "Reservation",
                principalColumn: "ReservationID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
