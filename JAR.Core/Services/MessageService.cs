using JAR.Core.Contracts;
using JAR.Core.Hubs;
using JAR.Core.Models.Chat;
using JAR.Infrastructure.Data.Models;
using JAR.Infrastructure.Repository;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace JAR.Core.Services
{
    public class MessageService : IMessageService
    {
        private readonly IRepository repository;
        private readonly IHubContext<ChatHub>? hubContext;

        public MessageService(IRepository _repository,
                              IHubContext<ChatHub>? _hubContext)
        {
            repository = _repository;
            hubContext = _hubContext;
        }

        public async Task<MessageViewModel?> GetById(int id)
        {
            var message = await repository.AllReadOnly<Message>()
                                       .Where(m => !m.IsDeleted)
                                       .Include(m => m.Sender)
                                       .Include(m => m.Room)
                                       .FirstOrDefaultAsync(m => m.Id == id);

            return new MessageViewModel()
            {
                Content = message.Content,
                FromFullName = message.Sender.FirstName + " " + message.Sender.LastName,
                FromUserName = message.Sender.UserName,
                Id = id,
                Room = message.Room.Name,
                Timestamp = message.Timestamp,
            };
        }

        public async Task<int>? GetRoomIdByName(string name)
        {
            var room = await repository.AllReadOnly<Room>().FirstOrDefaultAsync(r => r.Name == name);
            if (room == null) return 0;
            return room.Id;
        }

        public async Task<IEnumerable<MessageViewModel>?> GetMessages(string roomName)
        {
            int roomId = await GetRoomIdByName(roomName);
            if (roomId == null)
            {
                return null;
            }
            var messages = await repository.AllReadOnly<Message>()
                                   .Where(m => m.RoomId == roomId && !m.IsDeleted)
                                   .Include(m => m.Sender)
                                   .Include(m => m.Room)
                                   .OrderByDescending(m => m.Timestamp)
                                   .Reverse()
                                   .Select(m => new MessageViewModel()
                                   {
                                       Content = m.Content,
                                       FromFullName = m.Sender.FirstName + " " + m.Sender.LastName,
                                       FromUserName = m.Sender.UserName,
                                       Id = m.Id,
                                       Room = m.Room.Name,
                                       Timestamp = m.Timestamp,
                                   })
                                   .ToListAsync();
            return messages;
        }
        public async Task<MessageViewModel?> Create(MessageViewModel viewModel, string userId)
        {
            var room = await repository.AllReadOnly<Room>().FirstOrDefaultAsync(r => r.Name == viewModel.Room);
            if (room == null)
                return null;

            var message = new Message()
            {
                Content = Regex.Replace(viewModel.Content, @"<.*?>", string.Empty),
                SenderId = userId,
                RoomId = room.Id,
                Timestamp = DateTime.Now
            };

            await repository.AddAsync(message);
            await repository.SaveChangesAsync();
            var user = await repository.AllReadOnly<User>().FirstOrDefaultAsync(u => u.Id == userId);

            MessageViewModel createdMessage = new MessageViewModel()
            {
                Content = message.Content,
                FromFullName = user.FirstName + " " + user.LastName,
                FromUserName = user.UserName,
                Id = message.Id,
                Room = room.Name,
                Timestamp = message.Timestamp,
                Avatar = "fillUserAvatar"
            };

            if (hubContext is not null)
            {
                await hubContext.Clients.Group(room.Name).SendAsync("newMessage", createdMessage);
            }

            return createdMessage;
        }

        public async Task<bool> Delete(int id, string userId)
        {
            var message = await repository.All<Message>()
                                        .Include(u => u.Sender)
                                        .FirstOrDefaultAsync(m => m.Id == id && m.SenderId == userId && !m.IsDeleted);

            if (message == null)
                return false;

            message.IsDeleted = true;
            await repository.SaveChangesAsync();

            if (hubContext is not null)
            {
                await hubContext.Clients.All.SendAsync("removeChatMessage", message.Id);
            }
            return true;
        }
    }
}
