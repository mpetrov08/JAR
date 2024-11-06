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
    public class ProfessionalExperience
    {
        [Key]
        [Comment("Professional Experience Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(CompanyNameMaxLength)]
        [Comment("Name of the company where the user worked")]
        public string CompanyName { get; set; } = string.Empty;

        [Required]
        [MaxLength(CityMaxLength)]
        [Comment("The city where the user worked")]
        public string City {  get; set; } = string.Empty;

        [Required]
        [Comment("The date the user started working")]
        public DateTime StartDate { get; set; }

        [Required]
        [Comment("The date the user ended working")]
        public DateTime EndDate { get; set; }

        [Required]
        [MaxLength(DescriptionMaxLength)]
        [Comment("Description of professional experience")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Comment("Checks if the Professional Experience has been deleted")]
        public bool IsDeleted { get; set; }

        [Required]
        [Comment("CV Foreign Key")]
        public int CVId { get; set; }

        [ForeignKey(nameof(CVId))]
        public CV CV { get; set; } = null!;
    }
}
