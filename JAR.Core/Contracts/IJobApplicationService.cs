using JAR.Core.Models.JobApplication;
using JAR.Core.Models.JobOffer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAR.Core.Contracts
{
    public interface IJobApplicationService
    {
        Task<bool> HasUserAlreadyAppliedAsync(int jobOfferId, string userId);

        Task<bool> IsUserAlreadyApprovedAsync(int jobOfferId, string userId);

        Task ApplyAsync(int jobOfferId, string userId, DateTime appliedOn);

        Task WithdrawApplication(int jobOfferId, string userId);

        Task ApproveAsync(int jobOfferId, string userId, string message);

        Task<bool> CheckStatusAsync(int jobOfferId, string userId);

        Task<List<JobOfferApplicantViewModel>> GetApplicantsAsync(int jobOfferId);

        Task<JobOfferApplicantViewModel> GetApplicantByIdAsync(int jobOfferId, string userId);

        Task<JobApplicationStatusViewModel> GetJobApplicationStatusViewModelAsync(int jobOfferId, string userId);
    }
}
