using Dropbox.Api.TeamLog;
using JAR.Core.Contracts;
using JAR.Core.Enumerations;
using JAR.Core.Services;
using JAR.Infrastructure.Data.Models;
using static JAR.Infrastructure.Constants.DataConstants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using JAR.Core.Models.JobOffer;
using System.Net;
using static Dropbox.Api.Files.ListRevisionsMode;

namespace JAR.Tests.UnitTests
{
    [TestFixture]
    public class JobOfferServiceTests : UnitTestsBase
    {
        private IJobOfferService jobOfferService;
        private int invalidId = -1;

        [OneTimeSetUp]
        public void SetUp()
        {
            jobOfferService = new JobOfferService(repository);
        }

        [Test]
        public async Task AllAsync_ShouldWorkCorrectly()
        {
            var result = await jobOfferService.AllAsync();
            Assert.IsNotNull(result);
            Assert.That(result.TotalJobOfferCount, Is.EqualTo(1));

            var resultJobOffer = result.JobOffers.FirstOrDefault();
            Assert.IsNotNull(resultJobOffer);
            Assert.That(resultJobOffer.Id, Is.EqualTo(JobOffer.Id));
            Assert.That(resultJobOffer.Title, Is.EqualTo(JobOffer.Title));
            Assert.That(resultJobOffer.Address, Is.EqualTo(JobOffer.Address));
            Assert.That(resultJobOffer.RequiredLanguage, Is.EqualTo(JobOffer.RequiredLanguage));
            Assert.That(resultJobOffer.RequiredDegree, Is.EqualTo(JobOffer.RequiredDegree));
            Assert.That(resultJobOffer.RequiredExperience, Is.EqualTo(JobOffer.RequiredExperience));
            Assert.That(resultJobOffer.RequiredSkills, Is.EqualTo(JobOffer.RequiredSkills));
            Assert.That(resultJobOffer.Salary, Is.EqualTo(JobOffer.Salary));
            Assert.That(resultJobOffer.CreatedOn, Is.EqualTo(JobOffer.CreatedOn.Date.ToString()));
            Assert.That(resultJobOffer.CompanyOwnerId, Is.EqualTo(JobOffer.Company.OwnerId));
            Assert.That(resultJobOffer.CompanyLogo, Is.EqualTo(JobOffer.Company.Logo));
        }

        [Test]
        public async Task AllCategoriesAsync_ShouldWorkCorrectly()
        {
            var result = await jobOfferService.AllCategoriesAsync();
            Assert.IsNotNull(result);

            var categories = repository
                .AllReadOnly<Category>()
                .ToList();

            Assert.That(result.Count(), Is.EqualTo(categories.Count()));

            var resultCategory = result.FirstOrDefault(r => r.Id == Category.Id);
            Assert.That(resultCategory.Name, Is.EqualTo(Category.Name));
        }

        [Test]
        public async Task AllCategoriesNamesAsync_ShouldWorkCorrectly()
        {
            var result = await jobOfferService.AllCategoriesNamesAsync();
            Assert.IsNotNull(result);

            var categories = repository
                .AllReadOnly<Category>()
                .ToList();

            Assert.That(result.Count(), Is.EqualTo(categories.Count()));

            Assert.That(result.Contains(Category.Name), Is.True);
        }

        [Test]
        public async Task AllJobTypesAsync_ShouldWorkCorrectly()
        {
            var result = await jobOfferService.AllJobTypesAsync();
            Assert.IsNotNull(result);

            var jobTypes = repository
                .AllReadOnly<JobType>()
                .ToList();

            Assert.That(result.Count(), Is.EqualTo(jobTypes.Count()));

            var resultJobType = result.FirstOrDefault(r => r.Id == JobType.Id);
            Assert.That(resultJobType.Name, Is.EqualTo(JobType.Name));
        }

        [Test]
        public async Task AllJobTypeNamesAsync_ShouldWorkCorrectly()
        {
            var result = await jobOfferService.AllJobTypeNamesAsync();
            Assert.IsNotNull(result);

            var jobTypes = repository
                .AllReadOnly<JobType>()
                .ToList();

            Assert.That(result.Count(), Is.EqualTo(jobTypes.Count()));
            Assert.That(result.Contains(JobType.Name));
        }

