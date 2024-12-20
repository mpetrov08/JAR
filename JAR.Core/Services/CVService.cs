﻿using JAR.Core.Contracts;
using JAR.Core.Models.CV;
using JAR.Infrastructure.Data.Models;
using JAR.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
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
            if (!DateTime.TryParseExact(model.BirthDate, DateFormat, CultureInfo.InvariantCulture,
                DateTimeStyles.None, out DateTime birthDate))
            {
                throw new InvalidOperationException("Invalid date format");
            }

            if (!string.IsNullOrEmpty(model.DegreesJson))
            {
                model.Degrees = JsonConvert.DeserializeObject<List<DegreeFormModel>>(model.DegreesJson);
            }

            if (!string.IsNullOrEmpty(model.ProfessionalExperiencesJson))
            {
                model.ProfessionalExperiences = JsonConvert.DeserializeObject<List<ProfessionalExperienceFormModel>>(model.ProfessionalExperiencesJson);
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
                Photo = model.PhotoUrl,
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
            if (!DateTime.TryParseExact(model.StartDate, DateFormat, CultureInfo.InvariantCulture,
                DateTimeStyles.None, out DateTime startDate))
            {
                throw new InvalidOperationException("Invalid date format");
            }

            if (!DateTime.TryParseExact(model.EndDate, DateFormat, CultureInfo.InvariantCulture,
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
            if (!DateTime.TryParseExact(model.StartDate, DateFormat, CultureInfo.InvariantCulture,
                DateTimeStyles.None, out DateTime startDate))
            {
                throw new InvalidOperationException("Invalid date format");
            }

            if (!DateTime.TryParseExact(model.EndDate, DateFormat, CultureInfo.InvariantCulture,
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

        public async Task DeleteCVAsync(int cvId)
        {
            var cv = await repository
                .All<CV>()
                .Include(c => c.Degrees)
                .Include(c => c.ProfessionalExperiences)
                .FirstOrDefaultAsync(c => c.Id == cvId);

            if (cv != null && cv.IsDeleted == false)
            {
                cv.IsDeleted = true;

                foreach (var degree in cv.Degrees)
                {
                    await DeleteDegree(degree.Id);
                }

                foreach (var professionalExperience in cv.ProfessionalExperiences)
                {
                    await DeleteProfessionalExperienceAsync(professionalExperience.Id);
                }
            }
            
            await repository.SaveChangesAsync();
        }

        public async Task DeleteDegree(int degreeId)
        {
            var degree = await repository.GetByIdAsync<Degree>(degreeId);

            if (degree != null && degree.IsDeleted == false)
            {
                degree.IsDeleted = true;
            }
        }

        public async Task DeleteProfessionalExperienceAsync(int professionalExperienceId)
        {
            var professionalExperience = await repository
                .GetByIdAsync<ProfessionalExperience>(professionalExperienceId);

            if (professionalExperience != null && professionalExperience.IsDeleted == false)
            {
                professionalExperience.IsDeleted = true;
            }
        }

        public async Task EditCVAsync(CVFormModel model, int cvId)
        {
            if (!DateTime.TryParseExact(model.BirthDate, DateFormat, CultureInfo.InvariantCulture,
                DateTimeStyles.None, out DateTime birthDate))
            {
                throw new InvalidOperationException("Invalid date format");
            }

            if (!string.IsNullOrEmpty(model.DegreesJson))
            {
                model.Degrees = JsonConvert.DeserializeObject<List<DegreeFormModel>>(model.DegreesJson);
            }

            if (!string.IsNullOrEmpty(model.ProfessionalExperiencesJson))
            {
                model.ProfessionalExperiences = JsonConvert.DeserializeObject<List<ProfessionalExperienceFormModel>>(model.ProfessionalExperiencesJson);
            }

            var cv = await repository
                .All<CV>()
                .Include(c => c.Degrees)
                .Include(c => c.ProfessionalExperiences)
                .FirstOrDefaultAsync(c => c.Id == cvId && c.IsDeleted == false);

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
                cv.Photo = model.PhotoUrl;
                cv.Languages = model.Languages;
                cv.Skills = model.Skills;
                cv.DrivingLicenseCategory = model.DrivingLicense;

                var degrees = model.Degrees
                    .Select(d => CreateDegree(d, cv.Id))
                    .ToList();

                var cvDegrees = cv.Degrees.Where(d => d.IsDeleted == false);

                foreach (var degree in cvDegrees)
                {
                    if (!degrees.Contains(degree))
                    {
                        await DeleteDegree(degree.Id);
                    }
                }

                foreach (var degree in degrees)
                {
                    if (!cvDegrees.Contains(degree))
                    {
                        await repository.AddAsync(degree);
                    }
                }

                var experiences = model.ProfessionalExperiences
                .Select(e => CreateProfessionalExperience(e, cv.Id))
                .ToList();

                var cvProfessionalExperiences = cv.ProfessionalExperiences.Where(c => c.IsDeleted == false);

                foreach (var experience in cvProfessionalExperiences)
                {
                    if (!experiences.Contains(experience))
                    {
                        await DeleteProfessionalExperienceAsync(experience.Id);
                    }
                }

                foreach (var experience in experiences)
                {
                    if (!cvProfessionalExperiences.Contains(experience))
                    {
                        await repository.AddAsync(experience);
                    }
                }
            }

            await repository.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int cvId)
        {
            return await repository
                .All<CV>()
                .FirstOrDefaultAsync(c => c.Id == cvId && c.IsDeleted == false) != null;
        }

        public async Task<CVFormModel> GetCVFormModelByUserIdAsync(string userId)
        {
            var cv = await repository
                .AllReadOnly<CV>()
                .Where(c => c.UserId == userId && c.IsDeleted == false)
                .Select(c => new CVFormModel()
                {
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    Email = c.Email,
                    LinkedInProfile = c.LinkedInProfile,
                    PhoneNumber = c.PhoneNumber,
                    Address = c.Address,
                    Gender = c.Gender,
                    BirthDate = c.BirthDate.ToString(DateFormat, CultureInfo.InvariantCulture),
                    Citizenship = c.Citizenship,
                    PhotoUrl = c.Photo,
                    Languages = c.Languages,
                    Skills = c.Skills,
                    DrivingLicense = c.DrivingLicenseCategory,
                    Degrees = c.Degrees
                               .Where(d => d.IsDeleted == false)
                               .Select(d => new DegreeFormModel()
                               {
                                   EducationalInstitution = d.EducationalInstitution,
                                   Major = d.Major,
                                   EducationalLevel = d.EducationLevel,
                                   City = d.City,
                                   StartDate = d.StartDate.ToString(DateFormat, CultureInfo.InvariantCulture),
                                   EndDate = d.EndDate.ToString(DateFormat, CultureInfo.InvariantCulture),
                                   Description = d.Description,
                               })
                               .ToList(),
                    ProfessionalExperiences = c.ProfessionalExperiences
                                               .Where(pf => pf.IsDeleted == false)
                                               .Select(pf => new ProfessionalExperienceFormModel()
                                               {
                                                   CompanyName = pf.CompanyName,
                                                   City = pf.City,
                                                   StartDate = pf.StartDate.ToString(DateFormat, CultureInfo.InvariantCulture),
                                                   EndDate = pf.EndDate.ToString(DateFormat, CultureInfo.InvariantCulture),
                                                   Description = pf.Description
                                               })
                                               .ToList(),
                })
                .FirstOrDefaultAsync();

            cv.DegreesJson = JsonConvert.SerializeObject(cv.Degrees);
            cv.ProfessionalExperiencesJson = JsonConvert.SerializeObject(cv.ProfessionalExperiences);

            return cv;
        }

        public async Task<CVViewModel> GetCVViewModelByUserIdAsync(string userId)
        {
            var cv = await repository
                .AllReadOnly<CV>()
                .Where(c => c.UserId == userId && c.IsDeleted == false)
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
                    BirthDate = c.BirthDate.ToString(DateFormat, CultureInfo.InvariantCulture),
                    Citizenship = c.Citizenship,
                    PhotoUrl = c.Photo,
                    Languages = c.Languages,
                    Skills = c.Skills,
                    DrivingLicenseCategory = c.DrivingLicenseCategory,
                    Degrees = c.Degrees
                               .Where(d => d.IsDeleted == false)
                               .Select(d => new DegreeViewModel()
                               {
                                   EducationalInstitution = d.EducationalInstitution,
                                   Major = d.Major,
                                   EducationalLevel = d.EducationLevel,
                                   City = d.City,
                                   StartDate = d.StartDate.ToString(DateFormat, CultureInfo.InvariantCulture),
                                   EndDate = d.EndDate.ToString(DateFormat, CultureInfo.InvariantCulture),
                                   Description = d.Description,
                               })
                               .ToList(),
                    ProfessionalExperiences = c.ProfessionalExperiences
                                               .Where(pf => pf.IsDeleted == false)
                                               .Select(pf => new ProfessionalExperienceViewModel()
                                               {
                                                   CompanyName = pf.CompanyName,
                                                   City = pf.City,
                                                   StartDate = pf.StartDate.ToString(DateFormat, CultureInfo.InvariantCulture),
                                                   EndDate = pf.EndDate.ToString(DateFormat, CultureInfo.InvariantCulture),
                                                   Description= pf.Description
                                               })
                                               .ToList()
                })
                .FirstOrDefaultAsync();

            return cv;
        }

        public async Task<bool> UserHasCVAsync(string userId)
        {
            return await repository
                .AllReadOnly<CV>()
                .AnyAsync(c => c.IsDeleted == false && c.UserId == userId);
        }

        public async Task<bool> UserHasCVWithIdAsync(int cvId, string userId)
        {
            return await repository
                .AllReadOnly<CV>()
                .AnyAsync(c => c.Id == cvId && c.UserId == userId && c.IsDeleted == false);
        }
    }
}
