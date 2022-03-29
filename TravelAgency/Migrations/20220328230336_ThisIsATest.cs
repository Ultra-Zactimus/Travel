using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelAgency.Migrations
{
    public partial class ThisIsATest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Destinations",
                columns: new[] { "DestinationId", "City", "Country" },
                values: new object[] { 2, "Chicago", "USA" });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "ReviewId", "DestinationId", "Rating", "Text", "User" },
                values: new object[] { 2, 1, 2, "It's windy", "Charlie" });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "ReviewId", "DestinationId", "Rating", "Text", "User" },
                values: new object[] { 3, 2, 6, "go there", "Dakota" });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "ReviewId", "DestinationId", "Rating", "Text", "User" },
                values: new object[] { 4, 2, 6, "Yolo", "Bob" });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "ReviewId", "DestinationId", "Rating", "Text", "User" },
                values: new object[] { 5, 2, 6, "Yolo", "Sam" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Destinations",
                keyColumn: "DestinationId",
                keyValue: 2);
        }
    }
}
