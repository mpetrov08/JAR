using JAR.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAR.Infrastructure.Data.Seed
{
    internal class JobTypeConfiguration : IEntityTypeConfiguration<JobType>
    {
        public void Configure(EntityTypeBuilder<JobType> builder)
        {
            var data = new SeedData();

            builder.HasData(new JobType[] { data.InternshipJob, data.FullTimeJob, data.PartTimeJob, data.TemporaryJob, data.SeasonalJob });
        }
    }
}
