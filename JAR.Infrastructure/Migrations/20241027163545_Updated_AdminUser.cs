using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JAR.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Updated_AdminUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2656a468-b215-4b17-865d-240a63b0d5cf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0ab5fd92-b05b-4fcf-905c-9175908490b4", "AQAAAAIAAYagAAAAEDFIcjCtmd6Df5BhOnOL5VKF3YMkjJTiLMZtUf0S8LaKbOQ4Rvs12IgXK62SsepNcw==", "66b2f3da-6bf9-43c4-a0e2-e4211d0baeb8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71811921-1918-4043-90b9-20f2522f315b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bc7019eb-940d-4332-a27c-644e0343d097", "AQAAAAIAAYagAAAAEGj2Ijby2s6fh0hTlqz6wLwGOq/ALWBCvNIDp9QrrX1o0bKwYJ8f+MGZnrE1Em80kg==", "a70fda25-3bce-434b-bdfe-4afc43312187" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CVId", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "80277b99-4cab-4ff1-8084-6d0a5df3e787", 0, null, "6e81eab6-9bcb-4cde-8d55-cbed20158c47", "admin@gmail.com", false, "Admin", "Adminov", false, null, "ADMIN@GMAIL.COM", "ADMINISTRATOR", "AQAAAAIAAYagAAAAEBYSNFsWsBWlneTinGhm/xYclCrYRIq+z7qatYMfDnWPwbO0yxxCuzsHsR9FMdCxMw==", null, false, "8afc6f2c-5854-47a5-a286-17b47388137d", false, "Administrator" });

            migrationBuilder.UpdateData(
                table: "JobApplications",
                keyColumns: new[] { "JobOfferId", "UserId" },
                keyValues: new object[] { 1, "2656a468-b215-4b17-865d-240a63b0d5cf" },
                column: "AppliedOn",
                value: new DateTime(2024, 10, 27, 16, 35, 44, 983, DateTimeKind.Utc).AddTicks(6338));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 27, 16, 35, 44, 859, DateTimeKind.Utc).AddTicks(2700));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 27, 16, 35, 44, 859, DateTimeKind.Utc).AddTicks(2706));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 27, 16, 35, 44, 859, DateTimeKind.Utc).AddTicks(2709));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80277b99-4cab-4ff1-8084-6d0a5df3e787");

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
    }
}
