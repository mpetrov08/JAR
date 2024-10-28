using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JAR.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Added_CompanyLogo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Logo",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "Company Logo");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2656a468-b215-4b17-865d-240a63b0d5cf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9f1e5b3b-ade0-4f54-b0e4-2efbc1ad5343", "AQAAAAIAAYagAAAAEIXKdv9jx31b+vFB7ub7gKdmeHkVUfdhVP5Ah9M15LCp5sdHFpxF2qecNrzHutubqg==", "38d5c23f-674a-4bb6-8087-8eea2c3d71f2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71811921-1918-4043-90b9-20f2522f315b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "efbc727b-5b5d-4d6d-8a6c-df275a4f3754", "AQAAAAIAAYagAAAAEHBWwj8crXOh6zr23eWbfW/5rnlUtFwVDX8PdkhbZ5la9aNTUEXPh0qLO6ETp6N6Uw==", "6a23b552-5acb-41f5-87bd-1335c9a2bed4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80277b99-4cab-4ff1-8084-6d0a5df3e787",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7d1f8086-ab2d-4059-b907-a7586780142a", "AQAAAAIAAYagAAAAEMJZzCIKIyOMMwHiLCzkD/AXJQJhS7vvIvVRsg4Dvh6eTsZ144ht8zg2ba+5ex1V6g==", "7832d979-bf61-4427-8ae8-1133314b2e58" });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1,
                column: "Logo",
                value: "https://blogs.microsoft.com/wp-content/uploads/prod/2012/08/8867.Microsoft_5F00_Logo_2D00_for_2D00_screen.jpg");

            migrationBuilder.UpdateData(
                table: "JobApplications",
                keyColumns: new[] { "JobOfferId", "UserId" },
                keyValues: new object[] { 1, "2656a468-b215-4b17-865d-240a63b0d5cf" },
                column: "AppliedOn",
                value: new DateTime(2024, 10, 28, 17, 37, 55, 56, DateTimeKind.Utc).AddTicks(6000));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 28, 17, 37, 54, 928, DateTimeKind.Utc).AddTicks(5982));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 28, 17, 37, 54, 928, DateTimeKind.Utc).AddTicks(5989));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 28, 17, 37, 54, 928, DateTimeKind.Utc).AddTicks(5999));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Logo",
                table: "Companies");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2656a468-b215-4b17-865d-240a63b0d5cf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d10791ec-2888-4858-8d91-0decd64049f1", "AQAAAAIAAYagAAAAEBqyCz9b6lKzh6Uybgalk0LB8nhVCuCfi0f6w3wfKcU9+A00h2HEjYZnMcnHNR1KdQ==", "e34435b2-a829-4e5c-ab6e-ba701a25eb77" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71811921-1918-4043-90b9-20f2522f315b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e3c599b9-d083-47dc-ae0b-4c8cfe795d6b", "AQAAAAIAAYagAAAAEFjNvzvDf7X7wOaMpMtz7c4UtVIgKUme+jRmabhkcdXKUzl9hH6MB6hpwNOCLV0d9g==", "f33e062a-ed35-4e91-a783-f02cc9d8217d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80277b99-4cab-4ff1-8084-6d0a5df3e787",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "43a0d9c1-1ff3-4f06-9f6d-8804a565f532", "AQAAAAIAAYagAAAAEG71b05pYxC1hcpcQ409q92BRgRq4XeB/Qu3F9LxAC3AH8DNpb0EAfLOWktLZmWDvQ==", "36789534-3b66-4794-841e-87e2f5f422f1" });

            migrationBuilder.UpdateData(
                table: "JobApplications",
                keyColumns: new[] { "JobOfferId", "UserId" },
                keyValues: new object[] { 1, "2656a468-b215-4b17-865d-240a63b0d5cf" },
                column: "AppliedOn",
                value: new DateTime(2024, 10, 27, 20, 14, 11, 872, DateTimeKind.Utc).AddTicks(4624));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 27, 20, 14, 11, 743, DateTimeKind.Utc).AddTicks(5667));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 27, 20, 14, 11, 743, DateTimeKind.Utc).AddTicks(5675));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 27, 20, 14, 11, 743, DateTimeKind.Utc).AddTicks(5677));
        }
    }
}
