using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JAR.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Added_Tables_Conferences_And_Lecturers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lecturers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Lecturer Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Foreign key of user"),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false, comment: "Lecturer`s Description")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lecturers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lecturers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Conferences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Conference Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LecturerId = table.Column<int>(type: "int", nullable: false, comment: "Foreign Key of Lecturer"),
                    Topic = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false, comment: "Conference`s topic"),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Start time of the conference"),
                    End = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "End time of the conference"),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false, comment: "Conference`s Description")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conferences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Conferences_Lecturers_LecturerId",
                        column: x => x.LecturerId,
                        principalTable: "Lecturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2656a468-b215-4b17-865d-240a63b0d5cf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d5573ebd-f700-4ed4-a43a-249a16ba623d", "AQAAAAIAAYagAAAAECMyM52HlNiNnSwUBb7P3NHDzf8o0LfIiPW6NsDvl2RV8EUPfq59APx1mNORhU+qvQ==", "07afcc7d-7ab1-4cd2-8526-5f2817c8488d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71811921-1918-4043-90b9-20f2522f315b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9f0540d3-a15d-40cf-a4e0-2b0eba44b164", "AQAAAAIAAYagAAAAEK1UnKzwCA3zciSLZRRG9RSWdfRPZC5iLFfpRv7XqOmUN4Btb+uL0u2CDAf57gd3Jw==", "d85c1a58-7c40-4f44-839c-aa7716ac668b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80277b99-4cab-4ff1-8084-6d0a5df3e787",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "52318357-9132-45d4-b444-b7f17bcf4c56", "AQAAAAIAAYagAAAAEM/X2qCpYelj+oBD4vF062NPAFhWZel8QZC3kP2cXvQAiNh8CCPdfPUOGr71aHM9gg==", "8f411300-d189-4122-8777-9820bd3ffe74" });

            migrationBuilder.UpdateData(
                table: "JobApplications",
                keyColumns: new[] { "JobOfferId", "UserId" },
                keyValues: new object[] { 1, "2656a468-b215-4b17-865d-240a63b0d5cf" },
                column: "AppliedOn",
                value: new DateTime(2024, 11, 12, 21, 22, 39, 991, DateTimeKind.Utc).AddTicks(1171));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 11, 12, 21, 22, 39, 866, DateTimeKind.Utc).AddTicks(1960));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 11, 12, 21, 22, 39, 866, DateTimeKind.Utc).AddTicks(1966));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 11, 12, 21, 22, 39, 866, DateTimeKind.Utc).AddTicks(1969));

            migrationBuilder.CreateIndex(
                name: "IX_Conferences_LecturerId",
                table: "Conferences",
                column: "LecturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Lecturers_UserId",
                table: "Lecturers",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Conferences");

            migrationBuilder.DropTable(
                name: "Lecturers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2656a468-b215-4b17-865d-240a63b0d5cf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6db54122-ced0-4cc2-8e48-7c17a2018095", "AQAAAAIAAYagAAAAECy5nx+ar6jtQugWUIl1QrE79qgaEtoXV/KWtVT/JC+kryuyHZ6Xu9p9oa2Jz7k+ww==", "9deb2695-0847-4f5e-a22c-073c3a6aaca8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71811921-1918-4043-90b9-20f2522f315b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "23c051da-3892-407c-a224-1f001b9fe85c", "AQAAAAIAAYagAAAAEIrB7CL0pNOUGieiXwB0b5ah/tlWA9WMawJxfcbq11pBH/r9VSbYuhdZAifq3bmOYg==", "79e0305d-1e52-48cd-9b11-a421f0dc000b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80277b99-4cab-4ff1-8084-6d0a5df3e787",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "69e01b82-886f-4b19-861f-df355b70444c", "AQAAAAIAAYagAAAAEPCOXQdEAs/a85sbnZmKL0ChGQdBKmG8vpuGPmjedVDc6pRNFKNxKit62Qamh2O00A==", "5040efae-7e61-4637-83e8-deccb32b8beb" });

            migrationBuilder.UpdateData(
                table: "JobApplications",
                keyColumns: new[] { "JobOfferId", "UserId" },
                keyValues: new object[] { 1, "2656a468-b215-4b17-865d-240a63b0d5cf" },
                column: "AppliedOn",
                value: new DateTime(2024, 11, 6, 17, 34, 6, 39, DateTimeKind.Utc).AddTicks(4470));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 11, 6, 17, 34, 5, 915, DateTimeKind.Utc).AddTicks(1122));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 11, 6, 17, 34, 5, 915, DateTimeKind.Utc).AddTicks(1213));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 11, 6, 17, 34, 5, 915, DateTimeKind.Utc).AddTicks(1216));
        }
    }
}
