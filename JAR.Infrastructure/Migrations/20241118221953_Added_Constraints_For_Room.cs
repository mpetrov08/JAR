using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JAR.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Added_Constraints_For_Room : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Rooms",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                comment: "Room`s Name",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "Room`s Name");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2656a468-b215-4b17-865d-240a63b0d5cf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "57ffe073-83ba-4da4-a06a-11c7db12865a", "AQAAAAIAAYagAAAAECp0p47vvvzAycDq5ySi1rW2Z3nLYcl3tAp4XtJNb7TlXPpziLqMO47561LF44XIPg==", "ddf726b4-0699-4807-98cf-15474856ec43" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71811921-1918-4043-90b9-20f2522f315b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e41df477-142e-4ba8-8438-88c7f11d225c", "AQAAAAIAAYagAAAAEOU5sJ5JEAbi+dIc9LkdypxJymzpFLyAqmUN9USp/blAJOS4vTvMErbKOu0hkWEk5Q==", "5a4cef03-7994-43e6-9a55-da472d924d94" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80277b99-4cab-4ff1-8084-6d0a5df3e787",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b50ed9c1-d089-4269-bcdc-d8b89943fbd5", "AQAAAAIAAYagAAAAEFKNfQR6nGSuHHk8ukNJefX0/oxE5dkFmSIrZ+1kku4cHWSYgpdUAqGf0I4txgJasw==", "118e45f2-4e54-46ee-b528-867de460a8db" });

            migrationBuilder.UpdateData(
                table: "JobApplications",
                keyColumns: new[] { "JobOfferId", "UserId" },
                keyValues: new object[] { 1, "2656a468-b215-4b17-865d-240a63b0d5cf" },
                column: "AppliedOn",
                value: new DateTime(2024, 11, 18, 22, 19, 52, 781, DateTimeKind.Utc).AddTicks(5610));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 11, 18, 22, 19, 52, 633, DateTimeKind.Utc).AddTicks(3350));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 11, 18, 22, 19, 52, 633, DateTimeKind.Utc).AddTicks(3354));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 11, 18, 22, 19, 52, 633, DateTimeKind.Utc).AddTicks(3357));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: false,
                comment: "Room`s Name",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldComment: "Room`s Name");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2656a468-b215-4b17-865d-240a63b0d5cf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0a191d3f-8d21-47d4-83e7-b7b94794b53c", "AQAAAAIAAYagAAAAEFlYIbgYibMiK6/CMJXmRiJfiOvQmMtw+6WRlVCdJ2XbIAq/I+/UHpkJbR5OcKTzCw==", "347bd194-05e5-401c-8c3a-6b6a7e763fd8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71811921-1918-4043-90b9-20f2522f315b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "06e225f0-1377-4530-9338-2272bf50f233", "AQAAAAIAAYagAAAAEGHRdh53AzUIEN3kbT36iWO986eBVz7X2HwnYzVd4kIs6VCljvGSuHBRtLm9AM9Njg==", "35672ea4-2067-4fc3-b7de-71ee1bb683d5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80277b99-4cab-4ff1-8084-6d0a5df3e787",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5ba090ac-368d-47df-bfe3-82f72151870a", "AQAAAAIAAYagAAAAELPdrUoMy60j+hf3z29J7FTYZv3ZFdYcvtY3CwAyG4bQRCHyTZui4eXkifV6ovPJhw==", "ce2124ab-f46d-4ca6-938f-0f1ead95e655" });

            migrationBuilder.UpdateData(
                table: "JobApplications",
                keyColumns: new[] { "JobOfferId", "UserId" },
                keyValues: new object[] { 1, "2656a468-b215-4b17-865d-240a63b0d5cf" },
                column: "AppliedOn",
                value: new DateTime(2024, 11, 18, 9, 2, 6, 990, DateTimeKind.Utc).AddTicks(5329));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 11, 18, 9, 2, 6, 855, DateTimeKind.Utc).AddTicks(7887));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 11, 18, 9, 2, 6, 855, DateTimeKind.Utc).AddTicks(7893));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 11, 18, 9, 2, 6, 855, DateTimeKind.Utc).AddTicks(7998));
        }
    }
}
