using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleRpg.Migrations
{
    /// <inheritdoc />
    public partial class UpdateQuest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GoldReward",
                table: "Quests",
                newName: "RewardGold");

            migrationBuilder.AddColumn<int>(
                name: "RewardExperience",
                table: "Quests",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RewardExperience",
                table: "Quests");

            migrationBuilder.RenameColumn(
                name: "RewardGold",
                table: "Quests",
                newName: "GoldReward");
        }
    }
}
