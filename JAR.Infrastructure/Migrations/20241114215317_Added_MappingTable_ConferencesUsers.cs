using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JAR.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Added_MappingTable_ConferencesUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_CVs_CVId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CVId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CVId",
                table: "AspNetUsers");

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
                values: new object[] { "10c900b1-f7e5-4b7a-9916-f00f5e288a23", "AQAAAAIAAYagAAAAEGzhw3pt95nCwfDN/jljyocYOaZkLxwZwAAMWZb1/fPG+0bWeD4j0OpFLu5IB8sNRg==", "56ba7802-8139-46ca-a703-199400712f1d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71811921-1918-4043-90b9-20f2522f315b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "07515587-ff78-49b0-9eab-6f479433e5cf", "AQAAAAIAAYagAAAAEJ6cDNL+3jERsaG/EfuBvHqYWCBBc6bIES1CN6UBiPNsLb7x0LfeSVnNiiB4dTTl4w==", "2223af5c-8fbf-44b1-9f94-321e79f9ed8b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80277b99-4cab-4ff1-8084-6d0a5df3e787",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "32b03977-8826-4e99-948f-89f4c7c480d5", "AQAAAAIAAYagAAAAENX6fJrqDwvCVT3cwHxmpvnwnUlTva1Pbi7/L5Eh1AZaa8mOAjwzhGMAVccExL6C8g==", "a162cbae-6745-4746-aaf6-90a6ab6044d7" });

            migrationBuilder.UpdateData(
                table: "JobApplications",
                keyColumns: new[] { "JobOfferId", "UserId" },
                keyValues: new object[] { 1, "2656a468-b215-4b17-865d-240a63b0d5cf" },
                column: "AppliedOn",
                value: new DateTime(2024, 11, 14, 21, 53, 16, 563, DateTimeKind.Utc).AddTicks(985));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 11, 14, 21, 53, 16, 437, DateTimeKind.Utc).AddTicks(9069));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 11, 14, 21, 53, 16, 437, DateTimeKind.Utc).AddTicks(9074));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 11, 14, 21, 53, 16, 437, DateTimeKind.Utc).AddTicks(9160));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConferencesUsers");

            migrationBuilder.AddColumn<int>(
                name: "CVId",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                comment: "Foreign key of CV. It is not required");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2656a468-b215-4b17-865d-240a63b0d5cf",
                columns: new[] { "CVId", "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { null, "074ee41e-8894-450b-9de4-fe4719b4c67e", "AQAAAAIAAYagAAAAEC2q4j1I5P/fWa6RNP0Ffht07mwJBfNOMpWnG0K/TXx2kKMc+WFW59PPBykhRuuX2A==", "1fee48f2-5c74-4505-aff6-31aac7a99b3e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71811921-1918-4043-90b9-20f2522f315b",
                columns: new[] { "CVId", "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { null, "417dd017-70f4-4bb3-b2b8-bc0b235ecd91", "AQAAAAIAAYagAAAAEK4uScm9L2gjz0xFmoCWqeVAPjFD3glHB7nDvAEDjBP5ygUNNfDKm7i9vHF0PF/hiw==", "fcc0af2e-5e4b-4fa7-a84e-e03736176eab" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80277b99-4cab-4ff1-8084-6d0a5df3e787",
                columns: new[] { "CVId", "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { null, "176d717d-0dd0-4b2f-8a49-cfb8bc1e46ab", "AQAAAAIAAYagAAAAEGiufYZZY2sAYG9SL7tySUXgZUUd2pVUsluxntds2fRS6J31TTDK4MS48CR3amQrWg==", "ab8b2f3e-f39b-4073-b76e-756fa40d2ca6" });

            migrationBuilder.UpdateData(
                table: "JobApplications",
                keyColumns: new[] { "JobOfferId", "UserId" },
                keyValues: new object[] { 1, "2656a468-b215-4b17-865d-240a63b0d5cf" },
                column: "AppliedOn",
                value: new DateTime(2024, 11, 13, 21, 25, 14, 424, DateTimeKind.Utc).AddTicks(6370));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 11, 13, 21, 25, 14, 295, DateTimeKind.Utc).AddTicks(3424));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 11, 13, 21, 25, 14, 295, DateTimeKind.Utc).AddTicks(3428));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 11, 13, 21, 25, 14, 295, DateTimeKind.Utc).AddTicks(3431));

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CVId",
                table: "AspNetUsers",
                column: "CVId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_CVs_CVId",
                table: "AspNetUsers",
                column: "CVId",
                principalTable: "CVs",
                principalColumn: "Id");
        }
    }
}
