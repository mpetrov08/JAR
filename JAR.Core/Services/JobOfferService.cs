﻿using Ganss.Xss;
using JAR.Core.Contracts;
using JAR.Core.Enumerations;
using JAR.Core.Models.Category;
using JAR.Core.Models.Company;
using JAR.Core.Models.JobOffer;
using JAR.Core.Models.JobType;
using JAR.Infrastructure.Data.Models;
using JAR.Infrastructure.Repository;
using static JAR.Infrastructure.Constants.DataConstants;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace JAR.Core.Services
{
    public class JobOfferService : IJobOfferService
    {
        private readonly IRepository repository;

        public JobOfferService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<JobOfferResultModel> AllAsync(string? category = null, 
            string? jobType = null, 
            string? searchTerm = null, 
            JobOfferSorting sorting = JobOfferSorting.Newest, 
            int currentPage = 1, 
            int jobsPerPage = 1)
        {
            var jobOffers = repository
                .AllReadOnly<JobOffer>()
                .Where(jo => jo.IsDeleted == false);

            if (!string.IsNullOrEmpty(category))
            {
                jobOffers = jobOffers.Where(jo => jo.Category.Name == category);
            }

            if (!string.IsNullOrEmpty(jobType)) 
            {
                jobOffers = jobOffers.Where(jo => jo.JobType.Name == jobType);
            }

            if (!string.IsNullOrEmpty(searchTerm))
            {
                string normalizedSearchTerm = searchTerm.ToLower();

                jobOffers = jobOffers.Where(jo => (jo.Title.ToLower().Contains(normalizedSearchTerm) ||
                                                   jo.Description.ToLower().Contains(normalizedSearchTerm) ||
                                                   jo.Address.ToLower().Contains(normalizedSearchTerm) ||
                                                   jo.RequiredSkills.ToLower().Contains(normalizedSearchTerm)));
            }

            jobOffers = sorting switch
            {
                JobOfferSorting.LowestSalary => jobOffers.OrderBy(jo => jo.Salary),
                JobOfferSorting.HighestSalary => jobOffers.OrderByDescending(jo => jo.Salary),
                _ => jobOffers.OrderBy(jo => jo.CreatedOn),
            };

            var jobOffersToShow = await jobOffers
                .Skip((currentPage - 1) * jobsPerPage)
                .Take(jobsPerPage)
                .Select(jo => new JobOfferViewModel
                {
                    Id = jo.Id,
                    Title = jo.Title,
                    Address = jo.Address,
                    RequiredLanguage = jo.RequiredLanguage,
                    RequiredDegree = jo.RequiredDegree,
                    RequiredExperience = jo.RequiredExperience,
                    RequiredSkills = jo.RequiredSkills,
                    Salary = jo.Salary,
                    CreatedOn = jo.CreatedOn.Date.ToString(),
                    CompanyOwnerId = jo.Company.OwnerId,
                    CompanyLogo = jo.Company.Logo
                })
                .ToListAsync();

            int totalJobOffers = jobOffers.Count();

            return new JobOfferResultModel
            {
                TotalJobOfferCount = totalJobOffers,
                JobOffers = jobOffersToShow,
            };
        }

        public async Task<List<CategoryViewModel>> AllCategoriesAsync()
        {
            return await repository
                .AllReadOnly<Category>()
                .Select(c => new CategoryViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                })
                .ToListAsync();
        }

        public async Task<List<string>> AllCategoriesNamesAsync()
        {       
            return await repository.AllReadOnly<Category>()
                .Select(c => c.Name)
                .ToListAsync();
        }

        public async Task<List<JobTypeViewModel>> AllJobTypesAsync()
        {
            return await repository
                .AllReadOnly<JobType>()
                .Select(jt => new JobTypeViewModel()
                {
                    Id = jt.Id,
                    Name = jt.Name
                })
                .ToListAsync();
        }

        public async Task<List<string>> AllJobTypeNamesAsync()
        {
            return await repository.AllReadOnly<JobType>()
                .Select(jt => jt.Name)
                .ToListAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await repository
                .AllReadOnly<JobOffer>()
                .AnyAsync(jo => jo.Id == id && jo.IsDeleted == false);
        }

        public async Task<JobOfferDetailsViewModel> JobOfferDetailsAsync(int id)
        {
            return await repository
                .AllReadOnly<JobOffer>()
                .Where(jo => jo.Id == id)
                .Where(jo => jo.IsDeleted == false)
                .Select(jo => new JobOfferDetailsViewModel()
                {
                    Id = id,
                    Title = jo.Title,
                    Description = jo.Description,
                    Address = jo.Address,
                    RequiredLanguage = jo.RequiredLanguage,
                    RequiredDegree = jo.RequiredDegree,
                    RequiredExperience = jo.RequiredExperience,
                    RequiredSkills = jo.RequiredSkills,
                    Salary = jo.Salary,
                    Category = jo.Category.Name,
                    JobType = jo.JobType.Name,
                    Company = new CompanyViewModel()
                    {
                       Id = jo.Company.Id,
                       Name = jo.Company.Name,
                       Description = jo.Company.Description,
                       Address = jo.Company.Address,
                       PhoneNumber = jo.Company.PhoneNumber,
                       Email = jo.Company.Email,
                       OwnerName = jo.Company.Owner.FirstName + " " + jo.Company.Owner.LastName,
                       LogoUrl = jo.Company.Logo
                    },
                    CreatedOn = jo.CreatedOn.Date.ToString(DateFormat, CultureInfo.InvariantCulture)
                })
                .FirstAsync();
        }

        public async Task<int> CreateAsync(JobOfferFormModel model, int companyId, DateTime createdOn)
        {
            var sanitizer = new HtmlSanitizer();

            JobOffer jobOffer = new JobOffer()
            {
               Title = model.Title,
               Description = sanitizer.Sanitize(model.Description),
               Address = model.Address,
               Salary = model.Salary,
               RequiredLanguage = model.RequiredLanguage,
               RequiredDegree = model.RequiredDegree,
               RequiredExperience = model.RequiredExperience,
               RequiredSkills = model.RequiredSkills,
               CategoryId = model.CategoryId,
               JobTypeId = model.JobTypeId,
               CompanyId = companyId,
               CreatedOn = createdOn,
            };

            await repository.AddAsync(jobOffer);
            await repository.SaveChangesAsync();

            return jobOffer.Id;
        }

        public async Task<bool> CategoryExistsAsync(int id)
        {
            return await repository.AllReadOnly<Category>().AnyAsync(c => c.Id == id);
        }

        public async Task<bool> JobTypeExistsAsync(int id)
        {
            return await repository.AllReadOnly<JobType>().AnyAsync(c => c.Id == id);
        }

        public async Task<JobOfferFormModel> GetJobOfferFormModelByIdAsync(int id)
        {
            var jobOffer = await repository
                .AllReadOnly<JobOffer>()
                .Where(jo => jo.IsDeleted == false && jo.Id == id)
                .Select(jo => new JobOfferFormModel
                {
                    Title = jo.Title,
                    Description = jo.Description,
                    Address = jo.Address,
                    Salary = jo.Salary,
                    RequiredLanguage = jo.RequiredLanguage,
                    RequiredDegree = jo.RequiredDegree,
                    RequiredExperience = jo.RequiredExperience,
                    RequiredSkills = jo.RequiredSkills,
                    CategoryId = jo.CategoryId,
                    JobTypeId = jo.JobTypeId,
                })
                .FirstOrDefaultAsync();

            if (jobOffer != null)
            {
                jobOffer.Categories = await AllCategoriesAsync();
                jobOffer.JobTypes = await AllJobTypesAsync();
            }

            return jobOffer;
        }

        public async Task<bool> HasCompanyWithIdAsync(int jobOfferId, string userId)
        {
            return await repository
                .AllReadOnly<JobOffer>()
                .AnyAsync(jo => jo.Id == jobOfferId && jo.Company.OwnerId == userId && jo.Company.IsDeleted == false);
        }

        public async Task EditAsync(JobOfferFormModel model, int jobOfferId)
        {
            var jobOffer = await repository
                .All<JobOffer>()
                .Where(jo => jo.Id == jobOfferId)
                .Where(jo => jo.IsDeleted == false)
                .FirstOrDefaultAsync();

            if (jobOffer != null) 
            {
                var sanitizer = new HtmlSanitizer();

                jobOffer.Title = model.Title;
                jobOffer.Description = sanitizer.Sanitize(model.Description);
                jobOffer.Address = model.Address;
                jobOffer.Salary = model.Salary;
                jobOffer.RequiredLanguage = model.RequiredLanguage;
                jobOffer.RequiredDegree = model.RequiredDegree;
                jobOffer.RequiredExperience = model.RequiredExperience;
                jobOffer.RequiredSkills = model.RequiredSkills;
                jobOffer.CategoryId = model.CategoryId;
                jobOffer.JobTypeId = model.JobTypeId;

                await repository.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var jobOffer = await repository
                .All<JobOffer>()
                .Include(jo => jo.JobApplications)
                .FirstOrDefaultAsync(jo => jo.Id == id);

            if (jobOffer != null)
            {
                foreach (var jobApplication in jobOffer.JobApplications)
                {
                    await repository.DeleteCompositeAsync<JobApplication>(new object[] { jobApplication.JobOfferId, jobApplication.UserId });
                }

                jobOffer.IsDeleted = true;
                await repository.SaveChangesAsync();
            }
        }

        public async Task<List<JobOfferViewModel>> AllByUserIdAsync(string userId)
        {
            return await repository
                    .AllReadOnly<JobOffer>()
                    .Where(jo => jo.IsDeleted == false)
                    .Where(jo => jo.JobApplications.Any(ja => ja.UserId == userId))
                    .Select(jo => new JobOfferViewModel
                    {
                        Id = jo.Id,
                        Title = jo.Title,
                        Address = jo.Address,
                        RequiredLanguage = jo.RequiredLanguage,
                        RequiredDegree = jo.RequiredDegree,
                        RequiredExperience = jo.RequiredExperience,
                        RequiredSkills = jo.RequiredSkills,
                        Salary = jo.Salary,
                        CreatedOn = jo.CreatedOn.Date.ToString(DateFormat, CultureInfo.InvariantCulture),
                        CompanyLogo = jo.Company.Logo,
                        CompanyOwnerId = jo.Company.OwnerId
                    })
                    .ToListAsync();
        }

        public async Task<List<JobOfferViewModel>> AllByOwnerIdAsync(string ownerId)
        {
            return await repository
                    .AllReadOnly<JobOffer>()
                    .Where(jo => jo.IsDeleted == false)
                    .Where(jo => jo.Company.OwnerId == ownerId)
                    .Select(jo => new JobOfferViewModel
                    {
                        Id = jo.Id,
                        Title = jo.Title,
                        Address = jo.Address,
                        RequiredLanguage = jo.RequiredLanguage,
                        RequiredDegree = jo.RequiredDegree,
                        RequiredExperience = jo.RequiredExperience,
                        RequiredSkills = jo.RequiredSkills,
                        Salary = jo.Salary,
                        CreatedOn = jo.CreatedOn.Date.ToString(DateFormat, CultureInfo.InvariantCulture),
                        CompanyLogo = jo.Company.Logo,
                        CompanyOwnerId = jo.Company.OwnerId
                    })
                    .ToListAsync();
        }
    }
}
