using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JAR.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Category Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Category Name")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                },
                comment: "Category");

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Company Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Company Name"),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "Company Address"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false, comment: "Company PhoneNumber"),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "Company Email"),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false, comment: "Company Description"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Checks if the Company has been deleted"),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Company Owner Identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Companies_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Company");

            migrationBuilder.CreateTable(
                name: "JobTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Job Type Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Job Type Name")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTypes", x => x.Id);
                },
                comment: "Job Type");

            migrationBuilder.CreateTable(
                name: "JobOffers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Job Offer Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false, comment: "Job Offer Title"),
                    Description = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false, comment: "Job Offer Description"),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "Job Offer Address"),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Job Offer Salary"),
                    RequiredLanguage = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false, comment: "Job Offer Required Language"),
                    RequiredDegree = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false, comment: "Job Offer Required Degree"),
                    RequiredExperience = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false, comment: "Job Offer Required Experience"),
                    RequiredSkills = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false, comment: "Job Offer Required Skills"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "When Job Offer was created"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Checks if the Job Offer has been deleted"),
                    CategoryId = table.Column<int>(type: "int", nullable: false, comment: "Job Offer Category Identifier"),
                    JobTypeId = table.Column<int>(type: "int", nullable: false, comment: "Job Offer Type Identifier"),
                    CompanyId = table.Column<int>(type: "int", nullable: false, comment: "Job Offer Company Identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobOffers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobOffers_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobOffers_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobOffers_JobTypes_JobTypeId",
                        column: x => x.JobTypeId,
                        principalTable: "JobTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Job Offer");

            migrationBuilder.CreateTable(
                name: "JobApplications",
                columns: table => new
                {
                    JobOfferId = table.Column<int>(type: "int", nullable: false, comment: "Job Offer Identifier"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "User Identifier"),
                    AppliedOn = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "When Job Application has been applied")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobApplications", x => new { x.JobOfferId, x.UserId });
                    table.ForeignKey(
                        name: "FK_JobApplications_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JobApplications_JobOffers_JobOfferId",
                        column: x => x.JobOfferId,
                        principalTable: "JobOffers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Job Applications");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_OwnerId",
                table: "Companies",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_JobApplications_UserId",
                table: "JobApplications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_JobOffers_CategoryId",
                table: "JobOffers",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_JobOffers_CompanyId",
                table: "JobOffers",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_JobOffers_JobTypeId",
                table: "JobOffers",
                column: "JobTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobApplications");

            migrationBuilder.DropTable(
                name: "JobOffers");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "JobTypes");
        }
    }
}
