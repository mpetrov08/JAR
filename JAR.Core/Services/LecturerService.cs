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

        public async Task<IEnumerable<LecturerViewModel>> AllAsync()
        {
            return await repository
                .AllReadOnly<Lecturer>()
                .Select(l => new LecturerViewModel()
                {
                    Id = l.Id,
                    FirstName = l.User.FirstName,
                    LastName = l.User.LastName
                })
                .ToListAsync();
        }

        public async Task<bool> Exists(int id)
        {
            return await repository.GetByIdAsync<Lecturer>(id) != null;
        }

        public async Task<int> GetLecturerId(string userId)
        {
            var lecturer = await repository.AllReadOnly<Lecturer>().FirstOrDefaultAsync(l => l.UserId == userId);

            if (lecturer == null)
            {
                return 0;
            }

            return lecturer.Id;
        }

        public async Task<LecturerViewModel> GetLecturerViewModel(int id)
        {
            var lecturer = await repository
                .AllReadOnly<Lecturer>()
                .Where(l => l.Id == id && l.IsDeleted == false)
                .Select(l => new LecturerViewModel()
                {
                    Id = l.Id,
                    FirstName = l.User.FirstName,
                    LastName = l.User.LastName,
                })
                .FirstOrDefaultAsync();

            return lecturer;
        }

        public async Task<bool> HasLecturerConference(string userId, int conferenceId)
        {
            var conference = await repository.GetByIdAsync<Conference>(conferenceId);
            var lecturerId = await GetLecturerId(userId);

            return conference.LecturerId == lecturerId;
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
