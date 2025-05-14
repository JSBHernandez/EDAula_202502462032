using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EDAula_202502462032.Migrations
{
    /// <inheritdoc />
    public partial class UpdateLuggageAndTicketModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Luggages_Passengers_PassengerId",
                table: "Luggages");

            migrationBuilder.DropForeignKey(
                name: "FK_Luggages_Trains_TrainId",
                table: "Luggages");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Passengers_PassengerId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Trains_TrainId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_PassengerId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_TrainId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Luggages_TrainId",
                table: "Luggages");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "SeatCategory",
                table: "Tickets",
                newName: "Seat");

            migrationBuilder.RenameColumn(
                name: "PurchaseDate",
                table: "Tickets",
                newName: "PurchaseDateTime");

            migrationBuilder.RenameColumn(
                name: "DepartureDate",
                table: "Tickets",
                newName: "DepartureDateTime");

            migrationBuilder.RenameColumn(
                name: "ArrivalDate",
                table: "Tickets",
                newName: "ArrivalDateTime");

            migrationBuilder.RenameColumn(
                name: "PassengerId",
                table: "Luggages",
                newName: "TicketId");

            migrationBuilder.RenameIndex(
                name: "IX_Luggages_PassengerId",
                table: "Luggages",
                newName: "IX_Luggages_TicketId");

            migrationBuilder.AlterColumn<string>(
                name: "PassengerId",
                table: "Tickets",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Tickets",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "EmergencyContactFirstName",
                table: "Tickets",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "EmergencyContactLastName",
                table: "Tickets",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "EmergencyContactPhoneNumber",
                table: "Tickets",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Tickets",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "IdentificationType",
                table: "Tickets",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Tickets",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "PassengerCategory",
                table: "Tickets",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Tickets",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<decimal>(
                name: "TicketPrice",
                table: "Tickets",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "CargoCarId",
                table: "Luggages",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_Luggages_Tickets_TicketId",
                table: "Luggages",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Luggages_Tickets_TicketId",
                table: "Luggages");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "EmergencyContactFirstName",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "EmergencyContactLastName",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "EmergencyContactPhoneNumber",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "IdentificationType",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "PassengerCategory",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "TicketPrice",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "CargoCarId",
                table: "Luggages");

            migrationBuilder.RenameColumn(
                name: "Seat",
                table: "Tickets",
                newName: "SeatCategory");

            migrationBuilder.RenameColumn(
                name: "PurchaseDateTime",
                table: "Tickets",
                newName: "PurchaseDate");

            migrationBuilder.RenameColumn(
                name: "DepartureDateTime",
                table: "Tickets",
                newName: "DepartureDate");

            migrationBuilder.RenameColumn(
                name: "ArrivalDateTime",
                table: "Tickets",
                newName: "ArrivalDate");

            migrationBuilder.RenameColumn(
                name: "TicketId",
                table: "Luggages",
                newName: "PassengerId");

            migrationBuilder.RenameIndex(
                name: "IX_Luggages_TicketId",
                table: "Luggages",
                newName: "IX_Luggages_PassengerId");

            migrationBuilder.AlterColumn<int>(
                name: "PassengerId",
                table: "Tickets",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Tickets",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_PassengerId",
                table: "Tickets",
                column: "PassengerId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_TrainId",
                table: "Tickets",
                column: "TrainId");

            migrationBuilder.CreateIndex(
                name: "IX_Luggages_TrainId",
                table: "Luggages",
                column: "TrainId");

            migrationBuilder.AddForeignKey(
                name: "FK_Luggages_Passengers_PassengerId",
                table: "Luggages",
                column: "PassengerId",
                principalTable: "Passengers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Luggages_Trains_TrainId",
                table: "Luggages",
                column: "TrainId",
                principalTable: "Trains",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Passengers_PassengerId",
                table: "Tickets",
                column: "PassengerId",
                principalTable: "Passengers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Trains_TrainId",
                table: "Tickets",
                column: "TrainId",
                principalTable: "Trains",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
