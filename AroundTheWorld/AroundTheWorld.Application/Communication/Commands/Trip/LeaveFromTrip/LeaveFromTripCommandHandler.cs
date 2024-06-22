using AroundTheWorld.Application.Communication.Commands.Trip.CreateTrip;
using AroundTheWorld.Application.Interfaces.Trips;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AroundTheWorld.Application.Communication.Commands.Trip.LeaveFromTrip
{
    public class LeaveFromTripCommandHandler : IRequestHandler<LeaveFromTripCommand>
    {

        private readonly ITripService _tripService;
        public LeaveFromTripCommandHandler(ITripService tripService)
        {
            _tripService = tripService;
        }

        public async Task Handle(LeaveFromTripCommand request, CancellationToken cancellationToken)
        {
            await _tripService.LeaveFromTrip(request.userId,request.tripId);
        }
    }
}
