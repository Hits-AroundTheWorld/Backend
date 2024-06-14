using AroundTheWorld.Application.DTO.Trip;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AroundTheWorld.Application.Communication.Queries.Trip.GetMyTrip
{
    public record GetMyTripsQuery(Guid userId) : IRequest<GetTripInfoDTO>;
}
