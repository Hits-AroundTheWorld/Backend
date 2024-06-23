using AroundTheWorld.Application.Interfaces.Days;
using AroundTheWorld.Domain.Entities;
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
        protected TimeIntervalRepository(AppDbContext dbContext) : base(dbContext){
            _dbContext = dbContext;
        }

        public IQueryable<TimeInterval> GetTimeIntervalsByTripId(Guid tripId)
        {
            var timeSlots = _dbContext.TimeSlots.Where(ts => ts.TripId == tripId);

            return timeSlots;
        }
    }
}
