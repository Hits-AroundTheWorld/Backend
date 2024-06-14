using AroundTheWorld.Application.DTO.Trip;
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
    }
}
