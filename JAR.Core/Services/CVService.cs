using JAR.Core.Contracts;
using JAR.Core.Models.CV;
using JAR.Infrastructure.Data.Models;
using JAR.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JAR.Infrastructure.Constants.DataConstants;

namespace JAR.Core.Services
{
    public class CVService : ICVService
    {
        private readonly IRepository repository;

        public CVService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task CreateCV(CVFormModel model, string userId)
        {
            if (!DateTime.TryParseExact(model.BirthDate, DateTimeFormat, CultureInfo.InvariantCulture, 
                DateTimeStyles.None, out DateTime birthDate))
            {
                throw new InvalidOperationException("Invalid date format");
            }

            var cv = new CV()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                LinkedInProfile = model.LinkedInProfile,
                PhoneNumber = model.PhoneNumber,
                Address = model.Address,
                Gender = model.Gender,
                BirthDate = birthDate,
                Citizenship = model.Citizenship,
                Photo = model.Photo,
                Languages = model.Languages,
                Skills = model.Skills,
                DrivingLicenseCategory = model.DrivingLicense,
                UserId = userId
            };

            foreach (var degree in model.Degrees)
            {
                await CreateDegree(degree, cv.Id);
            }

            foreach (var professionalExperience in model.ProfessionalExperiences)
            {
                await CreateProfessionalExperience(professionalExperience, cv.Id);
            }

            await repository.AddAsync(cv);
            await repository.SaveChangesAsync();
        }

        public async Task CreateDegree(DegreeFormModel model, int cvId)
        {
            if (!DateTime.TryParseExact(model.StartDate, DateTimeFormat, CultureInfo.InvariantCulture,
                DateTimeStyles.None, out DateTime startDate))
            {
                throw new InvalidOperationException("Invalid date format");
            }

            if (!DateTime.TryParseExact(model.EndDate, DateTimeFormat, CultureInfo.InvariantCulture,
                DateTimeStyles.None, out DateTime endDate))
            {
                throw new InvalidOperationException("Invalid date format");
            }

            var degree = new Degree()
            {
                EducationalInstitution = model.EducationalInstitution,
                Major = model.Major,
                EducationLevel = model.EducationalLevel,
                City = model.City,
                StartDate = startDate,
                EndDate = endDate,
                Description = model.Description,
                CVId = cvId
            };

            await repository.AddAsync(degree);  
        }

        public async Task CreateProfessionalExperience(ProfessionalExperienceFormModel model, int cvId)
        {
            if (!DateTime.TryParseExact(model.StartDate, DateTimeFormat, CultureInfo.InvariantCulture,
                DateTimeStyles.None, out DateTime startDate))
            {
                throw new InvalidOperationException("Invalid date format");
            }

            if (!DateTime.TryParseExact(model.EndDate, DateTimeFormat, CultureInfo.InvariantCulture,
                DateTimeStyles.None, out DateTime endDate))
            {
                throw new InvalidOperationException("Invalid date format");
            }

            var professionalExperience = new ProfessionalExperience()
            {
                CompanyName = model.CompanyName,
                City = model.City,
                StartDate = startDate,
                EndDate = endDate,
                Description = model.Description,
                CVId = cvId
            };

            await repository.AddAsync(professionalExperience);
        }
    }
}
