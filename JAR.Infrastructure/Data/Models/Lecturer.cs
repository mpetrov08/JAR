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
    public class Lecturer
    {
        [Key]
        [Comment("Lecturer Identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("Foreign key of user")]
        public string UserId {  get; set; } = string.Empty;

        [ForeignKey(nameof(UserId))]
        public User User { get; set; } = null!;
        
        [Required]
        [MaxLength(DescriptionMaxLength)]
        [Comment("Lecturer`s Description")]
        public string Description { get; set; }= string.Empty;

        public IEnumerable<Conference> Conferences { get; set; } = new List<Conference>();
    }
}
