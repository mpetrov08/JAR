using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JAR.Infrastructure.Constants.DataConstants;

namespace JAR.Infrastructure.Data.Models
{
    public class Conference
    {
        [Key]
        [Comment("Conference Identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("Foreign Key of Lecturer")]
        public int LecturerId { get; set; }

        [ForeignKey(nameof(LecturerId))]
        public Lecturer Lecturer { get; set; } = null!;

        [Required]
        [MaxLength(ConferenceTopicMaxLength)]
        [Comment("Conference`s topic")]
        public string Topic { get; set; } = string.Empty;

        [Required]
        [Comment("Start time of the conference")]
        public DateTime Start {  get; set; }

        [Required]
        [Comment("End time of the conference")]
        public DateTime End { get; set; }

        [Required]
        [MaxLength(DescriptionMaxLength)]
        [Comment("Conference`s Description")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Comment("Checks if the Conference has been deleted")]
        public bool IsDeleted { get; set; }
    }
}
