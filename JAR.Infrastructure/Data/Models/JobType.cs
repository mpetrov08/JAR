using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JAR.Infrastructure.Constants.DataConstants;

namespace JAR.Infrastructure.Data.Models
{
    [Comment("Job Type")]
    public class JobType
    {
        [Key]
        [Comment("Job Type Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(JobTypeNameMaxLength)]
        [Comment("Job Type Name")]
        public string Name { get; set; } = string.Empty;

        public IEnumerable<JobOffer> JobOffers { get; set; } = new List<JobOffer>();
    }
}
