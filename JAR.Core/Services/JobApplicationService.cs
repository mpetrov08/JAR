using JAR.Core.Contracts;
using JAR.Core.Models.JobOffer;
using JAR.Infrastructure.Data.Models;
using JAR.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAR.Core.Services
{
    public class JobApplicationService : IJobApplicationService
    {
        private readonly IRepository repository;

        public JobApplicationService(IRepository _repository)
        {
            repository = _repository; 
        }

        public async Task Apply(int jobOfferId, string userId, DateTime appliedOn)
        {
            var jobApplication = new JobApplication()
            {
                JobOfferId = jobOfferId,
                UserId = userId,
                AppliedOn = appliedOn,
            };

            await repository.AddAsync(jobApplication);
            await repository.SaveChangesAsync();
        }

        public async Task Approve(int jobOfferId, string userId)
        {
            var jobApplication = await repository
                .All<JobApplication>()
                .Where(ja => ja.JobOfferId == jobOfferId && ja.UserId == userId)
                .FirstOrDefaultAsync();

            if (jobApplication != null)
            {
                jobApplication.IsApproved = true;
            }

            await repository.SaveChangesAsync();
        }

        public async Task<bool> CheckStatus(int jobOfferId, string userId)
        {
            var jobOffer =  await repository
                .AllReadOnly<JobApplication>()
                .Where(ja => ja.JobOfferId == jobOfferId)
                .Where(ja => ja.UserId == userId)
                .FirstOrDefaultAsync();

            return jobOffer != null && jobOffer.IsApproved == true;
        }

        public async Task<List<JobOfferApplicantsViewModel>> GetApplicantsAsync(int jobOfferId)
        {
            return await repository
                    .AllReadOnly<JobApplication>()
                    .Where(ja => ja.JobOfferId == jobOfferId)
                    .Select(ja => new JobOfferApplicantsViewModel
                    {
                        UserId = ja.UserId,
                        JobId = jobOfferId,
                        Email = ja.User.Email,
                        IsApproved = ja.IsApproved,
                        AppliedOn = ja.AppliedOn.Date.ToString()
                    })
                    .ToListAsync();
                                
        }

        public async Task<bool> HasUserAlreadyAppliedAsync(int jobOfferId, string userId)
        {
            var jobApplication = await repository
                .AllReadOnly<JobApplication>()
                .Where(ja => ja.JobOfferId == jobOfferId && ja.UserId == userId)
                .FirstOrDefaultAsync();

            return jobApplication != null;
        }

        public async Task<bool> IsUserAlreadyApprovedAsync(int jobOfferId, string userId)
        {
            var jobApplication = await repository
                .AllReadOnly<JobApplication>()
                .Where(ja => ja.JobOfferId == jobOfferId && ja.UserId == userId)
                .FirstOrDefaultAsync();

            return jobApplication != null;
        }
    }
}
