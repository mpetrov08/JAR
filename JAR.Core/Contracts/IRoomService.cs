using JAR.Core.Enumerations;
using JAR.Core.Models.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAR.Core.Contracts
{
    public interface IRoomService
    {
        public Task<IEnumerable<RoomViewModel>> GetAllAsync(string userId);

        public Task<RoomViewModel?> GetByIdAsync(int id, string userId);

        public Task<RoomViewModel?> CreateAsync(RoomViewModel viewModel, string userId, string companyOwnerId);

        public Task<HttpError> EditAsync(int id, RoomViewModel viewModel, string userId);

        public Task<bool> DeleteAsync(int id, string userId);

        public Task<bool> AddUserAsync(int roomId, string userId);

        public Task<ChatsViewModel> GetChatsViewModelAsync(string userId);

        public Task<bool> ExistsAsync(string jobTitle, string userId);
    }
}
