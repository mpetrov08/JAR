using JAR.Core.Models.JobOffer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JAR.Infrastructure.Constants.DataConstants;

namespace JAR.Core.Models.JobApplication
{
    public class JobApplicationApproveViewModel
    {
        public string UserId { get; set; } = null!;

        public int JobId { get; set; }

        public string Email { get; set; } = null!;

        public bool IsApproved { get; set; }

        public string AppliedOn { get; set; } = null!;

        [Required]
        [StringLength(JobApplicationMessageMaxLength,
            MinimumLength = JobOfferDescriptionMinLength)]
        public string Message { get; set; } = null!;
    }
}
