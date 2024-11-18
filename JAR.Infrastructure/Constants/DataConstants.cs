using JAR.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAR.Infrastructure.Constants
{
    public static class DataConstants
    {
        public const int CompanyNameMinLength = 2;

        public const int CompanyNameMaxLength = 100;   

        public const int CompanyEmailMinLength = 8;

        public const int CompanyEmailMaxLength = 50;

        public const int CompanyUICMinLength = 5;

        public const int CompanyUICMaxLength = 30;

        public const int CategoryNameMinLength = 2;

        public const int CategoryNameMaxLength = 50;

        public const int JobTypeNameMinLength = 5;

        public const int JobTypeNameMaxLength = 30;

        public const int JobOfferTitleMinLength = 10;

        public const int JobOfferTitleMaxLength = 150;

        public const int JobOfferDescriptionMinLength = 50;

        public const int JobOfferDescriptionMaxLength = 1500;

        public const string JobOfferMinSalary = "500";

        public const string JobOfferMaxSalary = "50000";

        public const int JobOfferRequiredMinLength = 5;

        public const int JobOfferRequiredMaxLength = 150;

        public const int JobApplicationMessageMinLength = 10;

        public const int JobApplicationMessageMaxLength = 500;

        public const int CVLanguagesMinLength = 5;

        public const int CVLanguagesMaxLength = 200;

        public const int CVSkillsMinLength = 15;

        public const int CVSkillsMaxLength = 300;

        public const int CVLinkedInProfileMinLength = 30;

        public const int CVLinkedInProfileMaxLength = 300;

        public const int CVGenderMinLength = 1;

        public const int CVGenderMaxLength = 20;

        public const int CVCitizenshipMinLength = 2;

        public const int CVCitizenshipMaxLength = 50;

        public const int CVDrivingLicenseCategoryLength = 1;

        public const int DegreeEducationalInstitutionMinLength = 5;

        public const int DegreeEducationalInstitutionMaxLength = 200;

        public const int DegreeMajorMinLength = 2;

        public const int DegreeMajorMaxLength = 100;

        public const int DegreeEducationLevelMinLength = 5;

        public const int DegreeEducationLevelMaxLength = 50;

        public const int ConferenceTopicMinLength = 2;

        public const int ConferenceTopicMaxLength = 150;

        public const string ConferenceDateTimeFormat = "dd/MM/yyyy HH:mm";

        public const int RoomNameMinLength = 5;

        public const int RoomNameMaxLength = 100;

        public const int CountryMinLength = 2;

        public const int CountryMaxLength = 30;

        public const int CityMinLength = 1;

        public const int CityMaxLength = 85;

        public const int AddressMinLength = 20;

        public const int AddressMaxLength = 200;

        public const int PhoneNumberMinLength = 7;

        public const int PhoneNumberMaxLength = 15;

        public const int DescriptionMinLength = 20;

        public const int DescriptionMaxLength = 300;

        public const int NameMinLength = 2;

        public const int NameMaxLength = 50;

        public const int EmailMinLength = 3;

        public const int EmailMaxLength = 150;

        public const string DateFormat = "dd/MM/yyyy";
    }
}