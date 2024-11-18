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
        public Task<IEnumerable<RoomViewModel>> GetAll(string userId);

        public Task<RoomViewModel?> GetById(int id, string userId);

        public Task<RoomViewModel?> Create(RoomViewModel viewModel, string userId, string companyOwnerId);

        public Task<HttpError> Edit(int id, RoomViewModel viewModel, string userId);

        public Task<bool> Delete(int id, string userId);

        public Task<bool> AddUser(int roomId, string userId);

        public Task<ChatsViewModel> GetChatsViewModel(string userId);
    }
}
