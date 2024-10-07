using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAR.Core.Models.JobOffer
{
    public class JobOfferResultModel
    {
        public int TotalJobOfferCount { get; set; }

        public IEnumerable<JobOfferViewModel> JobOffers { get; set; } = new List<JobOfferViewModel>();
    }
}
