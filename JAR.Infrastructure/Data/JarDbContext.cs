using JAR.Infrastructure.Data.Models;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JobApplication>()
                .HasKey(ja => new { ja.JobOfferId, ja.UserId });

            modelBuilder.Entity<JobApplication>()
                .HasOne(ja => ja.JobOffer)
                .WithMany(jo => jo.JobApplications)
                .HasForeignKey(ja => ja.JobOfferId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<JobApplication>()
                .HasOne(ja => ja.User)
                .WithMany()
                .HasForeignKey(ja => ja.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder); 
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Company> Companies { get; set; }

        public DbSet<JobApplication> JobApplications { get; set; }

        public DbSet<JobOffer> JobOffers { get; set; }

        public DbSet<JobType> JobTypes { get; set; }
    }
}