        [Test]
        public async Task ExistsAsync_ShouldReturnTrue()
        {
            var result = await jobOfferService.ExistsAsync(JobOffer.Id);
            Assert.That(result, Is.True);
        }

        [Test]
        public async Task ExistsAsync_ShouldReturnFalse()
        {
            var result = await jobOfferService.ExistsAsync(invalidId);
            Assert.That(result, Is.False);
        }

        [Test]
        public async Task JobOfferDetailsAsync_ShouldWorkCorrectly()
        {
            var result = await jobOfferService.JobOfferDetailsAsync(JobOffer.Id);

            Assert.That(result.Id, Is.EqualTo(JobOffer.Id));
            Assert.That(result.Title, Is.EqualTo(JobOffer.Title));
            Assert.That(result.Address, Is.EqualTo(JobOffer.Address));
            Assert.That(result.RequiredLanguage, Is.EqualTo(JobOffer.RequiredLanguage));
            Assert.That(result.RequiredDegree, Is.EqualTo(JobOffer.RequiredDegree));
            Assert.That(result.RequiredExperience, Is.EqualTo(JobOffer.RequiredExperience));
            Assert.That(result.RequiredSkills, Is.EqualTo(JobOffer.RequiredSkills));
            Assert.That(result.Salary, Is.EqualTo(JobOffer.Salary));
            Assert.That(result.CreatedOn, Is.EqualTo(JobOffer.CreatedOn.ToString(DateFormat, CultureInfo.InvariantCulture)));
            Assert.That(result.Description, Is.EqualTo(JobOffer.Description));
            Assert.That(result.JobType, Is.EqualTo(JobOffer.JobType.Name));
            Assert.That(result.Category, Is.EqualTo(JobOffer.Category.Name));
            Assert.That(result.Company.Id, Is.EqualTo(JobOffer.Company.Id));
            Assert.That(result.Company.Name, Is.EqualTo(JobOffer.Company.Name));
            Assert.That(result.Company.Address, Is.EqualTo(JobOffer.Company.Address));
            Assert.That(result.Company.PhoneNumber, Is.EqualTo(JobOffer.Company.PhoneNumber));
            Assert.That(result.Company.Email, Is.EqualTo(JobOffer.Company.Email));
            Assert.That(result.Company.Description, Is.EqualTo(JobOffer.Company.Description));
            Assert.That(result.Company.OwnerName, Is.EqualTo(JobOffer.Company.Owner.FirstName + " " + JobOffer.Company.Owner.LastName));
            Assert.That(result.Company.LogoUrl, Is.EqualTo(JobOffer.Company.Logo));
        }

        [Test]
        public async Task CreateAsync_ShouldWorkCorrectly()
        {
            var jobOffersCountBefore = repository
                .AllReadOnly<JobOffer>()
                .Where(c => c.IsDeleted == false)
                .Count();

            var model = new JobOfferFormModel()
            {
                Title = JobOffer.Title,
                Description = JobOffer.Description,
                Address = JobOffer.Address,
                Salary = JobOffer.Salary,
                RequiredDegree = JobOffer.RequiredDegree,
                RequiredExperience = JobOffer.RequiredExperience,
                RequiredLanguage = JobOffer.RequiredLanguage,
                RequiredSkills = JobOffer.RequiredSkills,
                CategoryId = JobOffer.CategoryId,
                JobTypeId = JobOffer.JobTypeId
            };

            await jobOfferService.CreateAsync(model, ApprovedCompany.Id, DateTime.Now);

            var currentCount = repository
                .AllReadOnly<JobOffer>()
                .Where(c => c.IsDeleted == false)
                .Count();

            Assert.That(currentCount, Is.EqualTo(jobOffersCountBefore + 1));
        }

        [Test]
        public async Task CategoryExistsAsync_ShouldReturnTrue()
        {
            var result = await jobOfferService.CategoryExistsAsync(Category.Id);
            Assert.That(result, Is.True);
        }

