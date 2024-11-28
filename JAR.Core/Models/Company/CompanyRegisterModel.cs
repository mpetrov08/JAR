using Microsoft.AspNetCore.Http;
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
        public IFormFile Image { get; set; } = null!;

        public string? LogoUrl { get; set; }

        [Required]
        [StringLength(CompanyUICMaxLength,
            MinimumLength = CompanyUICMinLength)]
        [Display(Name = "Unique Identification Code")]
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
        [Display(Name = "Phone Number")]
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
