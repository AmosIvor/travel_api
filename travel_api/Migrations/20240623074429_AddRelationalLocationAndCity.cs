using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace travel_api.Migrations
{
    public partial class AddRelationalLocationAndCity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Location",
                type: "int",
                nullable: false,
                defaultValue: 0); // change 0 to 1 if it shows error

            migrationBuilder.CreateIndex(
                name: "IX_Location_CityId",
                table: "Location",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Location_City_CityId",
                table: "Location",
                column: "CityId",
                principalTable: "City",
                principalColumn: "CityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Location_City_CityId",
                table: "Location");

            migrationBuilder.DropIndex(
                name: "IX_Location_CityId",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Location");
        }
    }
}
