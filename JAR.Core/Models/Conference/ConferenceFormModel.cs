using JAR.Core.Models.Lecturer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JAR.Infrastructure.Constants.DataConstants;

namespace JAR.Core.Models.Conference
{
    public class ConferenceFormModel
    {
        [Required]
        public int LecturerId { get; set; }

        public IEnumerable<LecturerOptionViewModel> Lecturers { get; set; } = new List<LecturerOptionViewModel>();

        [Required]
        [StringLength(ConferenceTopicMaxLength,
            MinimumLength = ConferenceTopicMinLength)]
        public string Topic { get; set; } = null!;

        [Required]
        public string Start { get; set; } = null!;

        [Required]
        public string End { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength,
            MinimumLength = DescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required]
        [Display(Name = "Conference Link (e.g., Zoom, Google Meets, etc.)")]
        public string ConferenceUrl { get; set; } = null!;
    }
}
