using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JAR.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Seeded_CV_Releated_Data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2656a468-b215-4b17-865d-240a63b0d5cf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4d9b4a16-f0e1-424d-849f-84998cb45ff0", "AQAAAAIAAYagAAAAEJhD17Up9jvUWNx4uW2D02pY817ZFFydsWPkT3jThCae9LaQgZ3bmiI5ilrEHMEIsg==", "2c46264e-a9c9-4afc-951c-033bc108c5df" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71811921-1918-4043-90b9-20f2522f315b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fb35278d-cc6e-4cb1-bef9-536a89d3325f", "AQAAAAIAAYagAAAAEHfPeZ5ZyoFvUVLcpAGUdWA00YTVxaBNt+C2+sE4Zhyx9DwhCs5Tvj/gzctJgE6B0A==", "ef835d41-5c81-4a08-9d00-62c88c871a7b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80277b99-4cab-4ff1-8084-6d0a5df3e787",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "429a93cd-b1f1-4f80-82b8-3973779421c6", "AQAAAAIAAYagAAAAELSGm29LAwG2mR5kUJ6pmpeo2uDMFwfVwsOUT7Q0Sq94xPleNHy/pI8b8gw89bZeIQ==", "3687a642-16ae-4e2b-ab57-f78c95088f02" });

            migrationBuilder.InsertData(
                table: "CVs",
                columns: new[] { "Id", "Address", "BirthDate", "Citizenship", "DrivingLicenseCategory", "Email", "FirstName", "Gender", "IsDeleted", "Languages", "LastName", "LinkedInProfile", "PhoneNumber", "Photo", "Skills", "UserId" },
                values: new object[] { 1, "Somewhere in Bulgaria, Europe", new DateTime(2008, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bulgarian", "A", "mihailnanpetrov@gmai.com", "Mihail", "Male", false, "Bulgarian C2, German B1, English B1", "Petrov", "https://www.linkedin.com/mihail", "0888888888", "https://cdn-icons-png.flaticon.com/512/149/149071.png", "Math, Programming, History, Table Tennis, Football", "2656a468-b215-4b17-865d-240a63b0d5cf" });

            migrationBuilder.UpdateData(
                table: "Conferences",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "End", "Start" },
                values: new object[] { new DateTime(2024, 12, 9, 23, 52, 18, 805, DateTimeKind.Utc).AddTicks(3320), new DateTime(2024, 12, 9, 21, 52, 18, 805, DateTimeKind.Utc).AddTicks(3320) });

            migrationBuilder.UpdateData(
                table: "JobApplications",
                keyColumns: new[] { "JobOfferId", "UserId" },
                keyValues: new object[] { 1, "2656a468-b215-4b17-865d-240a63b0d5cf" },
                column: "AppliedOn",
                value: new DateTime(2024, 12, 9, 21, 52, 18, 280, DateTimeKind.Utc).AddTicks(501));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 9, 21, 52, 18, 152, DateTimeKind.Utc).AddTicks(6881));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 9, 21, 52, 18, 152, DateTimeKind.Utc).AddTicks(6886));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 9, 21, 52, 18, 152, DateTimeKind.Utc).AddTicks(6889));

            migrationBuilder.InsertData(
                table: "Degrees",
                columns: new[] { "Id", "CVId", "City", "Description", "EducationLevel", "EducationalInstitution", "EndDate", "IsDeleted", "Major", "StartDate" },
                values: new object[] { 1, 1, "secondary", "I learned a lot of here", "secondary", "PPMG \"Dobri Chintulov\"", new DateTime(2027, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Math and Informatik", new DateTime(2019, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "ProfessionalExperiences",
                columns: new[] { "Id", "CVId", "City", "CompanyName", "Description", "EndDate", "IsDeleted", "StartDate" },
                values: new object[] { 1, 1, "Sofia", "Softuni", "Ï worked a lot of there", new DateTime(2050, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2025, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Degrees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProfessionalExperiences",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CVs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2656a468-b215-4b17-865d-240a63b0d5cf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a829c359-c72d-4421-84f0-a6b9788d8e87", "AQAAAAIAAYagAAAAEJ+BACi8mLKUPbhBx53ndesJuhd7madFLW9HsV3z0wlixhaIBFTjp/ZUm/U1Q+I5tA==", "a9538c47-5690-40d6-a58b-f6badc806514" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71811921-1918-4043-90b9-20f2522f315b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "edbb56e7-8e2d-4bdc-bf1a-14c0afcd0a39", "AQAAAAIAAYagAAAAEO6h0fNzdS5wqV2eYzsUxlKkpFhv6jxCd1r2dRYCQrhqsZkbjT9sGn1/Z7xrUe4cgw==", "eb8c87d3-3a09-4a75-93c8-2fd7e0793b04" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80277b99-4cab-4ff1-8084-6d0a5df3e787",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f06118d6-6234-462c-8b2a-652baf8d13fb", "AQAAAAIAAYagAAAAEJTGA8BX4uPnRCyRLd2zkUBeKqTE0+w6L32VYs+xXal+HIuZREhrjsXW9Qbg1L9T5g==", "6a615bd3-c83e-4f7d-bd22-e8f3d2694fa6" });

            migrationBuilder.UpdateData(
                table: "Conferences",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "End", "Start" },
                values: new object[] { new DateTime(2024, 12, 4, 23, 30, 45, 377, DateTimeKind.Utc).AddTicks(2212), new DateTime(2024, 12, 4, 21, 30, 45, 377, DateTimeKind.Utc).AddTicks(2088) });

            migrationBuilder.UpdateData(
                table: "JobApplications",
                keyColumns: new[] { "JobOfferId", "UserId" },
                keyValues: new object[] { 1, "2656a468-b215-4b17-865d-240a63b0d5cf" },
                column: "AppliedOn",
                value: new DateTime(2024, 12, 4, 21, 30, 44, 673, DateTimeKind.Utc).AddTicks(4504));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 4, 21, 30, 44, 506, DateTimeKind.Utc).AddTicks(7425));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 4, 21, 30, 44, 506, DateTimeKind.Utc).AddTicks(7432));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 4, 21, 30, 44, 506, DateTimeKind.Utc).AddTicks(7436));
        }
    }
}
