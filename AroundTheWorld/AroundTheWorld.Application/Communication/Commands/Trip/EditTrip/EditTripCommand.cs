using AroundTheWorld.Application.DTO.Trip;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AroundTheWorld.Application.Communication.Commands.Trip.EditTrip
{
    public record class EditTripCommand(Guid userId,Guid tripId, EditTripInfoDTO editInfoCreds):IRequest;
}
