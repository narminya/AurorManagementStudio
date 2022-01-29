using Microsoft.EntityFrameworkCore.Migrations;

namespace Auror.Migrations
{
    public partial class userhotelid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HotelId",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HotelId",
                table: "AspNetUsers");
        }
    }
}
