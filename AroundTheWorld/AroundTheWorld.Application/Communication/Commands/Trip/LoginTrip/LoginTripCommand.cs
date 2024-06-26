using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AroundTheWorld.Application.Communication.Commands.Trip.LoginTrip
{
    public record class LoginTripCommand(Guid userId, string inviteCode): IRequest;
}
