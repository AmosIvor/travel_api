using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace travel_api.Migrations
{
    public partial class AddChatFeatureConstraint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MessageType",
                table: "Message",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Message",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "RoomName",
                table: "ChatRoom",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_RoomDetail_RoomId",
                table: "RoomDetail",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageMedia_MessageId",
                table: "MessageMedia",
                column: "MessageId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_RoomId",
                table: "Message",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_ChatRoom_RoomId",
                table: "Message",
                column: "RoomId",
                principalTable: "ChatRoom",
                principalColumn: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_MessageMedia_Message_MessageId",
                table: "MessageMedia",
                column: "MessageId",
                principalTable: "Message",
                principalColumn: "MessageId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomDetail_ChatRoom_RoomId",
                table: "RoomDetail",
                column: "RoomId",
                principalTable: "ChatRoom",
                principalColumn: "RoomId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message_ChatRoom_RoomId",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_MessageMedia_Message_MessageId",
                table: "MessageMedia");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomDetail_ChatRoom_RoomId",
                table: "RoomDetail");

            migrationBuilder.DropIndex(
                name: "IX_RoomDetail_RoomId",
                table: "RoomDetail");

            migrationBuilder.DropIndex(
                name: "IX_MessageMedia_MessageId",
                table: "MessageMedia");

            migrationBuilder.DropIndex(
                name: "IX_Message_RoomId",
                table: "Message");

            migrationBuilder.AlterColumn<string>(
                name: "MessageType",
                table: "Message",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Message",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RoomName",
                table: "ChatRoom",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
