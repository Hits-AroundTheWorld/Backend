using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AroundTheWorld.Application.DTO.Trip
{
    public class ApplyForTripInfoDTO
    {
        public Guid TripId { get; set; }
        public Guid UserId { get; set; }
    }
}
