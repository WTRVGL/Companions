using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Companions.API.Migrations
{
    /// <inheritdoc />
    public partial class FKs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppointmentBuddy");

            migrationBuilder.AddColumn<string>(
                name: "BuddyId",
                table: "Appointments",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_BuddyId",
                table: "Appointments",
                column: "BuddyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Buddies_BuddyId",
                table: "Appointments",
                column: "BuddyId",
                principalTable: "Buddies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Buddies_BuddyId",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_BuddyId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "BuddyId",
                table: "Appointments");

            migrationBuilder.CreateTable(
                name: "AppointmentBuddy",
                columns: table => new
                {
                    AppointmentsId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BuddiesId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentBuddy", x => new { x.AppointmentsId, x.BuddiesId });
                    table.ForeignKey(
                        name: "FK_AppointmentBuddy_Appointments_AppointmentsId",
                        column: x => x.AppointmentsId,
                        principalTable: "Appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppointmentBuddy_Buddies_BuddiesId",
                        column: x => x.BuddiesId,
                        principalTable: "Buddies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentBuddy_BuddiesId",
                table: "AppointmentBuddy",
                column: "BuddiesId");
        }
    }
}
