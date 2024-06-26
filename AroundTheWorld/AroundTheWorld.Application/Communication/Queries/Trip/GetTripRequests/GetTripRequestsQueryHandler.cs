using AroundTheWorld.Application.Communication.Queries.Trip.GetUsersFromTrip;
using AroundTheWorld.Application.DTO.Trip;
using AroundTheWorld.Application.Interfaces.Trips;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AroundTheWorld.Application.Communication.Queries.Trip.GetTripRequests
{
    public class GetTripRequestsQueryHandler : IRequestHandler<GetTripRequestsQuery, GetTripRequestsInfoDTO>
    {

        private readonly ITripService _tripService;
        public GetTripRequestsQueryHandler(ITripService tripService)
        {
            _tripService = tripService;
        }

        public async Task<GetTripRequestsInfoDTO> Handle(GetTripRequestsQuery request, CancellationToken cancellationToken)
        {
            var requests = await _tripService.GetTripRequests(request.size, request.page, request.tripId);
            return requests;
        }
    }
}
