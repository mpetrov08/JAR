using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JAR.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Updated_Description_Max_Length : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ProfessionalExperiences",
                type: "nvarchar(max)",
                maxLength: 2147483647,
                nullable: false,
                comment: "Description of professional experience",
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300,
                oldComment: "Description of professional experience");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Lecturers",
                type: "nvarchar(max)",
                maxLength: 2147483647,
                nullable: false,
                comment: "Lecturer`s Description",
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300,
                oldComment: "Lecturer`s Description");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Degrees",
                type: "nvarchar(max)",
                maxLength: 2147483647,
                nullable: false,
                comment: "The description of degree",
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300,
                oldComment: "The description of degree");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Conferences",
                type: "nvarchar(max)",
                maxLength: 2147483647,
                nullable: false,
                comment: "Conference`s Description",
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300,
                oldComment: "Conference`s Description");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Companies",
                type: "nvarchar(max)",
                maxLength: 2147483647,
                nullable: false,
                comment: "Company Description",
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300,
                oldComment: "Company Description");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ProfessionalExperiences",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                comment: "Description of professional experience",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldMaxLength: 2147483647,
                oldComment: "Description of professional experience");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Lecturers",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                comment: "Lecturer`s Description",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldMaxLength: 2147483647,
                oldComment: "Lecturer`s Description");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Degrees",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                comment: "The description of degree",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldMaxLength: 2147483647,
                oldComment: "The description of degree");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Conferences",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                comment: "Conference`s Description",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldMaxLength: 2147483647,
                oldComment: "Conference`s Description");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Companies",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                comment: "Company Description",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldMaxLength: 2147483647,
                oldComment: "Company Description");

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
    }
}
