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
            var company = new Company()
            {
                Name = model.Name,
                Logo = model.Logo,
                UIC = model.UIC,
                Country = model.Country,
                Address = model.Address,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                Description = model.Description,
                OwnerId = userId
            };

            await repository.AddAsync(company);
            await repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<CompanyApproveViewModel>> GetAllCompaniesAsync()
        {
            var companies = await repository
                .All<Company>()
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

        public async Task<int?> GetCompanyIdAsync(string userId)
        {
            return (await repository
                .AllReadOnly<Company>()
                .FirstOrDefaultAsync(c => c.OwnerId == userId && c.IsDeleted == false))?.Id;
        }

        public async Task<bool> OwnerCompanyExistsAsync(string userId)
        {
            return await repository
                .AllReadOnly<Company>()
                .FirstOrDefaultAsync(c => c.OwnerId == userId && c.IsDeleted == false) != null;
        }
    }
}