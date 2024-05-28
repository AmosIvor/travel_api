using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace travel_api.Migrations
{
    public partial class CreateTable_Feedback_Post_Location_Media : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    LocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationRateAverage = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.LocationId);
                });

            migrationBuilder.CreateTable(
                name: "Feedback",
                columns: table => new
                {
                    FeedbackId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeedbackDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FeedbackContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FeedbackRate = table.Column<float>(type: "real", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedback", x => x.FeedbackId);
                    table.ForeignKey(
                        name: "FK_Feedback_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Feedback_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "LocationId");
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PostTotalLike = table.Column<int>(type: "int", nullable: false),
                    PostContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.PostId);
                    table.ForeignKey(
                        name: "FK_Post_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Post_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "LocationId");
                });

            migrationBuilder.CreateTable(
                name: "FeedbackMedia",
                columns: table => new
                {
                    FeedbackMediaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeedbackMediaOrder = table.Column<int>(type: "int", nullable: false),
                    FeedbackMediaUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FeedbackId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedbackMedia", x => x.FeedbackMediaId);
                    table.ForeignKey(
                        name: "FK_FeedbackMedia_Feedback_FeedbackId",
                        column: x => x.FeedbackId,
                        principalTable: "Feedback",
                        principalColumn: "FeedbackId");
                });

            migrationBuilder.CreateTable(
                name: "PostMedia",
                columns: table => new
                {
                    PostMediaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostMediaOrder = table.Column<int>(type: "int", nullable: false),
                    PostMediaUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostMedia", x => x.PostMediaId);
                    table.ForeignKey(
                        name: "FK_PostMedia_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "PostId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_LocationId",
                table: "Feedback",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_UserId",
                table: "Feedback",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FeedbackMedia_FeedbackId",
                table: "FeedbackMedia",
                column: "FeedbackId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_LocationId",
                table: "Post",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_UserId",
                table: "Post",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PostMedia_PostId",
                table: "PostMedia",
                column: "PostId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FeedbackMedia");

            migrationBuilder.DropTable(
                name: "PostMedia");

            migrationBuilder.DropTable(
                name: "Feedback");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "Location");
        }
    }
}
