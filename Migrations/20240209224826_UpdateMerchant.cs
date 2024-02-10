using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleRpg.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMerchant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Merchants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Merchants");
        }
    }
}
