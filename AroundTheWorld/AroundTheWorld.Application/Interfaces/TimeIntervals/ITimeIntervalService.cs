
using AroundTheWorld.Application.DTO.TimeIntervals;
using AroundTheWorld.Domain.Entities;

namespace AroundTheWorld.Application.Interfaces.TimeIntervals
{
    public interface ITimeIntervalService
    {
        public Task CreateTimeInterval(CreateTimeIntervalDTO createDayDTO);
        public Task EditTimeInterval(EditTimeIntervalDTO editTimeIntervalDTO);
        public Task<IQueryable<TimeInterval>> GetTripTimeIntervals(Guid tripId);
    }
}
