using JAR.Core.Contracts;
using JAR.Core.Models.CV;
using JAR.Core.Services;
using JAR.Infrastructure.Data.Models;
using static JAR.Infrastructure.Constants.DataConstants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using JAR.Infrastructure.Repository;
using Moq;

namespace JAR.Tests.UnitTests
{
    [TestFixture]
    public class CVServiceTests : UnitTestsBase
    {
        private ICVService cvService;
        private int invalidCVId = -1;

        [OneTimeSetUp]
        public void SetUp()
        {
            cvService = new CVService(repository);
        }

        [Test]
        public async Task CreateCVAsync_ShouldWorkCorrectly()
        {
            var cvsCountBefore = repository
                .AllReadOnly<CV>()
                .Where(c => c.IsDeleted == false)
                .Count();

            var cvModel = new CVFormModel()
            {
                FirstName = CV.FirstName,
                LastName = CV.LastName,
                Email = CV.Email,
                LinkedInProfile = CV.LinkedInProfile,
                PhoneNumber = CV.PhoneNumber,
                Address = CV.Address,
                Gender = CV.Gender,
                BirthDate = CV.BirthDate.ToString(DateFormat, CultureInfo.InvariantCulture),
                Citizenship = CV.Citizenship,
                PhotoUrl = CV.Photo,
                Languages = CV.Languages,
                Skills = CV.Skills,
                DrivingLicense = CV.DrivingLicenseCategory,
                Degrees = new List<DegreeFormModel>()
                {
                    new DegreeFormModel()
                    {
                        EducationalInstitution = CVDegree.EducationalInstitution,
                        Major = CVDegree.Major,
                        EducationalLevel = CVDegree.EducationLevel,
                        City = CVDegree.City,
                        StartDate = CVDegree.StartDate.ToString(DateFormat, CultureInfo.InvariantCulture),
                        EndDate = CVDegree.EndDate.ToString(DateFormat, CultureInfo.InvariantCulture),
                        Description = CVDegree.Description
                    }
                },
                ProfessionalExperiences = new List<ProfessionalExperienceFormModel>() 
                {
                    new ProfessionalExperienceFormModel()
                    {
                        CompanyName = CVProfessionalExperience.CompanyName,
                        City = CVProfessionalExperience.City,
                        StartDate = CVProfessionalExperience.StartDate.ToString(DateFormat, CultureInfo.InvariantCulture),
                        EndDate = CVProfessionalExperience.EndDate.ToString(DateFormat, CultureInfo.InvariantCulture),
                        Description = CVProfessionalExperience.Description
                    }
                }
            };

            await cvService.CreateCVAsync(cvModel, LecturerUser.Id);

            var currentCount = repository
                .AllReadOnly<CV>()
                .Where(c => c.IsDeleted == false)
                .Count();

            Assert.That(currentCount, Is.EqualTo(cvsCountBefore + 1));
            await SetUpBase();
            SetUp();
        }

        [Test]
        public void CreateDegreeAsync_ShouldWorkCorrectly()
        {
            var degreeModel = new DegreeFormModel()
            {
                EducationalInstitution = CVDegree.EducationalInstitution,
                Major = CVDegree.Major,
                EducationalLevel = CVDegree.EducationLevel,
                City = CVDegree.City,
                StartDate = CVDegree.StartDate.ToString(DateFormat, CultureInfo.InvariantCulture),
                EndDate = CVDegree.EndDate.ToString(DateFormat, CultureInfo.InvariantCulture),
                Description = CVDegree.Description
            };

            var degree = cvService.CreateDegree(degreeModel, CV.Id);

            Assert.That(degree.EducationalInstitution, Is.EqualTo(degreeModel.EducationalInstitution));
            Assert.That(degree.Major, Is.EqualTo(degreeModel.Major));
            Assert.That(degree.EducationLevel, Is.EqualTo(degreeModel.EducationalLevel));
            Assert.That(degree.City, Is.EqualTo(degreeModel.City));
            Assert.That(degree.StartDate.ToString(DateFormat, CultureInfo.InvariantCulture), Is.EqualTo(degreeModel.StartDate));
            Assert.That(degree.EndDate.ToString(DateFormat, CultureInfo.InvariantCulture), Is.EqualTo(degreeModel.EndDate));
            Assert.That(degree.Description, Is.EqualTo(degreeModel.Description));
        }

