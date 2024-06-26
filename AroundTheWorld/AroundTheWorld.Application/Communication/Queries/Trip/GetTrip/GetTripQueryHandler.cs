using AroundTheWorld.Application.DTO.Trip;
using AroundTheWorld.Application.Interfaces.Trips;
using MediatR;

namespace AroundTheWorld.Application.Communication.Queries.Trip.GetTrip
{
    public class GetTripQueryHandler: IRequestHandler<GetTripQuery, GetTripDTO>
    {
        private readonly ITripService _tripService;
        public GetTripQueryHandler(ITripService tripService)
        {
            _tripService = tripService;
        }

        public async Task<GetTripDTO> Handle(GetTripQuery request, CancellationToken cancellationToken)
        {
            var trips = await _tripService.GetTripById(request.tripId);
            return trips;
        }
    }
}
