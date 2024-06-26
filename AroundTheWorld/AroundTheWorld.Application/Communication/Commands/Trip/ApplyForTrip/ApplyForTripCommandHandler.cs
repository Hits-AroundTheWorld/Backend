using AroundTheWorld.Application.Communication.Commands.Trip.CreateTrip;
using AroundTheWorld.Application.Interfaces.Trips;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AroundTheWorld.Application.Communication.Commands.Trip.ApplyForTrip
{
    public class ApplyForTripCommandHandler : IRequestHandler<ApplyForTripCommand>
    {

        private readonly ITripService _tripService;
        public ApplyForTripCommandHandler(ITripService tripService)
        {
            _tripService = tripService;
        }

        public async Task Handle(ApplyForTripCommand request, CancellationToken cancellationToken)
        {
            await _tripService.ApplyForTrip(request.tripId, request.userId);
        }
    }
}
