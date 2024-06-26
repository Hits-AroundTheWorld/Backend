using AroundTheWorld.Application.Interfaces.Trips;
using AroundTheWorld.Domain.Entities;
using AroundTheWorld.Domain.Entities.Enums;
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

        public async Task<TripAndUsers?> GetTripById(Guid tripId)
        {
            return await _dbContext.TripAndUsers.FirstOrDefaultAsync(t => t.TripId == tripId);
        }

        public async Task<List<TripAndUsers>?> GetUsersFromTrip(Guid tripId)
        {
            return await _dbContext.TripAndUsers
                .Include(t => t.User)
                .Where(t => t.TripId == tripId)
                .ToListAsync();
        }
        public async Task<List<TripAndUsers>?> GetRequests(Guid tripId)
        {
            return await _dbContext.TripAndUsers.Where(t => t.TripId == tripId && t.Status == UserRequestStatus.InQueue).ToListAsync();
        }
        public async Task<List<Guid>?> GetUserTrips(Guid userId)
        {
            return await _dbContext.TripAndUsers.Where(t => t.UserId == userId).Select(i => i.TripId).ToListAsync();
        }
        public async Task<List<TripAndUsers>?> GetUserRequests(Guid userId)
        {
            return await _dbContext.TripAndUsers.Where(t => t.UserId == userId).ToListAsync();
        }
    }
}
