using Microsoft.AspNetCore.Identity;
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
    public class CV
    {
        [Key]
        [Comment("CV Identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("Foreign key of User")]
        public string UserId { get; set; } = string.Empty;

        [ForeignKey(nameof(UserId))]
        public User User { get; set; } = null!;

        [Required]
        [MaxLength(NameMaxLength)]
        [Comment("First Name")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(NameMaxLength)]
        [Comment("Last Name")]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [MaxLength(CVLinkedInProfileMaxLength)]
        [Comment("LinkedIn Profile Link")]
        public string LinkedInProfile { get; set; } = string.Empty;

        [Required]
        [MaxLength(PhoneNumberMaxLength)]
        [Comment("Users Phone Number")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        [MaxLength(AddressMaxLength)]
        [Comment("Users Address")]
        public string Address { get; set; } = string.Empty;

        [Required]
        [MaxLength(CVGenderMaxLength)]
        [Comment("Users Gender")]
        public string Gender { get; set; } = string.Empty;

        [Required]
        [Comment("Birthday Date of the user")]
        public DateTime BirthDate { get; set; }

        [Required]
        [MaxLength(CVCitizenshipMaxLength)]
        [Comment("Citizenship of the user")]
        public string Citizenship { get; set; } = string.Empty;

        [Required]
        [Comment("Photo of the user")]
        public string Photo { get; set; } = string.Empty;

        [Required]
        [MaxLength(CVLanguagesMaxLength)]
        [Comment("All languages and their levels that user knows")]
        public string Languages { get; set; } = string.Empty;

        [Required]
        [MaxLength(CVSkillsMaxLength)]
        [Comment("Skills that user has")]
        public string Skills { get; set; } = string.Empty;

        [MaxLength(CVDrivingLicenseCategoryLength)]
        [Comment("Driving License Category that user has")]
        public string? DrivingLicenseCategory { get; set; }

        public IEnumerable<Degree> Degrees { get; set; } = new List<Degree>();

        public IEnumerable<ProfessionalExperience> ProfessionalExperiences { get; set; } = new List<ProfessionalExperience>();
    }
}
