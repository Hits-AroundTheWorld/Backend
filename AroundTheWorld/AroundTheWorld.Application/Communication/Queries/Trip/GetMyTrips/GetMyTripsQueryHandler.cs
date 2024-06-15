using AroundTheWorld.Application.Communication.Queries.Trip.GetMyTrip;
using AroundTheWorld.Application.Communication.Queries.User.GetProfile;
using AroundTheWorld.Application.DTO.Trip;
using AroundTheWorld.Application.DTO.User;
using AroundTheWorld.Application.Interfaces.Trips;
using AroundTheWorld.Application.Interfaces.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AroundTheWorld.Application.Communication.Queries.Trip.GetMyTrips
{
    public class GetMyTripsQueryHandler : IRequestHandler<GetMyTripsQuery, GetQuerybleTripsInfoDTO>
    {

        private readonly ITripService _tripService;
        public GetMyTripsQueryHandler(ITripService tripService)
        {
            _tripService = tripService;
        }

        public async Task<GetQuerybleTripsInfoDTO> Handle(GetMyTripsQuery request, CancellationToken cancellationToken)
        {
            var trips = await _tripService.GetMyTrips(request.size, request.page, request.userId, request.tripName, request.requestSorting, request.tripDate) ;
            return trips;
        }
    }
}
