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
    public class JobApplicationApproveViewModel : JobOfferApplicantViewModel
    {
        [Required]
        [StringLength(JobApplicationMessageMaxLength,
            MinimumLength = JobOfferDescriptionMinLength)]
        public string Message { get; set; } = null!;
    }
}
