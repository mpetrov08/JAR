using JAR.Core.Models.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAR.Core.Contracts
{
    public interface IMessageService
    {
        public Task<MessageViewModel?> GetByIdAsync(int id);

        public Task<int>? GetRoomIdByNameAsync(string name);

        public Task<IEnumerable<MessageViewModel>?> GetMessagesAsync(string roomName);

        public Task<MessageViewModel?> CreateAsync(MessageViewModel viewModel, string userId);

        public Task<bool> DeleteAsync(int id, string userId);
    }
}
