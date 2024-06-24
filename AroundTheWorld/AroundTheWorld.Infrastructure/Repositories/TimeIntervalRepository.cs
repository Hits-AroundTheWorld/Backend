using AroundTheWorld.Application.Interfaces.Days;
using AroundTheWorld.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AroundTheWorld.Infrastructure.Repositories
{
    public class TimeIntervalRepository : BaseRepository<TimeInterval>, ITimeIntervalRepository
    {
        private readonly AppDbContext _dbContext;
        protected TimeIntervalRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<TimeInterval> GetTimeIntervalsByTripId(Guid tripId)
        {
            var timeSlots = _dbContext.TimeIntervals.Where(ts => ts.TripId == tripId);

            return timeSlots;
        }

        public async Task<bool> IsTimeIntervalExistsAsync(Guid timeIntervalId)
        {
            var isTimeIntervalExists = await _dbContext.TimeIntervals
                .Where(ti => ti.Id == timeIntervalId)
                .AnyAsync();

            return isTimeIntervalExists;
        }
        public async Task ClearAllMapPointsAsync(Guid timeIntervalId)
        {
            var timePoints = await GetMapPointsByIntervalIdAsync(timeIntervalId);
            _dbContext.RemoveRange(timePoints);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<TimeIntervalMapPoint>> GetMapPointsByIntervalIdAsync(Guid timeIntervalId)
        {
            var mapPoints = await _dbContext.MapPoints.Where(mp => mp.ParentId == timeIntervalId).ToListAsync();
            return mapPoints;
        }
        public async Task AddMapPointsAsync(List<MapPoint> mapPointsList, Guid timeIntervalId)
        {
            List<TimeIntervalMapPoint> timeIntervalMapPoints = new List<TimeIntervalMapPoint>();
            foreach (var point in mapPointsList)
            {
                var timeIntervalMapPoint = new TimeIntervalMapPoint
                {
                    ParentId = timeIntervalId,
                    MapPoint = point
                };
                timeIntervalMapPoints.Add(timeIntervalMapPoint);
            }
            await _dbContext.MapPoints.AddRangeAsync(timeIntervalMapPoints);
            await _dbContext.SaveChangesAsync();
        }
    }
}
