using Microsoft.EntityFrameworkCore.Migrations;

namespace Auror.Migrations
{
    public partial class modelChanges6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsMain",
                table: "RoomImage",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsMain",
                table: "RoomImage");
        }
    }
}
