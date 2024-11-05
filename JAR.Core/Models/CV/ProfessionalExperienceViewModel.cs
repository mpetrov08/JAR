using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAR.Core.Models.CV
{
    public class ProfessionalExperienceViewModel
    {
        public string CompanyName { get; set; } = null!;

        public string City { get; set; } = null!;

        public string StartDate { get; set; } = null!;

        public string EndDate { get; set; } = null!;

        public string Description { get; set; } = null!;
    }
}
