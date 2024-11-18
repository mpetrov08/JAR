using JAR.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAR.Infrastructure.Data.Seed
{
    internal class SeedData
    {
        public User GuestUser { get; set; }

        public User CompanyOwnerUser { get; set; }

        public User AdminUser { get; set; }

        public Category SoftwareEngineeringCategory { get; set; }

        public Category HealthCareCategory { get; set; }

        public Category ManagementCategory { get; set; }

        public JobType InternshipJob { get; set; }

        public JobType FullTimeJob { get; set; }

        public JobType PartTimeJob { get; set; }

        public JobType TemporaryJob { get; set; }

        public JobType SeasonalJob {  get; set; }

        public Company ProgrammingCompany { get; set; }

        public JobOffer ProgrammerJobOffer1 { get; set; }

        public JobOffer ProgrammerJobOffer2 { get; set; }

        public JobOffer ManagerJobOffer { get; set; }

        public JobApplication ProgrammerJobApplication { get; set; }

        public Room Room { get; set; }

        public RoomUser RoomUser1 { get; set; }

        public RoomUser RoomUser2 { get; set; }

        public SeedData()
        {
            SeedUsers();
            SeedCategories();
            SeedJobTypes();
            SeedCompany();
            SeedJobOffers();
            SeedJobApplication();
            SeedRoom();
            SeedRoomsUsers();
        }

        private void SeedUsers()
        {
            var hasher = new PasswordHasher<IdentityUser>();

            GuestUser = new User()
            {
                Id = "2656a468-b215-4b17-865d-240a63b0d5cf",
                UserName = "guest@gmail.com",
                NormalizedUserName = "GUEST@GMAIL.COM",
                Email = "guest@gmail.com",
                NormalizedEmail = "GUEST@GMAIL.COM",
                FirstName = "Guest",
                LastName = "Guestov"
            };

            GuestUser.PasswordHash = 
                hasher.HashPassword(GuestUser, "guest123");

            CompanyOwnerUser = new User()
            {
                Id = "71811921-1918-4043-90b9-20f2522f315b",
                UserName = "owner@gmail.com",
                NormalizedUserName = "OWNER@GMAIL.COM",
                Email = "owner@gmail.com",
                NormalizedEmail = "OWNER@GMAIL.COM",
                FirstName = "Owner",
                LastName = "Ownerov"
            };

            CompanyOwnerUser.PasswordHash = 
                hasher.HashPassword(CompanyOwnerUser, "owner123");

            AdminUser = new User()
            {
                Id = "80277b99-4cab-4ff1-8084-6d0a5df3e787",
                UserName = "admin@gmail.com",
                NormalizedUserName = "ADMIN@GMAIL.COM",
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                FirstName = "Admin",
                LastName = "Adminov"
            };

            AdminUser.PasswordHash = 
                hasher.HashPassword(AdminUser, "admin123");
        }

        private void SeedCategories()
        {
            SoftwareEngineeringCategory = new Category()
            {
                Id = 1,
                Name = "Software Engineering"
            };

            HealthCareCategory = new Category()
            {
                Id = 2,
                Name = "Health Care"
            };

            ManagementCategory = new Category()
            {
                Id = 3,
                Name = "Management"
            };
        }

        private void SeedJobTypes()
        {
            InternshipJob = new JobType()
            {
                Id = 1,
                Name = "Internship Job"
            };

            FullTimeJob = new JobType()
            {
                Id = 2,
                Name = "Full Time Job"
            };

            PartTimeJob = new JobType()
            {
                Id = 3,
                Name = "Part Time Job"
            };

            TemporaryJob = new JobType()
            {
                Id = 4,
                Name = "Temporary Job"
            };

            SeasonalJob = new JobType()
            {
                Id = 5,
                Name = "Seasonal Job"
            };
        }

        private void SeedCompany()
        {
            ProgrammingCompany = new Company()
            {
                Id = 1,
                Name = "Microsoft",
                Logo = "https://blogs.microsoft.com/wp-content/uploads/prod/2012/08/8867.Microsoft_5F00_Logo_2D00_for_2D00_screen.jpg",
                UIC = "91-1144442",
                Country = "USA",
                Address = "Redmond, Washington, USA",
                PhoneNumber = "1234567890",
                Email = "microsoft@gmail.com",
                Description = "Microsoft is a global technology company known for software and hardware.",
                IsDeleted = false,
                IsApproved = true,
                OwnerId = CompanyOwnerUser.Id
            };
        }

        private void SeedJobOffers()
        {
            ProgrammerJobOffer1 = new JobOffer()
            {
                Id = 1,
                Title = "Junior C# Programmer",
                Description = "A C# junior programmer should know OOP, Design Patterns, .NET, debugging and SQL.",
                Address = "Redmond, Washington, USA",
                Salary = 2000,
                RequiredLanguage = "English C2",
                RequiredDegree = "Higher Education",
                RequiredSkills = "OOP, SQL, .NET, Design Patterns, Data Structures and Algorithms",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false,
                CategoryId = 1,
                JobTypeId = 1,
                CompanyId = 1
            };

            ProgrammerJobOffer2 = new JobOffer()
            {
                Id = 2,
                Title = "Senior C# Programmer",
                Description = "C# Senior Developer must have excellent knowledge of .NET, architecture, code optimization.",
                Address = "Reading, Thames Valley Park, UK",
                Salary = 10_000,
                RequiredLanguage = "English C2",
                RequiredDegree = "Higher Education",
                RequiredSkills = "OOP, SQL, .NET, Architecture, Code Optimization",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false,
                CategoryId = 1,
                JobTypeId = 2,
                CompanyId = 1
            };

            ManagerJobOffer = new JobOffer()
            {
                Id = 3,
                Title = "Looking for a manager to lead Microsoft",
                Description = "Dynamic manager needed at Microsoft to lead teams and drive innovation.",
                Address = "Reading, Thames Valley Park, UK",
                Salary = 15_000,
                RequiredLanguage = "English C2",
                RequiredDegree = "Higher Education",
                RequiredExperience = "10 years",
                RequiredSkills = " Project Management, Strong Communication, Leadership, Problem-Solving",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false,
                CategoryId = 3,
                JobTypeId = 2,
                CompanyId = 1
            };
        }

        private void SeedJobApplication()
        {
            ProgrammerJobApplication = new JobApplication()
            {
                JobOfferId = 1,
                UserId = "2656a468-b215-4b17-865d-240a63b0d5cf",
                IsApproved = false,
                AppliedOn = DateTime.UtcNow,
            };
        }

        private void SeedRoom()
        {
            Room = new Room()
            {
                Id = 1,
                Name = "Chat Room",
                AdminId = AdminUser.Id,
                IsDeleted = false
            };
        }

        private void SeedRoomsUsers()
        {
            RoomUser1 = new RoomUser()
            {
                RoomId = Room.Id,
                UserId = AdminUser.Id
            };

            RoomUser2 = new RoomUser()
            {
                RoomId = Room.Id,
                UserId = GuestUser.Id
            };
        }
    }
}
