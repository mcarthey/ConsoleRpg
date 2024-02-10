using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleRpg.Migrations
{
    /// <inheritdoc />
    public partial class AddQuestTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enemies_Quests_QuestId",
                table: "Enemies");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerQuests_Quests_QuestId",
                table: "PlayerQuests");

            migrationBuilder.DropForeignKey(
                name: "FK_Quests_Locations_LocationId",
                table: "Quests");

            migrationBuilder.DropForeignKey(
                name: "FK_Quests_Npcs_NpcId",
                table: "Quests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Quests",
                table: "Quests");

            migrationBuilder.RenameTable(
                name: "Quests",
                newName: "Quest");

            migrationBuilder.RenameIndex(
                name: "IX_Quests_NpcId",
                table: "Quest",
                newName: "IX_Quest_NpcId");

            migrationBuilder.RenameIndex(
                name: "IX_Quests_LocationId",
                table: "Quest",
                newName: "IX_Quest_LocationId");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Quest",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TargetItem",
                table: "Quest",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TargetLocation",
                table: "Quest",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TargetNpc",
                table: "Quest",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Quest",
                table: "Quest",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Enemies_Quest_QuestId",
                table: "Enemies",
                column: "QuestId",
                principalTable: "Quest",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerQuests_Quest_QuestId",
                table: "PlayerQuests",
                column: "QuestId",
                principalTable: "Quest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Quest_Locations_LocationId",
                table: "Quest",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Quest_Npcs_NpcId",
                table: "Quest",
                column: "NpcId",
                principalTable: "Npcs",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enemies_Quest_QuestId",
                table: "Enemies");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerQuests_Quest_QuestId",
                table: "PlayerQuests");

            migrationBuilder.DropForeignKey(
                name: "FK_Quest_Locations_LocationId",
                table: "Quest");

            migrationBuilder.DropForeignKey(
                name: "FK_Quest_Npcs_NpcId",
                table: "Quest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Quest",
                table: "Quest");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Quest");

            migrationBuilder.DropColumn(
                name: "TargetItem",
                table: "Quest");

            migrationBuilder.DropColumn(
                name: "TargetLocation",
                table: "Quest");

            migrationBuilder.DropColumn(
                name: "TargetNpc",
                table: "Quest");

            migrationBuilder.RenameTable(
                name: "Quest",
                newName: "Quests");

            migrationBuilder.RenameIndex(
                name: "IX_Quest_NpcId",
                table: "Quests",
                newName: "IX_Quests_NpcId");

            migrationBuilder.RenameIndex(
                name: "IX_Quest_LocationId",
                table: "Quests",
                newName: "IX_Quests_LocationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Quests",
                table: "Quests",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Enemies_Quests_QuestId",
                table: "Enemies",
                column: "QuestId",
                principalTable: "Quests",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerQuests_Quests_QuestId",
                table: "PlayerQuests",
                column: "QuestId",
                principalTable: "Quests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Quests_Locations_LocationId",
                table: "Quests",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Quests_Npcs_NpcId",
                table: "Quests",
                column: "NpcId",
                principalTable: "Npcs",
                principalColumn: "Id");
        }
    }
}
