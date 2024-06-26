using AroundTheWorld.Application.DTO.Trip;
using AroundTheWorld.Domain.Entities.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AroundTheWorld.Application.Communication.Queries.Trip.GetTrip
{
    public record class GetTripQuery(Guid tripId) : IRequest<GetTripDTO>;
}
