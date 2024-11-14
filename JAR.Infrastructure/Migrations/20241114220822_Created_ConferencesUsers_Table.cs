using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JAR.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Created_ConferencesUsers_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConferencesUsers",
                columns: table => new
                {
                    ConferenceId = table.Column<int>(type: "int", nullable: false, comment: "Foreign key of conference"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Foreign key of user")
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
                        name: "FK_ConferencesUsers_Conferences_ConferenceId",
                        column: x => x.ConferenceId,
                        principalTable: "Conferences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2656a468-b215-4b17-865d-240a63b0d5cf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bc31a7b3-a02d-47cb-9ce2-3e2e4d867a74", "AQAAAAIAAYagAAAAEBFU2VecuTXn69JhJZpuTj5ddRmvtSZnbB1BzwcKUXhBEmmjNab9LAO8cEAo+/fXIg==", "d680012d-bffc-494b-8bd2-af704656e1b2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71811921-1918-4043-90b9-20f2522f315b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "01888808-98f2-4fc9-a448-e9bf189a33d5", "AQAAAAIAAYagAAAAEJZLkowip75Wrk8FGGob4HjoKxsq2cpLYaHEUk+4cpJLuFFkKiuJqGa8ig0sjAtY6w==", "69df5f9f-a040-4b17-8782-3fe0988cc2ae" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80277b99-4cab-4ff1-8084-6d0a5df3e787",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3b0df9c6-6be8-433a-8c45-7c5c5d9fafce", "AQAAAAIAAYagAAAAEJ0zlcnH1o9zR/CPEYxt+6cQZmSHuXulerjKqR9szlIvV0/IuLXCwlD5ivQLUSua4g==", "7216862c-31fd-4461-9b8d-124ea745b703" });

            migrationBuilder.UpdateData(
                table: "JobApplications",
                keyColumns: new[] { "JobOfferId", "UserId" },
                keyValues: new object[] { 1, "2656a468-b215-4b17-865d-240a63b0d5cf" },
                column: "AppliedOn",
                value: new DateTime(2024, 11, 14, 22, 8, 22, 298, DateTimeKind.Utc).AddTicks(1783));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 11, 14, 22, 8, 22, 173, DateTimeKind.Utc).AddTicks(9001));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 11, 14, 22, 8, 22, 173, DateTimeKind.Utc).AddTicks(9006));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 11, 14, 22, 8, 22, 173, DateTimeKind.Utc).AddTicks(9009));

            migrationBuilder.CreateIndex(
                name: "IX_ConferencesUsers_UserId",
                table: "ConferencesUsers",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
