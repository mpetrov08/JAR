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

        Task<List<JobOfferViewModel>> AllByUserIdAsync(string userId);

        Task<List<JobOfferViewModel>> AllByOwnerIdAsync(string ownerId);

        Task<List<string>> AllCategoriesNamesAsync();

        Task<List<CategoryViewModel>> AllCategoriesAsync();

        Task<bool> CategoryExistsAsync(int id);

        Task<List<string>> AllJobTypeNamesAsync();

        Task<List<JobTypeViewModel>> AllJobTypesAsync();

        Task<JobOfferDetailsViewModel> JobOfferDetailsAsync(int id);

        Task<bool> JobTypeExistsAsync(int id);

        Task<bool> ExistsAsync(int id);

        Task<int> CreateAsync(JobOfferFormModel model, int companyId, DateTime createdOn);

        Task<JobOfferFormModel> GetJobOfferFormModelByIdAsync(int id);

        Task<bool> HasCompanyWithIdAsync(int jobOfferId, string userId);

        Task EditAsync(JobOfferFormModel model, int jobOfferId);

        Task DeleteAsync(int id);
    }
}
