using AroundTheWorld.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Xml;


namespace AroundTheWorld.Infrastructure
{
    public class AppDbContext: DbContext
    {
        public DbSet<User> Users {  get; init; }
        public DbSet<CompanionsPair> Companions { get; init; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CompanionsPair>()
                .HasKey(e => new { e.FirstCompanion, e.SecondCompanion });
        }
    }


}
