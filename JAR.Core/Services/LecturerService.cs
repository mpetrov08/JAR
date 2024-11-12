using JAR.Core.Contracts;
using JAR.Core.Models.Lecturer;
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
    public class LecturerService : ILecturerService
    {
        private readonly IRepository repository;

        public LecturerService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<bool> IsLecturer(string userId)
        {
            return await repository
                .AllReadOnly<Lecturer>()
                .FirstOrDefaultAsync(l => l.UserId == userId) != null;
        }

        public async Task<bool> PromoteToLecturer(LecturerFormModel model)
        {
            var user = await repository
                .All<User>()
                .FirstOrDefaultAsync(u => u.Id == model.UserId);

            if (user != null)
            {
                var lecturer = new Lecturer()
                {
                    UserId = model.UserId,
                    Description = model.Description
                };

                await repository.AddAsync(lecturer);
                await repository.SaveChangesAsync();

                return true;
            }

            return false;
        }
    }
}
