using JAR.Core.Models.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAR.Core.Models.JobOffer
{
    public class JobOfferDetailsViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public string RequiredLanguage { get; set; } = string.Empty;

        public string RequiredDegree { get; set; } = string.Empty;

        public string RequiredExperience { get; set; } = string.Empty;

        public string RequiredSkills { get; set; } = string.Empty;

        public decimal Salary { get; set; }

        public string CreatedOn { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Category {  get; set; } = string.Empty;

        public string JobType {  get; set; } = string.Empty;

        public CompanyViewModel Company { get; set; } = null!;
    }
}
