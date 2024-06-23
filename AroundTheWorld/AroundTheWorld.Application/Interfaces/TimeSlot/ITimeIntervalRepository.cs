using AroundTheWorld.Application.Interfaces.Users;
using AroundTheWorld.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AroundTheWorld.Application.Interfaces.Days
{



    public interface ITimeIntervalRepository: IBaseRepository<TimeInterval>
    {
        public IQueryable<TimeInterval> GetTimeIntervalsByTripId(Guid tripId);
    }
}
