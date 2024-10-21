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
    public class Degree
    {
        [Key]
        [Comment("Degree Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(DegreeEducationalInstitutionMaxLength)]
        [Comment("Educational Institution where the user studied")]
        public string EducationalInstitution { get; set; } = string.Empty;

        [Required]
        [MaxLength(DegreeMajorMaxLength)]
        [Comment("Major that the user have studied")]
        public string Major { get; set; } = string.Empty;

        [Required]
        [MaxLength(DegreeEducationLevelMaxLength)]
        [Comment("Education Level Degree")]
        public string EducationLevel { get; set; } = string.Empty;

        [Required]
        [MaxLength(CityMaxLength)]
        [Comment("City where the user learned")]
        public string City { get; set; } = string.Empty;

        [Required]
        [Comment("The degree start date")]
        public DateTime StartDate { get; set; }

        [Required]
        [Comment("The degree end date")]
        public DateTime EndDate { get; set; }

        [Required]
        [MaxLength(DescriptionMaxLength)]
        [Comment("The description of degree")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Comment("Foreign key of CV")]
        public int CVId { get; set; }

        [ForeignKey(nameof(CVId))]
        public CV CV { get; set; } = null!;
    }
}
