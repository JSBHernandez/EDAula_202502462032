using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EDAula_202502462032.Migrations
{
    /// <inheritdoc />
    public partial class PopulateStations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { 1, "Ubicación A", "A" },
                    { 2, "Ubicación B", "B" },
                    { 3, "Ubicación C", "C" },
                    { 4, "Ubicación D", "D" },
                    { 5, "Ubicación E", "E" },
                    { 6, "Ubicación F", "F" },
                    { 7, "Ubicación G", "G" },
                    { 8, "Ubicación H", "H" },
                    { 9, "Ubicación I", "I" },
                    { 10, "Ubicación J", "J" },
                    { 11, "Ubicación K", "K" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 11);
        }
    }
}
