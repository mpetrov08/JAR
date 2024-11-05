using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAR.Core.Models.CV
{
    public class CVViewModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string LinkedInProfile { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public string Address { get; set; } = null!;

        public string Gender { get; set; } = null!;

        public string BirthDate { get; set; } = null!;

        public string Citizenship { get; set; } = null!;

        public string PhotoUrl { get; set; } = null!;

        public string Languages { get; set; } = null!;

        public string Skills { get; set; } = null!;
         
        public string? DrivingLicenseCategory { get; set; }

        public IEnumerable<DegreeViewModel> Degrees { get; set; } = new List<DegreeViewModel>();

        public IEnumerable<ProfessionalExperienceViewModel> ProfessionalExperiences { get; set; } = new List<ProfessionalExperienceViewModel>();
    }
}
