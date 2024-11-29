using JAR.Core.Contracts;
using JAR.Core.Models.Company;
using JAR.Core.Services;
using JAR.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAR.Tests.UnitTests
{
    [TestFixture]
    public class CompanyServiceTests : UnitTestsBase
    {
        private ICompanyService companyService;
        private int InvalidCompanyId = 3;
        private string InvalidUserId = "InvalidUserId";

        [OneTimeSetUp]
        public void SetUp()
        {
            companyService = new CompanyService(repository);
        }

        [Test]
        public async Task ApproveCompanyAsync_ShouldApproveCompanyAndReturnTrue()
        {
            var result = await companyService.ApproveCompanyAsync(UnapprovedCompany.Id);
            Assert.That(result, Is.True);
            Assert.That(UnapprovedCompany.IsApproved, Is.True);
        }

        [Test]
        public async Task ApproveCompanyAsync_ShouldNotApproveAlreadyApprovedCompanyAndReturnFalse()
        {
            var result = await companyService.ApproveCompanyAsync(ApprovedCompany.Id);
            Assert.That(result, Is.False);
        }

        [Test]
        public async Task CompanyExistsAsync_ShouldReturnTrue()
        {
            var result1 = await companyService.CompanyExistsAsync(UnapprovedCompany.Id);
            var result2 = await companyService.CompanyExistsAsync(ApprovedCompany.Id);

            Assert.That(result1, Is.True);
            Assert.That(result2, Is.True);
        }

        [Test]
        public async Task CompanyExistsAsync_ShouldReturnFalse()
        {
            var result = await companyService.CompanyExistsAsync(InvalidCompanyId);

            Assert.That(result, Is.False);
        }

        [Test]
        public async Task CompanyWithUICExistsAsync_ShouldReturnTrue()
        {
            var result = await companyService.CompanyWithUICExistsAsync(ApprovedCompany.UIC);

            Assert.That(result, Is.True);
        }

        [Test]
        public async Task CreateAsync_ShouldCreateCompany()
        {
            var companyCountBefore = repository
                .AllReadOnly<Company>()
                .Where(c => c.IsDeleted == false)
                .Count();

            var companyModel = new CompanyRegisterModel()
            {
                Name = UnapprovedCompany.Name,
                LogoUrl = UnapprovedCompany.Logo,
                UIC = UnapprovedCompany.UIC,
                Country = UnapprovedCompany.Country,
                Address = UnapprovedCompany.Address,
                PhoneNumber = UnapprovedCompany.PhoneNumber,
                Email = UnapprovedCompany.Email,
                Description = UnapprovedCompany.Description,
            };

            await companyService.CreateCompanyAsync(companyModel, OwnerUser.Id);

            var currentCount = repository
                .AllReadOnly<Company>()
                .Where(c => c.IsDeleted == false)
                .Count();

            Assert.That(companyCountBefore + 1, Is.EqualTo(currentCount));
        }

        [Test]
        public async Task DeleteAsync_ShouldDeleteCompany()
        {
            var companyCountBefore = repository
                .AllReadOnly<Company>()
                .Where(c => c.IsDeleted == false)
                .Count();

            await companyService.DeleteAsync(UnapprovedCompany.Id);

            var currentCount = repository
                .AllReadOnly<Company>()
                .Where(c => c.IsDeleted == false)
                .Count();


            Assert.That(companyCountBefore - 1, Is.EqualTo(currentCount));

            var isExisting = await companyService.CompanyExistsAsync(UnapprovedCompany.Id);

            Assert.That(isExisting, Is.False);
        }

        [Test]
        public async Task All_ShouldWorkCorrectly()
        {
            var result = await companyService.GetAllCompaniesAsync();

            Assert.IsNotNull(result);

            var allCompanies = repository
                .AllReadOnly<Company>()
                .Where(c => c.IsDeleted == false)
                .ToList();

            Assert.That(result.Count(), Is.EqualTo(allCompanies.Count()));

            var resultCompany = result.FirstOrDefault(rc => rc.Name == ApprovedCompany.Name);

            Assert.IsNotNull(resultCompany);
            Assert.That(resultCompany.Address, Is.EqualTo(ApprovedCompany.Address));
            Assert.That(resultCompany.PhoneNumber, Is.EqualTo(ApprovedCompany.PhoneNumber));
            Assert.That(resultCompany.Email, Is.EqualTo(ApprovedCompany.Email));
            Assert.That(resultCompany.Description, Is.EqualTo(ApprovedCompany.Description));
            Assert.That(resultCompany.OwnerName, Is.EqualTo(ApprovedCompany.Owner.FirstName + " " + ApprovedCompany.Owner.LastName));
        }

        [Test]
        public async Task GetCompanyIdAsync_ShouldReturnCorrectId()
        {
            var result = await companyService.GetCompanyIdAsync(ApprovedCompany.OwnerId);

            Assert.That(result, Is.EqualTo(ApprovedCompany.Id));
        }

        [Test]
        public async Task GetCompanyIdAsync_ShouldWorkCorrectlyIfWrongIdIsPassed()
        {
            var result = await companyService.GetCompanyIdAsync(InvalidUserId);

            Assert.That(result, Is.EqualTo(-1));
        }

        [Test]
        public async Task GetCompanyViewModelByIdAsync_ShouldWorkCorrectly()
        {
            var result = await companyService.GetCompanyViewModelByIdAsync(ApprovedCompany.Id);

            Assert.IsNotNull(result);
            Assert.That(result.Name, Is.EqualTo(ApprovedCompany.Name));
            Assert.That(result.Address, Is.EqualTo(ApprovedCompany.Address));
            Assert.That(result.PhoneNumber, Is.EqualTo(ApprovedCompany.PhoneNumber));
            Assert.That(result.Email, Is.EqualTo(ApprovedCompany.Email));
            Assert.That(result.Description, Is.EqualTo(ApprovedCompany.Description));
            Assert.That(result.OwnerName, Is.EqualTo(ApprovedCompany.Owner.FirstName + " " + ApprovedCompany.Owner.LastName));
        }

        [Test]
        public async Task IsApprovedAsync_ShouldReturnTrue()
        {
            var result = await companyService.IsApproved(ApprovedCompany.Id);
            Assert.That(result, Is.True);
        }

        [Test]
        public async Task IsApprovedAsync_ShouldReturnFalse()
        {
            var result = await companyService.IsApproved(InvalidCompanyId);
            Assert.That(result, Is.False);
        }

        [Test]
        public async Task OwnerCompanyExistsAsync_ShouldReturnTrue()
        {
            var result = await companyService.OwnerCompanyExistsAsync(ApprovedCompany.OwnerId);
            Assert.That(result, Is.True);
        }

        [Test]
        public async Task OwnerCompanyExistsAsync_ShouldReturnFalse()
        {
            var result = await companyService.OwnerCompanyExistsAsync(InvalidUserId);
            Assert.That(result, Is.False);
        }

        [Test]
        public async Task OwnerCompanyExistsAsync_ShouldWorkCorrectly()
        {
            var result = await companyService.DisapproveCompanyAsync(ApprovedCompany.Id);
            Assert.That(result, Is.True);
            Assert.That(JobOffer.IsDeleted, Is.True);
        }
    }
}