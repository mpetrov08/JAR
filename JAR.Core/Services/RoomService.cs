using JAR.Core.Contracts;
using JAR.Core.Enumerations;
using JAR.Core.Hubs;
using JAR.Core.Models.Chat;
using JAR.Infrastructure.Data.Models;
using JAR.Infrastructure.Repository;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace JAR.Core.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRepository repository;
        private readonly IHubContext<ChatHub>? hubContext;

        public RoomService(IRepository _repository, IHubContext<ChatHub>? _hubContext)
        {
            repository = _repository;
            hubContext = _hubContext;
        }

        private async Task<ProfileViewModel> GetCurrentUserProfile(string id)
        {
            var user = await repository.AllReadOnly<User>().FirstOrDefaultAsync(u => u.Id == id);
            return new ProfileViewModel()
            {
                Name = user.FirstName + " " + user.LastName,
            };
        }

        public async Task<ChatsViewModel> GetChatsViewModelAsync(string userId)
        {
            ProfileViewModel profile = await GetCurrentUserProfile(userId);
            return new ChatsViewModel()
            {
                Profile = profile,
                Rooms = await GetAllAsync(userId)
            };
        }

        public async Task<IEnumerable<RoomViewModel>> GetAllAsync(string userId)
        {
            var rooms = await repository.AllReadOnly<Room>()
                .Include(r => r.Admin)
                .Include(r => r.Messages)
                .Where(r => !r.IsDeleted && (r.Users.Any(u => u.UserId == userId) || r.AdminId == userId))
                .ToListAsync();

            return rooms.Select(room =>
            {
                var lastMessage = room.Messages.OrderBy(m => m.Timestamp).FirstOrDefault();
                return new RoomViewModel
                {
                    Admin = room.Admin.Id,
                    Id = room.Id,
                    Name = room.Name,
                    LastMessage = room.Messages.OrderBy(m => m.Timestamp).FirstOrDefault() == null ? "" : room.Messages.OrderByDescending(m => m.Timestamp).FirstOrDefault().Content,
                    TimeStamp = room.Messages.OrderBy(m => m.Timestamp).FirstOrDefault() == null ? "" : room.Messages.OrderBy(m => m.Timestamp).FirstOrDefault().Timestamp.ToString("MM/dd/yyyy") ?? ""
                };
            });
        }

        public async Task<RoomViewModel?> GetByIdAsync(int id, string userId)
        {
            var room = await repository.AllReadOnly<Room>()
                .Where(r => !r.IsDeleted && r.Users.Any(u => u.UserId == userId))
                .Include(r => r.Admin)
                .Include(r => r.Messages)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (room == null)
                return null;

            var adminName = room.Admin != null ? room.Admin.FirstName + " " + room.Admin.LastName : "Unknown Admin";
            var lastMessage = room.Messages?
                .OrderBy(m => m.Timestamp)
                .FirstOrDefault();

            return new RoomViewModel()
            {
                Admin = adminName,
                Id = room.Id,
                Name = room.Name,
                LastMessage = lastMessage?.Content ?? "",
                TimeStamp = lastMessage?.Timestamp.ToString("MM/dd/yyyy") ?? ""
            };
        }

        public async Task<RoomViewModel?> CreateAsync(RoomViewModel viewModel, string userId, string companyOwnerId)
        {
            viewModel.Name = await GenerateUniqueRoomName(viewModel.Name);

            if (repository.AllReadOnly<Room>().Where(r => !r.IsDeleted).Any(r => r.Name == viewModel.Name))
            {
                return null;
            }   

            var room = new Room()
            {
                Name = viewModel.Name,
                AdminId = companyOwnerId
            };

            await repository.AddAsync(room);
            await repository.SaveChangesAsync();

            var newRoom = await repository.AllReadOnly<Room>().FirstAsync(r => r.Name == viewModel.Name);
            var roomId = newRoom.Id;

            await AddUserAsync(roomId, userId);
            await AddUserAsync(roomId, companyOwnerId);

            room.Admin = await repository.All<User>().FirstOrDefaultAsync(u => u.Id == companyOwnerId);

            var createdRoom = new RoomViewModel()
            {
                Admin = room.Admin.FirstName + " " + room.Admin.LastName,
                Id = room.Id,
                Name = room.Name,
                LastMessage = "",
                TimeStamp = ""
            };
            if (hubContext is not null)
            {
                await hubContext.Clients.All.SendAsync("addChatRoom", createdRoom);
            }

            return createdRoom;
        }

        public async Task<HttpError> EditAsync(int id, RoomViewModel viewModel, string userId)
        {
            if (repository.AllReadOnly<Room>().Where(r => !r.IsDeleted).Any(r => r.Name == viewModel.Name))
                return HttpError.NotFound;

            var room = await repository.All<Room>()
                .Include(r => r.Admin)
                .Include(r => r.Messages)
                .Where(r => r.Id == id && r.AdminId == userId && !r.IsDeleted)
                .FirstOrDefaultAsync();

            if (room == null)
                return HttpError.NotFound;

            room.Name = viewModel.Name;
            await repository.SaveChangesAsync();

            var updatedRoom = new RoomViewModel()
            {
                Admin = room.Admin.FirstName + " " + room.Admin.LastName,
                Id = room.Id,
                Name = room.Name,
                LastMessage = room.Messages.MinBy(m => m.Timestamp) is null ? "" : room.Messages.MinBy(m => m.Timestamp).Content,
                TimeStamp = room.Messages.MinBy(m => m.Timestamp) is null ? "" : room.Messages.MinBy(m => m.Timestamp).Timestamp.ToString("MM/dd/yyyy")
            };
            if (hubContext is not null)
            {
                await hubContext.Clients.All.SendAsync("updateChatRoom", updatedRoom);
            }

            return HttpError.Ok;
        }

        public async Task<bool> DeleteAsync(int id, string userId)
        {
            var room = await repository.All<Room>()
                .Include(r => r.Admin)
                .Where(r => r.Id == id && r.AdminId == userId && !r.IsDeleted)
                .FirstOrDefaultAsync();

            if (room == null)
                return false;

            room.IsDeleted = true;
            await repository.SaveChangesAsync();

            if (hubContext is not null)
            {
                await hubContext.Clients.All.SendAsync("removeChatRoom", room.Id);
                await hubContext.Clients.Group(room.Name).SendAsync("onRoomDeleted");
            }

            return true;
        }

        public async Task<bool> AddUserAsync(int roomId, string userId)
        {
            var room = await repository.All<Room>()
                                    .Include(r => r.Users)
                                    .Where(r => !r.IsDeleted && r.Id == roomId)
                                    .FirstOrDefaultAsync();
            if (room == null)
            {
                return false;
            }

            if (room.Users.Any(u => u.UserId == userId))
            {
                return false;
            }

            var roomUser = new RoomUser()
            {
                RoomId = roomId,
                UserId = userId
            };

            await repository.AddAsync(roomUser);

            await repository.SaveChangesAsync();
            return true;
        }

        private async Task<string> GenerateUniqueRoomName(string baseName)
        {
            int counter = 1;
            string uniqueName = $"{baseName}_{counter}";

            while (await repository.AllReadOnly<Room>().AnyAsync(r => r.Name == uniqueName))
            {
                uniqueName = $"{baseName}_{counter}";
                counter++;
            }

            return uniqueName;
        }

        public async Task<bool> ExistsAsync(string jobTitle, string userId)
        {
            var roomUser = await repository
                .AllReadOnly<RoomUser>()
                .FirstOrDefaultAsync(ru => ru.UserId == userId && ru.Room.Name.Contains(jobTitle));

            return roomUser != null;
        }
    }
}
