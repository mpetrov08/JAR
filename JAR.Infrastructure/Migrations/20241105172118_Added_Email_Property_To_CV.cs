using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JAR.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Added_Email_Property_To_CV : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "CVs",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "",
                comment: "Email Address");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "CVs");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2656a468-b215-4b17-865d-240a63b0d5cf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9f1e5b3b-ade0-4f54-b0e4-2efbc1ad5343", "AQAAAAIAAYagAAAAEIXKdv9jx31b+vFB7ub7gKdmeHkVUfdhVP5Ah9M15LCp5sdHFpxF2qecNrzHutubqg==", "38d5c23f-674a-4bb6-8087-8eea2c3d71f2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71811921-1918-4043-90b9-20f2522f315b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "efbc727b-5b5d-4d6d-8a6c-df275a4f3754", "AQAAAAIAAYagAAAAEHBWwj8crXOh6zr23eWbfW/5rnlUtFwVDX8PdkhbZ5la9aNTUEXPh0qLO6ETp6N6Uw==", "6a23b552-5acb-41f5-87bd-1335c9a2bed4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80277b99-4cab-4ff1-8084-6d0a5df3e787",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7d1f8086-ab2d-4059-b907-a7586780142a", "AQAAAAIAAYagAAAAEMJZzCIKIyOMMwHiLCzkD/AXJQJhS7vvIvVRsg4Dvh6eTsZ144ht8zg2ba+5ex1V6g==", "7832d979-bf61-4427-8ae8-1133314b2e58" });

            migrationBuilder.UpdateData(
                table: "JobApplications",
                keyColumns: new[] { "JobOfferId", "UserId" },
                keyValues: new object[] { 1, "2656a468-b215-4b17-865d-240a63b0d5cf" },
                column: "AppliedOn",
                value: new DateTime(2024, 10, 28, 17, 37, 55, 56, DateTimeKind.Utc).AddTicks(6000));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 28, 17, 37, 54, 928, DateTimeKind.Utc).AddTicks(5982));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 28, 17, 37, 54, 928, DateTimeKind.Utc).AddTicks(5989));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 28, 17, 37, 54, 928, DateTimeKind.Utc).AddTicks(5999));
        }
    }
}
