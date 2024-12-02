using JAR.Core.Contracts;
using JAR.Core.Services;
using JAR.Infrastructure.Data.Models;
using static JAR.Infrastructure.Constants.DataConstants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Dropbox.Api.TeamLog;
using JAR.Core.Models.Company;
using JAR.Core.Models.Conference;
using System.ComponentModel.DataAnnotations;

namespace JAR.Tests.UnitTests
{
    [TestFixture]
    public class ConferenceServiceTests : UnitTestsBase
    {
        private IConferenceService conferenceService;
        private ILecturerService lecturerService;
        private int InvalidConferenceId = 5;

        [OneTimeSetUp]
        public void SetUp()
        {
            lecturerService = new LecturerService(repository);
            conferenceService = new ConferenceService(repository, lecturerService);
        }

        [Test]
        public async Task AllAsync_ShouldWorkCorrectly()
        {
            var result = await conferenceService.AllAsync();

            Assert.IsNotNull(result);

            var allConferences = repository
                .AllReadOnly<Conference>()
                .Where(c => c.IsDeleted == false)
                .ToList();

            Assert.That(result.Count(), Is.EqualTo(allConferences.Count()));

            var resultConference = result.FirstOrDefault(rc => rc.Topic == Conference.Topic);
            var lecturer = await lecturerService.GetLecturerOptionViewModel(resultConference.Id);

            Assert.IsNotNull(resultConference);
            Assert.That(resultConference.Start, Is.EqualTo(Conference.Start.ToString(ConferenceDateTimeFormat, CultureInfo.InvariantCulture)));
            Assert.That(resultConference.End, Is.EqualTo(Conference.End.ToString(ConferenceDateTimeFormat, CultureInfo.InvariantCulture)));
            Assert.That(resultConference.ConferenceUrl, Is.EqualTo(Conference.ConferenceUrl));
            Assert.That(resultConference.Lecturer.FirstName, Is.EqualTo(lecturer.FirstName));
            Assert.That(resultConference.Lecturer.LastName, Is.EqualTo(lecturer.LastName));
            Assert.That(resultConference.Lecturer.Id, Is.EqualTo(lecturer.Id));
        }

        [Test]
        public async Task AllByLecturerIdAsync_ShouldWorkCorrectly()
        {
            var result = await conferenceService.AllByLecturerId(Lecturer.User.Id);

            Assert.IsNotNull(result);

            var allConferences = repository
                .AllReadOnly<Conference>()
                .Where(c => c.IsDeleted == false && c.Lecturer.Id == Lecturer.Id)
                .ToList();

            Assert.That(result.Count(), Is.EqualTo(allConferences.Count()));

            var resultConference = result.FirstOrDefault(rc => rc.Topic == Conference.Topic);
            var lecturer = await lecturerService.GetLecturerOptionViewModel(resultConference.Id);

            Assert.IsNotNull(resultConference);
            Assert.That(resultConference.Start, Is.EqualTo(Conference.Start.ToString(ConferenceDateTimeFormat, CultureInfo.InvariantCulture)));
            Assert.That(resultConference.End, Is.EqualTo(Conference.End.ToString(ConferenceDateTimeFormat, CultureInfo.InvariantCulture)));
            Assert.That(resultConference.ConferenceUrl, Is.EqualTo(Conference.ConferenceUrl));
            Assert.That(resultConference.Lecturer.FirstName, Is.EqualTo(lecturer.FirstName));
            Assert.That(resultConference.Lecturer.LastName, Is.EqualTo(lecturer.LastName));
            Assert.That(resultConference.Lecturer.Id, Is.EqualTo(lecturer.Id));
        }

