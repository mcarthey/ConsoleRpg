using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleRpg.Migrations
{
    /// <inheritdoc />
    public partial class UpdateQuestLocations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Quests",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Quests_LocationId",
                table: "Quests",
                column: "LocationId",
                unique: true,
                filter: "[LocationId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Quests_Locations_LocationId",
                table: "Quests",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quests_Locations_LocationId",
                table: "Quests");

            migrationBuilder.DropIndex(
                name: "IX_Quests_LocationId",
                table: "Quests");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Quests");
        }
    }
}
