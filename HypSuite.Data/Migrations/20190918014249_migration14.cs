using Microsoft.EntityFrameworkCore.Migrations;

namespace HypSuite.Data.Migrations
{
    public partial class migration14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Reservations_ReservationId",
                table: "Rooms");

            migrationBuilder.RenameColumn(
                name: "ReservationId",
                table: "Rooms",
                newName: "ReservationRefId");

            migrationBuilder.RenameColumn(
                name: "ReservationID",
                table: "Rooms",
                newName: "ReservationRefID");

            migrationBuilder.RenameIndex(
                name: "IX_Rooms_ReservationId",
                table: "Rooms",
                newName: "IX_Rooms_ReservationRefId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Reservations_ReservationRefId",
                table: "Rooms",
                column: "ReservationRefId",
                principalTable: "Reservations",
                principalColumn: "ReservationID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Reservations_ReservationRefId",
                table: "Rooms");

            migrationBuilder.RenameColumn(
                name: "ReservationRefId",
                table: "Rooms",
                newName: "ReservationId");

            migrationBuilder.RenameColumn(
                name: "ReservationRefID",
                table: "Rooms",
                newName: "ReservationID");

            migrationBuilder.RenameIndex(
                name: "IX_Rooms_ReservationRefId",
                table: "Rooms",
                newName: "IX_Rooms_ReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Reservations_ReservationId",
                table: "Rooms",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "ReservationID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
