using AroundTheWorld.Application.Communication.Queries.Trip.GetMyTrip;
using AroundTheWorld.Application.DTO.Trip;
using AroundTheWorld.Application.Interfaces.Trips;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AroundTheWorld.Application.Communication.Queries.Trip.GetPublicTrips
{
    public class GetPublicTripsQueryHandler : IRequestHandler<GetPublicTripsQuery, GetQuerybleTripsInfoDTO>
    {

        private readonly ITripService _tripService;
        public GetPublicTripsQueryHandler(ITripService tripService)
        {
            _tripService = tripService;
        }

        public async Task<GetQuerybleTripsInfoDTO> Handle(GetPublicTripsQuery request, CancellationToken cancellationToken)
        {
            var trips = await _tripService.GetPublicTrips(request.size, request.page, request.userId, request.tripName, request.requestSorting, request.tripDate);
            return trips;
        }
    }
}
