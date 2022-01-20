using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Auror.Migrations
{
    public partial class HotelAdvantages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AirportTransfer",
                table: "HotelAdvantages");

            migrationBuilder.DropColumn(
                name: "AllInclusive",
                table: "HotelAdvantages");

            migrationBuilder.DropColumn(
                name: "FreeCancel",
                table: "HotelAdvantages");

            migrationBuilder.DropColumn(
                name: "Gym",
                table: "HotelAdvantages");

            migrationBuilder.DropColumn(
                name: "Laundry",
                table: "HotelAdvantages");

            migrationBuilder.DropColumn(
                name: "Parking",
                table: "HotelAdvantages");

            migrationBuilder.DropColumn(
                name: "Pool",
                table: "HotelAdvantages");

            migrationBuilder.DropColumn(
                name: "Restaurant",
                table: "HotelAdvantages");

            migrationBuilder.DropColumn(
                name: "Security",
                table: "HotelAdvantages");

            migrationBuilder.AddColumn<int>(
                name: "AdvantageId",
                table: "HotelAdvantages",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Advantages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advantages", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HotelAdvantages_AdvantageId",
                table: "HotelAdvantages",
                column: "AdvantageId");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelAdvantages_Advantages_AdvantageId",
                table: "HotelAdvantages",
                column: "AdvantageId",
                principalTable: "Advantages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelAdvantages_Advantages_AdvantageId",
                table: "HotelAdvantages");

            migrationBuilder.DropTable(
                name: "Advantages");

            migrationBuilder.DropIndex(
                name: "IX_HotelAdvantages_AdvantageId",
                table: "HotelAdvantages");

            migrationBuilder.DropColumn(
                name: "AdvantageId",
                table: "HotelAdvantages");

            migrationBuilder.AddColumn<bool>(
                name: "AirportTransfer",
                table: "HotelAdvantages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AllInclusive",
                table: "HotelAdvantages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "FreeCancel",
                table: "HotelAdvantages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Gym",
                table: "HotelAdvantages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Laundry",
                table: "HotelAdvantages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Parking",
                table: "HotelAdvantages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Pool",
                table: "HotelAdvantages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Restaurant",
                table: "HotelAdvantages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Security",
                table: "HotelAdvantages",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
