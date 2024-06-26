using AroundTheWorld.Application.DTO.Trip;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AroundTheWorld.Application.Communication.Queries.Trip.GetTripRequests
{
    public record class GetTripRequestsQuery(int size, int page, Guid tripId):IRequest<GetTripRequestsInfoDTO>;
}
