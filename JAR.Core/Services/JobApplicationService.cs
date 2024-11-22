using JAR.Core.Contracts;
using JAR.Core.Models.JobApplication;
using JAR.Core.Models.JobOffer;
using JAR.Infrastructure.Data.Models;
using JAR.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
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

        public async Task ApplyAsync(int jobOfferId, string userId, DateTime appliedOn)
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

        public async Task ApproveAsync(int jobOfferId, string userId, string message)
        {
            var jobApplication = await repository
                .All<JobApplication>()
                .FirstOrDefaultAsync(ja => ja.JobOfferId == jobOfferId && ja.UserId == userId);

            if (jobApplication != null)
            {
                jobApplication.IsApproved = true;
                jobApplication.Message = message;
            }

            await repository.SaveChangesAsync();
        }

        public async Task<bool> CheckStatusAsync(int jobOfferId, string userId)
        {
            var jobOffer =  await repository
                .AllReadOnly<JobApplication>()
                .FirstOrDefaultAsync(ja => ja.JobOfferId == jobOfferId && ja.UserId == userId);

            return jobOffer != null && jobOffer.IsApproved == true;
        }

        public async Task<JobOfferApplicantViewModel> GetApplicantByIdAsync(int jobOfferId, string userId)
        {
            return await repository
                .AllReadOnly<JobApplication>()
                .Where(ja => ja.JobOfferId == jobOfferId && ja.UserId == userId)
                .Select(ja => new JobOfferApplicantViewModel()
                {
                    UserId = userId,
                    JobId = jobOfferId,
                    Email = ja.User.Email,
                    IsApproved = ja.IsApproved,
                    AppliedOn = ja.AppliedOn.Date.ToString()
                })
                .FirstOrDefaultAsync() ?? new JobOfferApplicantViewModel();
        }

        public async Task<List<JobOfferApplicantViewModel>> GetApplicantsAsync(int jobOfferId)
        {
            return await repository
                    .AllReadOnly<JobApplication>()
                    .Where(ja => ja.JobOfferId == jobOfferId)
                    .Select(ja => new JobOfferApplicantViewModel
                    {
                        UserId = ja.UserId,
                        JobId = jobOfferId,
                        Email = ja.User.Email,
                        IsApproved = ja.IsApproved,
                        AppliedOn = ja.AppliedOn.Date.ToString()
                    })
                    .ToListAsync();
                                
        }

        public async Task<JobApplicationStatusViewModel> GetJobApplicationStatusViewModelAsync(int jobOfferId, string userId)
        {
            return await repository
                .AllReadOnly<JobApplication>()
                .Where(ja => ja.JobOfferId == jobOfferId && ja.UserId == userId)
                .Select(ja => new JobApplicationStatusViewModel
                {
                    Title = ja.JobOffer.Title,
                    Address = ja.JobOffer.Address,
                    Description = ja.JobOffer.Description,
                    Message = ja.Message,
                    IsApproved = ja.IsApproved
                })
                .FirstOrDefaultAsync() ?? new JobApplicationStatusViewModel();
        }

        public async Task<bool> HasUserAlreadyAppliedAsync(int jobOfferId, string userId)
        {
            var jobApplication = await repository
                .AllReadOnly<JobApplication>()
                .FirstOrDefaultAsync(ja => ja.JobOfferId == jobOfferId && ja.UserId == userId);

            return jobApplication != null;
        }

        public async Task<bool> IsUserAlreadyApprovedAsync(int jobOfferId, string userId)
        {
            var jobApplication = await repository
                .AllReadOnly<JobApplication>()
                .Where(ja => ja.JobOfferId == jobOfferId && ja.UserId == userId)
                .FirstOrDefaultAsync();

            return jobApplication.IsApproved;
        }
    }
}
