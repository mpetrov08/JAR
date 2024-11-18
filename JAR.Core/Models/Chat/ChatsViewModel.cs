using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAR.Core.Models.Chat
{
    public class ChatsViewModel
    {
        public ProfileViewModel Profile { get; set; } = null!;
        
        public IEnumerable<RoomViewModel> Rooms { get; set; } = new List<RoomViewModel>();
    }
}
