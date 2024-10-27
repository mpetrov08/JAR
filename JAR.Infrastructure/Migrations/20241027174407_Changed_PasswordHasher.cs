using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JAR.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Changed_PasswordHasher : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2656a468-b215-4b17-865d-240a63b0d5cf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9f2e1f49-0ed8-47bd-9d11-3436fce49d66", "AQAAAAIAAYagAAAAEAR7RuGTU51uVavGsBq/itkHf4ahVnOB+ztiQEpA9u+X4DBXqbkr5tAGeN/QoMKVWg==", "aac39600-de8a-43e5-aa04-14b9fb0a2720" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71811921-1918-4043-90b9-20f2522f315b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b2fa3891-ae74-4e0b-b9b9-9e0855f74c96", "AQAAAAIAAYagAAAAECDgb1iuW6qDD/Wp7qL8LEIQ5Ud2+WeZcr6hL8L/DE8p2OO6KgGesZ1wG58ZqPQVNQ==", "3929ad72-c025-4312-80f4-5e71b2f75006" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80277b99-4cab-4ff1-8084-6d0a5df3e787",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "50283cda-aeee-4576-964f-671f0fa02b53", "AQAAAAIAAYagAAAAEN1mXZB7+pYosYJs2iT0G+CnoPklMFN6ytBsRkACB57cIbiSo5leJ7KJD1ujiwH4/g==", "b70da1f5-1fae-4bc9-8213-6fdba57e1447" });

            migrationBuilder.UpdateData(
                table: "JobApplications",
                keyColumns: new[] { "JobOfferId", "UserId" },
                keyValues: new object[] { 1, "2656a468-b215-4b17-865d-240a63b0d5cf" },
                column: "AppliedOn",
                value: new DateTime(2024, 10, 27, 17, 44, 6, 666, DateTimeKind.Utc).AddTicks(8492));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 27, 17, 44, 6, 543, DateTimeKind.Utc).AddTicks(7513));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 27, 17, 44, 6, 543, DateTimeKind.Utc).AddTicks(7518));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 27, 17, 44, 6, 543, DateTimeKind.Utc).AddTicks(7520));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2656a468-b215-4b17-865d-240a63b0d5cf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ad260237-6149-47a4-87dd-2b656fd13df5", "AQAAAAIAAYagAAAAEEOIn55Nf7c26TJKFUzCTG21vTzaXvjECwS0mz3W1f+6/5WAD2d2TPOm/m3Rte/WRQ==", "99587668-8297-4f37-bb5e-183459bdadb8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71811921-1918-4043-90b9-20f2522f315b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b5ca7d66-8144-48b6-b8b2-02df53e52df6", "AQAAAAIAAYagAAAAEEmUyd03by/LdP9bxaCE5kMvELpmxAu79M0RnM94q8MG02CRQ/Vb/WYd/L2f3//Sbg==", "ef08b790-2da7-40b9-8496-38464a36b834" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80277b99-4cab-4ff1-8084-6d0a5df3e787",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "03f0ec58-a12d-4d93-baf4-868828cbcde3", "AQAAAAIAAYagAAAAEC6vSogwLu4gtjh9CLJWoHY85c5a4+adPX6qoYgUg9Woz2AHiN8JmyWrwCjRjymw0w==", "250fba9f-0bd9-4c1e-8c53-dc0becdc47b2" });

            migrationBuilder.UpdateData(
                table: "JobApplications",
                keyColumns: new[] { "JobOfferId", "UserId" },
                keyValues: new object[] { 1, "2656a468-b215-4b17-865d-240a63b0d5cf" },
                column: "AppliedOn",
                value: new DateTime(2024, 10, 27, 17, 1, 0, 369, DateTimeKind.Utc).AddTicks(5228));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 27, 17, 1, 0, 232, DateTimeKind.Utc).AddTicks(1201));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 27, 17, 1, 0, 232, DateTimeKind.Utc).AddTicks(1206));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 27, 17, 1, 0, 232, DateTimeKind.Utc).AddTicks(1208));
        }
    }
}