        [Test]
        public async Task CategoryExistsAsync_ShouldReturnFalse()
        {
            var result = await jobOfferService.CategoryExistsAsync(invalidId);
            Assert.That(result, Is.False);
        }

        [Test]
        public async Task JobTypeExistsAsync_ShouldReturnTrue()
        {
            var result = await jobOfferService.JobTypeExistsAsync(JobType.Id);
            Assert.That(result, Is.True);
        }

        [Test]
        public async Task JobTypeExistsAsync_ShouldReturnFalse()
        {
            var result = await jobOfferService.JobTypeExistsAsync(invalidId);
            Assert.That(result, Is.False);
        }

        [Test]
        public async Task GetJobOfferFormModelByIdAsync_ShouldWorkCorrectly()
        {
            var result = await jobOfferService.GetJobOfferFormModelByIdAsync(JobType.Id);

            Assert.That(result.Title, Is.EqualTo(JobOffer.Title));
            Assert.That(result.Description, Is.EqualTo(JobOffer.Description));
            Assert.That(result.Address, Is.EqualTo(JobOffer.Address));
            Assert.That(result.Salary, Is.EqualTo(JobOffer.Salary));
            Assert.That(result.RequiredDegree, Is.EqualTo(JobOffer.RequiredDegree));
            Assert.That(result.RequiredExperience, Is.EqualTo(JobOffer.RequiredExperience));
            Assert.That(result.RequiredLanguage, Is.EqualTo(JobOffer.RequiredLanguage));
            Assert.That(result.RequiredSkills, Is.EqualTo(JobOffer.RequiredSkills));
            Assert.That(result.CategoryId, Is.EqualTo(JobOffer.CategoryId));
            Assert.That(result.JobTypeId, Is.EqualTo(JobOffer.JobTypeId));
            Assert.IsNotNull(result.Categories);
            Assert.IsNotNull(result.JobTypes);
        }

        [Test]
        public async Task HasCompanyWithIdAsync_ShouldReturnTrue()
        {
            var result = await jobOfferService.HasCompanyWithIdAsync(JobOffer.Id, OwnerUser.Id);
            Assert.That(result, Is.True);
        }

        [Test]
        public async Task HasCompanyWithIdAsync_ShouldReturnFalse()
        {
            var result1 = await jobOfferService.HasCompanyWithIdAsync(JobOffer.Id, GuestUser.Id);
            Assert.That(result1, Is.False);

            var result2 = await jobOfferService.HasCompanyWithIdAsync(invalidId, OwnerUser.Id);
            Assert.That(result2, Is.False);
        }

        [Test]
        public async Task EditAsync_ShouldWorkCorrectly()
        {
            var model = new JobOfferFormModel()
            {
                Title = "New Title",
                Description = JobOffer.Description,
                Address = JobOffer.Address,
                Salary = JobOffer.Salary,
                RequiredDegree = JobOffer.RequiredDegree,
                RequiredExperience = JobOffer.RequiredExperience,
                RequiredLanguage = JobOffer.RequiredLanguage,
                RequiredSkills = JobOffer.RequiredSkills,
                CategoryId = JobOffer.CategoryId,
                JobTypeId = JobOffer.JobTypeId
            };

            await jobOfferService.CreateAsync(model, ApprovedCompany.Id, DateTime.Now);

            var id = repository.AllReadOnly<JobOffer>().FirstOrDefault(jo => jo.Title == model.Title).Id;

            model.Title = "Edited Title";
            await jobOfferService.EditAsync(model, id);

            var jobOffer = await jobOfferService.GetJobOfferFormModelByIdAsync(id);
            Assert.That(jobOffer.Title, Is.EqualTo(model.Title));
        }

