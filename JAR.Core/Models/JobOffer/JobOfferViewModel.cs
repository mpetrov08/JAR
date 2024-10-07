using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAR.Core.Models.JobOffer
{
    public class JobOfferViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public string RequiredLanguage { get; set; } = null!;

        public string RequiredDegree { get; set; } = null!;

        public string RequiredExperience { get; set; } = null!;

        public string RequiredSkills { get; set; } = string.Empty;

        public decimal Salary { get; set; }

        public string CreatedOn { get; set; } = string.Empty;
    }
}
