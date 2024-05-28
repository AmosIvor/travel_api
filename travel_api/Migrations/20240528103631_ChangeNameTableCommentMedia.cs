using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace travel_api.Migrations
{
    public partial class ChangeNameTableCommentMedia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentMedias_Comment_CommentId",
                table: "CommentMedias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommentMedias",
                table: "CommentMedias");

            migrationBuilder.RenameTable(
                name: "CommentMedias",
                newName: "CommentMedia");

            migrationBuilder.RenameIndex(
                name: "IX_CommentMedias_CommentId",
                table: "CommentMedia",
                newName: "IX_CommentMedia_CommentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommentMedia",
                table: "CommentMedia",
                column: "CommentMediaId");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentMedia_Comment_CommentId",
                table: "CommentMedia",
                column: "CommentId",
                principalTable: "Comment",
                principalColumn: "CommentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentMedia_Comment_CommentId",
                table: "CommentMedia");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommentMedia",
                table: "CommentMedia");

            migrationBuilder.RenameTable(
                name: "CommentMedia",
                newName: "CommentMedias");

            migrationBuilder.RenameIndex(
                name: "IX_CommentMedia_CommentId",
                table: "CommentMedias",
                newName: "IX_CommentMedias_CommentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommentMedias",
                table: "CommentMedias",
                column: "CommentMediaId");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentMedias_Comment_CommentId",
                table: "CommentMedias",
                column: "CommentId",
                principalTable: "Comment",
                principalColumn: "CommentId");
        }
    }
}
