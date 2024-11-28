using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JAR.Infrastructure.Constants.DataConstants;

namespace JAR.Core.Models.CV
{
    public class CVFormModel
    {
        [Required]
        [StringLength(NameMaxLength,
            MinimumLength = NameMinLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(NameMaxLength,
            MinimumLength = NameMinLength)]
        public string LastName { get; set; } = null!;

        [Required]
        [StringLength(EmailMaxLength,
            MinimumLength = EmailMinLength)]
        public string Email { get; set; } = null!;

        [Required]
        [StringLength(CVLinkedInProfileMaxLength,
            MinimumLength = CVLinkedInProfileMinLength)]
        public string LinkedInProfile { get; set; } = null!;

        [Required]
        [StringLength(PhoneNumberMaxLength,
            MinimumLength = PhoneNumberMinLength)]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [StringLength(AddressMaxLength,
            MinimumLength = AddressMinLength)]
        public string Address { get; set; } = null!;

        [Required]
        [StringLength(CVGenderMaxLength,
            MinimumLength = CVGenderMinLength)]
        public string Gender { get; set; } = null!;

        [Required]
        public string BirthDate { get; set; } = null!;

        [Required]
        [StringLength(CVCitizenshipMaxLength,
            MinimumLength = CVCitizenshipMinLength)]
        public string Citizenship { get; set; } = null!;

        public IFormFile? Image { get; set; }

        public string? PhotoUrl { get; set; }

        [Required]
        [StringLength(CVLanguagesMaxLength,
            MinimumLength = CVLanguagesMinLength)]
        public string Languages { get; set; } = null!;

        [Required]
        [StringLength(CVSkillsMaxLength,
            MinimumLength = CVSkillsMinLength)]
        public string Skills { get; set; } = null!;

        [StringLength(CVDrivingLicenseCategoryLength)]
        public string? DrivingLicense { get; set; }

        public string? DegreesJson { get; set; }
        public IEnumerable<DegreeFormModel> Degrees { get; set; } = new List<DegreeFormModel>();

        public string? ProfessionalExperiencesJson { get; set; }
        public IEnumerable<ProfessionalExperienceFormModel> ProfessionalExperiences { get; set; } = new List<ProfessionalExperienceFormModel>();
    }
}
