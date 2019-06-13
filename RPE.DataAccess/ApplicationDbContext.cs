using System.Reflection;
using Microsoft.EntityFrameworkCore;
using RPE.DataAccess.Entities;

namespace PersonalProfile.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Travel> Travels { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Attachment> Attachmentes { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(assembly: Assembly.GetExecutingAssembly());
        }
    }
}
