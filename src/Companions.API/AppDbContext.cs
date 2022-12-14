using Companions.Domain;
using Microsoft.EntityFrameworkCore;

namespace Companions.API
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }


        public DbSet<User> Users { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<ActivityType> ActivityTypes { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<AppointmentType> AppointmentTypes { get; set; }
        public DbSet<Buddy> Buddies { get; set; }
        public DbSet<BuddyWeight> BuddyWeights { get; set; }
        public DbSet<FeedBrand> FeedBrands { get; set; }
        public DbSet<FeedingSchedule> FeedingSchedules { get; set; }
        public DbSet<FeedProduct> FeedProducts { get; set; }
        public DbSet<Species> Species { get; set; }
        public DbSet<Vaccination> Vaccinations { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Image> Images { get; set; }
    }
}
