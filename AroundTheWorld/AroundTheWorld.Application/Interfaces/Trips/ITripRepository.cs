using AroundTheWorld.Application.Interfaces.Users;
using AroundTheWorld.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AroundTheWorld.Application.Interfaces.Trips
{
    public interface ITripRepository:IBaseRepository<Trip>
    {
        public Task<List<Trip>?> GetByUserIdAsync(Guid userId);
        public Task<List<Trip>?> GetTripsAsync();
        public Task<Trip?> GetByTripIdAsync(Guid tripId);
        public Task<Trip?> GetTripById(Guid founderId, Guid tripId);
        public Task<bool> IsFounder(Guid userId, Guid tripId);
    }
}
 