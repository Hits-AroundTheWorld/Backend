﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AroundTheWorld.Application.Communication.Commands.Trip.RemoveMyTripRequest
{
    public record class RemoveMyTripRequestCommand(Guid userId, Guid tripId):IRequest;
}
