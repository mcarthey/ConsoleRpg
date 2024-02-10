using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleRpg.Migrations
{
    /// <inheritdoc />
    public partial class AddLootTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LootTableId",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LootTables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnemyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LootTables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LootTables_Enemies_EnemyId",
                        column: x => x.EnemyId,
                        principalTable: "Enemies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_LootTableId",
                table: "Items",
                column: "LootTableId");

            migrationBuilder.CreateIndex(
                name: "IX_LootTables_EnemyId",
                table: "LootTables",
                column: "EnemyId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_LootTables_LootTableId",
                table: "Items",
                column: "LootTableId",
                principalTable: "LootTables",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_LootTables_LootTableId",
                table: "Items");

            migrationBuilder.DropTable(
                name: "LootTables");

            migrationBuilder.DropIndex(
                name: "IX_Items_LootTableId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "LootTableId",
                table: "Items");
        }
    }
}
