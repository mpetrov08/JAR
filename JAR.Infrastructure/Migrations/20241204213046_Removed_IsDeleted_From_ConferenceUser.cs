using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JAR.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Removed_IsDeleted_From_ConferenceUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ConferencesUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2656a468-b215-4b17-865d-240a63b0d5cf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a829c359-c72d-4421-84f0-a6b9788d8e87", "AQAAAAIAAYagAAAAEJ+BACi8mLKUPbhBx53ndesJuhd7madFLW9HsV3z0wlixhaIBFTjp/ZUm/U1Q+I5tA==", "a9538c47-5690-40d6-a58b-f6badc806514" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71811921-1918-4043-90b9-20f2522f315b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "edbb56e7-8e2d-4bdc-bf1a-14c0afcd0a39", "AQAAAAIAAYagAAAAEO6h0fNzdS5wqV2eYzsUxlKkpFhv6jxCd1r2dRYCQrhqsZkbjT9sGn1/Z7xrUe4cgw==", "eb8c87d3-3a09-4a75-93c8-2fd7e0793b04" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80277b99-4cab-4ff1-8084-6d0a5df3e787",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f06118d6-6234-462c-8b2a-652baf8d13fb", "AQAAAAIAAYagAAAAEJTGA8BX4uPnRCyRLd2zkUBeKqTE0+w6L32VYs+xXal+HIuZREhrjsXW9Qbg1L9T5g==", "6a615bd3-c83e-4f7d-bd22-e8f3d2694fa6" });

            migrationBuilder.UpdateData(
                table: "Conferences",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "End", "Start" },
                values: new object[] { new DateTime(2024, 12, 4, 23, 30, 45, 377, DateTimeKind.Utc).AddTicks(2212), new DateTime(2024, 12, 4, 21, 30, 45, 377, DateTimeKind.Utc).AddTicks(2088) });

            migrationBuilder.UpdateData(
                table: "JobApplications",
                keyColumns: new[] { "JobOfferId", "UserId" },
                keyValues: new object[] { 1, "2656a468-b215-4b17-865d-240a63b0d5cf" },
                column: "AppliedOn",
                value: new DateTime(2024, 12, 4, 21, 30, 44, 673, DateTimeKind.Utc).AddTicks(4504));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 4, 21, 30, 44, 506, DateTimeKind.Utc).AddTicks(7425));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 4, 21, 30, 44, 506, DateTimeKind.Utc).AddTicks(7432));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 4, 21, 30, 44, 506, DateTimeKind.Utc).AddTicks(7436));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ConferencesUsers",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Checks if the ConferenceUser has been deleted");

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
                table: "Conferences",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "End", "Start" },
                values: new object[] { new DateTime(2024, 12, 3, 23, 55, 22, 97, DateTimeKind.Utc).AddTicks(2005), new DateTime(2024, 12, 3, 21, 55, 22, 97, DateTimeKind.Utc).AddTicks(2004) });

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
        }
    }
}
