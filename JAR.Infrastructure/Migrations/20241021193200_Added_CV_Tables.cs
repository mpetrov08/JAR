using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JAR.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Added_CV_Tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CVs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "CV Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Foreign key of User"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "First Name"),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Last Name"),
                    LinkedInProfile = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false, comment: "LinkedIn Profile Link"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false, comment: "Users Phone Number"),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "Users Address"),
                    Gender = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Users Gender"),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Birthday Date of the user"),
                    Citizenship = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Citizenship of the user"),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Photo of the user"),
                    Languages = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "All languages and their levels that user knows"),
                    Skills = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false, comment: "Skills that user has"),
                    DrivingLicenseCategory = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true, comment: "Driving License Category that user has")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CVs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CVs_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Degrees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Degree Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EducationalInstitution = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "Educational Institution where the user studied"),
                    Major = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Major that the user have studied"),
                    EducationLevel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Education Level Degree"),
                    City = table.Column<string>(type: "nvarchar(85)", maxLength: 85, nullable: false, comment: "City where the user learned"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "The degree start date"),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "The degree end date"),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false, comment: "The description of degree"),
                    CVId = table.Column<int>(type: "int", nullable: false, comment: "Foreign key of CV")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Degrees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Degrees_CVs_CVId",
                        column: x => x.CVId,
                        principalTable: "CVs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProfessionalExperiences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Professional Experience Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Name of the company where the user worked"),
                    City = table.Column<string>(type: "nvarchar(85)", maxLength: 85, nullable: false, comment: "The city where the user worked"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "The date the user started working"),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "The date the user ended working"),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false, comment: "Description of professional experience"),
                    CVId = table.Column<int>(type: "int", nullable: false, comment: "CV Foreign Key")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessionalExperiences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfessionalExperiences_CVs_CVId",
                        column: x => x.CVId,
                        principalTable: "CVs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_CVs_UserId",
                table: "CVs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Degrees_CVId",
                table: "Degrees",
                column: "CVId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessionalExperiences_CVId",
                table: "ProfessionalExperiences",
                column: "CVId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Degrees");

            migrationBuilder.DropTable(
                name: "ProfessionalExperiences");

            migrationBuilder.DropTable(
                name: "CVs");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2656a468-b215-4b17-865d-240a63b0d5cf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "28d3f13c-b799-4e1d-b980-a3b8d3cef370", "AQAAAAIAAYagAAAAEM4ia0NLcpDhkzbAIMblaegsDjugyL6RS6graYBoRbNkMds4Yv6Yk2ZKZWxCIb1kPA==", "5b5c00b3-1c24-4940-8cba-35559b78cdcc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71811921-1918-4043-90b9-20f2522f315b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e207c46d-2bb1-4828-a7d2-11762c79a9bb", "AQAAAAIAAYagAAAAECJ9+fa7y9C5InCLe6L147AL7yL5zXKyZjcBtSm0YJqcA/cpTFfwmupYCYLdU7af8w==", "b2530d50-9f70-41ab-bbcb-33acc031f584" });

            migrationBuilder.UpdateData(
                table: "JobApplications",
                keyColumns: new[] { "JobOfferId", "UserId" },
                keyValues: new object[] { 1, "2656a468-b215-4b17-865d-240a63b0d5cf" },
                column: "AppliedOn",
                value: new DateTime(2024, 10, 11, 18, 55, 51, 821, DateTimeKind.Utc).AddTicks(3475));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 11, 18, 55, 51, 697, DateTimeKind.Utc).AddTicks(5978));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 11, 18, 55, 51, 697, DateTimeKind.Utc).AddTicks(5984));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 11, 18, 55, 51, 697, DateTimeKind.Utc).AddTicks(5989));
        }
    }
}
