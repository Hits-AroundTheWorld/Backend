using AroundTheWorld.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AroundTheWorld.Application.Communication.Queries.TimeIntervals.GetTimeIntervals
{
    public record GetTripTimeIntervalsQuery(Guid tripId) : IRequest<IQueryable<TimeInterval>> {}
}