        [Test]
        public async Task AllByUserIdAsync_ShouldWorkCorrectly()
        {
            var result = await conferenceService.AllByUserId(GuestUser.Id);

            Assert.IsNotNull(result);

            var allConferences = repository
                .AllReadOnly<Conference>()
                .Where(c => c.IsDeleted == false && c.ConferencesUsers.Any(cu => cu.UserId == GuestUser.Id))
                .ToList();

            Assert.That(result.Count(), Is.EqualTo(allConferences.Count()));

            var resultConference = result.FirstOrDefault(rc => rc.Topic == Conference.Topic);
            var lecturer = await lecturerService.GetLecturerOptionViewModel(resultConference.Id);

            Assert.IsNotNull(resultConference);
            Assert.That(resultConference.Start, Is.EqualTo(Conference.Start.ToString(ConferenceDateTimeFormat, CultureInfo.InvariantCulture)));
            Assert.That(resultConference.End, Is.EqualTo(Conference.End.ToString(ConferenceDateTimeFormat, CultureInfo.InvariantCulture)));
            Assert.That(resultConference.ConferenceUrl, Is.EqualTo(Conference.ConferenceUrl));
            Assert.That(resultConference.Lecturer.FirstName, Is.EqualTo(lecturer.FirstName));
            Assert.That(resultConference.Lecturer.LastName, Is.EqualTo(lecturer.LastName));
            Assert.That(resultConference.Lecturer.Id, Is.EqualTo(lecturer.Id));
        }

        [Test]
        public async Task CreateConferenceAsync_ShouldWorkCorrectly()
        {
            var conferenceCountBefore = repository
                .AllReadOnly<Conference>()
                .Where(c => c.IsDeleted == false)
                .Count();

            var conferenceModel = new ConferenceFormModel()
            {
                LecturerId = Conference.LecturerId,
                Topic = Conference.Topic,
                Start = Conference.Start.ToString(ConferenceDateTimeFormat, CultureInfo.InvariantCulture),
                End = Conference.End.ToString(ConferenceDateTimeFormat, CultureInfo.InvariantCulture),
                ConferenceUrl = Conference.ConferenceUrl,
                Description = Conference.Description,
            };

            await conferenceService.CreateConferenceAsync(conferenceModel);

            var currentCount = repository
                .AllReadOnly<Conference>()
                .Where(c => c.IsDeleted == false)
                .Count();

            Assert.That(conferenceCountBefore + 1, Is.EqualTo(currentCount));
            await SetUpBase();
            SetUp();
        }

        [Test]
        public async Task EditConferenceAsync_ShouldWorkCorrectly()
        {
            string editedTopic = "Edited Topic";
            var conferenceModel = new ConferenceFormModel()
            {
                LecturerId = Conference.LecturerId,
                Topic = editedTopic,
                Start = Conference.Start.ToString(ConferenceDateTimeFormat, CultureInfo.InvariantCulture),
                End = Conference.End.ToString(ConferenceDateTimeFormat, CultureInfo.InvariantCulture),
                ConferenceUrl = Conference.ConferenceUrl,
                Description = Conference.Description,
            };

            await conferenceService.EditConferenceAsync(conferenceModel, Conference.Id);

            Assert.That(Conference.Topic, Is.EqualTo(editedTopic));
            await SetUpBase();
            SetUp();
        }

        [Test]
        public async Task ExistsAsync_ShouldReturnTrue()
        {
            var result = await conferenceService.ExistsAsync(Conference.Id);
            Assert.That(result, Is.True);
        }

        [Test]
        public async Task ExistsAsync_ShouldReturnFalse()
        {
            var result = await conferenceService.ExistsAsync(InvalidConferenceId);
            Assert.That(result, Is.False);
        }

        [Test]
        public async Task GetConferenceDetailsViewModelByIdAsync_ShouldWorkCorrectly()
        {
            var result = await conferenceService.GetConferenceDetailsViewModelByIdAsync(Conference.Id);

            Assert.IsNotNull(result);
            Assert.That(result.Id, Is.EqualTo(Conference.Id));
            Assert.That(result.Topic, Is.EqualTo(Conference.Topic));
            Assert.That(result.Start, Is.EqualTo(Conference.Start.ToString(ConferenceDateTimeFormat, CultureInfo.InvariantCulture)));
            Assert.That(result.End, Is.EqualTo(Conference.End.ToString(ConferenceDateTimeFormat, CultureInfo.InvariantCulture)));
            Assert.That(result.Description, Is.EqualTo(Conference.Description));
            Assert.That(result.ConferenceUrl, Is.EqualTo(Conference.ConferenceUrl));
            Assert.That(result.Lecturer.Id, Is.EqualTo(Conference.Lecturer.Id));
            Assert.That(result.Lecturer.FirstName, Is.EqualTo(Conference.Lecturer.User.FirstName));
            Assert.That(result.Lecturer.LastName, Is.EqualTo(Conference.Lecturer.User.LastName));
            Assert.That(result.Lecturer.Description, Is.EqualTo(Conference.Lecturer.Description));
        }

