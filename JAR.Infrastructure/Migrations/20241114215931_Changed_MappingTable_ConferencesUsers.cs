using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JAR.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Changed_MappingTable_ConferencesUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2656a468-b215-4b17-865d-240a63b0d5cf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c9fc1189-f750-4f93-8a26-d10750464677", "AQAAAAIAAYagAAAAEL3OEkhyQMwX1majQpjuMh9fXVof+WRfa0v2sqNhMg4H30ySY9V1Y/fmtfNr8+ZWKQ==", "30bbc996-1054-4018-a137-3458c3523d02" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71811921-1918-4043-90b9-20f2522f315b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7d561d5e-f84d-40bf-8984-8a8cb0d16254", "AQAAAAIAAYagAAAAEB8IgbabQTuS2CkqINVg7EB/ijWKR3DmEvJ6onbLtWWrXI/V+4sR6e+TgYoH1itW6A==", "d1622d8d-e40b-4843-8863-09dba8b3d768" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80277b99-4cab-4ff1-8084-6d0a5df3e787",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0f6fcbf4-7c0d-4b4c-93b3-6313da1f1eb3", "AQAAAAIAAYagAAAAEBWt65NTvs+5IKh/92FjDlA7sYMI//Zf5heYUByehHwnzx5Voe7B7rcmLz1S5hJ7JA==", "dc137985-cdfb-4324-8c15-13a80e3b5dac" });

            migrationBuilder.UpdateData(
                table: "JobApplications",
                keyColumns: new[] { "JobOfferId", "UserId" },
                keyValues: new object[] { 1, "2656a468-b215-4b17-865d-240a63b0d5cf" },
                column: "AppliedOn",
                value: new DateTime(2024, 11, 14, 21, 59, 30, 948, DateTimeKind.Utc).AddTicks(498));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 11, 14, 21, 59, 30, 824, DateTimeKind.Utc).AddTicks(2190));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 11, 14, 21, 59, 30, 824, DateTimeKind.Utc).AddTicks(2196));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 11, 14, 21, 59, 30, 824, DateTimeKind.Utc).AddTicks(2199));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2656a468-b215-4b17-865d-240a63b0d5cf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "10c900b1-f7e5-4b7a-9916-f00f5e288a23", "AQAAAAIAAYagAAAAEGzhw3pt95nCwfDN/jljyocYOaZkLxwZwAAMWZb1/fPG+0bWeD4j0OpFLu5IB8sNRg==", "56ba7802-8139-46ca-a703-199400712f1d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71811921-1918-4043-90b9-20f2522f315b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "07515587-ff78-49b0-9eab-6f479433e5cf", "AQAAAAIAAYagAAAAEJ6cDNL+3jERsaG/EfuBvHqYWCBBc6bIES1CN6UBiPNsLb7x0LfeSVnNiiB4dTTl4w==", "2223af5c-8fbf-44b1-9f94-321e79f9ed8b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80277b99-4cab-4ff1-8084-6d0a5df3e787",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "32b03977-8826-4e99-948f-89f4c7c480d5", "AQAAAAIAAYagAAAAENX6fJrqDwvCVT3cwHxmpvnwnUlTva1Pbi7/L5Eh1AZaa8mOAjwzhGMAVccExL6C8g==", "a162cbae-6745-4746-aaf6-90a6ab6044d7" });

            migrationBuilder.UpdateData(
                table: "JobApplications",
                keyColumns: new[] { "JobOfferId", "UserId" },
                keyValues: new object[] { 1, "2656a468-b215-4b17-865d-240a63b0d5cf" },
                column: "AppliedOn",
                value: new DateTime(2024, 11, 14, 21, 53, 16, 563, DateTimeKind.Utc).AddTicks(985));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 11, 14, 21, 53, 16, 437, DateTimeKind.Utc).AddTicks(9069));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 11, 14, 21, 53, 16, 437, DateTimeKind.Utc).AddTicks(9074));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 11, 14, 21, 53, 16, 437, DateTimeKind.Utc).AddTicks(9160));
        }
    }
}
