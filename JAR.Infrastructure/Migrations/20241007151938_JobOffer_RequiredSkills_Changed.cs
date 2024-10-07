using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JAR.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class JobOffer_RequiredSkills_Changed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2656a468-b215-4b17-865d-240a63b0d5cf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "badc1ea4-4385-4cfc-a387-dbe3f813f434", "AQAAAAIAAYagAAAAEB/PznHEG/mquaoYUXgfFbJXqjkSMewwebD4LUCz9QQy9DgvLAANlEpCVK0m6oN61g==", "f780b0eb-be9e-4c23-ae83-b2860ff2c76a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71811921-1918-4043-90b9-20f2522f315b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "00462694-95b7-40af-baac-f1d811490725", "AQAAAAIAAYagAAAAEKQ2o6gZpDX9scJ7zGq0NkLgUPoY2jxEWeXP5QwUlOd8UdLFUeVduVcvzLBscmT2ZA==", "94a85434-ade5-423b-a82a-1078ae4af495" });

            migrationBuilder.UpdateData(
                table: "JobApplications",
                keyColumns: new[] { "JobOfferId", "UserId" },
                keyValues: new object[] { 1, "2656a468-b215-4b17-865d-240a63b0d5cf" },
                column: "AppliedOn",
                value: new DateTime(2024, 10, 7, 15, 19, 38, 488, DateTimeKind.Utc).AddTicks(9162));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 7, 15, 19, 38, 330, DateTimeKind.Utc).AddTicks(1515));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 7, 15, 19, 38, 330, DateTimeKind.Utc).AddTicks(1524));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 7, 15, 19, 38, 330, DateTimeKind.Utc).AddTicks(1530));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2656a468-b215-4b17-865d-240a63b0d5cf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "869af271-6a5f-4719-98e8-1a1f6932d9b2", "AQAAAAIAAYagAAAAEATOOTjvpIvIWOh9odNpZp3WRItj7SQuQgM6H98XfcuHtrJcRzg2N1inVQQWp00DIA==", "b3362f8e-2c6d-4d7b-9103-890c0ada7e62" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71811921-1918-4043-90b9-20f2522f315b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8abdac22-be44-4be7-adda-bec519bdc6ec", "AQAAAAIAAYagAAAAEL7um7YWRwKVspxGvY2sdQsrsF3h2G8tXlyY6aGvB0S+YKM28XY9iOqtUXHNQVgjag==", "e9300033-b06b-41d6-b63d-6e6f93dbbab2" });

            migrationBuilder.UpdateData(
                table: "JobApplications",
                keyColumns: new[] { "JobOfferId", "UserId" },
                keyValues: new object[] { 1, "2656a468-b215-4b17-865d-240a63b0d5cf" },
                column: "AppliedOn",
                value: new DateTime(2024, 10, 4, 19, 0, 2, 752, DateTimeKind.Utc).AddTicks(8075));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 4, 19, 0, 2, 600, DateTimeKind.Utc).AddTicks(9209));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 4, 19, 0, 2, 600, DateTimeKind.Utc).AddTicks(9218));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 4, 19, 0, 2, 600, DateTimeKind.Utc).AddTicks(9223));
        }
    }
}
