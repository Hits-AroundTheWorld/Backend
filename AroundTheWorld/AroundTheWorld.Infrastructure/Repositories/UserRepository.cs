using AroundTheWorld.Application.Interfaces.Users;
using AroundTheWorld.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AroundTheWorld.Infrastructure.Repositories
{
    public class UserRepository: BaseRepository<User>, IUserRepository
    {
        private readonly AppDbContext _dbContext;
        
        public UserRepository(AppDbContext dbContext) : base(dbContext) {
            _dbContext = dbContext;
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
