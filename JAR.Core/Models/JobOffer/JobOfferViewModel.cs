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

        [Required]
        [StringLength(JobOfferTitleMaxLength,
            MinimumLength = JobOfferTitleMinLength)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(AddressMaxLength,
            MinimumLength = AddressMinLength)]
        public string Address { get; set; } = string.Empty;

        [StringLength(JobOfferRequiredMaxLength,
            MinimumLength = JobOfferRequiredMinLength)]
        public string RequiredLanguage { get; set; } = string.Empty;

        [StringLength(JobOfferRequiredMaxLength,
            MinimumLength = JobOfferRequiredMinLength)]
        public string RequiredDegree { get; set; } = string.Empty;

        [StringLength(JobOfferRequiredMaxLength,
            MinimumLength = JobOfferRequiredMinLength)]
        public string RequiredExperience { get; set; } = string.Empty;

        [Required]
        [StringLength(JobOfferRequiredMaxLength,
            MinimumLength = JobOfferRequiredMinLength)]
        public string RequiredSkills { get; set; } = string.Empty;

        [Required]
        [Range(typeof(decimal), 
            JobOfferMinSalary, 
            JobOfferMaxSalary, 
            ConvertValueInInvariantCulture = true,
            ErrorMessage = "The salary must be between {2} and {1}")]
        public decimal Salary { get; set; }

        [Required]
        public string CreatedOn { get; set; } = string.Empty;

        [Required]
        public string CompanyLogo {  get; set; } = string.Empty;
    }
}
