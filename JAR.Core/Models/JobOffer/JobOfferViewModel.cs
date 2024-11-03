using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JAR.Infrastructure.Constants.DataConstants;

namespace JAR.Core.Models.JobOffer
{
    public class JobOfferViewModel
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

        public string CompanyLogo {  get; set; } = string.Empty;
    }
}
