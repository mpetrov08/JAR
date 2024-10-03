﻿using Microsoft.AspNetCore.Identity;
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
    [Comment("Company")]
    public class Company
    {
        [Key]
        [Comment("Company Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(CompanyNameMaxLength)]
        [Comment("Company Name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(AddressMaxLength)]
        [Comment("Company Address")]
        public string Address { get; set; } = string.Empty;

        [Required]
        [MaxLength(CompanyPhoneNumberMaxLength)]
        [Comment("Company PhoneNumber")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [MaxLength(AddressMaxLength)]
        [Comment("Company Email")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MaxLength(CompanyDescriptionMaxLength)]
        [Comment("Company Description")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Comment("Checks if the Company has been deleted")]
        public bool IsDeleted { get; set; } = false;

        [Required]
        [Comment("Company Owner Identifier")]
        public string OwnerId { get; set; } = string.Empty;

        [ForeignKey(nameof(OwnerId))]
        public IdentityUser Owner { get; set; } = null!;

        public IEnumerable<JobOffer> JobOffers { get; set; } = new List<JobOffer>();
    }
}