using Microsoft.EntityFrameworkCore.Migrations;

namespace Auror.Migrations
{
    public partial class contact2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Message",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Message_UserId",
                table: "Message",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_AspNetUsers_UserId",
                table: "Message",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message_AspNetUsers_UserId",
                table: "Message");

            migrationBuilder.DropIndex(
                name: "IX_Message_UserId",
                table: "Message");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Message");
        }
    }
}
