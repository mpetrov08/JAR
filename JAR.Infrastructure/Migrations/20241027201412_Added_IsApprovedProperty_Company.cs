using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JAR.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Added_IsApprovedProperty_Company : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Companies",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Checks if the Company has been approved");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2656a468-b215-4b17-865d-240a63b0d5cf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d10791ec-2888-4858-8d91-0decd64049f1", "AQAAAAIAAYagAAAAEBqyCz9b6lKzh6Uybgalk0LB8nhVCuCfi0f6w3wfKcU9+A00h2HEjYZnMcnHNR1KdQ==", "e34435b2-a829-4e5c-ab6e-ba701a25eb77" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71811921-1918-4043-90b9-20f2522f315b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e3c599b9-d083-47dc-ae0b-4c8cfe795d6b", "AQAAAAIAAYagAAAAEFjNvzvDf7X7wOaMpMtz7c4UtVIgKUme+jRmabhkcdXKUzl9hH6MB6hpwNOCLV0d9g==", "f33e062a-ed35-4e91-a783-f02cc9d8217d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80277b99-4cab-4ff1-8084-6d0a5df3e787",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "43a0d9c1-1ff3-4f06-9f6d-8804a565f532", "AQAAAAIAAYagAAAAEG71b05pYxC1hcpcQ409q92BRgRq4XeB/Qu3F9LxAC3AH8DNpb0EAfLOWktLZmWDvQ==", "36789534-3b66-4794-841e-87e2f5f422f1" });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsApproved",
                value: true);

            migrationBuilder.UpdateData(
                table: "JobApplications",
                keyColumns: new[] { "JobOfferId", "UserId" },
                keyValues: new object[] { 1, "2656a468-b215-4b17-865d-240a63b0d5cf" },
                column: "AppliedOn",
                value: new DateTime(2024, 10, 27, 20, 14, 11, 872, DateTimeKind.Utc).AddTicks(4624));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 27, 20, 14, 11, 743, DateTimeKind.Utc).AddTicks(5667));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 27, 20, 14, 11, 743, DateTimeKind.Utc).AddTicks(5675));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 27, 20, 14, 11, 743, DateTimeKind.Utc).AddTicks(5677));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Companies");

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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f5d83e62-2ad7-4de1-9d34-92061e4054c9", "AQAAAAIAAYagAAAAEIs5gu9ch2T17pnExenPJtBPUJovsuBagAfBTNqhzXQ6HFG5Y7OFGvQWioQ4lcwZqg==", "4093c206-cd6c-4cf6-b2bf-ecc0760b5355" });

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
    }
}
