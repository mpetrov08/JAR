using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAR.Infrastructure.Data.Models
{
    public class ConferenceUser
    {
        [Required]
        [Comment("Foreign key of conference")]
        public int ConferenceId { get; set; }

        [ForeignKey(nameof(ConferenceId))]
        public Conference Conference { get; set; } = null!;

        [Required]
        [Comment("Foreign key of user")]
        public string UserId { get; set; } = string.Empty;

        [ForeignKey(nameof(UserId))]
        public User User { get; set; } = null!;
    }
}
