using Ganss.Xss;
using JAR.Core.Contracts;
using JAR.Core.Models.Company;
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
    public class CompanyService : ICompanyService
    {
        private readonly IRepository repository;

        public CompanyService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<bool> ApproveCompanyAsync(int companyId)
        {
            var company = await repository.GetByIdAsync<Company>(companyId);

            if (company == null || company.IsDeleted == true || company.IsApproved == true)
            {
                return false;
            }

            company.IsApproved = true;

            await repository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> CompanyExistsAsync(int companyId)
        {
            return await repository
                .AllReadOnly<Company>()
                .AnyAsync(c => c.Id == companyId && c.IsDeleted == false);  
        }

        public async Task<bool> CompanyWithUICExistsAsync(string uic)
        {
            return await repository
                .AllReadOnly<Company>()
                .FirstOrDefaultAsync(c => c.UIC == uic && c.IsDeleted == false) != null;
        }

        public async Task CreateCompanyAsync(CompanyRegisterModel model, string userId)
        {
            var sanitizer = new HtmlSanitizer();
            var company = new Company()
            {
                Name = model.Name,
                Logo = model.LogoUrl,
                UIC = model.UIC,
                Country = model.Country,
                Address = model.Address,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                Description = sanitizer.Sanitize(model.Description),
                OwnerId = userId
            };

            await repository.AddAsync(company);
            await repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int companyId)
        {
            var company = await repository.GetByIdAsync<Company>(companyId);

            if(company != null)
            {
                company.IsDeleted = true;
                await repository.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<CompanyApproveViewModel>> GetAllCompaniesAsync()
        {
            var companies = await repository
                .All<Company>()
                .Where(c => c.IsDeleted == false)
                .Select(c => new CompanyApproveViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                    UIC = c.UIC,
                    Country = c.Country,
                    Address = c.Address,
                    PhoneNumber = c.PhoneNumber,
                    Email = c.Email,
                    Description = c.Description,
                    OwnerName = $"{c.Owner.FirstName} {c.Owner.LastName}",
                    IsApproved = c.IsApproved,
                    IsDeleted = c.IsDeleted
                })
                .ToListAsync();

            return companies;
        }

        public async Task<int> GetCompanyIdAsync(string userId)
        {
            var company = await repository
                .AllReadOnly<Company>()
                .FirstOrDefaultAsync(c => c.OwnerId == userId && c.IsDeleted == false);

            if (company == null)
            {
                return -1;
            }

            return company.Id;
        }

        public async Task<CompanyViewModel> GetCompanyViewModelByIdAsync(int companyId)
        {
            return await repository
                .AllReadOnly<Company>()
                .Where(c => c.Id == companyId && c.IsDeleted == false)
                .Select(c => new CompanyViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                    Address = c.Address,
                    PhoneNumber = c.PhoneNumber,
                    Email = c.Email,
                    Description = c.Description,
                    OwnerName = c.Owner.FirstName + " " + c.Owner.LastName,
                    LogoUrl = c.Logo
                })
                .FirstOrDefaultAsync();
        }

        public async Task<bool> IsApproved(int companyId)
        {
            var company = await repository
                .AllReadOnly<Company>()
                .FirstOrDefaultAsync(c => c.Id == companyId && c.IsDeleted == false);

            if (company == null)
            {
                return false;
            }

            return company.IsApproved;
        }

        public async Task<bool> OwnerCompanyExistsAsync(string userId)
        {
            return await repository
                .AllReadOnly<Company>()
                .FirstOrDefaultAsync(c => c.OwnerId == userId && c.IsDeleted == false) != null;
        }

        public async Task<bool> DisapproveCompanyAsync(int companyId)
        {
            var company = await repository
                .All<Company>()
                .Include(c => c.JobOffers)
                .FirstOrDefaultAsync(c => c.Id == companyId);

            if (company == null || company.IsDeleted == true || company.IsApproved == false)
            {
                return false;
            }

            company.IsApproved = false;

            foreach (var jobOffer in company.JobOffers)
            {
                jobOffer.IsDeleted = true;
            }

            await repository.SaveChangesAsync();

            return true;
        }
    }
}