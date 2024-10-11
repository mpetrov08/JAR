using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAR.Core.Models.JobApplication
{
    public class JobApplicationStatusViewModel
    {
        public string Title { get; set; } = null!;

        public string Address { get; set; } = null!;

        public string Description { get; set; } = null!;

        public bool IsApproved {  get; set; }
    }
}
