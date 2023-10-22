using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace rpg_training.Migrations
{
    /// <inheritdoc />
    public partial class seedDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "characters",
                columns: new[] { "id", "Class", "Defense", "Hitpoints", "Intelligence", "Name", "Strength" },
                values: new object[,]
                {
                    { 1, 2, 10, 100, 10, "Slim", 10 },
                    { 2, 1, 10, 100, 10, "chaima", 10 },
                    { 3, 3, 10, 100, 10, "Mariem", 10 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "characters",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "characters",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "characters",
                keyColumn: "id",
                keyValue: 3);
        }
    }
}
