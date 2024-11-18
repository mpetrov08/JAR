using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAR.Core.Models.User
{
    public class UserChatModel
    {
        public string UserName { get; set; } = string.Empty;

        public string FullName { get; set; } = string.Empty;

        public string CurrentRoom { get; set; } = string.Empty;
    }
}
