using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAR.Infrastructure.Data.Models
{
    public class Message
    {
        [Key]
        [Comment("Message Identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("Message Content")]
        public string Content { get; set; } = string.Empty;

        [Required]
        [Comment("Message Timestamp")]
        public DateTime Timestamp { get; set; }

        [Required]
        [Comment("Foreign key of user(sender)")]
        public string SenderId { get; set; } = string.Empty ;

        [ForeignKey(nameof(SenderId))]
        public User Sender { get; set; } = null!;

        [Required]
        [Comment("Foreign key of room")]
        public int RoomId { get; set; }

        [ForeignKey(nameof(RoomId))]
        public Room Room { get; set; } = null!;

        [Required]
        [Comment("Checks if the Message has been deleted")]
        public bool IsDeleted { get; set; }
    }
}
