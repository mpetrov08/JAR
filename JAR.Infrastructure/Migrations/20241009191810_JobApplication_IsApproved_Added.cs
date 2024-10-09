using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JAR.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class JobApplication_IsApproved_Added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "JobApplications",
                type: "bit",
                nullable: false,
                defaultValue: false);

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
                columns: new[] { "AppliedOn", "IsApproved" },
                values: new object[] { new DateTime(2024, 10, 9, 19, 18, 9, 832, DateTimeKind.Utc).AddTicks(431), false });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "JobApplications");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2656a468-b215-4b17-865d-240a63b0d5cf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e27c78df-b5dd-4c93-8542-38ec342fa304", "AQAAAAIAAYagAAAAEIW2lm0HekQVllfTS1XbnZLKiTcVj+/PYMMMgzMdqjoH9UgHeXgS0r1nbll58W0L4Q==", "95160343-982c-431a-8061-2b7da7139be3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71811921-1918-4043-90b9-20f2522f315b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "df68e265-9e33-46b0-96ad-b00012fb957d", "AQAAAAIAAYagAAAAEF1Ops5+09maNkHUDLo7O8LJyoZ+UvCGDM8aL+YkIk3RXHutywfBSU2kuz38JHPGJA==", "a7744c3d-1f8c-4236-8445-ecd6d01fe615" });

            migrationBuilder.UpdateData(
                table: "JobApplications",
                keyColumns: new[] { "JobOfferId", "UserId" },
                keyValues: new object[] { 1, "2656a468-b215-4b17-865d-240a63b0d5cf" },
                column: "AppliedOn",
                value: new DateTime(2024, 10, 8, 18, 37, 33, 79, DateTimeKind.Utc).AddTicks(5105));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 8, 18, 37, 32, 996, DateTimeKind.Utc).AddTicks(6979));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 8, 18, 37, 32, 996, DateTimeKind.Utc).AddTicks(6983));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 8, 18, 37, 32, 996, DateTimeKind.Utc).AddTicks(6985));
        }
    }
}
