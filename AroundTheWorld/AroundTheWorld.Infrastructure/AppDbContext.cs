using AroundTheWorld.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Xml;


namespace AroundTheWorld.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; init; }
        public DbSet<CompanionsPair> Companions { get; init; }
        public DbSet<Trip> Trips { get; init; }
        public DbSet<TripAndUsers> TripAndUsers { get; init; }
        public DbSet<Checklist> Checklists { get; init; }
        public DbSet<Checkpoint> Checkpoints { get; init; }
        public DbSet<TimeInterval> TimeIntervals { get; init; }
        public DbSet<TimeIntervalMapPoint> MapPoints { get; init; }
        
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CompanionsPair>()
                .HasKey(e => new { e.FirstCompanion, e.SecondCompanion });
            modelBuilder.Entity<TripAndUsers>()
                .HasKey(e => new { e.TripId, e.UserId });
            modelBuilder.Entity<TimeIntervalMapPoint>()
                .HasKey(e => new { e.ParentId, e.pointId });
        }
    }
}
