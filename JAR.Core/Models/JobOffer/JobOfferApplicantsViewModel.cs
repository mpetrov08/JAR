using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAR.Core.Models.JobOffer
{
    public class JobOfferApplicantsViewModel
    {
        public string UserId { get; set; } = null!;

        public int JobId { get; set; }

        public string Email { get; set; } = null!;

        public bool IsApproved { get; set; }

        public string AppliedOn { get; set; } = null!;
    }
}
