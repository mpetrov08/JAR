using JAR.Core.Contracts;
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

        public async Task<bool> HasUserAlreadyAppliedAsync(int jobOfferId, string userId)
        {
            var jobApplication = await repository
                .AllReadOnly<JobApplication>()
                .Where(ja => ja.JobOfferId == jobOfferId && ja.UserId == userId)
                .FirstOrDefaultAsync();

            return jobApplication != null;
        }
    }
}
