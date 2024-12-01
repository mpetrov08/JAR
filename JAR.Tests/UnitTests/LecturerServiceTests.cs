﻿using JAR.Core.Contracts;
using JAR.Core.Models.Lecturer;
using JAR.Core.Services;
using JAR.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAR.Tests.UnitTests
{
    [TestFixture]
    public class LecturerServiceTests : UnitTestsBase
    {
        private ILecturerService lecturerService;
        private int invalidLecturerId = -1;

        [OneTimeSetUp]
        public void SetUp()
        {
            lecturerService = new LecturerService(repository);
        }

        [Test]
        public async Task AllOptionsAsync_ShouldWorkCorrectly()
        {
            var result = await lecturerService.AllOptionsAsync();
            Assert.IsNotNull(result);

            var resultLecturer = result.FirstOrDefault(r => r.Id == Lecturer.Id);

            Assert.That(resultLecturer.FirstName, Is.EqualTo(LecturerUser.FirstName));
            Assert.That(resultLecturer.LastName, Is.EqualTo(LecturerUser.LastName));
        }

        [Test]
        public async Task ExistsAsync_ShouldReturnTrue()
        {
            var result = await lecturerService.Exists(Lecturer.Id);

            Assert.That(result, Is.True);
        }

        [Test]
        public async Task ExistsAsync_ShouldReturnFalse()
        {
            var result1 = await lecturerService.Exists(invalidLecturerId);
            Assert.That(result1, Is.False);
        }

        [Test]
        public async Task GetLecturerIdAsync_ShouldWorkCorrectly()
        {
            var result = await lecturerService.GetLecturerId(LecturerUser.Id);
            Assert.That(result, Is.EqualTo(Lecturer.Id));
        }

        [Test]
        public async Task GetLecturerOptionViewModelAsync_ShouldWorkCorrectly()
        {
            var result = await lecturerService.GetLecturerOptionViewModel(Lecturer.Id);

            Assert.That(result.Id, Is.EqualTo(Lecturer.Id));
            Assert.That(result.FirstName, Is.EqualTo(LecturerUser.FirstName));
            Assert.That(result.LastName, Is.EqualTo(LecturerUser.LastName));
        }

        [Test]
        public async Task HasLecturerConferenceAsync_ShouldReturnTrue()
        {
            var result = await lecturerService.HasLecturerConference(LecturerUser.Id, Conference.Id);
            Assert.That(result, Is.True);
        }

        [Test]
        public async Task HasLecturerConferenceAsync_ShouldReturnFalse()
        {
            var result = await lecturerService.HasLecturerConference(GuestUser.Id, Conference.Id);
            Assert.That(result, Is.False);
        }

        [Test]
        public async Task IsLecturerAsync_ShouldReturnTrue()
        {
            var result = await lecturerService.IsLecturer(LecturerUser.Id);
            Assert.That(result, Is.True);
        }

        [Test]
        public async Task IsLecturerAsync_ShouldReturnFalse()
        {
            var result = await lecturerService.IsLecturer(GuestUser.Id);
            Assert.That(result, Is.False);
        }

        [Test]
        public async Task PromoteToLecturerAsync_ShouldWorkCorrectly()
        {
            var model = new LecturerFormModel()
            {
                UserId = OwnerUser.Id,
                Description = "Any Description. Its very interesting!"
            };

            var result = await lecturerService.PromoteToLecturer(model);
            var isLecturer = await lecturerService.IsLecturer(OwnerUser.Id);

            Assert.That(result, Is.True);
            Assert.That(isLecturer, Is.True);
        }

        [Test]
        public async Task DemoteFromLecturerAsync_ShouldWorkCorrectly()
        {
            var model = new LecturerFormModel()
            {
                UserId = OwnerUser.Id,
                Description = "Any Description. Its very interesting!"
            };

            await lecturerService.PromoteToLecturer(model);
            var id = await lecturerService.GetLecturerId(OwnerUser.Id);

            var result = await lecturerService.DemoteFromLecturerAsync(id);
            var isLecturer = await lecturerService.IsLecturer(OwnerUser.Id);

            Assert.That(result, Is.True);
            Assert.That(isLecturer, Is.False);
        }

        [Test]
        public async Task AllAsync_ShouldWorkCorrectly()
        {
            var result = await lecturerService.AllAsync();
            Assert.IsNotNull(result);

            var allLecturers = repository
                .AllReadOnly<Lecturer>()
                .ToList();

            Assert.That(result.Count(), Is.EqualTo(allLecturers.Count()));

            var resultLecturer = result.FirstOrDefault(r => r.Id == Lecturer.Id);

            Assert.That(resultLecturer.Id, Is.EqualTo(Lecturer.Id));
            Assert.That(resultLecturer.FirstName, Is.EqualTo(LecturerUser.FirstName));
            Assert.That(resultLecturer.LastName, Is.EqualTo(LecturerUser.LastName));
            Assert.That(resultLecturer.Description, Is.EqualTo(Lecturer.Description));
        }

        [Test]
        public async Task EditAsync_ShouldWorkCorrectly()
        {
            var model = new LecturerFormModel()
            {
                UserId = OwnerUser.Id,
                Description = "Any Description. Its very interesting!"
            };

            await lecturerService.PromoteToLecturer(model);
            var id = await lecturerService.GetLecturerId(OwnerUser.Id);

            model.Description = "Edited Description";
            await lecturerService.Edit(model, id);
            var lecturer = await lecturerService.GetLecturerFormModel(id);

            Assert.That(lecturer.Description, Is.EqualTo(model.Description));
        }

        [Test]
        public async Task GetLecturerFormModelAsync_ShouldWorkCorrectly()
        {
            var result = await lecturerService.GetLecturerFormModel(Lecturer.Id);

            Assert.That(result.UserId, Is.EqualTo(LecturerUser.Id));
            Assert.That(result.Description, Is.EqualTo(Lecturer.Description));
        }
    }
}
