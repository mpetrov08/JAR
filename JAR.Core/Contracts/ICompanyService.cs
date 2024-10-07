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
    }
}
