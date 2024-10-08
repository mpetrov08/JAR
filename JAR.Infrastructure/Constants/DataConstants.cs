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

        public const int CompanyPhoneNumberMinLength = 7;

        public const int CompanyPhoneNumberMaxLength = 15;

        public const int CompanyEmailMinLength = 8;

        public const int CompanyEmailMaxLength = 50;

        public const int CompanyDescriptionMinLength = 20;

        public const int CompanyDescriptionMaxLength = 300;

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

        public const int CountryMinLength = 2;

        public const int CountryMaxLength = 30;

        public const int AddressMinLength = 20;

        public const int AddressMaxLength = 200;
    }
}
