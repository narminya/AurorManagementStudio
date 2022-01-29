using Microsoft.EntityFrameworkCore.Migrations;

namespace Auror.Migrations
{
    public partial class userhotelid4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HotelId",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HotelId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);
        }
    }
}
