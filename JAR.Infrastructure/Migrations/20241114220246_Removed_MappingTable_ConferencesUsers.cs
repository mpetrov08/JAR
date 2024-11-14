using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JAR.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Removed_MappingTable_ConferencesUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConferencesUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2656a468-b215-4b17-865d-240a63b0d5cf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9471739b-29c7-4b38-978f-94c2b5e95f1b", "AQAAAAIAAYagAAAAEMESFbQLljMD0eLVrO8k+s0ZopsVKYWtdliLI7VeWo6BGluPNL2Z+JQ6BzhKleGGYQ==", "0a6ee3c3-38d8-4515-bc8f-ee9174e85509" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71811921-1918-4043-90b9-20f2522f315b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8acafe62-01b1-4fd8-9e9e-e036d8c61cdd", "AQAAAAIAAYagAAAAEGsDESE7ZFqWY9aplmKeeGivBXVfVyr8INYESAbLSPlLtj56PQJbY71K3E+atbw3KA==", "6fb2490c-636f-4301-9cec-9a005dfc2ad6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80277b99-4cab-4ff1-8084-6d0a5df3e787",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dc0aa38d-a4d2-494d-ad59-f5e4cbaa587a", "AQAAAAIAAYagAAAAEGhaaKLx7mhwnS04tHbMG87Kd9dRE/i/NpPzvahEda7VOboMxijmqIVwnWvF8gKtHw==", "d3f8f51f-2d61-4e57-8a5f-4469f1c55f80" });

            migrationBuilder.UpdateData(
                table: "JobApplications",
                keyColumns: new[] { "JobOfferId", "UserId" },
                keyValues: new object[] { 1, "2656a468-b215-4b17-865d-240a63b0d5cf" },
                column: "AppliedOn",
                value: new DateTime(2024, 11, 14, 22, 2, 45, 783, DateTimeKind.Utc).AddTicks(7837));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 11, 14, 22, 2, 45, 659, DateTimeKind.Utc).AddTicks(3730));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 11, 14, 22, 2, 45, 659, DateTimeKind.Utc).AddTicks(3739));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 11, 14, 22, 2, 45, 659, DateTimeKind.Utc).AddTicks(3742));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConferencesUsers",
                columns: table => new
                {
                    ConferenceId = table.Column<int>(type: "int", nullable: false, comment: "Foreign key of conference"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Foreign key of user"),
                    ConferenceId1 = table.Column<int>(type: "int", nullable: true),
                    UserId1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConferencesUsers", x => new { x.ConferenceId, x.UserId });
                    table.ForeignKey(
                        name: "FK_ConferencesUsers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ConferencesUsers_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ConferencesUsers_Conferences_ConferenceId",
                        column: x => x.ConferenceId,
                        principalTable: "Conferences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ConferencesUsers_Conferences_ConferenceId1",
                        column: x => x.ConferenceId1,
                        principalTable: "Conferences",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2656a468-b215-4b17-865d-240a63b0d5cf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c9fc1189-f750-4f93-8a26-d10750464677", "AQAAAAIAAYagAAAAEL3OEkhyQMwX1majQpjuMh9fXVof+WRfa0v2sqNhMg4H30ySY9V1Y/fmtfNr8+ZWKQ==", "30bbc996-1054-4018-a137-3458c3523d02" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71811921-1918-4043-90b9-20f2522f315b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7d561d5e-f84d-40bf-8984-8a8cb0d16254", "AQAAAAIAAYagAAAAEB8IgbabQTuS2CkqINVg7EB/ijWKR3DmEvJ6onbLtWWrXI/V+4sR6e+TgYoH1itW6A==", "d1622d8d-e40b-4843-8863-09dba8b3d768" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80277b99-4cab-4ff1-8084-6d0a5df3e787",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0f6fcbf4-7c0d-4b4c-93b3-6313da1f1eb3", "AQAAAAIAAYagAAAAEBWt65NTvs+5IKh/92FjDlA7sYMI//Zf5heYUByehHwnzx5Voe7B7rcmLz1S5hJ7JA==", "dc137985-cdfb-4324-8c15-13a80e3b5dac" });

            migrationBuilder.UpdateData(
                table: "JobApplications",
                keyColumns: new[] { "JobOfferId", "UserId" },
                keyValues: new object[] { 1, "2656a468-b215-4b17-865d-240a63b0d5cf" },
                column: "AppliedOn",
                value: new DateTime(2024, 11, 14, 21, 59, 30, 948, DateTimeKind.Utc).AddTicks(498));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 11, 14, 21, 59, 30, 824, DateTimeKind.Utc).AddTicks(2190));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 11, 14, 21, 59, 30, 824, DateTimeKind.Utc).AddTicks(2196));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 11, 14, 21, 59, 30, 824, DateTimeKind.Utc).AddTicks(2199));

            migrationBuilder.CreateIndex(
                name: "IX_ConferencesUsers_ConferenceId1",
                table: "ConferencesUsers",
                column: "ConferenceId1");

            migrationBuilder.CreateIndex(
                name: "IX_ConferencesUsers_UserId",
                table: "ConferencesUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ConferencesUsers_UserId1",
                table: "ConferencesUsers",
                column: "UserId1");
        }
    }
}
