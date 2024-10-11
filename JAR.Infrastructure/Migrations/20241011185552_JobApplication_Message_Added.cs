using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JAR.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class JobApplication_Message_Added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsApproved",
                table: "JobApplications",
                type: "bit",
                nullable: false,
                comment: "Job Application Is Approved",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "JobApplications",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                comment: "Job Application Message");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2656a468-b215-4b17-865d-240a63b0d5cf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "28d3f13c-b799-4e1d-b980-a3b8d3cef370", "AQAAAAIAAYagAAAAEM4ia0NLcpDhkzbAIMblaegsDjugyL6RS6graYBoRbNkMds4Yv6Yk2ZKZWxCIb1kPA==", "5b5c00b3-1c24-4940-8cba-35559b78cdcc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71811921-1918-4043-90b9-20f2522f315b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e207c46d-2bb1-4828-a7d2-11762c79a9bb", "AQAAAAIAAYagAAAAECJ9+fa7y9C5InCLe6L147AL7yL5zXKyZjcBtSm0YJqcA/cpTFfwmupYCYLdU7af8w==", "b2530d50-9f70-41ab-bbcb-33acc031f584" });

            migrationBuilder.UpdateData(
                table: "JobApplications",
                keyColumns: new[] { "JobOfferId", "UserId" },
                keyValues: new object[] { 1, "2656a468-b215-4b17-865d-240a63b0d5cf" },
                columns: new[] { "AppliedOn", "Message" },
                values: new object[] { new DateTime(2024, 10, 11, 18, 55, 51, 821, DateTimeKind.Utc).AddTicks(3475), "" });

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 11, 18, 55, 51, 697, DateTimeKind.Utc).AddTicks(5978));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 11, 18, 55, 51, 697, DateTimeKind.Utc).AddTicks(5984));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 11, 18, 55, 51, 697, DateTimeKind.Utc).AddTicks(5989));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Message",
                table: "JobApplications");

            migrationBuilder.AlterColumn<bool>(
                name: "IsApproved",
                table: "JobApplications",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "Job Application Is Approved");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2656a468-b215-4b17-865d-240a63b0d5cf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "365a688e-3c5d-4c6e-a22c-554606568392", "AQAAAAIAAYagAAAAEGDiBgIlsc5haPqjtb0UuJOFrd1NoWlRG0HLx/3/ANB9Fw84MuvU9pO+mBg27moOxw==", "72447b01-6e27-4daa-95bb-85eb188c0efe" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71811921-1918-4043-90b9-20f2522f315b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "075962c6-559e-4b9c-93ef-4fc522f8c765", "AQAAAAIAAYagAAAAEAyv+auulUWjdpleTu82DT3uNMWlrbwnYojpTlAOseuyep7kg8CdWfqDbVEW6Zzqrg==", "dd6bb18d-f335-49d7-99ae-e241a4e161d2" });

            migrationBuilder.UpdateData(
                table: "JobApplications",
                keyColumns: new[] { "JobOfferId", "UserId" },
                keyValues: new object[] { 1, "2656a468-b215-4b17-865d-240a63b0d5cf" },
                column: "AppliedOn",
                value: new DateTime(2024, 10, 9, 19, 18, 9, 832, DateTimeKind.Utc).AddTicks(431));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 9, 19, 18, 9, 748, DateTimeKind.Utc).AddTicks(990));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 9, 19, 18, 9, 748, DateTimeKind.Utc).AddTicks(994));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 9, 19, 18, 9, 748, DateTimeKind.Utc).AddTicks(997));
        }
    }
}
