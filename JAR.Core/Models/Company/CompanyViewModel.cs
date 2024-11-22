using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAR.Core.Models.Company
{
    public class CompanyViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Address { get; set; } = null!;

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string OwnerName { get; set; } = null!;

        public string LogoUrl { get; set; } = null!;
    }
}
