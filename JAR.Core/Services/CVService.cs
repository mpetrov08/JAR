using JAR.Core.Contracts;
using JAR.Core.Models.CV;
using JAR.Infrastructure.Data.Models;
using JAR.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
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

        public async Task CreateCVAsync(CVFormModel model, string userId)
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
                Email = model.Email,
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

            await repository.AddAsync(cv);
            await repository.SaveChangesAsync();

            var degrees = model.Degrees
                .Select(d => CreateDegree(d, cv.Id))
                .ToList();

            var experiences = model.ProfessionalExperiences
                .Select(e => CreateProfessionalExperience(e, cv.Id))
                .ToList();

            await repository.AddRangeAsync(degrees);
            await repository.AddRangeAsync(experiences);
            await repository.SaveChangesAsync();
        }

        public Degree CreateDegree(DegreeFormModel model, int cvId)
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

            return new Degree()
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
        }

        public ProfessionalExperience CreateProfessionalExperience(ProfessionalExperienceFormModel model, int cvId)
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

            return new ProfessionalExperience()
            {
                CompanyName = model.CompanyName,
                City = model.City,
                StartDate = startDate,
                EndDate = endDate,
                Description = model.Description,
                CVId = cvId
            };
        }

        public async Task DeleteCV(int cvId)
        {
            var cv = await repository.GetByIdAsync<CV>(cvId);

            if (cv != null)
            {
                cv.IsDeleted = true;
            }
            
            await repository.SaveChangesAsync();
        }

        public async Task EditCV(CVFormModel model, int cvId)
        {
            if (!DateTime.TryParseExact(model.BirthDate, DateTimeFormat, CultureInfo.InvariantCulture,
                DateTimeStyles.None, out DateTime birthDate))
            {
                throw new InvalidOperationException("Invalid date format");
            }

            var cv = await repository.GetByIdAsync<CV>(cvId);

            if (cv != null)
            {
                cv.FirstName = model.FirstName;
                cv.LastName = model.LastName;
                cv.Email = model.Email;
                cv.LinkedInProfile = model.LinkedInProfile;
                cv.PhoneNumber = model.PhoneNumber;
                cv.Address = model.Address;
                cv.Gender = model.Gender;
                cv.BirthDate = birthDate;
                cv.Citizenship = model.Citizenship;
                cv.Photo = model.Photo;
                cv.Languages = model.Languages;
                cv.Skills = model.Skills;
                cv.DrivingLicenseCategory = model.DrivingLicense;

                var degrees = model.Degrees
                    .Select(d => CreateDegree(d, cv.Id))
                    .ToList();

                foreach (var degree in degrees)
                {
                    if (!cv.Degrees.Contains(degree))
                    {
                        await repository.AddAsync(degree);
                    }
                }

                var experiences = model.ProfessionalExperiences
                .Select(e => CreateProfessionalExperience(e, cv.Id))
                .ToList();

                foreach (var experience in experiences)
                {
                    if (!cv.ProfessionalExperiences.Contains(experience))
                    {
                        await repository.AddAsync(experience);
                    }
                }
            }

            await repository.SaveChangesAsync();
        }

        public async Task<bool> Exists(int cvId)
        {
            return await repository.GetByIdAsync<CV>(cvId) != null;
        }

        public async Task<CVFormModel> GetCVFormModelByUserId(string userId)
        {
            var cv = await repository
                .AllReadOnly<CV>()
                .Where(c => c.UserId == userId)
                .Select(c => new CVFormModel()
                {
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    Email = c.Email,
                    LinkedInProfile = c.LinkedInProfile,
                    PhoneNumber = c.PhoneNumber,
                    Address = c.Address,
                    Gender = c.Gender,
                    BirthDate = c.BirthDate.ToString(DateTimeFormat),
                    Citizenship = c.Citizenship,
                    Photo = c.Photo,
                    Languages = c.Languages,
                    Skills = c.Skills,
                    DrivingLicense = c.DrivingLicenseCategory,
                    Degrees = c.Degrees
                               .Select(d => new DegreeFormModel()
                               {
                                   EducationalInstitution = d.EducationalInstitution,
                                   Major = d.Major,
                                   EducationalLevel = d.EducationLevel,
                                   City = d.City,
                                   StartDate = d.StartDate.ToString(DateTimeFormat),
                                   EndDate = d.EndDate.ToString(DateTimeFormat),
                                   Description = d.Description,
                               })
                               .ToList(),
                    ProfessionalExperiences = c.ProfessionalExperiences
                                               .Select(pf => new ProfessionalExperienceFormModel()
                                               {
                                                   CompanyName = pf.CompanyName,
                                                   City = pf.City,
                                                   StartDate = pf.StartDate.ToString(DateTimeFormat),
                                                   EndDate = pf.EndDate.ToString(DateTimeFormat),
                                                   Description = pf.Description
                                               })
                                               .ToList()
                })
                .FirstOrDefaultAsync();

            return cv;
        }

        public async Task<CVViewModel> GetCVViewModelByUserId(string userId)
        {
            var cv = await repository
                .AllReadOnly<CV>()
                .Where(c => c.UserId == userId)
                .Select(c => new CVViewModel()
                {
                    Id = c.Id,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    Email = c.Email,
                    LinkedInProfile = c.LinkedInProfile,
                    PhoneNumber = c.PhoneNumber,
                    Address = c.Address,
                    Gender = c.Gender,
                    BirthDate = c.BirthDate.ToString(DateTimeFormat),
                    Citizenship = c.Citizenship,
                    PhotoUrl = c.Photo,
                    Languages = c.Languages,
                    Skills = c.Skills,
                    DrivingLicenseCategory = c.DrivingLicenseCategory,
                    Degrees = c.Degrees
                               .Select(d => new DegreeViewModel()
                               {
                                   EducationalInstitution = d.EducationalInstitution,
                                   Major = d.Major,
                                   EducationalLevel = d.EducationLevel,
                                   City = d.City,
                                   StartDate = d.StartDate.ToString(DateTimeFormat),
                                   EndDate = d.EndDate.ToString(DateTimeFormat),
                                   Description = d.Description,
                               })
                               .ToList(),
                    ProfessionalExperiences = c.ProfessionalExperiences
                                               .Select(pf => new ProfessionalExperienceViewModel()
                                               {
                                                   CompanyName = pf.CompanyName,
                                                   City = pf.City,
                                                   StartDate = pf.StartDate.ToString(DateTimeFormat),
                                                   EndDate = pf.EndDate.ToString(DateTimeFormat),
                                                   Description= pf.Description
                                               })
                                               .ToList()
                })
                .FirstOrDefaultAsync();

            return cv;
        }

        public async Task<bool> UserHasCV(int cvId, string userId)
        {
            return await repository.AllReadOnly<CV>().AnyAsync(c => c.Id == cvId && c.UserId == userId);
        }
    }
}
