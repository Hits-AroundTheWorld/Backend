using AroundTheWorld.Domain.Entities;

namespace AroundTheWorld.Application.Interfaces.Users
{
    public interface IUserRepository : IBaseRepository<User> {
        public Task<User?> GetByEmailAsync(string email);
        public IQueryable<User> GetUsersByFullName(string? fullName);
    }
}
