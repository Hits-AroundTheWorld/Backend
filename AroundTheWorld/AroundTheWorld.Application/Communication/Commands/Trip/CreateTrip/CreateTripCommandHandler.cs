using AroundTheWorld.Application.Communication.Commands.User.Register;
using AroundTheWorld.Application.DTO.User;
using AroundTheWorld.Application.Interfaces.Trips;
using AroundTheWorld.Application.Interfaces.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AroundTheWorld.Application.Communication.Commands.Trip.CreateTrip
{
    public class CreateTripCommandHandler : IRequestHandler<CreateTripCommand>
    {

        private readonly ITripService _tripService;
        public CreateTripCommandHandler(ITripService tripService)
        {
            _tripService = tripService;
        }

        public async Task Handle(CreateTripCommand request, CancellationToken cancellationToken)
        {
            await _tripService.CreateTrip(request.userId, request.createTripCreds);
        }
    }
}