        [Test]
        public void CreateProfessionalExperience_ShouldWorkCorrectly()
        {
            var professionalExperienceModel = new ProfessionalExperienceFormModel()
            {
                CompanyName = CVProfessionalExperience.CompanyName,
                City = CVProfessionalExperience.City,
                StartDate = CVProfessionalExperience.StartDate.ToString(DateFormat, CultureInfo.InvariantCulture),
                EndDate = CVProfessionalExperience.EndDate.ToString(DateFormat, CultureInfo.InvariantCulture),
                Description = CVProfessionalExperience.Description
            };

            var professionalExperience = cvService.CreateProfessionalExperience(professionalExperienceModel, CV.Id);

            Assert.That(professionalExperience.CompanyName, Is.EqualTo(professionalExperienceModel.CompanyName));
            Assert.That(professionalExperience.City, Is.EqualTo(professionalExperienceModel.City));
            Assert.That(professionalExperience.StartDate.ToString(DateFormat, CultureInfo.InvariantCulture), Is.EqualTo(professionalExperienceModel.StartDate));
            Assert.That(professionalExperience.EndDate.ToString(DateFormat, CultureInfo.InvariantCulture), Is.EqualTo(professionalExperienceModel.EndDate));
            Assert.That(professionalExperience.Description, Is.EqualTo(professionalExperienceModel.Description));
        }

        [Test]
        public async Task DeleteCVAsync_ShouldWorkCorrectly()
        {
            var cvCountBefore = repository
                .AllReadOnly<CV>()
                .Where(cv => cv.IsDeleted == false)
                .Count();

            await cvService.DeleteCV(CV.Id);

            var currentCount = repository
                .AllReadOnly<CV>()
                .Where(c => c.IsDeleted == false)
                .Count();

            Assert.That(currentCount, Is.EqualTo(cvCountBefore - 1));

            var isExisting = await cvService.Exists(CV.Id);

            Assert.That(isExisting, Is.False);
            await SetUpBase();
            SetUp();
        }

        [Test]
        public async Task DeleteDegreeAsync_ShouldWorkCorrectly()
        {
            var degreeId = 100;
            var degree = new Degree
            {
                Id = degreeId,
                IsDeleted = false
            };

            await repository.AddAsync(degree);

            await cvService.DeleteDegree(degreeId);

            Assert.That(degree.IsDeleted, Is.True);
        }

        [Test]
        public async Task DeleteProfessionalExperienceAsync_ShouldWorkCorrectly()
        {
            var experienceId = 100;
            var professionalExperience = new ProfessionalExperience
            {
                Id = experienceId,
                IsDeleted = false
            };

            await repository.AddAsync(professionalExperience);

            await cvService.DeleteProfessionalExperience(experienceId);

            Assert.That(professionalExperience.IsDeleted, Is.True);
        }

        [Test]
        public async Task ExistsAsync_ShouldReturnTrue()
        {
            var result = await cvService.Exists(CV.Id);
            Assert.That(result, Is.True);
        }

        [Test]
        public async Task ExistsAsync_ShouldReturnFalse()
        {
            var result = await cvService.Exists(invalidCVId);
            Assert.That(result, Is.False);
        }

