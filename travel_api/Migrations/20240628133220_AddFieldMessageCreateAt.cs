using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace travel_api.Migrations
{
    public partial class AddFieldMessageCreateAt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "RoomDetail",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "MessageCreateAt",
                table: "Message",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoomDetail_UserId",
                table: "RoomDetail",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomDetail_AspNetUsers_UserId",
                table: "RoomDetail",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomDetail_AspNetUsers_UserId",
                table: "RoomDetail");

            migrationBuilder.DropIndex(
                name: "IX_RoomDetail_UserId",
                table: "RoomDetail");

            migrationBuilder.DropColumn(
                name: "MessageCreateAt",
                table: "Message");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "RoomDetail",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
