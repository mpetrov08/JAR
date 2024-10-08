using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JAR.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedCompany_Updated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2656a468-b215-4b17-865d-240a63b0d5cf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e27c78df-b5dd-4c93-8542-38ec342fa304", "AQAAAAIAAYagAAAAEIW2lm0HekQVllfTS1XbnZLKiTcVj+/PYMMMgzMdqjoH9UgHeXgS0r1nbll58W0L4Q==", "95160343-982c-431a-8061-2b7da7139be3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71811921-1918-4043-90b9-20f2522f315b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "df68e265-9e33-46b0-96ad-b00012fb957d", "AQAAAAIAAYagAAAAEF1Ops5+09maNkHUDLo7O8LJyoZ+UvCGDM8aL+YkIk3RXHutywfBSU2kuz38JHPGJA==", "a7744c3d-1f8c-4236-8445-ecd6d01fe615" });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Country", "UIC" },
                values: new object[] { "USA", "91-1144442" });

            migrationBuilder.UpdateData(
                table: "JobApplications",
                keyColumns: new[] { "JobOfferId", "UserId" },
                keyValues: new object[] { 1, "2656a468-b215-4b17-865d-240a63b0d5cf" },
                column: "AppliedOn",
                value: new DateTime(2024, 10, 8, 18, 37, 33, 79, DateTimeKind.Utc).AddTicks(5105));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 8, 18, 37, 32, 996, DateTimeKind.Utc).AddTicks(6979));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 8, 18, 37, 32, 996, DateTimeKind.Utc).AddTicks(6983));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 8, 18, 37, 32, 996, DateTimeKind.Utc).AddTicks(6985));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
