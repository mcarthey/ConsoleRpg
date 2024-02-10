using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleRpg.Migrations
{
    /// <inheritdoc />
    public partial class AddNpcQuests : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KillCount",
                table: "Quests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "KillCountProgress",
                table: "Quests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NpcId",
                table: "Quests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QuestId",
                table: "Enemies",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Npcs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Npcs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DialogueOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NpcId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DialogueOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DialogueOptions_Npcs_NpcId",
                        column: x => x.NpcId,
                        principalTable: "Npcs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Quests_NpcId",
                table: "Quests",
                column: "NpcId");

            migrationBuilder.CreateIndex(
                name: "IX_Enemies_QuestId",
                table: "Enemies",
                column: "QuestId");

            migrationBuilder.CreateIndex(
                name: "IX_DialogueOptions_NpcId",
                table: "DialogueOptions",
                column: "NpcId");

            migrationBuilder.AddForeignKey(
                name: "FK_Enemies_Quests_QuestId",
                table: "Enemies",
                column: "QuestId",
                principalTable: "Quests",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Quests_Npcs_NpcId",
                table: "Quests",
                column: "NpcId",
                principalTable: "Npcs",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enemies_Quests_QuestId",
                table: "Enemies");

            migrationBuilder.DropForeignKey(
                name: "FK_Quests_Npcs_NpcId",
                table: "Quests");

            migrationBuilder.DropTable(
                name: "DialogueOptions");

            migrationBuilder.DropTable(
                name: "Npcs");

            migrationBuilder.DropIndex(
                name: "IX_Quests_NpcId",
                table: "Quests");

            migrationBuilder.DropIndex(
                name: "IX_Enemies_QuestId",
                table: "Enemies");

            migrationBuilder.DropColumn(
                name: "KillCount",
                table: "Quests");

            migrationBuilder.DropColumn(
                name: "KillCountProgress",
                table: "Quests");

            migrationBuilder.DropColumn(
                name: "NpcId",
                table: "Quests");

            migrationBuilder.DropColumn(
                name: "QuestId",
                table: "Enemies");
        }
    }
}
