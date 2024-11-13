using JAR.Core.Contracts;
using JAR.Core.Models.Conference;
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

            if (conference != null)
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
            return await repository.GetByIdAsync<Conference>(id) != null;
        }

        public async Task<ConferenceFormModel> GetConferenceFormModelByIdAsync(int id)
        {
            var conference = await repository
                .AllReadOnly<Conference>()
                .Where(c => c.Id == id)
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
    }
}
