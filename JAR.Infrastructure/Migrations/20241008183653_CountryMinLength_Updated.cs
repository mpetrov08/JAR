using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JAR.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CountryMinLength_Updated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2656a468-b215-4b17-865d-240a63b0d5cf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "576441a1-f95a-483c-9e7e-aa86108c3def", "AQAAAAIAAYagAAAAEB+Bemvew8YpopWG4nqMkbUrtLci+DR6xFePDWksuJYhxeNBF7zZXuo4aA16XszBnQ==", "304f38da-e22f-4be1-a22b-1600319d7345" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71811921-1918-4043-90b9-20f2522f315b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1c8afa76-811f-4220-9ba1-3a1d9a72f632", "AQAAAAIAAYagAAAAEM1FQkzT/BJIRMtq+EQnSbkhTnKhCw37+0MfpSI8tp/e1COaZS+Du1RHabYRCGlUSQ==", "9ea2ae60-9a2c-46d1-856c-89d797000bb0" });

            migrationBuilder.UpdateData(
                table: "JobApplications",
                keyColumns: new[] { "JobOfferId", "UserId" },
                keyValues: new object[] { 1, "2656a468-b215-4b17-865d-240a63b0d5cf" },
                column: "AppliedOn",
                value: new DateTime(2024, 10, 8, 18, 36, 53, 619, DateTimeKind.Utc).AddTicks(6807));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 8, 18, 36, 53, 534, DateTimeKind.Utc).AddTicks(5327));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 8, 18, 36, 53, 534, DateTimeKind.Utc).AddTicks(5333));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 8, 18, 36, 53, 534, DateTimeKind.Utc).AddTicks(5336));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
