using AroundTheWorld.Application.DTO.TimeIntervals;
using AroundTheWorld.Application.Interfaces.TimeIntervals;
using AroundTheWorld.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AroundTheWorld.Application.Communication.Queries.TimeIntervals.GetTimeIntervals
{
    public class GetTripTimeIntervalsQueryHandler : IRequestHandler<GetTripTimeIntervalsQuery, IQueryable<TimeInterval>>
    {
        private readonly ITimeIntervalService _timeIntervalService;

        public GetTripTimeIntervalsQueryHandler(ITimeIntervalService timeIntervalService)
        {
            _timeIntervalService = timeIntervalService;
        }

        public async Task<IQueryable<TimeInterval>> Handle(GetTripTimeIntervalsQuery request, CancellationToken cancellationToken)
        {
            var timeIntervals = await _timeIntervalService.GetTripTimeIntervals(request.tripId);
            return timeIntervals;
        }
    }
}
