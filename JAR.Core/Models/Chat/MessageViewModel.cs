using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAR.Core.Models.Chat
{
    public class MessageViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; } = null!;

        public DateTime Timestamp { get; set; }

        public string FromUserName { get; set; } = null!;

        public string FromFullName { get; set; } = null!;

        [Required]
        public string Room { get; set; } = null!;

        public string Avatar { get; set; } = null!;
    }
}
