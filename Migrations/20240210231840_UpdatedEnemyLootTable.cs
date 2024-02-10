using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleRpg.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedEnemyLootTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LootTables_Enemies_EnemyId",
                table: "LootTables");

            migrationBuilder.DropIndex(
                name: "IX_LootTables_EnemyId",
                table: "LootTables");

            migrationBuilder.AlterColumn<int>(
                name: "EnemyId",
                table: "LootTables",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "LootTableId",
                table: "Enemies",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LootTables_EnemyId",
                table: "LootTables",
                column: "EnemyId",
                unique: true,
                filter: "[EnemyId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_LootTables_Enemies_EnemyId",
                table: "LootTables",
                column: "EnemyId",
                principalTable: "Enemies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LootTables_Enemies_EnemyId",
                table: "LootTables");

            migrationBuilder.DropIndex(
                name: "IX_LootTables_EnemyId",
                table: "LootTables");

            migrationBuilder.DropColumn(
                name: "LootTableId",
                table: "Enemies");

            migrationBuilder.AlterColumn<int>(
                name: "EnemyId",
                table: "LootTables",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LootTables_EnemyId",
                table: "LootTables",
                column: "EnemyId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LootTables_Enemies_EnemyId",
                table: "LootTables",
                column: "EnemyId",
                principalTable: "Enemies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
