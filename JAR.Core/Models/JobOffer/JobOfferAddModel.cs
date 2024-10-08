using JAR.Core.Models.Category;
using JAR.Core.Models.JobType;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JAR.Infrastructure.Constants.DataConstants;

namespace JAR.Core.Models.JobOffer
{
    public class JobOfferAddModel
    {
        [Required]
        [StringLength(JobOfferTitleMaxLength, 
            MinimumLength = JobOfferTitleMinLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(JobOfferDescriptionMaxLength,
            MinimumLength = JobOfferDescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required]
        [StringLength(AddressMaxLength,
            MinimumLength = AddressMinLength)]
        public string Address { get; set; } = null!;

        [Required]
        [Range(typeof(decimal), 
            JobOfferMinSalary, 
            JobOfferMaxSalary, 
            ConvertValueInInvariantCulture = true,
            ErrorMessage = "The salary must be between {2} and {1}")]
        public decimal Salary { get; set; }

        [StringLength(JobOfferRequiredMaxLength,
            MinimumLength = JobOfferRequiredMinLength)]
        [Display(Name = "Required Language")]
        public string RequiredLanguage { get; set; } = null!;

        [StringLength(JobOfferRequiredMaxLength,
            MinimumLength = JobOfferRequiredMinLength)]
        [Display(Name = "Required Degree")]
        public string RequiredDegree { get; set; } = null!;

        [StringLength(JobOfferRequiredMaxLength,
            MinimumLength = JobOfferRequiredMinLength)]
        [Display(Name = "Required Experience")]
        public string RequiredExperience { get; set; } = null!;

        [Required]
        [StringLength(JobOfferRequiredMaxLength,
            MinimumLength = JobOfferRequiredMinLength)]
        [Display(Name = "Required Skills")]
        public string RequiredSkills { get; set; } = null!;

        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public IEnumerable<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();

        [Required]
        [Display(Name = "Job Type")]
        public int JobTypeId { get; set; }

        public IEnumerable<JobTypeViewModel> JobTypes { get; set; } = new List<JobTypeViewModel>();
    }
}
