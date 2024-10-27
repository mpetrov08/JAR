using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JAR.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Updated_AdminUserName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2656a468-b215-4b17-865d-240a63b0d5cf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3017abe5-a49e-44d2-92ba-59b0c154ad50", "AQAAAAIAAYagAAAAEP5txw9RKojzZnb2/VcuMUDy7XcglkSDcmB2pzQvLb6+AzxMoYjr1LpDMHd7t5PSag==", "f2b87d61-ca80-45d9-82f5-8f916fe85fab" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71811921-1918-4043-90b9-20f2522f315b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "82372580-42ac-4599-92b0-ccf2815998af", "AQAAAAIAAYagAAAAEDpqITxXEdrzlcRLjD5k+RzFmsMIXelCU+BaSCBJGMlTb3vq9QLwkUfanq+2d4M1Sg==", "56676f21-f42d-48b2-9c16-8baf1f1f37e5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80277b99-4cab-4ff1-8084-6d0a5df3e787",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "f5d83e62-2ad7-4de1-9d34-92061e4054c9", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEIs5gu9ch2T17pnExenPJtBPUJovsuBagAfBTNqhzXQ6HFG5Y7OFGvQWioQ4lcwZqg==", "4093c206-cd6c-4cf6-b2bf-ecc0760b5355", "admin@gmail.com" });

            migrationBuilder.UpdateData(
                table: "JobApplications",
                keyColumns: new[] { "JobOfferId", "UserId" },
                keyValues: new object[] { 1, "2656a468-b215-4b17-865d-240a63b0d5cf" },
                column: "AppliedOn",
                value: new DateTime(2024, 10, 27, 17, 54, 39, 893, DateTimeKind.Utc).AddTicks(5023));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 27, 17, 54, 39, 770, DateTimeKind.Utc).AddTicks(7925));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 27, 17, 54, 39, 770, DateTimeKind.Utc).AddTicks(7933));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 27, 17, 54, 39, 770, DateTimeKind.Utc).AddTicks(7936));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "50283cda-aeee-4576-964f-671f0fa02b53", "ADMINISTRATOR", "AQAAAAIAAYagAAAAEN1mXZB7+pYosYJs2iT0G+CnoPklMFN6ytBsRkACB57cIbiSo5leJ7KJD1ujiwH4/g==", "b70da1f5-1fae-4bc9-8213-6fdba57e1447", "Administrator" });

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
    }
}
