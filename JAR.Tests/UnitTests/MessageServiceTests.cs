using JAR.Core.Contracts;
using JAR.Core.Models.Chat;
using JAR.Core.Services;
using JAR.Infrastructure.Data.Models;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace JAR.Tests.UnitTests
{
    [TestFixture]
    public class MessageServiceTests : UnitTestsBase
    {
        private IMessageService messageService;

        [OneTimeSetUp]
        public void SetUp()
        {
            messageService = new MessageService(repository, null);
        }

        [Test]
        public async Task GetMessages_Correct()
        {
            var result = await messageService.GetMessages(ChatRoom.Name);

            Assert.IsNotNull(result);
            var firstMsg = result?.FirstOrDefault();

            Assert.That(firstMsg?.Id, Is.EqualTo(Message1.Id));
            Assert.That(firstMsg?.Content, Is.EqualTo(Message1.Content));
            Assert.That(firstMsg?.FromFullName, Is.EqualTo(Message1.Sender.FirstName + " " + Message1.Sender.LastName));
            Assert.That(firstMsg?.Room, Is.EqualTo(Message1.Room.Name));
        }

        [Test]
        public async Task GetById_Correct()
        {
            var received = await messageService.GetById(Message1.Id);

            Assert.That(received.Id, Is.EqualTo(Message1.Id));
            Assert.That(received.Content, Is.EqualTo(Message1.Content));
            Assert.That(received.Timestamp, Is.EqualTo(Message1.Timestamp));
            Assert.That(received.FromUserName, Is.EqualTo(Message1.Sender.UserName));
            Assert.That(received.FromFullName, Is.EqualTo(Message1.Sender.FirstName + " " + Message1.Sender.LastName));
            Assert.That(received.Room, Is.EqualTo(Message1.Room.Name));
        }

        [Test]
        public async Task GetRoomIdByName_Correct()
        {
            var result = await messageService.GetRoomIdByName(ChatRoom.Name);

            Assert.That(result, Is.EqualTo(ChatRoom.Id));
        }

        [Test]
        public async Task Create_Correct()
        {
            var oldMessagesCount = repository.AllReadOnly<Message>().Count();
            var messageViewModel = new MessageViewModel()
            {
                Content = "Hello everyone",
                Room = "Chat Room"
            };

            var createdMessage = await messageService.Create(messageViewModel, GuestUser.Id);

            Assert.IsNotNull(createdMessage);
            Assert.That(data.Messages.Count(), Is.EqualTo(oldMessagesCount + 1));
            Assert.That(createdMessage.Content, Is.EqualTo(messageViewModel.Content));
            Assert.That(createdMessage.Room, Is.EqualTo(ChatRoom.Name));
            SetUpBase();
            SetUp();
        }

        [Test]
        public async Task Delete_Correct()
        {
            int oldMessagesCount = repository.AllReadOnly<Message>().Count(r => !r.IsDeleted);

            var result = await messageService.Delete(Message2.Id, OwnerUser.Id);

            Assert.That(result, Is.True);
            Assert.That(data.Messages.Count(r => !r.IsDeleted), Is.EqualTo(oldMessagesCount - 1));
            SetUpBase();
            SetUp();
        }

        [Test]
        public async Task Delete_MessageNotFound_ShouldReturnFalse()
        {
            var result = await messageService.Delete(9999, "TeacherUser");

            Assert.That(result, Is.False);
            SetUpBase();
            SetUp();
        }
    }
}