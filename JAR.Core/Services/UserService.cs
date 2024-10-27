using JAR.Core.Contracts;
using JAR.Core.Models.User;
using JAR.Infrastructure.Data.Models;
using JAR.Infrastructure.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JAR.Infrastructure.Constants.AdministratorConstants;

namespace JAR.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository repository;
        private readonly UserManager<User> userManager; 

        public UserService(IRepository _repository, UserManager<User> _userManager)
        {
            repository = _repository;
            userManager = _userManager;
        }

        public async Task<IEnumerable<UserViewModel>> All()
        {
            var users = await repository
                .All<User>()
                .Select(u => new UserViewModel()
                {
                    Id = u.Id,
                    Email = u.Email,
                    FullName = $"{u.FirstName} {u.LastName}"
                })
                .ToListAsync();

            return users;
        }

        public async Task<bool> PromoteUserToAdminAsync(string userId)
        {
            var user = await userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return false;
            }

            var result = await userManager.AddToRoleAsync(user, AdminRole);
            return result.Succeeded;
        }
    }
}
