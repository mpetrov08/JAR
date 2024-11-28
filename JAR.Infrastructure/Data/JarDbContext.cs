using JAR.Infrastructure.Data.Models;
using JAR.Infrastructure.Data.Seed;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace JAR.Infrastructure.Data
{
    public class JarDbContext : IdentityDbContext<User>
    {
        private bool seedDb;

        public JarDbContext(DbContextOptions<JarDbContext> options, bool _seedDb = true)
            : base(options)
        {
            if (Database.IsRelational())
            {
                Database.Migrate();
            }
            else
            {
                Database.EnsureCreated();
            }

            seedDb = _seedDb;
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

            builder.Entity<ConferenceUser>()
                .HasKey(cu => new { cu.ConferenceId, cu.UserId });

            builder.Entity<ConferenceUser>()
                .HasOne(cu => cu.Conference)
                .WithMany(c => c.ConferencesUsers)
                .HasForeignKey(cu => cu.ConferenceId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ConferenceUser>()
                .HasOne(cu => cu.User)
                .WithMany(u => u.ConferencesUsers)
                .HasForeignKey(cu => cu.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<RoomUser>()
                .HasKey(ru => new { ru.RoomId, ru.UserId });

            builder.Entity<RoomUser>()
                .HasOne(ru => ru.Room)
                .WithMany(r => r.Users)
                .HasForeignKey(ru => ru.RoomId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<RoomUser>()
                .HasOne(ru => ru.User)
                .WithMany()
                .HasForeignKey(ru => ru.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            if (seedDb)
            {
                builder.ApplyConfiguration(new UserConfiguration());
                builder.ApplyConfiguration(new CategoryConfiguration());
                builder.ApplyConfiguration(new JobTypeConfiguration());
                builder.ApplyConfiguration(new CompanyConfiguration());
                builder.ApplyConfiguration(new JobOfferConfiguration());
                builder.ApplyConfiguration(new JobApplicationConfiguration());
                builder.ApplyConfiguration(new RoomConfiguration());
                builder.ApplyConfiguration(new RoomUserConfiguration());
            }
            
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

        public DbSet<Lecturer> Lecturers { get; set; }

        public DbSet<Conference> Conferences { get; set; }

        public DbSet<ConferenceUser> ConferencesUsers { get; set; }

        public DbSet<Message> Messages { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<RoomUser> RoomsUsers { get; set; }
    }
}