        [Test]
        public async Task DeleteAsync_ShouldWorkCorrectly()
        {
            var model = new JobOfferFormModel()
            {
                Title = "Title For Delete",
                Description = JobOffer.Description,
                Address = JobOffer.Address,
                Salary = JobOffer.Salary,
                RequiredDegree = JobOffer.RequiredDegree,
                RequiredExperience = JobOffer.RequiredExperience,
                RequiredLanguage = JobOffer.RequiredLanguage,
                RequiredSkills = JobOffer.RequiredSkills,
                CategoryId = JobOffer.CategoryId,
                JobTypeId = JobOffer.JobTypeId
            };

            await jobOfferService.CreateAsync(model, ApprovedCompany.Id, DateTime.Now);
            var id = repository.AllReadOnly<JobOffer>().FirstOrDefault(jo => jo.Title == model.Title).Id;

            await jobOfferService.DeleteAsync(id);
            var isExisting = await jobOfferService.ExistsAsync(id);
            var jobOffer = repository.AllReadOnly<JobOffer>().FirstOrDefault(jo => jo.Title == model.Title);

            Assert.That(jobOffer.IsDeleted, Is.True);
            Assert.That(isExisting, Is.False);
        }

        [Test]
        public async Task AllByUserIdAsync_ShouldWorkCorrectly()
        {
            var result = await jobOfferService.AllByUserIdAsync(GuestUser.Id);
            Assert.IsNotNull(result);

            var jobOffersCount = repository
                .AllReadOnly<JobOffer>()
                .ToList();

            Assert.That(result.Count(), Is.EqualTo(jobOffersCount.Count()));
            var resultJobOffer = result.FirstOrDefault(r => r.Id == JobOffer.Id);

            Assert.That(resultJobOffer.Title, Is.EqualTo(JobOffer.Title));
            Assert.That(resultJobOffer.Address, Is.EqualTo(JobOffer.Address));
            Assert.That(resultJobOffer.Salary, Is.EqualTo(JobOffer.Salary));
            Assert.That(resultJobOffer.RequiredDegree, Is.EqualTo(JobOffer.RequiredDegree));
            Assert.That(resultJobOffer.RequiredExperience, Is.EqualTo(JobOffer.RequiredExperience));
            Assert.That(resultJobOffer.RequiredLanguage, Is.EqualTo(JobOffer.RequiredLanguage));
            Assert.That(resultJobOffer.RequiredSkills, Is.EqualTo(JobOffer.RequiredSkills));
            Assert.That(resultJobOffer.CreatedOn, Is.EqualTo(JobOffer.CreatedOn.ToString(DateFormat, CultureInfo.InvariantCulture)));
            Assert.That(resultJobOffer.CompanyOwnerId, Is.EqualTo(JobOffer.Company.OwnerId));
            Assert.That(resultJobOffer.CompanyLogo, Is.EqualTo(JobOffer.Company.Logo));
        }

        [Test]
        public async Task AllByOwnerIdAsync_ShouldWorkCorrectly()
        {
            var result = await jobOfferService.AllByOwnerIdAsync(OwnerUser.Id);
            Assert.IsNotNull(result);

            var jobOffersCount = repository
                .AllReadOnly<JobOffer>()
                .ToList();

            Assert.That(result.Count(), Is.EqualTo(jobOffersCount.Count()));
            var resultJobOffer = result.FirstOrDefault(r => r.Id == JobOffer.Id);

            Assert.That(resultJobOffer.Title, Is.EqualTo(JobOffer.Title));
            Assert.That(resultJobOffer.Address, Is.EqualTo(JobOffer.Address));
            Assert.That(resultJobOffer.Salary, Is.EqualTo(JobOffer.Salary));
            Assert.That(resultJobOffer.RequiredDegree, Is.EqualTo(JobOffer.RequiredDegree));
            Assert.That(resultJobOffer.RequiredExperience, Is.EqualTo(JobOffer.RequiredExperience));
            Assert.That(resultJobOffer.RequiredLanguage, Is.EqualTo(JobOffer.RequiredLanguage));
            Assert.That(resultJobOffer.RequiredSkills, Is.EqualTo(JobOffer.RequiredSkills));
            Assert.That(resultJobOffer.CreatedOn, Is.EqualTo(JobOffer.CreatedOn.ToString(DateFormat, CultureInfo.InvariantCulture)));
            Assert.That(resultJobOffer.CompanyOwnerId, Is.EqualTo(JobOffer.Company.OwnerId));
            Assert.That(resultJobOffer.CompanyLogo, Is.EqualTo(JobOffer.Company.Logo));
        }
    }
}
