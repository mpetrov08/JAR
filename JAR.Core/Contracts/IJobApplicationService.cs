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

        Task Apply(int jobOfferId, string userId, DateTime appliedOn);

        Task Approve(int jobOfferId, string userId);

        Task<bool> CheckStatus(int jobOfferId, string userId);

        Task<List<JobOfferApplicantsViewModel>> GetApplicantsAsync(int jobOfferId);
    }
}
