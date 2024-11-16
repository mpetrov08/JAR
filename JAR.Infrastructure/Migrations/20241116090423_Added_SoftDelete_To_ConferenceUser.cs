using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JAR.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Added_SoftDelete_To_ConferenceUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "4eaa4c41-f082-4268-946e-2b48caebb3ed", "AQAAAAIAAYagAAAAEOBREg9Vg0MfKZ1lyEFvDDd5+8P185b5uPu6LwR1VxsHQ01HPn2VR1in9H9rnTaeqg==", "49d6469d-93ef-4b35-9eab-2e15e0932878" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71811921-1918-4043-90b9-20f2522f315b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4d81789c-59bf-4e78-8479-095add31c4b0", "AQAAAAIAAYagAAAAEFjFUyYiViQnV7AUmDzlqQgpGnAlLatFjQKVJxerf6r6ayXxa1upr4AwLDbelXbe/Q==", "b429a0a3-af3e-4a82-af6d-3083299d1cc1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80277b99-4cab-4ff1-8084-6d0a5df3e787",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dd40f156-dee9-45af-874d-b32eeb177104", "AQAAAAIAAYagAAAAEDUKNmpdrqPSXT6hTa3lyfEhjzwELbOIvJlpBujZGtp0X8GOhNJbERXdrv3yuZrXhw==", "8550c35e-0352-4a76-89a0-f693ace5328a" });

            migrationBuilder.UpdateData(
                table: "JobApplications",
                keyColumns: new[] { "JobOfferId", "UserId" },
                keyValues: new object[] { 1, "2656a468-b215-4b17-865d-240a63b0d5cf" },
                column: "AppliedOn",
                value: new DateTime(2024, 11, 16, 9, 4, 23, 119, DateTimeKind.Utc).AddTicks(4989));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 11, 16, 9, 4, 22, 976, DateTimeKind.Utc).AddTicks(3031));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 11, 16, 9, 4, 22, 976, DateTimeKind.Utc).AddTicks(3036));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 11, 16, 9, 4, 22, 976, DateTimeKind.Utc).AddTicks(3039));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ConferencesUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2656a468-b215-4b17-865d-240a63b0d5cf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bc31a7b3-a02d-47cb-9ce2-3e2e4d867a74", "AQAAAAIAAYagAAAAEBFU2VecuTXn69JhJZpuTj5ddRmvtSZnbB1BzwcKUXhBEmmjNab9LAO8cEAo+/fXIg==", "d680012d-bffc-494b-8bd2-af704656e1b2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71811921-1918-4043-90b9-20f2522f315b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "01888808-98f2-4fc9-a448-e9bf189a33d5", "AQAAAAIAAYagAAAAEJZLkowip75Wrk8FGGob4HjoKxsq2cpLYaHEUk+4cpJLuFFkKiuJqGa8ig0sjAtY6w==", "69df5f9f-a040-4b17-8782-3fe0988cc2ae" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80277b99-4cab-4ff1-8084-6d0a5df3e787",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3b0df9c6-6be8-433a-8c45-7c5c5d9fafce", "AQAAAAIAAYagAAAAEJ0zlcnH1o9zR/CPEYxt+6cQZmSHuXulerjKqR9szlIvV0/IuLXCwlD5ivQLUSua4g==", "7216862c-31fd-4461-9b8d-124ea745b703" });

            migrationBuilder.UpdateData(
                table: "JobApplications",
                keyColumns: new[] { "JobOfferId", "UserId" },
                keyValues: new object[] { 1, "2656a468-b215-4b17-865d-240a63b0d5cf" },
                column: "AppliedOn",
                value: new DateTime(2024, 11, 14, 22, 8, 22, 298, DateTimeKind.Utc).AddTicks(1783));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 11, 14, 22, 8, 22, 173, DateTimeKind.Utc).AddTicks(9001));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 11, 14, 22, 8, 22, 173, DateTimeKind.Utc).AddTicks(9006));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 11, 14, 22, 8, 22, 173, DateTimeKind.Utc).AddTicks(9009));
        }
    }
}
