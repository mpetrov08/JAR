using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAR.Core.Models.CV
{
    public class DegreeViewModel
    {
        public string EducationalInstitution { get; set; } = null!;

        public string Major { get; set; } = null!;

        public string EducationalLevel { get; set; } = null!;

        public string City { get; set; } = null!;

        public string StartDate { get; set; } = null!;

        public string EndDate { get; set; } = null!;    

        public string Description { get; set; } = null!;
    }
}
