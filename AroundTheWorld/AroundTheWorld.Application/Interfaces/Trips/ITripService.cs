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
        public Task EditTrip(Guid userId,Guid tripId, EditTripInfoDTO editTripCreds);
        public Task<GetQuerybleTripsInfoDTO> GetMyTrips(int size, int page, Guid userId, string? tripName,RequestSorting? requestSorting, DateTime? tripDate, bool isOwner);

        public Task<GetQuerybleTripsInfoDTO> GetPublicTrips(int size, int page, Guid? userId, string? tripName, RequestSorting? requestSorting, DateTime? tripDate);
        public Task ApplyForTrip(Guid tripId, Guid userId);
        public Task ChangeTripRequestStatus(Guid userId, ChangeRequestStatusInfoDTO infoDTO);
        public Task ChangeTripStatus(Guid userId, ChangeTripStatusInfoDTO infoDTO);
        public Task LeaveFromTrip(Guid userId, Guid tripId);
        public Task RemoveTripRequest(Guid userId, Guid tripId);
        public Task<IQueryable<GetTripUsersDTO>> GetUsersFromTrip(Guid tripId);
        public Task<GetTripRequestsInfoDTO> GetTripRequests(int size, int page,Guid tripId);
        public Task RemoveTrip(Guid userId, Guid tripId);
        public Task<List<GetMyRequestsDTO>> GetMyRequests(Guid userId);
        public Task<GetTripDTO> GetTripById(Guid tripId);
        public Task LoginTripByInvite(Guid userId, InviteCodeInfoDTO infoDTO);
    }
}
