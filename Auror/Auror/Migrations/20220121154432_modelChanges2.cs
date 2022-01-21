using Microsoft.EntityFrameworkCore.Migrations;

namespace Auror.Migrations
{
    public partial class modelChanges2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BedCount",
                table: "Room",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BedCount",
                table: "Room");
        }
    }
}
