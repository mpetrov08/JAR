using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JAR.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Data_Seeded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RequiredSkills",
                table: "JobOffers",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                comment: "Job Offer Required Skills",
                oldClrType: typeof(string),
                oldType: "nvarchar(75)",
                oldMaxLength: 75,
                oldComment: "Job Offer Required Skills");

            migrationBuilder.AlterColumn<string>(
                name: "RequiredLanguage",
                table: "JobOffers",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                comment: "Job Offer Required Language",
                oldClrType: typeof(string),
                oldType: "nvarchar(75)",
                oldMaxLength: 75,
                oldComment: "Job Offer Required Language");

            migrationBuilder.AlterColumn<string>(
                name: "RequiredExperience",
                table: "JobOffers",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                comment: "Job Offer Required Experience",
                oldClrType: typeof(string),
                oldType: "nvarchar(75)",
                oldMaxLength: 75,
                oldComment: "Job Offer Required Experience");

            migrationBuilder.AlterColumn<string>(
                name: "RequiredDegree",
                table: "JobOffers",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                comment: "Job Offer Required Degree",
                oldClrType: typeof(string),
                oldType: "nvarchar(75)",
                oldMaxLength: 75,
                oldComment: "Job Offer Required Degree");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "2656a468-b215-4b17-865d-240a63b0d5cf", 0, "869af271-6a5f-4719-98e8-1a1f6932d9b2", "guest@gmail.com", false, false, null, "GUEST@GMAIL.COM", "GUEST@GMAIL.COM", "AQAAAAIAAYagAAAAEATOOTjvpIvIWOh9odNpZp3WRItj7SQuQgM6H98XfcuHtrJcRzg2N1inVQQWp00DIA==", null, false, "b3362f8e-2c6d-4d7b-9103-890c0ada7e62", false, "guest@gmail.com" },
                    { "71811921-1918-4043-90b9-20f2522f315b", 0, "8abdac22-be44-4be7-adda-bec519bdc6ec", "owner@gmail.com", false, false, null, "OWNER@GMAIL.COM", "OWNER@GMAIL.COM", "AQAAAAIAAYagAAAAEL7um7YWRwKVspxGvY2sdQsrsF3h2G8tXlyY6aGvB0S+YKM28XY9iOqtUXHNQVgjag==", null, false, "e9300033-b06b-41d6-b63d-6e6f93dbbab2", false, "owner@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Software Engineering" },
                    { 2, "Health Care" },
                    { 3, "Management" }
                });

            migrationBuilder.InsertData(
                table: "JobTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Internship Job" },
                    { 2, "Full Time Job" },
                    { 3, "Part Time Job" },
                    { 4, "Temporary Job" },
                    { 5, "Seasonal Job" }
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Address", "Description", "Email", "IsDeleted", "Name", "OwnerId", "PhoneNumber" },
                values: new object[] { 1, "Redmond, Washington, USA", "Microsoft is a global technology company known for software and hardware.", "microsoft@gmail.com", false, "Microsoft", "71811921-1918-4043-90b9-20f2522f315b", "1234567890" });

            migrationBuilder.InsertData(
                table: "JobOffers",
                columns: new[] { "Id", "Address", "CategoryId", "CompanyId", "CreatedOn", "Description", "IsDeleted", "JobTypeId", "RequiredDegree", "RequiredExperience", "RequiredLanguage", "RequiredSkills", "Salary", "Title" },
                values: new object[,]
                {
                    { 1, "Redmond, Washington, USA", 1, 1, new DateTime(2024, 10, 4, 19, 0, 2, 600, DateTimeKind.Utc).AddTicks(9209), "A C# junior programmer should know OOP, Design Patterns, .NET, debugging and SQL.", false, 1, "Higher Education", "", "English C2", "OOP, SQL, .NET, Design Patterns, Data Structures and Algorithms", 2000m, "Junior C# Programmer" },
                    { 2, "Reading, Thames Valley Park, UK", 1, 1, new DateTime(2024, 10, 4, 19, 0, 2, 600, DateTimeKind.Utc).AddTicks(9218), "C# Senior Developer must have excellent knowledge of .NET, architecture, code optimization.", false, 2, "Higher Education", "", "English C2", "OOP, SQL, .NET, Architecture, Code Optimization", 10000m, "Senior C# Programmer" },
                    { 3, "Reading, Thames Valley Park, UK", 3, 1, new DateTime(2024, 10, 4, 19, 0, 2, 600, DateTimeKind.Utc).AddTicks(9223), "Dynamic manager needed at Microsoft to lead teams and drive innovation.", false, 2, "Higher Education", "10 years", "English C2", " Project Management, Strong Communication, Leadership, Problem-Solving", 15000m, "Looking for a manager to lead Microsoft" }
                });

            migrationBuilder.InsertData(
                table: "JobApplications",
                columns: new[] { "JobOfferId", "UserId", "AppliedOn" },
                values: new object[] { 1, "2656a468-b215-4b17-865d-240a63b0d5cf", new DateTime(2024, 10, 4, 19, 0, 2, 752, DateTimeKind.Utc).AddTicks(8075) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "JobApplications",
                keyColumns: new[] { "JobOfferId", "UserId" },
                keyValues: new object[] { 1, "2656a468-b215-4b17-865d-240a63b0d5cf" });

            migrationBuilder.DeleteData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "JobTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "JobTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "JobTypes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2656a468-b215-4b17-865d-240a63b0d5cf");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "JobTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "JobTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71811921-1918-4043-90b9-20f2522f315b");

            migrationBuilder.AlterColumn<string>(
                name: "RequiredSkills",
                table: "JobOffers",
                type: "nvarchar(75)",
                maxLength: 75,
                nullable: false,
                comment: "Job Offer Required Skills",
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150,
                oldComment: "Job Offer Required Skills");

            migrationBuilder.AlterColumn<string>(
                name: "RequiredLanguage",
                table: "JobOffers",
                type: "nvarchar(75)",
                maxLength: 75,
                nullable: false,
                comment: "Job Offer Required Language",
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150,
                oldComment: "Job Offer Required Language");

            migrationBuilder.AlterColumn<string>(
                name: "RequiredExperience",
                table: "JobOffers",
                type: "nvarchar(75)",
                maxLength: 75,
                nullable: false,
                comment: "Job Offer Required Experience",
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150,
                oldComment: "Job Offer Required Experience");

            migrationBuilder.AlterColumn<string>(
                name: "RequiredDegree",
                table: "JobOffers",
                type: "nvarchar(75)",
                maxLength: 75,
                nullable: false,
                comment: "Job Offer Required Degree",
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150,
                oldComment: "Job Offer Required Degree");
        }
    }
}
