using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace travel_api.Migrations
{
    public partial class AddForeignKeyRoomDetailVsUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomDetail_AspNetUsers_UserId",
                table: "RoomDetail");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomDetail_AspNetUsers_UserId",
                table: "RoomDetail",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomDetail_AspNetUsers_UserId",
                table: "RoomDetail");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomDetail_AspNetUsers_UserId",
                table: "RoomDetail",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
