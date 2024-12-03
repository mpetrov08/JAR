using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JAR.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Seeded_Lecturer_And_Conference : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2656a468-b215-4b17-865d-240a63b0d5cf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e7f0d222-402c-4553-bb16-a25add765626", "AQAAAAIAAYagAAAAEBXumWsocQIsxEH6Oi1q2YwwuIU4Wl3TKg5VEHw1j40fikhQsRMWXSLxxRGJjE/Bhw==", "6ef71bb2-9ef3-4ccc-bf31-7e9cfc1ef0a6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71811921-1918-4043-90b9-20f2522f315b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fcfba324-987d-4807-be28-371814f9f137", "AQAAAAIAAYagAAAAEMRGPxzvm49hF7qkACmSlt/xKZPEdpPtxkcim3fOX4LsScpSBn1nGFmmfkL6tz6s0A==", "5dbad51c-f456-4a7d-bab1-00c33204d508" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80277b99-4cab-4ff1-8084-6d0a5df3e787",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "38aee771-c4ae-400a-86b6-e1179a401e40", "AQAAAAIAAYagAAAAECRJg9kyU+dVTieU0m9U+A/59dJGbIlAKcbJQ0RZw+Tqvoifn9bCzhpTDIqI+9rA8A==", "cb756f58-7004-451a-892a-5586e2d1bb87" });

            migrationBuilder.UpdateData(
                table: "JobApplications",
                keyColumns: new[] { "JobOfferId", "UserId" },
                keyValues: new object[] { 1, "2656a468-b215-4b17-865d-240a63b0d5cf" },
                column: "AppliedOn",
                value: new DateTime(2024, 12, 3, 21, 55, 21, 596, DateTimeKind.Utc).AddTicks(8257));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 3, 21, 55, 21, 467, DateTimeKind.Utc).AddTicks(9502));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 3, 21, 55, 21, 467, DateTimeKind.Utc).AddTicks(9508));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 3, 21, 55, 21, 467, DateTimeKind.Utc).AddTicks(9511));

            migrationBuilder.InsertData(
                table: "Lecturers",
                columns: new[] { "Id", "Description", "IsDeleted", "UserId" },
                values: new object[] { 1, "Very good lecturer. He has experience of 15 years, one of the best.", false, "71811921-1918-4043-90b9-20f2522f315b" });

            migrationBuilder.InsertData(
                table: "Conferences",
                columns: new[] { "Id", "ConferenceUrl", "Description", "End", "IsDeleted", "LecturerId", "Start", "Topic" },
                values: new object[] { 1, "https://meet.google.com/pra-cekt-nbn", "In this conference we will talk about that, how to find easy work and is it that hard.", new DateTime(2024, 12, 3, 23, 55, 22, 97, DateTimeKind.Utc).AddTicks(2005), false, 1, new DateTime(2024, 12, 3, 21, 55, 22, 97, DateTimeKind.Utc).AddTicks(2004), "How to find easy Job? Is it really hard?" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Conferences",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Lecturers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2656a468-b215-4b17-865d-240a63b0d5cf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "61d22050-af0d-4066-9a97-c8347ac8bac8", "AQAAAAIAAYagAAAAECdpOELx1kY81p+astdmIeiPhqG69Z6HiurP4DaOcWdg2GodIII/YVV/WsOr7alSaA==", "ea127e2b-15bf-4c59-bb3f-d098e3fc270a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71811921-1918-4043-90b9-20f2522f315b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e12ad374-f357-4bd4-b774-5b1c6c6bf278", "AQAAAAIAAYagAAAAEOl0OurnDTdYPDN0gdZ9yLsmMGCvU4suh1VstDyKhriCwV74J0Z1Id3X/xZGHltYPw==", "81bdb59d-7d87-4255-ab10-ce400639a24a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80277b99-4cab-4ff1-8084-6d0a5df3e787",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "09fdbcfe-2eee-42fe-89e7-b386cb448163", "AQAAAAIAAYagAAAAEKHgJj+RBv2kyfFOGke2FT0Awj5DN8m0N9ublG89wQIuBnl2EzOPzfgCKelKVwmhHg==", "30c4e814-e340-46a9-98ae-f35645d172e5" });

            migrationBuilder.UpdateData(
                table: "JobApplications",
                keyColumns: new[] { "JobOfferId", "UserId" },
                keyValues: new object[] { 1, "2656a468-b215-4b17-865d-240a63b0d5cf" },
                column: "AppliedOn",
                value: new DateTime(2024, 11, 27, 9, 20, 58, 842, DateTimeKind.Utc).AddTicks(7250));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 11, 27, 9, 20, 58, 717, DateTimeKind.Utc).AddTicks(3246));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 11, 27, 9, 20, 58, 717, DateTimeKind.Utc).AddTicks(3251));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 11, 27, 9, 20, 58, 717, DateTimeKind.Utc).AddTicks(3254));
        }
    }
}
