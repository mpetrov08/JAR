using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JAR.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Added_IsDeleted_To_CV : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CVs",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Checks if the Job Offer has been deleted");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2656a468-b215-4b17-865d-240a63b0d5cf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ea8de9bc-e492-4365-bb93-29fd39c00f4f", "AQAAAAIAAYagAAAAEDfXXYHyx+UWFHZ4HvvZJDwBn2cidNz6zgoXBrLdsj6EVLEOXP7NPQwc3DkjCNAIUA==", "e316a045-8027-4099-abb1-38bb6e7c7f90" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71811921-1918-4043-90b9-20f2522f315b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1d830370-d375-411a-b543-622e4df3cf0b", "AQAAAAIAAYagAAAAEJbyG4S8gdxWSwISa/aoKe0evzdA4WokB27NyVY5bty+9d0wRneYTBEaLSIkTTP0yw==", "2d22e61b-d13c-4f8f-a7c3-d668d21fd638" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80277b99-4cab-4ff1-8084-6d0a5df3e787",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "76cb71a5-376b-48cd-b3b9-4792baa81608", "AQAAAAIAAYagAAAAEOw+JMJDEVaz8BR6ZVceF5MP+AX5lkiEwxptj8orSkHD3mWO+ceZJg4vLGVT+Bqfug==", "3eae5052-f1db-41d3-bd0b-7095514bb120" });

            migrationBuilder.UpdateData(
                table: "JobApplications",
                keyColumns: new[] { "JobOfferId", "UserId" },
                keyValues: new object[] { 1, "2656a468-b215-4b17-865d-240a63b0d5cf" },
                column: "AppliedOn",
                value: new DateTime(2024, 11, 5, 19, 15, 45, 92, DateTimeKind.Utc).AddTicks(4529));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 11, 5, 19, 15, 44, 967, DateTimeKind.Utc).AddTicks(7856));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 11, 5, 19, 15, 44, 967, DateTimeKind.Utc).AddTicks(7862));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 11, 5, 19, 15, 44, 967, DateTimeKind.Utc).AddTicks(7865));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CVs");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2656a468-b215-4b17-865d-240a63b0d5cf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3261704d-3cfd-4c63-ad16-61e23fb2f9ae", "AQAAAAIAAYagAAAAEE7pN5VWiHP9zynRkkvZVQ7XEXXU5Ilpi4vEs5T8mtwV27zhwtosHRpTh1kFuvmj8w==", "a42f7eb9-ba42-435f-9d9a-0469371878bc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71811921-1918-4043-90b9-20f2522f315b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9f4e44c6-8144-4284-bd9b-f06f1c0a9e59", "AQAAAAIAAYagAAAAEFlKbRHUDqjXLxDWIl1YlAUzH/ITd8peOpQHAxyaekuLxF5iBHe7aM58htb2g4yLmw==", "ed3752b7-a453-45e5-bc45-39bccd61ae5a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80277b99-4cab-4ff1-8084-6d0a5df3e787",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cae40b7f-ae08-4ec4-9c68-c93893cd4aa7", "AQAAAAIAAYagAAAAEJ5Jbj+J7uyFyanuIC2oP+DAkitTkk26B6Lb/oNl+6I+W6eCQue+9ca7pwFJFtbk9Q==", "cafcfaa3-1699-4149-9b23-fd8c46717e79" });

            migrationBuilder.UpdateData(
                table: "JobApplications",
                keyColumns: new[] { "JobOfferId", "UserId" },
                keyValues: new object[] { 1, "2656a468-b215-4b17-865d-240a63b0d5cf" },
                column: "AppliedOn",
                value: new DateTime(2024, 11, 5, 17, 21, 18, 355, DateTimeKind.Utc).AddTicks(4394));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 11, 5, 17, 21, 18, 228, DateTimeKind.Utc).AddTicks(1076));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 11, 5, 17, 21, 18, 228, DateTimeKind.Utc).AddTicks(1082));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 11, 5, 17, 21, 18, 228, DateTimeKind.Utc).AddTicks(1085));
        }
    }
}
