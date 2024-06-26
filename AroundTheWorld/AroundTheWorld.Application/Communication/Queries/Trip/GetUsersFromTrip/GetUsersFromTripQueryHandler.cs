using AroundTheWorld.Application.Communication.Queries.Trip.GetPublicTrips;
using AroundTheWorld.Application.DTO.Trip;
using AroundTheWorld.Application.Interfaces.Trips;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AroundTheWorld.Application.Communication.Queries.Trip.GetUsersFromTrip
{
    public class GetUsersFromTripQueryHandler : IRequestHandler<GetUsersFromTripQuery, IQueryable<GetUserDTO>>
    {

        private readonly ITripService _tripService;
        public GetUsersFromTripQueryHandler(ITripService tripService)
        {
            _tripService = tripService;
        }

        public async Task<IQueryable<GetUserDTO>> Handle(GetUsersFromTripQuery request, CancellationToken cancellationToken)
        {
            var users = await _tripService.GetUsersFromTrip(request.tripId);
            return users;
        }
    }
}
