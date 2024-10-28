using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static JAR.Infrastructure.Constants.DataConstants;

namespace JAR.Core.Models.Company
{
    public class CompanyRegisterModel
    {
        [Required]
        [StringLength(CompanyNameMaxLength,
            MinimumLength = CompanyNameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        public string Logo { get; set; } = null!;

        [Required]
        [StringLength(CompanyUICMaxLength,
            MinimumLength = CompanyUICMinLength)]
        public string UIC { get; set; } = null!;

        [Required]
        [StringLength(CountryMaxLength,
            MinimumLength = CountryMinLength)]
        public string Country { get; set; } = null!;

        [Required]
        [StringLength(AddressMaxLength,
            MinimumLength = AddressMinLength)]
        public string Address { get; set; } = null!;

        [Required]
        [StringLength(PhoneNumberMaxLength,
            MinimumLength = PhoneNumberMinLength)]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [StringLength(CompanyEmailMaxLength,
            MinimumLength = CompanyEmailMinLength)]
        public string Email { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength,
            MinimumLength = DescriptionMinLength)]
        public string Description { get; set; } = null!;
    }
}
