using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JAR.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Added_Custom_User : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CVId",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                comment: "Foreign key of CV. It is not required");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "User First Name");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "User Last Name");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2656a468-b215-4b17-865d-240a63b0d5cf",
                columns: new[] { "CVId", "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { null, "549b993d-5dac-4d05-9cd2-361bba586fa6", "Guest", "Guestov", "AQAAAAIAAYagAAAAEGkX4owv50WJaXbd+6snCOynVDLgKjF8pFJNOgZSVfZa3I04731v+CeY2nNBw9Bfpw==", "e813116f-f329-44ca-bed1-06c989feefdb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71811921-1918-4043-90b9-20f2522f315b",
                columns: new[] { "CVId", "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { null, "a0103033-b63f-4d2a-b75f-8399147e6db7", "Owner", "Ownerov", "AQAAAAIAAYagAAAAENRuv1/mVSd9y8hah0arzJJDzCI98wuWHiH+rZBO0TqdPN5HA8Mtp/pCt082C33jFA==", "2d5ea249-e373-432b-8d68-58925ea9f467" });

            migrationBuilder.UpdateData(
                table: "JobApplications",
                keyColumns: new[] { "JobOfferId", "UserId" },
                keyValues: new object[] { 1, "2656a468-b215-4b17-865d-240a63b0d5cf" },
                column: "AppliedOn",
                value: new DateTime(2024, 10, 22, 17, 15, 27, 167, DateTimeKind.Utc).AddTicks(9386));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 22, 17, 15, 27, 83, DateTimeKind.Utc).AddTicks(3470));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 22, 17, 15, 27, 83, DateTimeKind.Utc).AddTicks(3475));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 22, 17, 15, 27, 83, DateTimeKind.Utc).AddTicks(3478));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

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
    }
}
