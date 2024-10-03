using Microsoft.AspNetCore.Identity;
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
    [Comment("Job Applications")]
    public class JobApplication
    {
        [Required]
        [Comment("Job Offer Identifier")]
        public int JobOfferId { get; set; }

        [ForeignKey(nameof(JobOfferId))]
        public JobOffer JobOffer { get; set; } = null!;

        [Required]
        [Comment("User Identifier")]
        public string UserId { get; set; } = string.Empty;

        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; } = null!;

        [Required]
        [Comment("When Job Application has been applied")]
        public DateTime AppliedOn { get; set; }  
    }
}
