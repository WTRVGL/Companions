using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Companions.API.Migrations
{
    /// <inheritdoc />
    public partial class FeedSchedulerelationupdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailyFeeding");

            migrationBuilder.AddColumn<string>(
                name: "BuddyId",
                table: "FeedingSchedules",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DailyFeedingEvents",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BuddyId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FeedingScheduleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyFeedingEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailyFeedingEvents_Buddies_BuddyId",
                        column: x => x.BuddyId,
                        principalTable: "Buddies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DailyFeedingEvents_FeedingSchedules_FeedingScheduleId",
                        column: x => x.FeedingScheduleId,
                        principalTable: "FeedingSchedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FeedingSchedules_BuddyId",
                table: "FeedingSchedules",
                column: "BuddyId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyFeedingEvents_BuddyId",
                table: "DailyFeedingEvents",
                column: "BuddyId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyFeedingEvents_FeedingScheduleId",
                table: "DailyFeedingEvents",
                column: "FeedingScheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_FeedingSchedules_Buddies_BuddyId",
                table: "FeedingSchedules",
                column: "BuddyId",
                principalTable: "Buddies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FeedingSchedules_Buddies_BuddyId",
                table: "FeedingSchedules");

            migrationBuilder.DropTable(
                name: "DailyFeedingEvents");

            migrationBuilder.DropIndex(
                name: "IX_FeedingSchedules_BuddyId",
                table: "FeedingSchedules");

            migrationBuilder.DropColumn(
                name: "BuddyId",
                table: "FeedingSchedules");

            migrationBuilder.CreateTable(
                name: "DailyFeeding",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BuddyId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FeedingScheduleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyFeeding", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailyFeeding_Buddies_BuddyId",
                        column: x => x.BuddyId,
                        principalTable: "Buddies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DailyFeeding_FeedingSchedules_FeedingScheduleId",
                        column: x => x.FeedingScheduleId,
                        principalTable: "FeedingSchedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
