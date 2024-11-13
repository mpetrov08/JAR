using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JAR.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Added_SoftDelete_To_Conference_And_Lecturer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Lecturers",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Checks if the Lecturer has been deleted");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Conferences",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Checks if the Conference has been deleted");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2656a468-b215-4b17-865d-240a63b0d5cf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "074ee41e-8894-450b-9de4-fe4719b4c67e", "AQAAAAIAAYagAAAAEC2q4j1I5P/fWa6RNP0Ffht07mwJBfNOMpWnG0K/TXx2kKMc+WFW59PPBykhRuuX2A==", "1fee48f2-5c74-4505-aff6-31aac7a99b3e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71811921-1918-4043-90b9-20f2522f315b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "417dd017-70f4-4bb3-b2b8-bc0b235ecd91", "AQAAAAIAAYagAAAAEK4uScm9L2gjz0xFmoCWqeVAPjFD3glHB7nDvAEDjBP5ygUNNfDKm7i9vHF0PF/hiw==", "fcc0af2e-5e4b-4fa7-a84e-e03736176eab" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80277b99-4cab-4ff1-8084-6d0a5df3e787",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "176d717d-0dd0-4b2f-8a49-cfb8bc1e46ab", "AQAAAAIAAYagAAAAEGiufYZZY2sAYG9SL7tySUXgZUUd2pVUsluxntds2fRS6J31TTDK4MS48CR3amQrWg==", "ab8b2f3e-f39b-4073-b76e-756fa40d2ca6" });

            migrationBuilder.UpdateData(
                table: "JobApplications",
                keyColumns: new[] { "JobOfferId", "UserId" },
                keyValues: new object[] { 1, "2656a468-b215-4b17-865d-240a63b0d5cf" },
                column: "AppliedOn",
                value: new DateTime(2024, 11, 13, 21, 25, 14, 424, DateTimeKind.Utc).AddTicks(6370));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 11, 13, 21, 25, 14, 295, DateTimeKind.Utc).AddTicks(3424));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 11, 13, 21, 25, 14, 295, DateTimeKind.Utc).AddTicks(3428));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 11, 13, 21, 25, 14, 295, DateTimeKind.Utc).AddTicks(3431));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Lecturers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Conferences");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2656a468-b215-4b17-865d-240a63b0d5cf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d5573ebd-f700-4ed4-a43a-249a16ba623d", "AQAAAAIAAYagAAAAECMyM52HlNiNnSwUBb7P3NHDzf8o0LfIiPW6NsDvl2RV8EUPfq59APx1mNORhU+qvQ==", "07afcc7d-7ab1-4cd2-8526-5f2817c8488d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71811921-1918-4043-90b9-20f2522f315b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9f0540d3-a15d-40cf-a4e0-2b0eba44b164", "AQAAAAIAAYagAAAAEK1UnKzwCA3zciSLZRRG9RSWdfRPZC5iLFfpRv7XqOmUN4Btb+uL0u2CDAf57gd3Jw==", "d85c1a58-7c40-4f44-839c-aa7716ac668b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80277b99-4cab-4ff1-8084-6d0a5df3e787",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "52318357-9132-45d4-b444-b7f17bcf4c56", "AQAAAAIAAYagAAAAEM/X2qCpYelj+oBD4vF062NPAFhWZel8QZC3kP2cXvQAiNh8CCPdfPUOGr71aHM9gg==", "8f411300-d189-4122-8777-9820bd3ffe74" });

            migrationBuilder.UpdateData(
                table: "JobApplications",
                keyColumns: new[] { "JobOfferId", "UserId" },
                keyValues: new object[] { 1, "2656a468-b215-4b17-865d-240a63b0d5cf" },
                column: "AppliedOn",
                value: new DateTime(2024, 11, 12, 21, 22, 39, 991, DateTimeKind.Utc).AddTicks(1171));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 11, 12, 21, 22, 39, 866, DateTimeKind.Utc).AddTicks(1960));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 11, 12, 21, 22, 39, 866, DateTimeKind.Utc).AddTicks(1966));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 11, 12, 21, 22, 39, 866, DateTimeKind.Utc).AddTicks(1969));
        }
    }
}
