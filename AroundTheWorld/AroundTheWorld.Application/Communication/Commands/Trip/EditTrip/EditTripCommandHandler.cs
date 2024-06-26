using AroundTheWorld.Application.Communication.Commands.Trip.CreateTrip;
using AroundTheWorld.Application.Interfaces.Trips;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AroundTheWorld.Application.Communication.Commands.Trip.EditTrip
{
    public class EditTripCommandHandler : IRequestHandler<EditTripCommand>
    {

        private readonly ITripService _tripService;
        public EditTripCommandHandler(ITripService tripService)
        {
            _tripService = tripService;
        }

        public async Task Handle(EditTripCommand request, CancellationToken cancellationToken)
        {
            await _tripService.EditTrip(request.userId,request.tripId, request.editInfoCreds);
        }
    }
}
