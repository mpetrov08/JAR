using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JAR.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CompanyModel_Country_and_UIC_added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Companies",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                comment: "Company Country");

            migrationBuilder.AddColumn<string>(
                name: "UIC",
                table: "Companies",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                comment: "Company Unique Identification Code");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2656a468-b215-4b17-865d-240a63b0d5cf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3961b185-3f81-4136-911c-7e1799f471a9", "AQAAAAIAAYagAAAAECYvzLVr+eGWkOytn3NypP/aWK+yiGLDgnBJNvmQ+q5QkEhND6uS5cAWNz9411mXSg==", "1fe58f2e-e23c-4a0a-8ebf-3a0a04c899cd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71811921-1918-4043-90b9-20f2522f315b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e1e5e707-bafd-4000-b818-86cca81229ae", "AQAAAAIAAYagAAAAECDs7L8PuDP4vtFERWQQ6qJ6uw25pIVaVEquhcpHK09jU/fFzMEVS4CED2EmKGESew==", "882b6168-a4d4-49b9-97cc-577972ee7f96" });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Country", "UIC" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "JobApplications",
                keyColumns: new[] { "JobOfferId", "UserId" },
                keyValues: new object[] { 1, "2656a468-b215-4b17-865d-240a63b0d5cf" },
                column: "AppliedOn",
                value: new DateTime(2024, 10, 8, 18, 33, 18, 819, DateTimeKind.Utc).AddTicks(8957));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 8, 18, 33, 18, 737, DateTimeKind.Utc).AddTicks(4233));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 8, 18, 33, 18, 737, DateTimeKind.Utc).AddTicks(4238));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 8, 18, 33, 18, 737, DateTimeKind.Utc).AddTicks(4251));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "UIC",
                table: "Companies");

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
    }
}
