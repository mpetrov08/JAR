using JAR.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

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

        public Category MarketingCategory { get; set; }

        public Category EducationCategory { get; set; }

        public Category FinanceCategory { get; set; }

        public Category DesignCategory { get; set; }

        public Category ConstructionCategory { get; set; }

        public Category RetailCategory { get; set; }

        public Category LogisticsCategory { get; set; }

        public Category HospitalityCategory { get; set; }

        public Category LawCategory { get; set; }

        public Category ManufacturingCategory { get; set; }

        public JobType InternshipJob { get; set; }

        public JobType FullTimeJob { get; set; }

        public JobType PartTimeJob { get; set; }

        public JobType TemporaryJob { get; set; }

        public JobType SeasonalJob { get; set; }

        public Company ProgrammingCompany { get; set; }

        public JobOffer ProgrammerJobOffer1 { get; set; }

        public JobOffer ProgrammerJobOffer2 { get; set; }

        public JobOffer ManagerJobOffer { get; set; }

        public JobApplication ProgrammerJobApplication { get; set; }

        public Room Room { get; set; }

        public RoomUser RoomUser1 { get; set; }

        public RoomUser RoomUser2 { get; set; }

        public Lecturer Lecturer { get; set; }

        public Conference Conference { get; set; }

        public Degree Degree { get; set; }

        public ProfessionalExperience ProfessionalExperience { get; set; }

        public CV CV { get; set; }

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
            SeedLecturers();
            SeedConferences();
            SeedCV();
            SeedDegree();
            SeedProfessionalExperience();
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
                FirstName = "Ivan",
                LastName = "Ivanov"
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
                FirstName = "Bill",
                LastName = "Gates"
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
                FirstName = "Mihail",
                LastName = "Petrov",
                EmailConfirmed = true
            };

            AdminUser.PasswordHash = 
                hasher.HashPassword(AdminUser, "admin123");
        }

        private void SeedCategories()
        {
            SoftwareEngineeringCategory = new Category()
            {
                Id = 1,
                Name = "Софтуерно инженерство"
            };

            HealthCareCategory = new Category()
            {
                Id = 2,
                Name = "Медицина"
            };

            ManagementCategory = new Category()
            {
                Id = 3,
                Name = "Мениджмънт"
            };

            MarketingCategory = new Category()
            {
                Id = 4,
                Name = "Маркетинг"
            };

            EducationCategory = new Category()
            {
                Id = 5,
                Name = "Образование"
            };

            FinanceCategory = new Category()
            {
                Id = 6,
                Name = "Финанси"
            };

            DesignCategory = new Category()
            {
                Id = 7,
                Name = "Графичен дизайн"
            };

            ConstructionCategory = new Category()
            {
                Id = 8,
                Name = "Строителство"
            };

            RetailCategory = new Category()
            {
                Id = 9,
                Name = "Търговия на дребно"
            };

            LogisticsCategory = new Category()
            {
                Id = 10,
                Name = "Логистика"
            };

            HospitalityCategory = new Category()
            {
                Id = 11,
                Name = "Хотелиерство и туризъм"
            };

            LawCategory = new Category()
            {
                Id = 12,
                Name = "Право"
            };

            ManufacturingCategory = new Category()
            {
                Id = 13,
                Name = "Производство"
            };
        }

        private void SeedJobTypes()
        {
            InternshipJob = new JobType()
            {
                Id = 1,
                Name = "Стажантска работа"
            };

            FullTimeJob = new JobType()
            {
                Id = 2,
                Name = "Работа на пълен работен ден"
            };

            PartTimeJob = new JobType()
            {
                Id = 3,
                Name = "Работа на непълен работен ден"
            };

            TemporaryJob = new JobType()
            {
                Id = 4,
                Name = "Временна работа"
            };

            SeasonalJob = new JobType()
            {
                Id = 5,
                Name = "Сезонна работа"
            };
        }

        private void SeedCompany()
        {
            ProgrammingCompany = new Company()
            {
                Id = 1,
                Name = "Майкрософт",
                Logo = "https://blogs.microsoft.com/wp-content/uploads/prod/2012/08/8867.Microsoft_5F00_Logo_2D00_for_2D00_screen.jpg",
                UIC = "91-1144442",
                Country = "САЩ",
                Address = "Редмънд, Вашингтон, САЩ",
                PhoneNumber = "1234567890",
                Email = "microsoft@gmail.com",
                Description = "Майкрософт е глобална технологична компания, позната заради софтуера и хардуера, който произвеждат.",
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
                Title = "Junior C# програмист",
                Description = "C# junior програмистът трябва да знае ООП, Design Patterns, .NET, дебъгване и SQL.",
                Address = "Редмънд, Вашингтон, САЩ",
                Salary = 2000,
                RequiredLanguage = "Аниглийски C2",
                RequiredDegree = "Висше образование",
                RequiredSkills = "ООП, SQL, .NET, Design Patterns, Структури от данни и алгоритми",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false,
                CategoryId = 1,
                JobTypeId = 1,
                CompanyId = 1
            };

            ProgrammerJobOffer2 = new JobOffer()
            {
                Id = 2,
                Title = "Senior C# програмист",
                Description = "C# Senior програмистът трябва да има отлични знания в .NET, архитектура на приложенията, оптимизация на код.",
                Address = "Редмънд, Вашингтон, САЩ",
                Salary = 10_000,
                RequiredLanguage = "Английски C2",
                RequiredDegree = "Висше образование",
                RequiredSkills = "ООП, SQL, .NET, архитектура, оптимизация на код",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false,
                CategoryId = 1,
                JobTypeId = 2,
                CompanyId = 1
            };

            ManagerJobOffer = new JobOffer()
            {
                Id = 3,
                Title = "Търси се мениджър за ръководене на Майкрософт",
                Description = "Търси се динамичен мениджър в Майкрософт, който да ръководи екипи и да стимулира иновации.",
                Address = "Редмънд, Вашингтон, САЩ",
                Salary = 15_000,
                RequiredLanguage = "Английски C2",
                RequiredDegree = "Висше образование",
                RequiredExperience = "10 години",
                RequiredSkills = "Управление на проекти, Добра комуникация, Лидерство, Решаване на проблеми",
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
                Name = "Чат стая",
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

        private void SeedLecturers()
        {
            Lecturer = new Lecturer()
            {
                Id = 1,
                UserId = CompanyOwnerUser.Id,
                Description = "Лектор с дългогодишен опит в сферата, един от най-добрите в работата си. Може да ви научи на много неща.",
                IsDeleted = false
            };
        }

        private void SeedConferences()
        {
            Conference = new Conference()
            {
                Id = 1,
                LecturerId = Lecturer.Id,
                Topic = "Как да си намерим работа? Наистина ли е толкова трудно?",
                Start = DateTime.UtcNow,
                End = DateTime.UtcNow.AddHours(2),
                Description = "На тази конференция ще си говорим как да си намерим лесно работа и дали е толкова трудно.",
                IsDeleted = false,
                ConferenceUrl = "https://meet.google.com/pra-cekt-nbn"
            };
        }

        private void SeedDegree()
        {
            Degree = new Degree()
            {
                Id = 1,
                EducationalInstitution = "ППМГ \"Добри Чинтулов\"",
                Major = "Математика и Информатика",
                EducationLevel = "средно",
                City = "Сливен",
                StartDate = new DateTime(2019, 09, 15),
                EndDate = new DateTime(2027, 05, 24),
                Description = "Тук научих много нови неща",
                CVId = CV.Id,
                IsDeleted = false
            };
        }

        private void SeedProfessionalExperience()
        {
            ProfessionalExperience = new ProfessionalExperience()
            {
                Id = 1,
                CompanyName = "Софтуни",
                City = "София",
                StartDate = new DateTime(2025, 02, 12),
                EndDate = new DateTime(2050, 10, 17),
                Description = "Тук работих много и научих много нови неща",
                CVId = CV.Id,
                IsDeleted = false
            };
        }

        private void SeedCV()
        {
            CV = new CV()
            {
                Id = 1,
                UserId = GuestUser.Id,
                FirstName = "Михаил",
                LastName = "Петров",
                LinkedInProfile = "https://www.linkedin.com/mihail",
                PhoneNumber = "0888888888",
                Address = "Сливен, България, Европа",
                Gender = "Мъж",
                BirthDate = new DateTime(2008, 09, 13),
                Citizenship = "Българско",
                Photo = "https://cdn-icons-png.flaticon.com/512/149/149071.png",
                Languages = "Български C2, Немски B1, Английски B1",
                Skills = "Математика, Програмиране, История, Тенис на маса, Футбол",
                DrivingLicenseCategory = "A",
                Email = "mihailnanpetrov@gmai.com",
                IsDeleted = false
            };
        }
    }
}
