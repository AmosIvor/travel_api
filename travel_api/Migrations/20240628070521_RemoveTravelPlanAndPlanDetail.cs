﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace travel_api.Migrations
{
    public partial class RemoveTravelPlanAndPlanDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlanDetail");

            migrationBuilder.DropTable(
                name: "TravelPlan");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CommentDate",
                table: "Comment",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CommentDate",
                table: "Comment",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateTable(
                name: "TravelPlan",
                columns: table => new
                {
                    PlanId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlanName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelPlan", x => x.PlanId);
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    PlanId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanDetail_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "LocationId");
                    table.ForeignKey(
                        name: "FK_PlanDetail_TravelPlan_PlanId",
                        column: x => x.PlanId,
                        principalTable: "TravelPlan",
                        principalColumn: "PlanId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlanDetail_LocationId",
                table: "PlanDetail",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanDetail_PlanId",
                table: "PlanDetail",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_TravelPlan_UserId",
                table: "TravelPlan",
                column: "UserId");
        }
    }
}
