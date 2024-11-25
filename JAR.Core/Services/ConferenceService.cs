using Ganss.Xss;
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
                .Select(c => new ConferenceViewModel
                {
                    Id = c.Id,
                    Topic = c.Topic,
                    Start = c.Start.ToString(ConferenceDateTimeFormat, CultureInfo.InvariantCulture),
                    End = c.End.ToString(ConferenceDateTimeFormat, CultureInfo.InvariantCulture),
                    ConferenceUrl = c.ConferenceUrl,
                    Lecturer = new LecturerOptionViewModel()
                    {
                        Id = c.LecturerId,
                        FirstName = c.Lecturer.User.FirstName,
                        LastName = c.Lecturer.User.LastName,
                    }
                })
                .ToListAsync();

            return conferences;
        }

        public async Task<List<ConferenceViewModel>> AllByLecturerId(string userId)
        {
            var lecturerId = await lecturerService.GetLecturerId(userId);

            return await repository
                .AllReadOnly<Conference>()
                .Where(c => c.LecturerId == lecturerId && c.IsDeleted == false)
                .Select(c => new ConferenceViewModel()
                {
                    Id = c.Id,
                    Topic = c.Topic,
                    Start = c.Start.ToString(ConferenceDateTimeFormat, CultureInfo.InvariantCulture),
                    End = c.End.ToString(ConferenceDateTimeFormat, CultureInfo.InvariantCulture),
                    ConferenceUrl = c.ConferenceUrl,
                    Lecturer = new LecturerOptionViewModel()
                    {
                        Id= c.LecturerId,
                        FirstName = c.Lecturer.User.FirstName,
                        LastName = c.Lecturer.User.LastName,
                    }
                })
                .ToListAsync();
        }

        public async Task<List<ConferenceViewModel>> AllByUserId(string userId)
        {
            return await repository
                .AllReadOnly<Conference>()
                .Where(c => c.ConferencesUsers.Any(cu => cu.UserId == userId) && c.IsDeleted == false)
                .Select(c => new ConferenceViewModel()
                {
                    Id = c.Id,
                    Topic = c.Topic,
                    Start = c.Start.ToString(ConferenceDateTimeFormat, CultureInfo.InvariantCulture),
                    End = c.End.ToString(ConferenceDateTimeFormat, CultureInfo.InvariantCulture),
                    ConferenceUrl = c.ConferenceUrl,
                    Lecturer = new LecturerOptionViewModel()
                    {
                        Id = c.LecturerId,
                        FirstName = c.Lecturer.User.FirstName,
                        LastName = c.Lecturer.User.LastName,
                    }
                })
                .ToListAsync();
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

            var sanitizer = new HtmlSanitizer();

            var conference = new Conference()
            {
                LecturerId = model.LecturerId,
                Topic = model.Topic,
                Start = start,
                End = end,
                Description = sanitizer.Sanitize(model.Description),
                ConferenceUrl = model.ConferenceUrl
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
                var sanitizer = new HtmlSanitizer();

                conference.LecturerId = model.LecturerId;
                conference.Topic = model.Topic;
                conference.Start = start;
                conference.End = end;
                conference.Description = sanitizer.Sanitize(model.Description);
                conference.ConferenceUrl = model.ConferenceUrl;

                await repository.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await repository
                .AllReadOnly<Conference>()
                .FirstOrDefaultAsync(c => c.Id == id && c.IsDeleted == false) != null;
        }

        public async Task<ConferenceDetailsViewModel> GetConferenceDetailsViewModelByIdAsync(int id)
        {
            var conference = await repository
                .AllReadOnly<Conference>()
                .Where(c => c.Id == id && c.IsDeleted == false)
                .Select(c => new ConferenceDetailsViewModel()
                {
                    Id = c.Id,
                    Topic = c.Topic,
                    Start = c.Start.ToString(ConferenceDateTimeFormat, CultureInfo.InvariantCulture),
                    End = c.End.ToString(ConferenceDateTimeFormat, CultureInfo.InvariantCulture),
                    Description = c.Description,
                    ConferenceUrl = c.ConferenceUrl,
                    Lecturer = new LecturerDetailsViewModel()
                    {
                        Id = c.LecturerId,
                        FirstName = c.Lecturer.User.FirstName,
                        LastName = c.Lecturer.User.LastName,
                        Description = c.Lecturer.Description
                    }
                })
                .FirstOrDefaultAsync();

            return conference;
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
                    Description = c.Description,
                    ConferenceUrl = c.ConferenceUrl
                })
                .FirstOrDefaultAsync();

            if (conference != null)
            {
                conference.Lecturers = await lecturerService.AllOptionsAsync();
            }

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
                    ConferenceUrl = c.ConferenceUrl,
                    Lecturer = new LecturerOptionViewModel()
                    {
                        Id = c.Id,
                        FirstName = c.Lecturer.User.FirstName,
                        LastName = c.Lecturer.User.LastName,
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