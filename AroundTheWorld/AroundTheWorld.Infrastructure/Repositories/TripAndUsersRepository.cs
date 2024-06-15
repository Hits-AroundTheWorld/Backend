using AroundTheWorld.Application.Interfaces.Trips;
using AroundTheWorld.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AroundTheWorld.Infrastructure.Repositories
{
    public class TripAndUsersRepository: BaseRepository<TripAndUsers>, ITripAndUsersRepository
    {
        private readonly AppDbContext _dbContext;

        public TripAndUsersRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TripAndUsers?> GetRequestByIdAsync(Guid userId, Guid tripId)
        {
            return await _dbContext.TripAndUsers.FirstOrDefaultAsync(t => t.UserId == userId && t.TripId == tripId);
        }
    }
}
