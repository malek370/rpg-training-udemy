using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace rpg_training.Migrations
{
    /// <inheritdoc />
    public partial class improveRequests1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "fightRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                table: "fightRequests");
        }
    }
}
