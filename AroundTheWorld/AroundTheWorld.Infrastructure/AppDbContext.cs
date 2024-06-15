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
        public DbSet<TripDays> TripDays { get; init; }
        public DbSet<TripAndUsers> TripAndUsers { get; init; }


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CompanionsPair>()
                .HasKey(e => new { e.FirstCompanion, e.SecondCompanion });
            modelBuilder.Entity<TripAndUsers>()
                .HasKey(e => new { e.TripId, e.UserId });
            modelBuilder.Entity<TripDays>()
                .HasKey(e => e.TripId);
        }
    }
}
