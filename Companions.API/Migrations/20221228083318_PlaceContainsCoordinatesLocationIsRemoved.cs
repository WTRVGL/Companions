using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Companions.API.Migrations
{
    /// <inheritdoc />
    public partial class PlaceContainsCoordinatesLocationIsRemoved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Places_Locations_LocationId",
                table: "Places");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Places_LocationId",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Places");

            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "Places",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "Places",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Places");

            migrationBuilder.AddColumn<string>(
                name: "LocationId",
                table: "Places",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Places_LocationId",
                table: "Places",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Places_Locations_LocationId",
                table: "Places",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id");
        }
    }
}
