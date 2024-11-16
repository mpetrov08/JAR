using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JAR.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Added_ConferenceURL_To_Conference : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ConferenceUrl",
                table: "Conferences",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "URL to room, where to conference will be held");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2656a468-b215-4b17-865d-240a63b0d5cf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4e54584b-256e-468b-8216-881e79ea0bd4", "AQAAAAIAAYagAAAAELsDhCDN2jeCDICKd5winnEfZyEXNHKJ0Btc2UO6M0vHDkYUCTgaTQ5ZaR66yHchJw==", "69387a9b-9cc4-436f-b9a1-1f19d0b87188" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71811921-1918-4043-90b9-20f2522f315b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6377156d-934e-4196-8b49-61140ae06282", "AQAAAAIAAYagAAAAEH58PzLoGeqHNrs64G+/neiFN2Vfj16wn18se8MkwgAOT6OeyZ07hn6Lm/KHmA8ZeQ==", "b81add34-e608-4b2c-8704-353116c1d1ea" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80277b99-4cab-4ff1-8084-6d0a5df3e787",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fb934af4-d68f-400d-ba63-8083d612bf66", "AQAAAAIAAYagAAAAEJwyA4n9CYMstwM8iioDEDLV0dWpogxazJN1/D0wa2djl7w2ICSo5Y6xRkEHQ+Z6lA==", "f8033dcd-fde5-47a4-8c07-2359a4ffcdf1" });

            migrationBuilder.UpdateData(
                table: "JobApplications",
                keyColumns: new[] { "JobOfferId", "UserId" },
                keyValues: new object[] { 1, "2656a468-b215-4b17-865d-240a63b0d5cf" },
                column: "AppliedOn",
                value: new DateTime(2024, 11, 16, 10, 2, 21, 554, DateTimeKind.Utc).AddTicks(8000));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 11, 16, 10, 2, 21, 428, DateTimeKind.Utc).AddTicks(8461));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 11, 16, 10, 2, 21, 428, DateTimeKind.Utc).AddTicks(8465));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 11, 16, 10, 2, 21, 428, DateTimeKind.Utc).AddTicks(8523));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConferenceUrl",
                table: "Conferences");

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
    }
}
