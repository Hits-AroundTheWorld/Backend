using AroundTheWorld.Application.DTO.Days;
using AroundTheWorld.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AroundTheWorld.Application.Interfaces.Days
{
    public interface ITimeIntervalService
    {
        public Task CreateTimeInterval(CreateTimeSlotDTO createDayDTO);
        public Task EditTimeInterval();
        public Task<IQueryable<TimeInterval>> GetTripTimeIntervals(Guid tripId);
    }
}
