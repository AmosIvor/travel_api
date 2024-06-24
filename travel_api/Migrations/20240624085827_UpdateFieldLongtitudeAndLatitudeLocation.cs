using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace travel_api.Migrations
{
    public partial class UpdateFieldLongtitudeAndLatitudeLocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "LocationLongtitude",
                table: "Location",
                type: "decimal(9,6)",
                precision: 9,
                scale: 6,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldPrecision: 18,
                oldScale: 2);

            migrationBuilder.AlterColumn<decimal>(
                name: "LocationLatitude",
                table: "Location",
                type: "decimal(8,6)",
                precision: 8,
                scale: 6,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldPrecision: 18,
                oldScale: 2);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "LocationLongtitude",
                table: "Location",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(9,6)",
                oldPrecision: 9,
                oldScale: 6);

            migrationBuilder.AlterColumn<decimal>(
                name: "LocationLatitude",
                table: "Location",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(8,6)",
                oldPrecision: 8,
                oldScale: 6);
        }
    }
}
