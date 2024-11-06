using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JAR.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Added_SoftDelete_Property_To_Degree_And_ProffesionalExperience : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ProfessionalExperiences",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Checks if the Professional Experience has been deleted");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Degrees",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Checks if the Degree has been deleted");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "CVs",
                type: "bit",
                nullable: false,
                comment: "Checks if the CV has been deleted",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "Checks if the Job Offer has been deleted");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ProfessionalExperiences");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Degrees");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "CVs",
                type: "bit",
                nullable: false,
                comment: "Checks if the Job Offer has been deleted",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "Checks if the CV has been deleted");

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
    }
}
