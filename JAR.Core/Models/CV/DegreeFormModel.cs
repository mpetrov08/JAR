using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JAR.Infrastructure.Constants.DataConstants;

namespace JAR.Core.Models.CV
{
    public class DegreeFormModel
    {
        [Required]
        [StringLength(DegreeEducationalInstitutionMaxLength,
            MinimumLength = DegreeEducationalInstitutionMinLength)]
        public string EducationalInstitution { get; set; } = null!;

        [Required]
        [StringLength(DegreeMajorMaxLength,
            MinimumLength = DegreeMajorMinLength)]
        public string Major { get; set; } = null!;

        [Required]
        [StringLength(DegreeEducationLevelMaxLength,
            MinimumLength = DegreeEducationLevelMinLength)]
        public string EducationalLevel { get; set; } = null!;

        [Required]
        [StringLength(CityMaxLength,
            MinimumLength = CityMinLength)]
        public string City { get; set; } = null!;

        [Required]
        public string StartDate { get; set; } = null!;

        [Required]
        public string EndDate { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength,
            MinimumLength = DescriptionMinLength)]
        public string Description { get; set; } = null!;
    }
}
