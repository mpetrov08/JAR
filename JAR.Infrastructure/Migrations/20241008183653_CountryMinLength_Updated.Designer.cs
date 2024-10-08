﻿// <auto-generated />
using System;
using JAR.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JAR.Infrastructure.Migrations
{
    [DbContext(typeof(JarDbContext))]
    [Migration("20241008183653_CountryMinLength_Updated")]
    partial class CountryMinLength_Updated
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("JAR.Infrastructure.Data.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Category Identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Category Name");

                    b.HasKey("Id");

                    b.ToTable("Categories", t =>
                        {
                            t.HasComment("Category");
                        });

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Software Engineering"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Health Care"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Management"
                        });
                });

            modelBuilder.Entity("JAR.Infrastructure.Data.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Company Identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("Company Address");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasComment("Company Country");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)")
                        .HasComment("Company Description");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("Company Email");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasComment("Checks if the Company has been deleted");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Company Name");

                    b.Property<string>("OwnerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasComment("Company Owner Identifier");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasComment("Company PhoneNumber");

                    b.Property<string>("UIC")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasComment("Company Unique Identification Code");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Companies", t =>
                        {
                            t.HasComment("Company");
                        });

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Redmond, Washington, USA",
                            Country = "",
                            Description = "Microsoft is a global technology company known for software and hardware.",
                            Email = "microsoft@gmail.com",
                            IsDeleted = false,
                            Name = "Microsoft",
                            OwnerId = "71811921-1918-4043-90b9-20f2522f315b",
                            PhoneNumber = "1234567890",
                            UIC = ""
                        });
                });

            modelBuilder.Entity("JAR.Infrastructure.Data.Models.JobApplication", b =>
                {
                    b.Property<int>("JobOfferId")
                        .HasColumnType("int")
                        .HasComment("Job Offer Identifier");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)")
                        .HasComment("User Identifier");

                    b.Property<DateTime>("AppliedOn")
                        .HasColumnType("datetime2")
                        .HasComment("When Job Application has been applied");

                    b.HasKey("JobOfferId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("JobApplications", t =>
                        {
                            t.HasComment("Job Applications");
                        });

                    b.HasData(
                        new
                        {
                            JobOfferId = 1,
                            UserId = "2656a468-b215-4b17-865d-240a63b0d5cf",
                            AppliedOn = new DateTime(2024, 10, 8, 18, 36, 53, 619, DateTimeKind.Utc).AddTicks(6807)
                        });
                });

            modelBuilder.Entity("JAR.Infrastructure.Data.Models.JobOffer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Job Offer Identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("Job Offer Address");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasComment("Job Offer Category Identifier");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int")
                        .HasComment("Job Offer Company Identifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2")
                        .HasComment("When Job Offer was created");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1500)
                        .HasColumnType("nvarchar(1500)")
                        .HasComment("Job Offer Description");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasComment("Checks if the Job Offer has been deleted");

                    b.Property<int>("JobTypeId")
                        .HasColumnType("int")
                        .HasComment("Job Offer Type Identifier");

                    b.Property<string>("RequiredDegree")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasComment("Job Offer Required Degree");

                    b.Property<string>("RequiredExperience")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasComment("Job Offer Required Experience");

                    b.Property<string>("RequiredLanguage")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasComment("Job Offer Required Language");

                    b.Property<string>("RequiredSkills")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasComment("Job Offer Required Skills");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18,2)")
                        .HasComment("Job Offer Salary");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasComment("Job Offer Title");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("JobTypeId");

                    b.ToTable("JobOffers", t =>
                        {
                            t.HasComment("Job Offer");
                        });

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Redmond, Washington, USA",
                            CategoryId = 1,
                            CompanyId = 1,
                            CreatedOn = new DateTime(2024, 10, 8, 18, 36, 53, 534, DateTimeKind.Utc).AddTicks(5327),
                            Description = "A C# junior programmer should know OOP, Design Patterns, .NET, debugging and SQL.",
                            IsDeleted = false,
                            JobTypeId = 1,
                            RequiredDegree = "Higher Education",
                            RequiredExperience = "",
                            RequiredLanguage = "English C2",
                            RequiredSkills = "OOP, SQL, .NET, Design Patterns, Data Structures and Algorithms",
                            Salary = 2000m,
                            Title = "Junior C# Programmer"
                        },
                        new
                        {
                            Id = 2,
                            Address = "Reading, Thames Valley Park, UK",
                            CategoryId = 1,
                            CompanyId = 1,
                            CreatedOn = new DateTime(2024, 10, 8, 18, 36, 53, 534, DateTimeKind.Utc).AddTicks(5333),
                            Description = "C# Senior Developer must have excellent knowledge of .NET, architecture, code optimization.",
                            IsDeleted = false,
                            JobTypeId = 2,
                            RequiredDegree = "Higher Education",
                            RequiredExperience = "",
                            RequiredLanguage = "English C2",
                            RequiredSkills = "OOP, SQL, .NET, Architecture, Code Optimization",
                            Salary = 10000m,
                            Title = "Senior C# Programmer"
                        },
                        new
                        {
                            Id = 3,
                            Address = "Reading, Thames Valley Park, UK",
                            CategoryId = 3,
                            CompanyId = 1,
                            CreatedOn = new DateTime(2024, 10, 8, 18, 36, 53, 534, DateTimeKind.Utc).AddTicks(5336),
                            Description = "Dynamic manager needed at Microsoft to lead teams and drive innovation.",
                            IsDeleted = false,
                            JobTypeId = 2,
                            RequiredDegree = "Higher Education",
                            RequiredExperience = "10 years",
                            RequiredLanguage = "English C2",
                            RequiredSkills = " Project Management, Strong Communication, Leadership, Problem-Solving",
                            Salary = 15000m,
                            Title = "Looking for a manager to lead Microsoft"
                        });
                });

            modelBuilder.Entity("JAR.Infrastructure.Data.Models.JobType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Job Type Identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasComment("Job Type Name");

                    b.HasKey("Id");

                    b.ToTable("JobTypes", t =>
                        {
                            t.HasComment("Job Type");
                        });

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Internship Job"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Full Time Job"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Part Time Job"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Temporary Job"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Seasonal Job"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "2656a468-b215-4b17-865d-240a63b0d5cf",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "576441a1-f95a-483c-9e7e-aa86108c3def",
                            Email = "guest@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "GUEST@GMAIL.COM",
                            NormalizedUserName = "GUEST@GMAIL.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEB+Bemvew8YpopWG4nqMkbUrtLci+DR6xFePDWksuJYhxeNBF7zZXuo4aA16XszBnQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "304f38da-e22f-4be1-a22b-1600319d7345",
                            TwoFactorEnabled = false,
                            UserName = "guest@gmail.com"
                        },
                        new
                        {
                            Id = "71811921-1918-4043-90b9-20f2522f315b",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "1c8afa76-811f-4220-9ba1-3a1d9a72f632",
                            Email = "owner@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "OWNER@GMAIL.COM",
                            NormalizedUserName = "OWNER@GMAIL.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEM1FQkzT/BJIRMtq+EQnSbkhTnKhCw37+0MfpSI8tp/e1COaZS+Du1RHabYRCGlUSQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "9ea2ae60-9a2c-46d1-856c-89d797000bb0",
                            TwoFactorEnabled = false,
                            UserName = "owner@gmail.com"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("JAR.Infrastructure.Data.Models.Company", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("JAR.Infrastructure.Data.Models.JobApplication", b =>
                {
                    b.HasOne("JAR.Infrastructure.Data.Models.JobOffer", "JobOffer")
                        .WithMany("JobApplications")
                        .HasForeignKey("JobOfferId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("JobOffer");

                    b.Navigation("User");
                });

            modelBuilder.Entity("JAR.Infrastructure.Data.Models.JobOffer", b =>
                {
                    b.HasOne("JAR.Infrastructure.Data.Models.Category", "Category")
                        .WithMany("JobOffers")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JAR.Infrastructure.Data.Models.Company", "Company")
                        .WithMany("JobOffers")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JAR.Infrastructure.Data.Models.JobType", "JobType")
                        .WithMany("JobOffers")
                        .HasForeignKey("JobTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Company");

                    b.Navigation("JobType");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("JAR.Infrastructure.Data.Models.Category", b =>
                {
                    b.Navigation("JobOffers");
                });

            modelBuilder.Entity("JAR.Infrastructure.Data.Models.Company", b =>
                {
                    b.Navigation("JobOffers");
                });

            modelBuilder.Entity("JAR.Infrastructure.Data.Models.JobOffer", b =>
                {
                    b.Navigation("JobApplications");
                });

            modelBuilder.Entity("JAR.Infrastructure.Data.Models.JobType", b =>
                {
                    b.Navigation("JobOffers");
                });
#pragma warning restore 612, 618
        }
    }
}
