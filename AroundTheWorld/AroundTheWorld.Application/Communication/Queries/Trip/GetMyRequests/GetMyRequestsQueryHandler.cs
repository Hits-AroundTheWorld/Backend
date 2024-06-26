using AroundTheWorld.Application.Communication.Queries.Trip.GetMyTrip;
using AroundTheWorld.Application.DTO.Trip;
using AroundTheWorld.Application.Interfaces.Trips;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AroundTheWorld.Application.Communication.Queries.Trip.GetMyRequests
{
    public class GetMyRequestsQueryHandler : IRequestHandler<GetMyRequestsQuery, List<GetMyRequestsDTO>>
    {

        private readonly ITripService _tripService;
        public GetMyRequestsQueryHandler(ITripService tripService)
        {
            _tripService = tripService;
        }

        public async Task<List<GetMyRequestsDTO>> Handle(GetMyRequestsQuery request, CancellationToken cancellationToken)
        {
            var trips = await _tripService.GetMyRequests(request.userId);
            return trips;
        }
    }
}
