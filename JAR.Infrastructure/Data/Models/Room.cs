using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JAR.Infrastructure.Constants.DataConstants;

namespace JAR.Infrastructure.Data.Models
{
    public class Room
    {
        [Key]
        [Comment("Room Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(RoomNameMaxLength)]
        [Comment("Room`s Name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Comment("Foreign key of room`s Admin")]
        public string AdminId { get; set; } = string.Empty;

        [ForeignKey(nameof(AdminId))]
        public User Admin { get; set; } = null!;

        [Required]
        [Comment("Checks if the Room has been deleted")]
        public bool IsDeleted { get; set; }

        public IEnumerable<Message> Messages { get; set; } = new List<Message>();

        public IEnumerable<RoomUser> Users { get; set; } = new List<RoomUser>();
    }
}
