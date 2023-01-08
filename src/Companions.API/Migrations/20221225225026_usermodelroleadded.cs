using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Companions.API.Migrations
{
    /// <inheritdoc />
    public partial class usermodelroleadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailyFeeding");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "DailyFeeding",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BuddyId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FeedingScheduleId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyFeeding", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailyFeeding_Buddies_BuddyId",
                        column: x => x.BuddyId,
                        principalTable: "Buddies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DailyFeeding_FeedingSchedules_FeedingScheduleId",
                        column: x => x.FeedingScheduleId,
                        principalTable: "FeedingSchedules",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DailyFeeding_BuddyId",
                table: "DailyFeeding",
                column: "BuddyId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyFeeding_FeedingScheduleId",
                table: "DailyFeeding",
                column: "FeedingScheduleId");
        }
    }
}
