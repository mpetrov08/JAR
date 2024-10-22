using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JAR.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Added_Navigation_Properties_To_CV : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2656a468-b215-4b17-865d-240a63b0d5cf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "03d9de35-f134-415f-aede-4ebad5150f2d", "AQAAAAIAAYagAAAAEDV6HA8fiZtdE9JnZ989gOt/sXWym5IbxgA8EbXdCykXGIjROnuxKscIeparBGbJnQ==", "68d49c33-93f3-4044-a31a-ce36dd79c8db" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71811921-1918-4043-90b9-20f2522f315b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8f08ffd2-9584-4863-9b03-98f0472db955", "AQAAAAIAAYagAAAAEKf7YW4a49oYBotHLETUyH/yL+z0F040WpAvcMoybPmKNlrfgwLOm1H4ItC8ELraIg==", "81ed357e-5218-44fe-ab3b-3b69b32bebd8" });

            migrationBuilder.UpdateData(
                table: "JobApplications",
                keyColumns: new[] { "JobOfferId", "UserId" },
                keyValues: new object[] { 1, "2656a468-b215-4b17-865d-240a63b0d5cf" },
                column: "AppliedOn",
                value: new DateTime(2024, 10, 22, 16, 50, 47, 108, DateTimeKind.Utc).AddTicks(8807));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 22, 16, 50, 47, 24, DateTimeKind.Utc).AddTicks(9853));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 22, 16, 50, 47, 24, DateTimeKind.Utc).AddTicks(9858));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 22, 16, 50, 47, 24, DateTimeKind.Utc).AddTicks(9861));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2656a468-b215-4b17-865d-240a63b0d5cf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f012b48b-a6de-4ea5-8583-a1539b7629fd", "AQAAAAIAAYagAAAAEHicT5V4OibZ3S9O/gwO09/bgR3FImaWSBXilU9xRr+KAlTIU7wXfVZ0KbAn7jrN3g==", "512490e1-6daa-4eb7-a23e-63648faddc9c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71811921-1918-4043-90b9-20f2522f315b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6ccf20ff-cb1d-4d67-bfbb-b7da0aba9e5d", "AQAAAAIAAYagAAAAEOOo4q3eOntWw9lwCBx3zhRTVN35u3Z4KSXq/4dc5n95w0iKANwn9TDFVPNB4gLXYg==", "521f3806-89d4-44eb-944b-5fb6d5144ea1" });

            migrationBuilder.UpdateData(
                table: "JobApplications",
                keyColumns: new[] { "JobOfferId", "UserId" },
                keyValues: new object[] { 1, "2656a468-b215-4b17-865d-240a63b0d5cf" },
                column: "AppliedOn",
                value: new DateTime(2024, 10, 21, 19, 31, 59, 645, DateTimeKind.Utc).AddTicks(6992));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 21, 19, 31, 59, 562, DateTimeKind.Utc).AddTicks(2855));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 21, 19, 31, 59, 562, DateTimeKind.Utc).AddTicks(2859));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 21, 19, 31, 59, 562, DateTimeKind.Utc).AddTicks(2862));
        }
    }
}
