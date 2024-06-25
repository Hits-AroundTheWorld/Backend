using AroundTheWorld.Application.DTO.TimeIntervals;
using AroundTheWorld.Application.Interfaces.TimeIntervals;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AroundTheWorld.Application.Communication.Queries.TimeIntervals.GetTimeInterval
{
    public class GetTripTimeIntervalQueryHandles : IRequestHandler<GetTripTimeIntervalQuery, GetTimeIntervalDTO>
    {

        private readonly ITimeIntervalService _timeIntervalService;

        public GetTripTimeIntervalQueryHandles(ITimeIntervalService timeIntervalService)
        {
            _timeIntervalService = timeIntervalService;
        }

        public async Task<GetTimeIntervalDTO> Handle(GetTripTimeIntervalQuery request, CancellationToken cancellationToken)
        {
            var timeInterval = await _timeIntervalService.GetTripTimeInterval(request.TimeIntervalId);
            return timeInterval;
        }
    }
}
