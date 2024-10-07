using JAR.Core.Models.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAR.Core.Models.JobOffer
{
    public class JobOfferDetailsViewModel : JobOfferViewModel
    {
        public string Description { get; set; } = string.Empty;

        public string Category {  get; set; } = string.Empty;

        public string JobType {  get; set; } = string.Empty;

        public CompanyViewModel Company { get; set; } = null!;
    }
}
