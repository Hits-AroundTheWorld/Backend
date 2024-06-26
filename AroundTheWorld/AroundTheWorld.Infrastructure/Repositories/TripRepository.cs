﻿using AroundTheWorld.Application.Interfaces.Trips;
using AroundTheWorld.Application.Interfaces.Users;
using AroundTheWorld.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AroundTheWorld.Infrastructure.Repositories
{
    public class TripRepository : BaseRepository<Trip>, ITripRepository
    {
        private readonly AppDbContext _dbContext;

        public TripRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Trip>?> GetByUserIdAsync(Guid userId)
        {
            return await _dbContext.Trips.Where(u => u.TripFounderId == userId).ToListAsync();
        }

        public async Task<Trip?> GetTripById(Guid founderId, Guid tripId)
        {
            return await _dbContext.Trips.FirstOrDefaultAsync(t => t.TripFounderId == founderId && t.TripId == tripId);
        }

        public async Task<List<Trip>?> GetTripsAsync()
        {
            return await _dbContext.Trips.Where(t => t.IsPublic == true).ToListAsync();
        }

        public async Task<bool> IsFounder(Guid userId, Guid tripId)
        {
            var probFounder = await _dbContext.Trips.FirstOrDefaultAsync(t => t.TripFounderId == userId && t.TripId == tripId);
            if(probFounder == null)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> IsTripExists(Guid tripId)
        {
            var isTripExists = await _dbContext.Trips.Where(t => t.TripId == tripId).AnyAsync();
            return isTripExists;
        }
    }
}
