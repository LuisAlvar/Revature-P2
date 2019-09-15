using Microsoft.EntityFrameworkCore.Migrations;

namespace HypSuite.Data.Migrations
{
    public partial class migration10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Guests_CustomerGuestID",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_CustomerGuestID",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "CustomerGuestID",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "ReservationID",
                table: "Guests");

            migrationBuilder.AlterColumn<int>(
                name: "GuestID",
                table: "Reservations",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_GuestID",
                table: "Reservations",
                column: "GuestID");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Guests_GuestID",
                table: "Reservations",
                column: "GuestID",
                principalTable: "Guests",
                principalColumn: "GuestID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Guests_GuestID",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_GuestID",
                table: "Reservations");

            migrationBuilder.AlterColumn<int>(
                name: "GuestID",
                table: "Reservations",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomerGuestID",
                table: "Reservations",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReservationID",
                table: "Guests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_CustomerGuestID",
                table: "Reservations",
                column: "CustomerGuestID");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Guests_CustomerGuestID",
                table: "Reservations",
                column: "CustomerGuestID",
                principalTable: "Guests",
                principalColumn: "GuestID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
