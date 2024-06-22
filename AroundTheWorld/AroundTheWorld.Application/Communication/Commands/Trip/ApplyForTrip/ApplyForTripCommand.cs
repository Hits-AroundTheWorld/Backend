using AroundTheWorld.Application.DTO.Trip;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AroundTheWorld.Application.Communication.Commands.Trip.ApplyForTrip
{
    public record ApplyForTripCommand(Guid tripId, Guid userId) : IRequest;
}
