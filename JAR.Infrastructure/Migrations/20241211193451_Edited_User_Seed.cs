using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JAR.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Edited_User_Seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2656a468-b215-4b17-865d-240a63b0d5cf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "48319e88-ca78-47a1-8a8d-a4bcf6be23e2", "AQAAAAIAAYagAAAAEENxnLikkAR8ilb5DFyqNt5jb5HrsRKTQD4sDFSAznB3QYlFY27UOGZVZ/ALYk9Cig==", "a094396d-c76b-4ee5-b323-dd2df6b185e5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71811921-1918-4043-90b9-20f2522f315b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6b15ce96-c599-4b25-949b-d694ad172bf9", "AQAAAAIAAYagAAAAEAx2CWome7O5zgARQ9GdD1IWnXa8lBywyvAaJlxQF5hQ493ocB1YU27xXVLQPMgVGA==", "6a63a5b9-6134-4454-825a-ca56e8d58895" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80277b99-4cab-4ff1-8084-6d0a5df3e787",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b06cc072-bd0f-4c29-8522-f6ceba448e9f", true, "AQAAAAIAAYagAAAAEPIlhZ7XGyxXn1Xg/xViT9ObJJJdU2uzBqJVGEBoJOjlrgm77fxogvETL8E17kh+OA==", "3eb1d5a7-761c-4ba1-8187-1e9d1f15150e" });

            migrationBuilder.UpdateData(
                table: "Conferences",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "End", "Start" },
                values: new object[] { new DateTime(2024, 12, 11, 21, 34, 50, 250, DateTimeKind.Utc).AddTicks(712), new DateTime(2024, 12, 11, 19, 34, 50, 250, DateTimeKind.Utc).AddTicks(710) });

            migrationBuilder.UpdateData(
                table: "JobApplications",
                keyColumns: new[] { "JobOfferId", "UserId" },
                keyValues: new object[] { 1, "2656a468-b215-4b17-865d-240a63b0d5cf" },
                column: "AppliedOn",
                value: new DateTime(2024, 12, 11, 19, 34, 49, 719, DateTimeKind.Utc).AddTicks(6340));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 11, 19, 34, 49, 579, DateTimeKind.Utc).AddTicks(4509));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 11, 19, 34, 49, 579, DateTimeKind.Utc).AddTicks(4516));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 11, 19, 34, 49, 579, DateTimeKind.Utc).AddTicks(4519));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2656a468-b215-4b17-865d-240a63b0d5cf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4d9b4a16-f0e1-424d-849f-84998cb45ff0", "AQAAAAIAAYagAAAAEJhD17Up9jvUWNx4uW2D02pY817ZFFydsWPkT3jThCae9LaQgZ3bmiI5ilrEHMEIsg==", "2c46264e-a9c9-4afc-951c-033bc108c5df" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71811921-1918-4043-90b9-20f2522f315b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fb35278d-cc6e-4cb1-bef9-536a89d3325f", "AQAAAAIAAYagAAAAEHfPeZ5ZyoFvUVLcpAGUdWA00YTVxaBNt+C2+sE4Zhyx9DwhCs5Tvj/gzctJgE6B0A==", "ef835d41-5c81-4a08-9d00-62c88c871a7b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80277b99-4cab-4ff1-8084-6d0a5df3e787",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "PasswordHash", "SecurityStamp" },
                values: new object[] { "429a93cd-b1f1-4f80-82b8-3973779421c6", false, "AQAAAAIAAYagAAAAELSGm29LAwG2mR5kUJ6pmpeo2uDMFwfVwsOUT7Q0Sq94xPleNHy/pI8b8gw89bZeIQ==", "3687a642-16ae-4e2b-ab57-f78c95088f02" });

            migrationBuilder.UpdateData(
                table: "Conferences",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "End", "Start" },
                values: new object[] { new DateTime(2024, 12, 9, 23, 52, 18, 805, DateTimeKind.Utc).AddTicks(3320), new DateTime(2024, 12, 9, 21, 52, 18, 805, DateTimeKind.Utc).AddTicks(3320) });

            migrationBuilder.UpdateData(
                table: "JobApplications",
                keyColumns: new[] { "JobOfferId", "UserId" },
                keyValues: new object[] { 1, "2656a468-b215-4b17-865d-240a63b0d5cf" },
                column: "AppliedOn",
                value: new DateTime(2024, 12, 9, 21, 52, 18, 280, DateTimeKind.Utc).AddTicks(501));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 9, 21, 52, 18, 152, DateTimeKind.Utc).AddTicks(6881));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 9, 21, 52, 18, 152, DateTimeKind.Utc).AddTicks(6886));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 9, 21, 52, 18, 152, DateTimeKind.Utc).AddTicks(6889));
        }
    }
}