        [Test]
        public async Task GetCVFormModelByUserIdAsync_ShouldWorkCorrectly()
        {
            var result = await cvService.GetCVFormModelByUserId(GuestUser.Id);

            Assert.IsNotNull(result);
            Assert.That(result.FirstName, Is.EqualTo(CV.FirstName));
            Assert.That(result.LastName, Is.EqualTo(CV.LastName));
            Assert.That(result.Email, Is.EqualTo(CV.Email));
            Assert.That(result.LinkedInProfile, Is.EqualTo(CV.LinkedInProfile));
            Assert.That(result.Address, Is.EqualTo(CV.Address));
            Assert.That(result.PhoneNumber, Is.EqualTo(CV.PhoneNumber));
            Assert.That(result.Gender, Is.EqualTo(CV.Gender));
            Assert.That(result.BirthDate, Is.EqualTo(CV.BirthDate.ToString(DateFormat, CultureInfo.InvariantCulture)));
            Assert.That(result.Citizenship, Is.EqualTo(CV.Citizenship));

            var degree = result.Degrees.First();
            Assert.IsNotNull(result.Degrees);
            Assert.That(degree.EducationalInstitution, Is.EqualTo(CVDegree.EducationalInstitution));
            Assert.That(degree.Major, Is.EqualTo(CVDegree.Major));
            Assert.That(degree.EducationalLevel, Is.EqualTo(CVDegree.EducationLevel));
            Assert.That(degree.City, Is.EqualTo(CVDegree.City));
            Assert.That(degree.StartDate, Is.EqualTo(CVDegree.StartDate.ToString(DateFormat, CultureInfo.InvariantCulture)));
            Assert.That(degree.EndDate, Is.EqualTo(CVDegree.EndDate.ToString(DateFormat, CultureInfo.InvariantCulture)));
            Assert.That(degree.Description, Is.EqualTo(CVDegree.Description));

            var professionalExperience = result.ProfessionalExperiences.First();
            Assert.IsNotNull(result.ProfessionalExperiences);
            Assert.That(professionalExperience.CompanyName, Is.EqualTo(CVProfessionalExperience.CompanyName));
            Assert.That(professionalExperience.City, Is.EqualTo(CVProfessionalExperience.City));
            Assert.That(professionalExperience.StartDate, Is.EqualTo(CVProfessionalExperience.StartDate.ToString(DateFormat, CultureInfo.InvariantCulture)));
            Assert.That(professionalExperience.EndDate, Is.EqualTo(CVProfessionalExperience.EndDate.ToString(DateFormat, CultureInfo.InvariantCulture)));
            Assert.That(professionalExperience.Description, Is.EqualTo(CVProfessionalExperience.Description));
        }

        [Test]
        public async Task GetCVViewModelByUserIdAsync_ShouldWorkCorrectly()
        {
            var result = await cvService.GetCVViewModelByUserId(GuestUser.Id);

            Assert.IsNotNull(result);
            Assert.That(result.Id, Is.EqualTo(CV.Id));
            Assert.That(result.FirstName, Is.EqualTo(CV.FirstName));
            Assert.That(result.LastName, Is.EqualTo(CV.LastName));
            Assert.That(result.Email, Is.EqualTo(CV.Email));
            Assert.That(result.LinkedInProfile, Is.EqualTo(CV.LinkedInProfile));
            Assert.That(result.Address, Is.EqualTo(CV.Address));
            Assert.That(result.PhoneNumber, Is.EqualTo(CV.PhoneNumber));
            Assert.That(result.Gender, Is.EqualTo(CV.Gender));
            Assert.That(result.BirthDate, Is.EqualTo(CV.BirthDate.ToString(DateFormat, CultureInfo.InvariantCulture)));
            Assert.That(result.Citizenship, Is.EqualTo(CV.Citizenship));

            var degree = result.Degrees.First();
            Assert.IsNotNull(result.Degrees);
            Assert.That(degree.EducationalInstitution, Is.EqualTo(CVDegree.EducationalInstitution));
            Assert.That(degree.Major, Is.EqualTo(CVDegree.Major));
            Assert.That(degree.EducationalLevel, Is.EqualTo(CVDegree.EducationLevel));
            Assert.That(degree.City, Is.EqualTo(CVDegree.City));
            Assert.That(degree.StartDate, Is.EqualTo(CVDegree.StartDate.ToString(DateFormat, CultureInfo.InvariantCulture)));
            Assert.That(degree.EndDate, Is.EqualTo(CVDegree.EndDate.ToString(DateFormat, CultureInfo.InvariantCulture)));
            Assert.That(degree.Description, Is.EqualTo(CVDegree.Description));

            var professionalExperience = result.ProfessionalExperiences.First();
            Assert.IsNotNull(result.ProfessionalExperiences);
            Assert.That(professionalExperience.CompanyName, Is.EqualTo(CVProfessionalExperience.CompanyName));
            Assert.That(professionalExperience.City, Is.EqualTo(CVProfessionalExperience.City));
            Assert.That(professionalExperience.StartDate, Is.EqualTo(CVProfessionalExperience.StartDate.ToString(DateFormat, CultureInfo.InvariantCulture)));
            Assert.That(professionalExperience.EndDate, Is.EqualTo(CVProfessionalExperience.EndDate.ToString(DateFormat, CultureInfo.InvariantCulture)));
            Assert.That(professionalExperience.Description, Is.EqualTo(CVProfessionalExperience.Description));
        }

