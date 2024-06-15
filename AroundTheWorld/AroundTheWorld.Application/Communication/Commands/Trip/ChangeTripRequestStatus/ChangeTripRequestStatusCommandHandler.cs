using AroundTheWorld.Application.Communication.Commands.Trip.CreateTrip;
using AroundTheWorld.Application.Interfaces.Trips;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AroundTheWorld.Application.Communication.Commands.Trip.ChangeTripRequestStatus
{
    public class ChangeTripRequestStatusCommandHandler : IRequestHandler<ChangeTripRequestStatusCommand>
    {

        private readonly ITripService _tripService;
        public ChangeTripRequestStatusCommandHandler(ITripService tripService)
        {
            _tripService = tripService;
        }

        public async Task Handle(ChangeTripRequestStatusCommand request, CancellationToken cancellationToken)
        {
            await _tripService.ChangeTripRequestStatus(request.userId, request.changeRequestStatusInfoDTO);
        }
    }
}
