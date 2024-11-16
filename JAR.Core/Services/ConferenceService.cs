using JAR.Core.Contracts;
using JAR.Core.Models.Conference;
using JAR.Core.Models.Lecturer;
using JAR.Infrastructure.Data.Models;
using JAR.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using static JAR.Infrastructure.Constants.DataConstants;
namespace JAR.Core.Services
{
    public class ConferenceService : IConferenceService
    {
        private readonly IRepository repository;
        private readonly ILecturerService lecturerService;

        public ConferenceService(IRepository _repository, 
            ILecturerService _lecturerService)
        {
            repository = _repository;
            lecturerService = _lecturerService;
        }

        public async Task<IEnumerable<ConferenceViewModel>> AllAsync()
        {
            var conferences = await repository
                .AllReadOnly<Conference>()
                .Where(c => c.IsDeleted == false)
                .Select(c => new ConferenceViewModel()
                {
                    Id = c.Id,
                    Topic = c.Topic,
                    Start = c.Start.ToString(ConferenceDateTimeFormat, CultureInfo.InvariantCulture),
                    End = c.End.ToString(ConferenceDateTimeFormat, CultureInfo.InvariantCulture),
                    Description = c.Description,
                    Lecturer = new LecturerViewModel()
                    {
                        FirstName = c.Lecturer.User.FirstName,
                        LastName = c.Lecturer.User.LastName,
                        Description = c.Lecturer.Description
                    }
                })
                .ToListAsync();

            return conferences;
        }

        public async Task CreateConferenceAsync(ConferenceFormModel model)
        {
            if (!DateTime.TryParseExact(model.Start, ConferenceDateTimeFormat, CultureInfo.InvariantCulture,
            DateTimeStyles.None, out DateTime start))
            {
                throw new InvalidOperationException("Invalid date or hour format");
            }

            if (!DateTime.TryParseExact(model.End, ConferenceDateTimeFormat, CultureInfo.InvariantCulture,
                DateTimeStyles.None, out DateTime end))
            {
                throw new InvalidOperationException("Invalid date or hour format");
            }

            if (!await lecturerService.Exists(model.LecturerId))
            {
                throw new KeyNotFoundException("Lecturer does not exist.");
            }


            var conference = new Conference()
            {
                LecturerId = model.LecturerId,
                Topic = model.Topic,
                Start = start,
                End = end,
                Description = model.Description,
            };

            await repository.AddAsync(conference);
            await repository.SaveChangesAsync();
        }

        public async Task DeleteConferenceAsync(int id)
        {
            var conference = await repository.GetByIdAsync<Conference>(id);
             
            if (conference != null && conference.IsDeleted == false)
            {
                conference.IsDeleted = true;
                await repository.SaveChangesAsync();
            }
        }

        public async Task EditConferenceAsync(ConferenceFormModel model, int id)
        {
            if (!DateTime.TryParseExact(model.Start, ConferenceDateTimeFormat, CultureInfo.InvariantCulture,
            DateTimeStyles.None, out DateTime start))
            {
                throw new InvalidOperationException("Invalid date or hour format");
            }

            if (!DateTime.TryParseExact(model.End, ConferenceDateTimeFormat, CultureInfo.InvariantCulture,
                DateTimeStyles.None, out DateTime end))
            {
                throw new InvalidOperationException("Invalid date or hour format");
            }

            if (!await lecturerService.Exists(model.LecturerId))
            {
                throw new KeyNotFoundException("Lecturer does not exist.");
            }

            var conference = await repository.GetByIdAsync<Conference>(id);

            if (conference != null && conference.IsDeleted == false)
            {
                conference.LecturerId = model.LecturerId;
                conference.Topic = model.Topic;
                conference.Start = start;
                conference.End = end;
                conference.Description = model.Description;

                await repository.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await repository
                .AllReadOnly<Conference>()
                .FirstOrDefaultAsync(c => c.Id == id && c.IsDeleted == false) != null;
        }

        public async Task<ConferenceFormModel> GetConferenceFormModelByIdAsync(int id)
        {
            var conference = await repository
                .AllReadOnly<Conference>()
                .Where(c => c.Id == id && c.IsDeleted == false)
                .Select(c => new ConferenceFormModel
                {
                    LecturerId = c.LecturerId,
                    Topic = c.Topic,
                    Start = c.Start.ToString(ConferenceDateTimeFormat, CultureInfo.InvariantCulture),
                    End = c.End.ToString(ConferenceDateTimeFormat, CultureInfo.InvariantCulture),
                    Description = c.Description
                })
                .FirstOrDefaultAsync();

            return conference;
        }

        public async Task<ConferenceViewModel> GetConferenceViewModelByIdAsync(int id)
        {
            var conference = await repository
                .AllReadOnly<Conference>()
                .Where(c => c.Id == id && c.IsDeleted == false)
                .Select(c => new ConferenceViewModel
                {
                    Id = c.Id,
                    Topic = c.Topic,
                    Start = c.Start.ToString(ConferenceDateTimeFormat, CultureInfo.InvariantCulture),
                    End = c.End.ToString(ConferenceDateTimeFormat, CultureInfo.InvariantCulture),
                    Description = c.Description,
                    Lecturer = new LecturerViewModel()
                    {
                        FirstName = c.Lecturer.User.FirstName,
                        LastName = c.Lecturer.User.LastName,
                        Description = c.Description
                    }
                })
                .FirstOrDefaultAsync();

            return conference;
        }

        public async Task<bool> HasUserSignedUp(int conferenceId, string userId)
        {
            return await repository
                .AllReadOnly<ConferenceUser>()
                .FirstOrDefaultAsync(cu => cu.ConferenceId == conferenceId && cu.UserId == userId && cu.IsDeleted == false) 
                != null;
        }

        public async Task<bool> IsConferenceOver(int conferenceId, DateTime currentTime)
        {
            var conference = await repository.GetByIdAsync<Conference>(conferenceId);

            return conference.End < currentTime;
        }

        public async Task SignUp(int conferenceId, string userId)
        {
            var conferenceUser = new ConferenceUser()
            {
                ConferenceId = conferenceId,
                UserId = userId
            };

            await repository.AddAsync(conferenceUser);
            await repository.SaveChangesAsync();
        }

        public async Task Unregister(int conferenceId, string userId)
        {
            var conferenceUser = await repository
                .All<ConferenceUser>()
                .FirstOrDefaultAsync(cu => cu.ConferenceId == conferenceId && cu.UserId == userId && cu.IsDeleted == false);

            if (conferenceUser != null)
            {
                conferenceUser.IsDeleted = true;
                await repository.SaveChangesAsync();
            }
        }
    }
}