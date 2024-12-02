using JAR.Infrastructure.Data;
using JAR.Infrastructure.Data.Models;
using JAR.Infrastructure.Repository;
using JAR.Tests.Mocks;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAR.Tests.UnitTests
{
    public class UnitTestsBase
    {
        protected JarDbContext data;
        protected IRepository repository;

        public User GuestUser { get; private set; }
        public User OwnerUser { get; private set; }
        public User LecturerUser { get; private set; }
        public Company ApprovedCompany { get; private set; } 
        public Company UnapprovedCompany { get; private set; }
        public JobType JobType { get; private set; }
        public Category Category { get; private set; }
        public JobOffer JobOffer { get; private set; }
        public JobApplication JobApplication { get; private set; }
        public CV CV { get; private set; }
        public Degree CVDegree { get; private set; }
        public ProfessionalExperience CVProfessionalExperience { get; private set; }
        public Lecturer Lecturer { get; private set; }
        public Conference Conference { get; private set; }
        public ConferenceUser ConferenceUser { get; private set; }
        public Room ChatRoom { get; private set; }
        public RoomUser RoomUser1 { get; private set; }
        public RoomUser RoomUser2 { get; private set; }
        public Message Message1 { get; private set; }
        public Message Message2 { get; private set; }

        [OneTimeSetUp]
        public async Task SetUpBase()
        {
            data = DatabaseMock.Instance;
            repository = new Repository(data);
            await SeedDatabase();
        }

        [OneTimeTearDown]
        public void TearDownBase()
        {
            data.Dispose();
        }

        private async Task SeedDatabase()
        {
            GuestUser = new User()
            {
                Id = "GuestUserId",
                Email = "guest@gmail.com",
                FirstName = "Ivan",
                LastName = "Georgiev"
            };

            await repository.AddAsync<User>(GuestUser);

            OwnerUser = new User()
            {
                Id = "CompanyOwnerUserId",
                Email = "owner@gmail.com",
                FirstName = "Mihail",
                LastName = "Petrov"
            };

            await repository.AddAsync<User>(OwnerUser);

            LecturerUser = new User()
            {
                Id = "LecturerUserId",
                Email = "lecturer@gmail.com",
                FirstName = "Petur",
                LastName = "Petrov"
            };

            await repository.AddAsync<User>(LecturerUser);

            ApprovedCompany = new Company()
            {
                Id = 1,
                Name = "CompanyName",
                Address = "CompanyAddress 22",
                PhoneNumber = "0888888923",
                Email = "company@gmail.com",
                Description = "This is company Description. Very interesting description.",
                Country = "Bulgaria",
                UIC = "11-1111111",
                IsApproved = true,
                Logo = "",
                Owner = OwnerUser,
            };

            await repository.AddAsync<Company>(ApprovedCompany);

            UnapprovedCompany = new Company()
            {
                Id = 2,
                Name = "Unapproved Company",
                Address = "Unapproved Company Address",
                PhoneNumber = "0888888888",
                Email = "unapprovedcompany@gmail.com",
                Description = "This is unapproved company Description. Very interesting description.",
                Country = "Bulgaria",
                UIC = "11-1212121",
                IsApproved = false,
                Logo = "",
                Owner = LecturerUser,
            };

            await repository.AddAsync<Company>(UnapprovedCompany);

            JobType = new JobType()
            {
                Id = 1,
                Name = "Test Job Type"
            };

            await repository.AddAsync<JobType>(JobType);

            Category = new Category()
            {
                Id = 1,
                Name = "Test Category"
            };

            await repository.AddAsync<Category>(Category);

            JobOffer = new JobOffer()
            {
                Id = 1,
                Title = "Job Offer Title",
                Description = "Job Offer Description. The best job offer.",
                Address = "Job Offer Address",
                Salary = 1000,
                RequiredLanguage = "English C1",
                RequiredDegree = "Higher Education",
                RequiredExperience = "3 years",
                RequiredSkills = "Some skills",
                CreatedOn = DateTime.Now,
                Category = Category,
                JobType = JobType,
                Company = ApprovedCompany
            };

            await repository.AddAsync<JobOffer>(JobOffer);

            JobApplication = new JobApplication()
            {
                JobOffer = JobOffer,
                User = GuestUser,
                AppliedOn = DateTime.Now,
                IsApproved = false,
            };

            await repository.AddAsync<JobApplication>(JobApplication);

            CV = new CV()
            {
                Id = 1,
                User = GuestUser,
                FirstName = GuestUser.FirstName,
                LastName = GuestUser.LastName,
                LinkedInProfile = "https://www.linkedin.com/ivan",
                PhoneNumber = "0888888988",
                Address = "User Address 42",
                Gender = "Male",
                BirthDate = new DateTime(2000, 11, 20),
                Citizenship = "Bulgarian",
                Photo = "",
                Languages = "English A1, Bulgarian C2",
                Skills = "Some Skills",
                DrivingLicenseCategory = "A",
                Email = GuestUser.Email
            };

            await repository.AddAsync<CV>(CV);

            CVDegree = new Degree()
            {
                Id = 1,
                EducationalInstitution = "Educational Institution",
                Major = "Major",
                EducationLevel = "Any Level",
                City = "City",
                StartDate = new DateTime(2024, 11, 20),
                EndDate = new DateTime(2024, 11, 28),
                Description = "My Degree Description",
                CV = CV
            };

            await repository.AddAsync<Degree>(CVDegree);

            CVProfessionalExperience = new ProfessionalExperience()
            {
                Id = 1,
                CompanyName = "Company Name",
                City = "City",
                StartDate = new DateTime(2024, 11, 20),
                EndDate = new DateTime(2024, 11, 28),
                Description = "My Professional Experience Description",
                CV = CV
            };

            await repository.AddAsync<ProfessionalExperience>(CVProfessionalExperience);

            Lecturer = new Lecturer()
            {
                Id = 1,
                User = LecturerUser,
                Description = "Very Good Lecturer"
            };

            await repository.AddAsync<Lecturer>(Lecturer);

            Conference = new Conference()
            {
                Id = 1,
                Lecturer = Lecturer,
                Topic = "Conference Topic",
                Start = new DateTime(2024, 11, 28, 22, 30, 0),
                End = new DateTime(2024, 11, 28, 23, 30, 0),
                Description = "Conference Description",
                ConferenceUrl = "https://meet.google.com/hee-zkjp-sob"
            };

            await repository.AddAsync<Conference>(Conference);

            ConferenceUser = new ConferenceUser()
            {
                Conference = Conference,
                User = GuestUser
            };

            await repository.AddAsync<ConferenceUser>(ConferenceUser);

            ChatRoom = new Room()
            {
                Id = 1,
                Name = "Chat Room",
                AdminId = OwnerUser.Id
            };

            await repository.AddAsync<Room>(ChatRoom);

            RoomUser1 = new RoomUser()
            {
                Room = ChatRoom,
                User = OwnerUser
            };
            
            await repository.AddAsync<RoomUser>(RoomUser1);

            RoomUser2 = new RoomUser()
            {
                Room = ChatRoom,
                User = GuestUser
            };

            await repository.AddAsync<RoomUser>(RoomUser2);

            Message1 = new Message()
            {
                Id = 1,
                Content = "Hello!",
                Sender = GuestUser,
                Room = ChatRoom,
                Timestamp = new DateTime(2024, 11, 28, 22, 30, 0)
            };

            await repository.AddAsync<Message>(Message1);

            Message2 = new Message()
            {
                Id = 2,
                Content = "How are you?",
                Sender = OwnerUser,
                Room = ChatRoom,
                Timestamp = new DateTime(2024, 11, 28, 22, 31, 0)
            };
            
            await repository.AddAsync<Message>(Message2);

            await repository.SaveChangesAsync();
        }
    }
}