using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Auror.Migrations
{
    public partial class modelChanges5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_AspNetUsers_GuestId1",
                table: "Reservation");

            migrationBuilder.DropIndex(
                name: "IX_Reservation_GuestId1",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "GuestId1",
                table: "Reservation");

            migrationBuilder.CreateTable(
                name: "Guest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GenderId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Guest_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Guest_Gender_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Gender",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_GuestId",
                table: "Reservation",
                column: "GuestId");

            migrationBuilder.CreateIndex(
                name: "IX_Guest_GenderId",
                table: "Guest",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Guest_UserId",
                table: "Guest",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Guest_GuestId",
                table: "Reservation",
                column: "GuestId",
                principalTable: "Guest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Guest_GuestId",
                table: "Reservation");

            migrationBuilder.DropTable(
                name: "Guest");

            migrationBuilder.DropIndex(
                name: "IX_Reservation_GuestId",
                table: "Reservation");

            migrationBuilder.AddColumn<string>(
                name: "GuestId1",
                table: "Reservation",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_GuestId1",
                table: "Reservation",
                column: "GuestId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_AspNetUsers_GuestId1",
                table: "Reservation",
                column: "GuestId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
