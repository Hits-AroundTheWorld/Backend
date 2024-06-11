using AroundTheWorld.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace AroundTheWorld.Infrastructure
{
    public class AppDbContext: DbContext
    {
        public DbSet<User> Users {  get; init; }
        public DbSet<CompanionsPair> Companions { get; init; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
