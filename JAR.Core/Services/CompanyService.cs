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

        public async Task<bool> CompanyWithUICExists(string uic)
        {
            return await repository.AllReadOnly<Company>().Where(c => c.UIC == uic).FirstOrDefaultAsync() != null;
        }

        public async Task CreateCompanyAsync(CompanyRegisterModel model, string userId)
        {
            var company = new Company()
            {
                Name = model.Name,
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

        public async Task<int?> GetCompanyIdAsync(string userId)
        {
            return (await repository.AllReadOnly<Company>().FirstOrDefaultAsync(c => c.OwnerId == userId))?.Id;
        }

        public async Task<bool> OwnerCompanyExistsAsync(string userId)
        {
            return await repository.AllReadOnly<Company>().FirstOrDefaultAsync(c => c.OwnerId == userId) != null;
        }
    }
}
