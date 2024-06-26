using AroundTheWorld.Application.Communication.Commands.Trip.RemoveTrip;
using AroundTheWorld.Application.Interfaces.Trips;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AroundTheWorld.Application.Communication.Commands.Trip.LoginTrip
{
    public class LoginTripCommandHandler : IRequestHandler<LoginTripCommand>
    {

        private readonly ITripService _tripService;
        public LoginTripCommandHandler(ITripService tripService)
        {
            _tripService = tripService;
        }

        public async Task Handle(LoginTripCommand request, CancellationToken cancellationToken)
        {
            await _tripService.LoginTripByInvite(request.userId, request.infoDTO);
        }
    }
}
