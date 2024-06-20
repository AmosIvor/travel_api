using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace travel_api.Migrations
{
    public partial class EditPropertyFeedbackAndLocationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "LocationRateAverage",
                table: "Location",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<decimal>(
                name: "FeedbackRate",
                table: "Feedback",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddColumn<int>(
                name: "TripType",
                table: "Feedback",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CityDescription",
                table: "City",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TripType",
                table: "Feedback");

            migrationBuilder.DropColumn(
                name: "CityDescription",
                table: "City");

            migrationBuilder.AlterColumn<float>(
                name: "LocationRateAverage",
                table: "Location",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldPrecision: 18,
                oldScale: 2);

            migrationBuilder.AlterColumn<float>(
                name: "FeedbackRate",
                table: "Feedback",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldPrecision: 18,
                oldScale: 2);
        }
    }
}
