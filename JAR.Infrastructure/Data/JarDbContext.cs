using JAR.Infrastructure.Data.Models;
using JAR.Infrastructure.Data.Seed;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JAR.Infrastructure.Data
{
    public class JarDbContext : IdentityDbContext
    {
        public JarDbContext(DbContextOptions<JarDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<JobApplication>()
                .HasKey(ja => new { ja.JobOfferId, ja.UserId });

            builder.Entity<JobApplication>()
                .HasOne(ja => ja.JobOffer)
                .WithMany(jo => jo.JobApplications)
                .HasForeignKey(ja => ja.JobOfferId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<JobApplication>()
                .HasOne(ja => ja.User)
                .WithMany()
                .HasForeignKey(ja => ja.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new JobTypeConfiguration());
            builder.ApplyConfiguration(new CompanyConfiguration());
            builder.ApplyConfiguration(new JobOfferConfiguration());
            builder.ApplyConfiguration(new JobApplicationConfiguration());

            base.OnModelCreating(builder); 
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Company> Companies { get; set; }

        public DbSet<JobApplication> JobApplications { get; set; }

        public DbSet<JobOffer> JobOffers { get; set; }

        public DbSet<JobType> JobTypes { get; set; }

        public DbSet<CV> CVs { get; set; }

        public DbSet<Degree> Degrees { get; set; }

        public DbSet<ProfessionalExperience> ProfessionalExperiences { get; set; }
    }
}
