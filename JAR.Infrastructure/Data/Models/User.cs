using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static JAR.Infrastructure.Constants.DataConstants;

namespace JAR.Infrastructure.Data.Models
{
    public class User : IdentityUser
    {
        [Required]
        [MaxLength(NameMaxLength)]
        [Comment("User First Name")]
        public string FirstName { get; set; } = string.Empty;   

        [Required]
        [MaxLength(NameMaxLength)]
        [Comment("User Last Name")]
        public string LastName { get; set; } = string.Empty;

        public IEnumerable<ConferenceUser> ConferencesUsers { get; set; } = new List<ConferenceUser>();
    }
}
