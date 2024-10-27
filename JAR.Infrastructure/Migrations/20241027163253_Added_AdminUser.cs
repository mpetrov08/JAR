using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JAR.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Added_AdminUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2656a468-b215-4b17-865d-240a63b0d5cf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aca83a4c-d74b-43ea-9039-7873368df68d", "AQAAAAIAAYagAAAAELLTQ6rbcCqtcLJn2MCCXv9Ir9Q5f8afmQakXqmaWcYgoXqFW2rmxiqOEWuP4bcNlQ==", "61623964-ae3b-4b28-a840-1443bcf79ead" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71811921-1918-4043-90b9-20f2522f315b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1d3934e5-adc3-45cc-88ca-9a9a3c58886d", "AQAAAAIAAYagAAAAEFl0yjedMOWMPNas90QAX/yMF46h/tTX8v/8CyPHYcWSVv850z8G81DU+lm4iGGe9A==", "d99a8762-d9c2-40ff-ad57-15f793f00f14" });

            migrationBuilder.UpdateData(
                table: "JobApplications",
                keyColumns: new[] { "JobOfferId", "UserId" },
                keyValues: new object[] { 1, "2656a468-b215-4b17-865d-240a63b0d5cf" },
                column: "AppliedOn",
                value: new DateTime(2024, 10, 27, 16, 32, 52, 918, DateTimeKind.Utc).AddTicks(1212));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 27, 16, 32, 52, 771, DateTimeKind.Utc).AddTicks(2478));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 27, 16, 32, 52, 771, DateTimeKind.Utc).AddTicks(2484));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 27, 16, 32, 52, 771, DateTimeKind.Utc).AddTicks(2489));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2656a468-b215-4b17-865d-240a63b0d5cf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "549b993d-5dac-4d05-9cd2-361bba586fa6", "AQAAAAIAAYagAAAAEGkX4owv50WJaXbd+6snCOynVDLgKjF8pFJNOgZSVfZa3I04731v+CeY2nNBw9Bfpw==", "e813116f-f329-44ca-bed1-06c989feefdb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71811921-1918-4043-90b9-20f2522f315b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a0103033-b63f-4d2a-b75f-8399147e6db7", "AQAAAAIAAYagAAAAENRuv1/mVSd9y8hah0arzJJDzCI98wuWHiH+rZBO0TqdPN5HA8Mtp/pCt082C33jFA==", "2d5ea249-e373-432b-8d68-58925ea9f467" });

            migrationBuilder.UpdateData(
                table: "JobApplications",
                keyColumns: new[] { "JobOfferId", "UserId" },
                keyValues: new object[] { 1, "2656a468-b215-4b17-865d-240a63b0d5cf" },
                column: "AppliedOn",
                value: new DateTime(2024, 10, 22, 17, 15, 27, 167, DateTimeKind.Utc).AddTicks(9386));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 22, 17, 15, 27, 83, DateTimeKind.Utc).AddTicks(3470));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 22, 17, 15, 27, 83, DateTimeKind.Utc).AddTicks(3475));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 22, 17, 15, 27, 83, DateTimeKind.Utc).AddTicks(3478));
        }
    }
}
