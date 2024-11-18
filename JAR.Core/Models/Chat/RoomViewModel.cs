using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JAR.Infrastructure.Constants.DataConstants;

namespace JAR.Core.Models.Chat
{
    public class RoomViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(RoomNameMaxLength,
            MinimumLength = RoomNameMinLength)]
        [RegularExpression(@"^\w+( \w+)*$")]
        public string Name { get; set; } = null!;

        public string Admin { get; set; } = null!;

        public string? LastMessage { get; set; }

        public string TimeStamp { get; set; } = null!;
    }
}
