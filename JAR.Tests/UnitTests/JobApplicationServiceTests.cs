using JAR.Core.Contracts;
using JAR.Core.Services;
using JAR.Infrastructure.Data.Models;
using static JAR.Infrastructure.Constants.DataConstants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace JAR.Tests.UnitTests
{
    [TestFixture]
    public class JobApplicationServiceTests : UnitTestsBase
    {
        private IJobApplicationService jobApplicationService;
        private string invalidUserId = "InvalidID";
        private int invalidJobId = -1;
        
        [OneTimeSetUp]
        public void SetUp()
        {
            jobApplicationService = new JobApplicationService(repository);
        }

        [Test]
        public async Task ApplyAsync_ShouldWorkCorrectly()
        {
            var jobApplicationsCountBefore = repository
                .AllReadOnly<JobApplication>()
                .Count();

            await jobApplicationService.ApplyAsync(JobOffer.Id, LecturerUser.Id, DateTime.Now);
            var hasApplied = await jobApplicationService.HasUserAlreadyAppliedAsync(JobOffer.Id, LecturerUser.Id);

            var currentCount = repository
                .AllReadOnly<JobApplication>()
                .Count();

            Assert.That(hasApplied, Is.True);
            Assert.That(currentCount, Is.EqualTo(jobApplicationsCountBefore + 1));
        }

        [Test]
        public async Task ApproveAsync_ShouldWorkCorrectly()
        {
            var message = "You have been approved!";
            await jobApplicationService.ApproveAsync(JobOffer.Id, GuestUser.Id, message);

            Assert.That(JobApplication.IsApproved, Is.True);
            Assert.That(JobApplication.Message, Is.EqualTo(message));
        }

        [Test]
        public async Task CheckStatusAsync_ShouldWorkCorrectly()
        {
            var message = "You have been approved!";
            await jobApplicationService.ApproveAsync(JobOffer.Id, GuestUser.Id, message);

            var result = await jobApplicationService.CheckStatusAsync(JobOffer.Id, GuestUser.Id);
            Assert.That(result, Is.True);
        }

        [Test]
        public async Task GetApplicantById_ShouldWorkCorrectly()
        {
            var result = await jobApplicationService.GetApplicantByIdAsync(JobOffer.Id, GuestUser.Id);

            Assert.That(result.UserId, Is.EqualTo(GuestUser.Id));
            Assert.That(result.JobId, Is.EqualTo(JobOffer.Id));
            Assert.That(result.Email, Is.EqualTo(GuestUser.Email));
            Assert.That(result.IsApproved, Is.EqualTo(JobApplication.IsApproved));
            Assert.That(result.AppliedOn, Is.EqualTo(JobApplication.AppliedOn.ToString(DateFormat, CultureInfo.InvariantCulture)));
        }

        [Test]
        public async Task GetApplicantsAsync_ShouldWorkCorrectly()
        {
            var result = await jobApplicationService.GetApplicantsAsync(JobOffer.Id);

            Assert.IsNotNull(result);

            var allJobApplicants = repository
                .AllReadOnly<JobApplication>()
                .Where(ja => ja.JobOfferId == JobOffer.Id)
                .ToList();

            Assert.That(result.Count, Is.EqualTo(allJobApplicants.Count()));
            var resultUser = result.FirstOrDefault(r => r.UserId == GuestUser.Id);

            Assert.That(resultUser.UserId, Is.EqualTo(GuestUser.Id));
            Assert.That(resultUser.JobId, Is.EqualTo(JobOffer.Id));
            Assert.That(resultUser.Email, Is.EqualTo(GuestUser.Email));
            Assert.That(resultUser.IsApproved, Is.EqualTo(JobApplication.IsApproved));
            Assert.That(resultUser.AppliedOn, Is.EqualTo(JobApplication.AppliedOn.ToString(DateFormat, CultureInfo.InvariantCulture)));
        }

        [Test]
        public async Task GetJobApplicationStatusViewModelAsync_ShouldWorkCorrectly()
        {
            var result = await jobApplicationService.GetJobApplicationStatusViewModelAsync(JobOffer.Id, GuestUser.Id);

            Assert.That(result.Title, Is.EqualTo(JobOffer.Title));
            Assert.That(result.Address, Is.EqualTo(JobOffer.Address));
            Assert.That(result.Description, Is.EqualTo(JobOffer.Description));
            Assert.That(result.Message, Is.EqualTo(JobApplication.Message));
            Assert.That(result.IsApproved, Is.EqualTo(JobApplication.IsApproved));
        }

        [Test]
        public async Task HasUserAlreadyAppliedAsync_ShouldReturnTrue()
        {
            var result = await jobApplicationService.HasUserAlreadyAppliedAsync(JobOffer.Id, GuestUser.Id);
            Assert.That(result, Is.True);
        }

        [Test]
        public async Task HasUserAlreadyAppliedAsync_ShouldReturnFalse()
        {
            var result1 = await jobApplicationService.HasUserAlreadyAppliedAsync(invalidJobId, GuestUser.Id);
            Assert.That(result1, Is.False);

            var result2 = await jobApplicationService.HasUserAlreadyAppliedAsync(JobOffer.Id, invalidUserId);
            Assert.That(result2, Is.False);
        }

        [Test]
        public async Task IsUserAlreadyApprovedAsync_ShouldReturnTrue()
        {
            var message = "You have been approved!";
            await jobApplicationService.ApproveAsync(JobOffer.Id, GuestUser.Id, message);

            var result = await jobApplicationService.IsUserAlreadyApprovedAsync(JobOffer.Id, GuestUser.Id);
            Assert.That(result, Is.True);
        }

        [Test]
        public async Task IsUserAlreadyApprovedAsync_ShouldReturnFalse()
        {
            var result1 = await jobApplicationService.IsUserAlreadyApprovedAsync(JobOffer.Id, LecturerUser.Id);
            Assert.That(result1, Is.False);
        }
    }
}