        [Test]
        public async Task GetConferenceFormModelByIdAsync_ShouldWorkCorrectly()
        {
            var result = await conferenceService.GetConferenceFormModelByIdAsync(Conference.Id);

            Assert.IsNotNull(result);
            Assert.That(result.Topic, Is.EqualTo(Conference.Topic));
            Assert.That(result.Start, Is.EqualTo(Conference.Start.ToString(ConferenceDateTimeFormat, CultureInfo.InvariantCulture)));
            Assert.That(result.End, Is.EqualTo(Conference.End.ToString(ConferenceDateTimeFormat, CultureInfo.InvariantCulture)));
            Assert.That(result.Description, Is.EqualTo(Conference.Description));
            Assert.That(result.ConferenceUrl, Is.EqualTo(Conference.ConferenceUrl));
            Assert.That(result.LecturerId, Is.EqualTo(Conference.LecturerId));
        }

        [Test]
        public async Task GetConferenceViewModelByIdAsync_ShouldWorkCorrectly()
        {
            var result = await conferenceService.GetConferenceViewModelByIdAsync(Conference.Id);
            var lecturer = await lecturerService.GetLecturerOptionViewModel(result.Id);

            Assert.IsNotNull(result);
            Assert.That(result.Start, Is.EqualTo(Conference.Start.ToString(ConferenceDateTimeFormat, CultureInfo.InvariantCulture)));
            Assert.That(result.End, Is.EqualTo(Conference.End.ToString(ConferenceDateTimeFormat, CultureInfo.InvariantCulture)));
            Assert.That(result.ConferenceUrl, Is.EqualTo(Conference.ConferenceUrl));
            Assert.That(result.Lecturer.FirstName, Is.EqualTo(lecturer.FirstName));
            Assert.That(result.Lecturer.LastName, Is.EqualTo(lecturer.LastName));
            Assert.That(result.Lecturer.Id, Is.EqualTo(lecturer.Id));
        }

        [Test]
        public async Task HasUserSignedUpAsync_ShouldReturnTrue()
        {
            var result = await conferenceService.HasUserSignedUp(Conference.Id, GuestUser.Id);
            Assert.That(result, Is.True);   
        }

        [Test]
        public async Task HasUserSignedUpAsync_ShouldReturnFalse()
        {
            var result = await conferenceService.HasUserSignedUp(Conference.Id, OwnerUser.Id);
            Assert.That(result, Is.False);
        }

        [Test]
        public async Task IsConferenceOverAsync_ShouldReturnTrue()
        {
            var result = await conferenceService.IsConferenceOver(Conference.Id, DateTime.Now);
            Assert.That(result, Is.True);
        }
        
        [Test]
        public async Task SignUp_ShouldWorkCorrectly()
        {
            await conferenceService.SignUp(Conference.Id, OwnerUser.Id);
            var isSignedUp = await conferenceService.HasUserSignedUp(Conference.Id, OwnerUser.Id);
            Assert.That(isSignedUp, Is.True);
        }

        [Test]
        public async Task Unregister_ShouldWorkCorrectly()
        {
            await conferenceService.Unregister(Conference.Id, GuestUser.Id);
            var isSignedUp = await conferenceService.HasUserSignedUp(Conference.Id, GuestUser.Id);
            Assert.That(isSignedUp, Is.False);
            await SetUpBase();
            SetUp();
        }

        [Test]  
        public async Task DeleteConferenceAsync_ShouldWorkCorrectly()
        {
            var conferenceCountBefore = repository
                .AllReadOnly<Conference>()
                .Where(c => c.IsDeleted == false)
                .Count();

            await conferenceService.DeleteConferenceAsync(Conference.Id);

            var currentCount = repository
                .AllReadOnly<Conference>()
                .Where(c => c.IsDeleted == false)
                .Count();


            Assert.That(conferenceCountBefore - 1, Is.EqualTo(currentCount));

            var isExisting = await conferenceService.ExistsAsync(Conference.Id);

            Assert.That(isExisting, Is.False);
            await SetUpBase();
            SetUp();
        }
    }
}
