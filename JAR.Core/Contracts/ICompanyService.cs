using JAR.Core.Models.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAR.Core.Contracts
{
    public interface ICompanyService
    {
        Task<int?> GetCompanyIdAsync(string userId);

        Task<bool> CompanyExistsAsync(int companyId);

        Task<bool> CompanyWithUICExistsAsync(string uic);

        Task<bool> OwnerCompanyExistsAsync(string userId);

        Task CreateCompanyAsync(CompanyRegisterModel model, string userId);

        Task<IEnumerable<CompanyApproveViewModel>> GetAllCompaniesAsync();

        Task<bool> ApproveCompanyAsync(int companyId);
    }
}
