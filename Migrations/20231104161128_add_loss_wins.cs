using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace rpg_training.Migrations
{
    /// <inheritdoc />
    public partial class add_loss_wins : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "loss",
                table: "characters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "wins",
                table: "characters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "characters",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "loss", "wins" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "characters",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "loss", "wins" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "characters",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "loss", "wins" },
                values: new object[] { 0, 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "loss",
                table: "characters");

            migrationBuilder.DropColumn(
                name: "wins",
                table: "characters");
        }
    }
}
