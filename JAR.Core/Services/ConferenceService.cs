using JAR.Core.Contracts;
using JAR.Core.Models.Conference;
using JAR.Infrastructure.Data.Models;
using JAR.Infrastructure.Repository;
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
    }
}
