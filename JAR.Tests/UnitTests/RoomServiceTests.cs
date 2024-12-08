using JAR.Core.Contracts;
using JAR.Core.Enumerations;
using JAR.Core.Models.Chat;
using JAR.Core.Services;
using JAR.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dropbox.Api.Files.ListRevisionsMode;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace JAR.Tests.UnitTests
{
    [TestFixture]
    public class RoomServiceTests : UnitTestsBase
    {
        private IRoomService roomService;

        [OneTimeSetUp]
        public void SetUp()
        {
            roomService = new RoomService(repository, null);
        }
            
        [Test]
        public async Task GetChatsViewModel_ShouldWorkCorrectly()
        {
            var userId = OwnerUser.Id;

            var expectedProfile = new ProfileViewModel
            {
                Name = OwnerUser.FirstName + " " + OwnerUser.LastName
            };

            var result = await roomService.GetChatsViewModelAsync(userId);

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Profile);
            Assert.That(result.Profile.Name, Is.EqualTo(expectedProfile.Name));
            Assert.IsNotNull(result.Rooms);
            Assert.That(result.Rooms.Count(), Is.EqualTo(1));

            var resultRoom = result.Rooms.FirstOrDefault(r => r.Id == ChatRoom.Id);
            Assert.IsNotNull(resultRoom);
            Assert.That(resultRoom.Name, Is.EqualTo(ChatRoom.Name));
            Assert.That(resultRoom.Admin, Is.EqualTo(OwnerUser.Id));
            Assert.That(resultRoom.LastMessage, Is.EqualTo(ChatRoom.Messages.Last().Content));
            Assert.That(resultRoom.TimeStamp, Is.EqualTo(ChatRoom.Messages.Last().Timestamp.ToString("MM.dd.yyyy")));
        }

        [Test]
        public async Task GetAll_ShouldWorkCorrectly()
        {
            var result = await roomService.GetAllAsync(GuestUser.Id);

            Assert.IsNotNull(result);

            var allRooms = repository.AllReadOnly<Room>().ToList();

            Assert.That(result.Count(), Is.EqualTo(allRooms.Count));

            var resultRoom = result.FirstOrDefault(r => r.Id == ChatRoom.Id);
            Assert.IsNotNull(resultRoom);
            Assert.That(resultRoom.Name, Is.EqualTo(ChatRoom.Name));
            Assert.That(resultRoom.Admin, Is.EqualTo(ChatRoom.Admin.Id));
            Assert.That(resultRoom.LastMessage, Is.EqualTo(ChatRoom.Messages.Last().Content));
            Assert.That(resultRoom.TimeStamp, Is.EqualTo(ChatRoom.Messages.Last().Timestamp.ToString("MM/dd/yyyy")));
        }

        [Test]
        public async Task GetById_ShouldWorkCorrectly()
        {
            var userId = OwnerUser.Id;
            var roomId = ChatRoom.Id;

            var result = await roomService.GetByIdAsync(roomId, userId);

            Assert.IsNotNull(result);
            Assert.That(result.Id, Is.EqualTo(ChatRoom.Id));
            Assert.That(result.Name, Is.EqualTo(ChatRoom.Name));
            Assert.That(result.Admin, Is.EqualTo($"{OwnerUser.FirstName} {OwnerUser.LastName}"));
            Assert.That(result.LastMessage, Is.EqualTo(Message1.Content));
            Assert.That(result.TimeStamp, Is.EqualTo(Message1.Timestamp.ToString("MM/dd/yyyy")));
        }

        [Test]
        public async Task Create_ShouldWorkCorrectly()
        {
            int oldRoomCount = repository.AllReadOnly<Room>().Count();

            var createdRoom = await roomService.CreateAsync(new RoomViewModel()
            {
                Name = "New Chat Room"
            }, GuestUser.Id, OwnerUser.Id);

            Assert.NotNull(createdRoom);
            Assert.That(oldRoomCount + 1, Is.EqualTo(data.Rooms.Count()));
            Assert.That(repository.AllReadOnly<Room>().Any(r => r.Name == createdRoom.Name), Is.True);
            await SetUpBase();
            SetUp();
        }

        [Test]
        public async Task Edit_ShouldWorkCorrectly()
        {
            var updatedRoom = new RoomViewModel()
            {
                Name = "Unique Updated Chat Room"
            };

            var result = await roomService.EditAsync(ChatRoom.Id, updatedRoom, OwnerUser.Id);

            Assert.That(result, Is.EqualTo(HttpError.Ok));

            var roomInDb = await repository.AllReadOnly<Room>().FirstAsync(r => r.Id == ChatRoom.Id);
            Assert.NotNull(roomInDb);
            Assert.That(updatedRoom.Name, Is.EqualTo(roomInDb.Name));
            await SetUpBase();
            SetUp();
        }

        [Test]
        public async Task Delete_ShouldWorkCorrectly()
        {
            int oldCount = repository.AllReadOnly<Room>().Count(r => !r.IsDeleted);

            var result = await roomService.DeleteAsync(ChatRoom.Id, OwnerUser.Id);

            Assert.That(result, Is.True);
            Assert.That(oldCount - 1, Is.EqualTo(repository.AllReadOnly<Room>().Count(r => !r.IsDeleted)));
            Assert.That(repository.AllReadOnly<Room>().First(r => r.Id == ChatRoom.Id).IsDeleted, Is.True);
            await SetUpBase();
            SetUp();
        }

        [Test]
        public async Task AddUser_ShouldWorkCorrectly()
        {
            int oldUserCount = repository.AllReadOnly<RoomUser>().Count(ru => ru.RoomId == ChatRoom.Id);

            var result = await roomService.AddUserAsync(ChatRoom.Id, "NewUserId");

            Assert.That(result, Is.True);
            Assert.That(oldUserCount + 1, Is.EqualTo(repository.AllReadOnly<RoomUser>().Count(ru => ru.RoomId == ChatRoom.Id)));
            await SetUpBase();
            SetUp();
        }

        [Test]
        public async Task ExistsAsync_ShouldReturnTrue()
        {
            var result = await roomService.ExistsAsync(JobOffer.Title, GuestUser.Id);
        }
    }
}