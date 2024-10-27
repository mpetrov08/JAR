using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JAR.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Update_AdminPassword : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2656a468-b215-4b17-865d-240a63b0d5cf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ad260237-6149-47a4-87dd-2b656fd13df5", "AQAAAAIAAYagAAAAEEOIn55Nf7c26TJKFUzCTG21vTzaXvjECwS0mz3W1f+6/5WAD2d2TPOm/m3Rte/WRQ==", "99587668-8297-4f37-bb5e-183459bdadb8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71811921-1918-4043-90b9-20f2522f315b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b5ca7d66-8144-48b6-b8b2-02df53e52df6", "AQAAAAIAAYagAAAAEEmUyd03by/LdP9bxaCE5kMvELpmxAu79M0RnM94q8MG02CRQ/Vb/WYd/L2f3//Sbg==", "ef08b790-2da7-40b9-8496-38464a36b834" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80277b99-4cab-4ff1-8084-6d0a5df3e787",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "03f0ec58-a12d-4d93-baf4-868828cbcde3", "AQAAAAIAAYagAAAAEC6vSogwLu4gtjh9CLJWoHY85c5a4+adPX6qoYgUg9Woz2AHiN8JmyWrwCjRjymw0w==", "250fba9f-0bd9-4c1e-8c53-dc0becdc47b2" });

            migrationBuilder.UpdateData(
                table: "JobApplications",
                keyColumns: new[] { "JobOfferId", "UserId" },
                keyValues: new object[] { 1, "2656a468-b215-4b17-865d-240a63b0d5cf" },
                column: "AppliedOn",
                value: new DateTime(2024, 10, 27, 17, 1, 0, 369, DateTimeKind.Utc).AddTicks(5228));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 27, 17, 1, 0, 232, DateTimeKind.Utc).AddTicks(1201));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 27, 17, 1, 0, 232, DateTimeKind.Utc).AddTicks(1206));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 27, 17, 1, 0, 232, DateTimeKind.Utc).AddTicks(1208));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80277b99-4cab-4ff1-8084-6d0a5df3e787",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6e81eab6-9bcb-4cde-8d55-cbed20158c47", "AQAAAAIAAYagAAAAEBYSNFsWsBWlneTinGhm/xYclCrYRIq+z7qatYMfDnWPwbO0yxxCuzsHsR9FMdCxMw==", "8afc6f2c-5854-47a5-a286-17b47388137d" });

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
    }
}
