using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JAR.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Fix_Data_Seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2656a468-b215-4b17-865d-240a63b0d5cf",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3d4c8d1f-57cd-4cd9-91e6-2951aefb48cc", "Ivan", "Ivanov", "AQAAAAIAAYagAAAAEHlNzTPws9rlPT50KXcayzK5mnmnJuxtdPl/AMuioWkWMwc4lAaZnqvC0pc3TFi4BA==", "f645bd4f-df08-4f6d-9679-dd3a9e8d5454" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71811921-1918-4043-90b9-20f2522f315b",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bb81986e-d26d-4b5d-aac3-9ef03eb70f14", "Bill", "Gates", "AQAAAAIAAYagAAAAEIVqvsOjhZnsTOtp+AAgFwytf/wdagHYR6E9PdrZ86t037Nq0AxwAD9X+rjrlkKiYg==", "3ab82a43-5ac0-4e83-afce-cc848c10c613" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80277b99-4cab-4ff1-8084-6d0a5df3e787",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "84d0326c-13ca-4831-9c8d-a018a24a14a5", "Mihail", "Petrov", "AQAAAAIAAYagAAAAEL9+m2EoZEkec1GAzS8OuqLq8oI185JZh2nPvwU0jTALiR8eP3/I/2kREKE6VYghZw==", "59a2d686-6f40-45eb-8d41-aa472157c9a3" });

            migrationBuilder.UpdateData(
                table: "Conferences",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "End", "Start" },
                values: new object[] { new DateTime(2025, 2, 21, 23, 24, 0, 511, DateTimeKind.Utc).AddTicks(8837), new DateTime(2025, 2, 21, 21, 24, 0, 511, DateTimeKind.Utc).AddTicks(8836) });

            migrationBuilder.UpdateData(
                table: "JobApplications",
                keyColumns: new[] { "JobOfferId", "UserId" },
                keyValues: new object[] { 1, "2656a468-b215-4b17-865d-240a63b0d5cf" },
                column: "AppliedOn",
                value: new DateTime(2025, 2, 21, 21, 24, 0, 10, DateTimeKind.Utc).AddTicks(364));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2025, 2, 21, 21, 23, 59, 878, DateTimeKind.Utc).AddTicks(1915));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2025, 2, 21, 21, 23, 59, 878, DateTimeKind.Utc).AddTicks(1923));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2025, 2, 21, 21, 23, 59, 878, DateTimeKind.Utc).AddTicks(1925));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2656a468-b215-4b17-865d-240a63b0d5cf",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "468c33a6-8a2d-42cd-8d3b-366f23d91cd8", "Иван", "Иванов", "AQAAAAIAAYagAAAAENymRjqMWuNrHu5SNcAYua8lApAEFITgCXdH6sIhWV3KOeWH6sS2XB8TFlm4YhLZsQ==", "e67ebc9a-426c-4c6e-8bd6-133e721c897c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71811921-1918-4043-90b9-20f2522f315b",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2a135434-74a7-48fe-a730-13b74d5cc114", "Петър", "Петров", "AQAAAAIAAYagAAAAEH96Y/ip3SFXdSfOUIWvZU7sZ0vYMn/YxeLoyHNAFj1IYuqBYfm3IfsuT9mkybpGWg==", "a9667e8b-a948-4e63-b37d-7ef0a5814d1d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80277b99-4cab-4ff1-8084-6d0a5df3e787",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f5edb4f3-8491-4136-84fb-4ec706db7905", "Михаил", "Петров", "AQAAAAIAAYagAAAAEGH12xkZarHZShki46hN30S6TgHmjBrkKwOKON4G4C9yOL6tS08uoMN5xBl5yzlP6Q==", "aefdf89f-242d-4b53-a1ad-5d082fbb6b3b" });

            migrationBuilder.UpdateData(
                table: "Conferences",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "End", "Start" },
                values: new object[] { new DateTime(2025, 2, 21, 16, 59, 57, 643, DateTimeKind.Utc).AddTicks(6797), new DateTime(2025, 2, 21, 14, 59, 57, 643, DateTimeKind.Utc).AddTicks(6797) });

            migrationBuilder.UpdateData(
                table: "JobApplications",
                keyColumns: new[] { "JobOfferId", "UserId" },
                keyValues: new object[] { 1, "2656a468-b215-4b17-865d-240a63b0d5cf" },
                column: "AppliedOn",
                value: new DateTime(2025, 2, 21, 14, 59, 57, 133, DateTimeKind.Utc).AddTicks(8873));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2025, 2, 21, 14, 59, 57, 7, DateTimeKind.Utc).AddTicks(1224));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2025, 2, 21, 14, 59, 57, 7, DateTimeKind.Utc).AddTicks(1231));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2025, 2, 21, 14, 59, 57, 7, DateTimeKind.Utc).AddTicks(1233));
        }
    }
}