        [Test]
        public async Task UserHasCVAsync_ShouldReturnTrue()
        {
            var result = await cvService.UserHasCV(GuestUser.Id);
            Assert.That(result, Is.True);
        }

        [Test]
        public async Task UserHasCVAsync_ShouldReturnFalse()
        {
            var result = await cvService.UserHasCV(OwnerUser.Id);
            Assert.That(result, Is.False);
        }

        [Test]
        public async Task UserHasCVWithId_ShouldReturnTrue()
        {
            var result = await cvService.UserHasCVWithId(CV.Id, GuestUser.Id);

            Assert.That(result, Is.True);
        }

        [Test]
        public async Task UserHasCVWithId_ShouldReturnFalse()
        {
            var result1 = await cvService.UserHasCVWithId(CV.Id, OwnerUser.Id);
            Assert.That(result1, Is.False);

            var result2 = await cvService.UserHasCVWithId(invalidCVId, GuestUser.Id);
            Assert.That(result2, Is.False);
        }

        [Test]
        public async Task EditCVAsync_ShouldWorkCorrectly()
        {
            var cvModel = new CVFormModel()
            {
                FirstName = "Edited First Name",
                LastName = CV.LastName,
                Email = CV.Email,
                LinkedInProfile = CV.LinkedInProfile,
                PhoneNumber = CV.PhoneNumber,
                Address = CV.Address,
                Gender = CV.Gender,
                BirthDate = CV.BirthDate.ToString(DateFormat, CultureInfo.InvariantCulture),
                Citizenship = CV.Citizenship,
                PhotoUrl = CV.Photo,
                Languages = CV.Languages,
                Skills = CV.Skills,
                DrivingLicense = CV.DrivingLicenseCategory,
                Degrees = new List<DegreeFormModel>()
                {
                    new DegreeFormModel()
                    {
                        EducationalInstitution = CVDegree.EducationalInstitution,
                        Major = CVDegree.Major,
                        EducationalLevel = CVDegree.EducationLevel,
                        City = CVDegree.City,
                        StartDate = CVDegree.StartDate.ToString(DateFormat, CultureInfo.InvariantCulture),
                        EndDate = CVDegree.EndDate.ToString(DateFormat, CultureInfo.InvariantCulture),
                        Description = CVDegree.Description
                    }
                },
                ProfessionalExperiences = new List<ProfessionalExperienceFormModel>()
                {
                    new ProfessionalExperienceFormModel()
                    {
                        CompanyName = CVProfessionalExperience.CompanyName,
                        City = CVProfessionalExperience.City,
                        StartDate = CVProfessionalExperience.StartDate.ToString(DateFormat, CultureInfo.InvariantCulture),
                        EndDate = CVProfessionalExperience.EndDate.ToString(DateFormat, CultureInfo.InvariantCulture),
                        Description = CVProfessionalExperience.Description
                    }
                }
            };

            await cvService.EditCV(cvModel, CV.Id);
            Assert.That(CV.FirstName, Is.EqualTo("Edited First Name"));
            await SetUpBase();
            SetUp();
        }
    }
}