using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAR.Core.Models.Company
{
    public class CompanyApproveViewModel : CompanyViewModel
    {
        public string UIC {  get; set; } = string.Empty;

        public string Country { get; set; } = string.Empty;

        public bool IsApproved { get; set; }

        public bool IsDeleted { get; set; }
    }
}
