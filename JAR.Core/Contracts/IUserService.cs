using JAR.Core.Models.User;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAR.Core.Contracts
{
    public interface IUserService
    {
        Task<IEnumerable<UserViewModel>> AllAsync();

        Task<bool> PromoteUserToAdminAsync(string userId);
    }
}
