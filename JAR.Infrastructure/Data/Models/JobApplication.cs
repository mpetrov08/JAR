using Microsoft.AspNetCore.Identity;
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
        public User User { get; set; } = null!;

        [Required]
        [Comment("Job Application Is Approved")]
        public bool IsApproved { get; set; }

        [MaxLength(JobApplicationMessageMaxLength)]
        [Comment("Job Application Message")]
        public string Message { get; set; } = string.Empty;

        [Required]
        [Comment("When Job Application has been applied")]
        public DateTime AppliedOn { get; set; }  
    }
}
