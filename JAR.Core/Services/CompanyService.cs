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
    public class CompanyService : ICompanyService
    {
        private readonly IRepository repository;

        public CompanyService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<int?> GetCompanyIdAsync(string userId)
        {
            return (await repository.AllReadOnly<Company>().FirstOrDefaultAsync(c => c.OwnerId == userId))?.Id;
        }
    }
}
