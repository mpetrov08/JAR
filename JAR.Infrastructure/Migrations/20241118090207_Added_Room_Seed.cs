using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JAR.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Added_Room_Seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "AdminId", "IsDeleted", "Name" },
                values: new object[] { 1, "80277b99-4cab-4ff1-8084-6d0a5df3e787", false, "Chat Room" });

            migrationBuilder.InsertData(
                table: "RoomsUsers",
                columns: new[] { "RoomId", "UserId" },
                values: new object[,]
                {
                    { 1, "2656a468-b215-4b17-865d-240a63b0d5cf" },
                    { 1, "80277b99-4cab-4ff1-8084-6d0a5df3e787" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RoomsUsers",
                keyColumns: new[] { "RoomId", "UserId" },
                keyValues: new object[] { 1, "2656a468-b215-4b17-865d-240a63b0d5cf" });

            migrationBuilder.DeleteData(
                table: "RoomsUsers",
                keyColumns: new[] { "RoomId", "UserId" },
                keyValues: new object[] { 1, "80277b99-4cab-4ff1-8084-6d0a5df3e787" });

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2656a468-b215-4b17-865d-240a63b0d5cf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "96852881-88c0-4092-aed7-88ca735f0f4c", "AQAAAAIAAYagAAAAEB76t6n0i7TsTA1yKdIWbTqFaXKd+QUhoj2NVHua+Ez5+uefHE6zudy1QdfDeZ3efA==", "e09369b6-6c95-4cf9-a284-b997719028c3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71811921-1918-4043-90b9-20f2522f315b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "95d0e263-2f6c-4278-89bb-4c4a55aefbf9", "AQAAAAIAAYagAAAAEHICajQjZVmOYmaDp4S84BL3+NQ+osq3mL1U4fplODKJchXfTiP1ipuJ9pVyPa/Qmg==", "c07e6bb3-2940-472f-882d-2761bd445ddc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80277b99-4cab-4ff1-8084-6d0a5df3e787",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "899f4136-5b94-4b26-861d-212c1004e18d", "AQAAAAIAAYagAAAAEJJAtomAUzj7+lVVf1Fdb8h6UGGiabr6U6gr1XiDYohF0jRl3BepClEf7CMtDAlbMg==", "0036f698-e6cc-41a0-b17f-c9738361509d" });

            migrationBuilder.UpdateData(
                table: "JobApplications",
                keyColumns: new[] { "JobOfferId", "UserId" },
                keyValues: new object[] { 1, "2656a468-b215-4b17-865d-240a63b0d5cf" },
                column: "AppliedOn",
                value: new DateTime(2024, 11, 18, 8, 2, 19, 808, DateTimeKind.Utc).AddTicks(554));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 11, 18, 8, 2, 19, 597, DateTimeKind.Utc).AddTicks(6839));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 11, 18, 8, 2, 19, 597, DateTimeKind.Utc).AddTicks(6845));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 11, 18, 8, 2, 19, 597, DateTimeKind.Utc).AddTicks(6854));
        }
    }
}
