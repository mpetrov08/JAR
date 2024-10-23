using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JAR.Infrastructure.Constants.DataConstants;

namespace JAR.Core.Models.CV
{
    public class ProfessionalExperienceFormModel
    {
        [Required]
        [StringLength(CompanyNameMaxLength,
            MinimumLength = CompanyNameMinLength)]
        public string CompanyName { get; set; } = null!;

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
