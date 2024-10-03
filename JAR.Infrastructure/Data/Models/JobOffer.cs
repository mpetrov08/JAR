using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JAR.Infrastructure.Constants.DataConstants;

namespace JAR.Infrastructure.Data.Models
{
    [Comment("Job Offer")]
    public class JobOffer
    {
        [Key]
        [Comment("Job Offer Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(JobOfferTitleMaxLength)]
        [Comment("Job Offer Title")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(JobOfferDescriptionMaxLength)]
        [Comment("Job Offer Description")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [MaxLength(AddressMaxLength)]
        [Comment("Job Offer Address")]
        public string Address { get; set; } = string.Empty;

        [Required]
        [Range(typeof(decimal), JobOfferMinSalary, JobOfferMaxSalary, ConvertValueInInvariantCulture = true)]
        [Comment("Job Offer Salary")]
        public decimal Salary { get; set; }

        [MaxLength(JobOfferRequiredMaxLength)]
        [Comment("Job Offer Required Language")]
        public string RequiredLanguage { get; set; } = string.Empty;

        [MaxLength(JobOfferRequiredMaxLength)]
        [Comment("Job Offer Required Degree")]
        public string RequiredDegree { get; set; } = string.Empty;

        [MaxLength(JobOfferRequiredMaxLength)]
        [Comment("Job Offer Required Experience")]
        public string RequiredExperience { get; set; } = string.Empty;

        [MaxLength(JobOfferRequiredMaxLength)]
        [Comment("Job Offer Required Skills")]
        public string RequiredSkills { get; set; } = string.Empty;

        [Required]
        [Comment("When Job Offer was created")]
        public DateTime CreatedOn { get; set; }

        [Required]
        [Comment("Checks if the Job Offer has been deleted")]
        public bool IsDeleted { get; set; }

        [Required]
        [Comment("Job Offer Category Identifier")]
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;

        [Required]
        [Comment("Job Offer Type Identifier")]
        public int JobTypeId { get; set; }

        [ForeignKey(nameof(JobTypeId))]
        public JobType JobType { get; set; } = null!;

        [Required]
        [Comment("Job Offer Company Identifier")]
        public int CompanyId { get; set; }

        [ForeignKey(nameof(CompanyId))]
        public Company Company { get; set; } = null!;

        public IEnumerable<JobApplication> JobApplications { get; set; } = new List<JobApplication>();
    }
}