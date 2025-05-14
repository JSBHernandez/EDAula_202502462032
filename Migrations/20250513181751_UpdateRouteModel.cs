using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EDAula_202502462032.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRouteModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Routes_Trains_TrainId",
                table: "Routes");

            migrationBuilder.DropTable(
                name: "RouteStation");

            migrationBuilder.RenameColumn(
                name: "TrainId",
                table: "Routes",
                newName: "StationId");

            migrationBuilder.RenameIndex(
                name: "IX_Routes_TrainId",
                table: "Routes",
                newName: "IX_Routes_StationId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Schedule",
                table: "Routes",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<double>(
                name: "Distance",
                table: "Routes",
                type: "double",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "IntermediateStations",
                table: "Routes",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Train",
                table: "Routes",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_Routes_Stations_StationId",
                table: "Routes",
                column: "StationId",
                principalTable: "Stations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Routes_Stations_StationId",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "IntermediateStations",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "Train",
                table: "Routes");

            migrationBuilder.RenameColumn(
                name: "StationId",
                table: "Routes",
                newName: "TrainId");

            migrationBuilder.RenameIndex(
                name: "IX_Routes_StationId",
                table: "Routes",
                newName: "IX_Routes_TrainId");

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Schedule",
                keyValue: null,
                column: "Schedule",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Schedule",
                table: "Routes",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "Distance",
                table: "Routes",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double");

            migrationBuilder.CreateTable(
                name: "RouteStation",
                columns: table => new
                {
                    RoutesId = table.Column<int>(type: "int", nullable: false),
                    StationsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RouteStation", x => new { x.RoutesId, x.StationsId });
                    table.ForeignKey(
                        name: "FK_RouteStation_Routes_RoutesId",
                        column: x => x.RoutesId,
                        principalTable: "Routes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RouteStation_Stations_StationsId",
                        column: x => x.StationsId,
                        principalTable: "Stations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_RouteStation_StationsId",
                table: "RouteStation",
                column: "StationsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Routes_Trains_TrainId",
                table: "Routes",
                column: "TrainId",
                principalTable: "Trains",
                principalColumn: "Id");
        }
    }
}
