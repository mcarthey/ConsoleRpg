using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleRpg.Migrations
{
    /// <inheritdoc />
    public partial class AddPlayerQuestsJoinTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quests_Players_PlayerId",
                table: "Quests");

            migrationBuilder.DropIndex(
                name: "IX_Quests_PlayerId",
                table: "Quests");

            migrationBuilder.DropColumn(
                name: "PlayerId",
                table: "Quests");

            migrationBuilder.CreateTable(
                name: "PlayerQuests",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    QuestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerQuests", x => new { x.PlayerId, x.QuestId });
                    table.ForeignKey(
                        name: "FK_PlayerQuests_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerQuests_Quests_QuestId",
                        column: x => x.QuestId,
                        principalTable: "Quests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerQuests_QuestId",
                table: "PlayerQuests",
                column: "QuestId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerQuests");

            migrationBuilder.AddColumn<int>(
                name: "PlayerId",
                table: "Quests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Quests_PlayerId",
                table: "Quests",
                column: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Quests_Players_PlayerId",
                table: "Quests",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
