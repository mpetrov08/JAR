using JAR.Core.Models.Category;
using JAR.Core.Models.JobType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAR.Core.Models.JobOffer
{
    public class JobOfferAddModel
    {
        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string Address { get; set; } = null!;

        public decimal Salary { get; set; }

        public string RequiredLanguage { get; set; } = null!;

        public string RequiredDegree { get; set; } = null!;

        public string RequiredExperience { get; set; } = null!;

        public string RequiredSkills { get; set; } = null!;

        public int CategoryId { get; set; }

        public IEnumerable<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();

        public int JobTypeId { get; set; }

        public IEnumerable<JobTypeViewModel> JobTypes { get; set; } = new List<JobTypeViewModel>();
    }
}
