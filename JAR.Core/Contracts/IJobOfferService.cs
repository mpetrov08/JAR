using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JAR.Core.Enumerations;
using JAR.Core.Models.Category;
using JAR.Core.Models.JobOffer;
using JAR.Core.Models.JobType;
using JAR.Infrastructure.Data.Models;

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

        Task<List<CategoryViewModel>> AllCategories();

        Task<bool> CategoryExists(int id);

        Task<List<string>> AllJobTypeNamesAsync();

        Task<List<JobTypeViewModel>> AllJobTypes();

        Task<JobOfferDetailsViewModel> JobOfferDetailsAsync(int id);

        Task<bool> JobTypeExists(int id);

        Task<bool> Exists(int id);

        Task<int> Create(JobOfferAddModel model, int companyId, DateTime createdOn);

        Task<JobOfferAddModel> GetJobOfferAddModelByIdAsync(int id);

        Task<bool> HasCompanyWithIdAsync(int jobOfferId, string userId);

        Task EditAsync(JobOfferAddModel model, int jobOfferId);

        Task Delete(int id);
    }
}
