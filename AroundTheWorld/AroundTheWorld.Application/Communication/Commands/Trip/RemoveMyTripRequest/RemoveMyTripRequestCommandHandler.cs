using AroundTheWorld.Application.Communication.Commands.Trip.LeaveFromTrip;
using AroundTheWorld.Application.Interfaces.Trips;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AroundTheWorld.Application.Communication.Commands.Trip.RemoveMyTripRequest
{
    public class RemoveMyTripRequestCommandHandler : IRequestHandler<RemoveMyTripRequestCommand>
    {

        private readonly ITripService _tripService;
        public RemoveMyTripRequestCommandHandler(ITripService tripService)
        {
            _tripService = tripService;
        }

        public async Task Handle(RemoveMyTripRequestCommand request, CancellationToken cancellationToken)
        {
            await _tripService.RemoveTripRequest(request.userId, request.tripId);
        }
    }
}
