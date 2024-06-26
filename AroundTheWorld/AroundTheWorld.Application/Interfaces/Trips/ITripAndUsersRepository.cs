using AroundTheWorld.Application.Interfaces.Users;
using AroundTheWorld.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AroundTheWorld.Application.Interfaces.Trips
{
    public interface ITripAndUsersRepository:IBaseRepository<TripAndUsers>
    {
        public Task<TripAndUsers?> GetRequestByIdAsync(Guid userId, Guid tripId);
        public Task<TripAndUsers?> GetTripById(Guid tripId);
        public Task<List<Guid>?> GetUserTrips(Guid userId);
        public Task<List<TripAndUsers>?> GetUsersFromTrip(Guid tripId);
        public Task<List<TripAndUsers>?> GetRequests(Guid tripId);
        public Task<List<TripAndUsers>?> GetUserRequests(Guid userId);
    }
}
