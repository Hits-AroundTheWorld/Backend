using AroundTheWorld.Application.Communication.Commands.Trip.LeaveFromTrip;
using AroundTheWorld.Application.Interfaces.Trips;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AroundTheWorld.Application.Communication.Commands.Trip.RemoveTrip
{
    public class RemoveTripCommandHandler : IRequestHandler<RemoveTripCommand>
    {

        private readonly ITripService _tripService;
        public RemoveTripCommandHandler(ITripService tripService)
        {
            _tripService = tripService;
        }

        public async Task Handle(RemoveTripCommand request, CancellationToken cancellationToken)
        {
            await _tripService.RemoveTrip(request.userId, request.tripId);
        }
    }
}
