using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace travel_api.Migrations
{
    public partial class ReCreateTravelPlanAndPlanDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TravelPlan",
                columns: table => new
                {
                    TravelPlanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TravelPlanName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlanCreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TravelDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TravelDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TravelUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelPlan", x => x.TravelPlanId);
                    table.ForeignKey(
                        name: "FK_TravelPlan_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PlanDetail",
                columns: table => new
                {
                    PlanDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlanDetailDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    TravelPlanId = table.Column<int>(type: "int", nullable: false),
                    PlanId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanDetail", x => x.PlanDetailId);
                    table.ForeignKey(
                        name: "FK_PlanDetail_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "LocationId");
                    table.ForeignKey(
                        name: "FK_PlanDetail_TravelPlan_TravelPlanId",
                        column: x => x.TravelPlanId,
                        principalTable: "TravelPlan",
                        principalColumn: "TravelPlanId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlanDetail_LocationId",
                table: "PlanDetail",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanDetail_TravelPlanId",
                table: "PlanDetail",
                column: "TravelPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_TravelPlan_UserId",
                table: "TravelPlan",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlanDetail");

            migrationBuilder.DropTable(
                name: "TravelPlan");
        }
    }
}
