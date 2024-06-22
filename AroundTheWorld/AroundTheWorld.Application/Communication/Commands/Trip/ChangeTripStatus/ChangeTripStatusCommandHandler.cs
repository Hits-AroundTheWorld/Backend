using AroundTheWorld.Application.Communication.Commands.Trip.ChangeTripRequestStatus;
using AroundTheWorld.Application.Interfaces.Trips;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AroundTheWorld.Application.Communication.Commands.Trip.ChangeTripStatus
{
    public class ChangeTripStatusCommandHandler : IRequestHandler<ChangeTripStatusCommand>
    {

        private readonly ITripService _tripService;
        public ChangeTripStatusCommandHandler(ITripService tripService)
        {
            _tripService = tripService;
        }

        public async Task Handle(ChangeTripStatusCommand request, CancellationToken cancellationToken)
        {
            await _tripService.ChangeTripStatus(request.userId, request.tripStatusCreds);
        }
    }
}
