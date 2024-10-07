using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JAR.Core.Enumerations;
using JAR.Core.Models.JobOffer;

namespace JAR.Core.Contracts
{
    public interface IJobOfferService
    {
        Task<JobOfferResultModel> AllAsync(string? category = null, 
            string? jobType = null, 
            string? searchTerm = null, 
            JobOfferSorting sorting = JobOfferSorting.Newest, 
            int currentPage = 1, 
            int jobsPerPage = 1);

        Task<List<string>> AllCategoriesNamesAsync();

        Task<List<string>> AllJobTypeNamesAsync();
    }
}
