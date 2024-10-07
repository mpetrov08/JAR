using JAR.Core.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAR.Core.Models.JobOffer
{
    public class JobOffersFilterModel
    {
        public int JobOffersPerPage = 3;

        public string Category { get; set; } = string.Empty;

        public string JobType {  get; set; } = string.Empty;

        [Display(Name = "Search by text")]
        public string SearchTerm { get; set; } = string.Empty;

        public JobOfferSorting Sorting { get; set; }

        public int CurrentPage { get; set; } = 1;

        public int TotalJobOffersCount { get; set; }

        public IEnumerable<string> Categories { get; set; } = null!;

        public IEnumerable<string> JobTypes { get; set; } = null!;

        public IEnumerable<JobOfferViewModel> JobOffers { get; set; } = new List<JobOfferViewModel>();
    }
}
