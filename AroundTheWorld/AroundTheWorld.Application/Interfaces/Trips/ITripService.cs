using AroundTheWorld.Application.DTO.Trip;
using AroundTheWorld.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AroundTheWorld.Application.Interfaces.Trips
{
    public interface ITripService
    {
        public Task CreateTrip(Guid userId, CreateTripInfoDTO createTripCreds);
        public Task<GetQuerybleTripsInfoDTO> GetMyTrips(int size, int page, Guid userId, string? tripName,RequestSorting? requestSorting, DateTime? tripDate);

        public Task<GetQuerybleTripsInfoDTO> GetPublicTrips(int size, int page, Guid? userId, string? tripName, RequestSorting? requestSorting, DateTime? tripDate);
        public Task ApplyForTrip(Guid tripId, Guid userId);
        public Task ChangeTripRequestStatus(Guid userId, ChangeRequestStatusInfoDTO infoDTO);
    }
}
