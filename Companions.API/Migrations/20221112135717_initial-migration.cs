using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Companions.API.Migrations
{
    /// <inheritdoc />
    public partial class initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ActivityTypes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ActivityTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppointmentTypes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FeedBrands",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedBrands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Species",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SpeciesName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpeciesRace = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Species", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ActivityTypeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Activities_ActivityTypes_ActivityTypeId",
                        column: x => x.ActivityTypeId,
                        principalTable: "ActivityTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AppoinmentDueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AppointmentTypeId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_AppointmentTypes_AppointmentTypeId",
                        column: x => x.AppointmentTypeId,
                        principalTable: "AppointmentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FeedProducts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FeedBrandId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductURL = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FeedProducts_FeedBrands_FeedBrandId",
                        column: x => x.FeedBrandId,
                        principalTable: "FeedBrands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Buddies",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SpeciesId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccountId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buddies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Buddies_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Buddies_Species_SpeciesId",
                        column: x => x.SpeciesId,
                        principalTable: "Species",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FeedingSchedules",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FeedProductId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TimeOfDay = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedingSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FeedingSchedules_FeedProducts_FeedProductId",
                        column: x => x.FeedProductId,
                        principalTable: "FeedProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActivityBuddy",
                columns: table => new
                {
                    ActivitiesId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BuddiesId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityBuddy", x => new { x.ActivitiesId, x.BuddiesId });
                    table.ForeignKey(
                        name: "FK_ActivityBuddy_Activities_ActivitiesId",
                        column: x => x.ActivitiesId,
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivityBuddy_Buddies_BuddiesId",
                        column: x => x.BuddiesId,
                        principalTable: "Buddies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "BuddyWeights",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BuddyId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    DateWeighed = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuddyWeights", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuddyWeights_Buddies_BuddyId",
                        column: x => x.BuddyId,
                        principalTable: "Buddies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vaccinations",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BuddyId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateFirstVaccination = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AmountOfRepeats = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaccinations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vaccinations_Buddies_BuddyId",
                        column: x => x.BuddyId,
                        principalTable: "Buddies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_Activities_ActivityTypeId",
                table: "Activities",
                column: "ActivityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityBuddy_BuddiesId",
                table: "ActivityBuddy",
                column: "BuddiesId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentBuddy_BuddiesId",
                table: "AppointmentBuddy",
                column: "BuddiesId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_AppointmentTypeId",
                table: "Appointments",
                column: "AppointmentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Buddies_AccountId",
                table: "Buddies",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Buddies_SpeciesId",
                table: "Buddies",
                column: "SpeciesId");

            migrationBuilder.CreateIndex(
                name: "IX_BuddyWeights_BuddyId",
                table: "BuddyWeights",
                column: "BuddyId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyFeeding_BuddyId",
                table: "DailyFeeding",
                column: "BuddyId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyFeeding_FeedingScheduleId",
                table: "DailyFeeding",
                column: "FeedingScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_FeedingSchedules_FeedProductId",
                table: "FeedingSchedules",
                column: "FeedProductId");

            migrationBuilder.CreateIndex(
                name: "IX_FeedProducts_FeedBrandId",
                table: "FeedProducts",
                column: "FeedBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Vaccinations_BuddyId",
                table: "Vaccinations",
                column: "BuddyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityBuddy");

            migrationBuilder.DropTable(
                name: "AppointmentBuddy");

            migrationBuilder.DropTable(
                name: "BuddyWeights");

            migrationBuilder.DropTable(
                name: "DailyFeeding");

            migrationBuilder.DropTable(
                name: "Vaccinations");

            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "FeedingSchedules");

            migrationBuilder.DropTable(
                name: "Buddies");

            migrationBuilder.DropTable(
                name: "ActivityTypes");

            migrationBuilder.DropTable(
                name: "AppointmentTypes");

            migrationBuilder.DropTable(
                name: "FeedProducts");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Species");

            migrationBuilder.DropTable(
                name: "FeedBrands");
        }
    }
}
