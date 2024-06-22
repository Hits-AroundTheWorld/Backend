using AroundTheWorld.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AroundTheWorld.Application.DTO.Trip
{
    public class ChangeTripStatusInfoDTO
    {
        public Guid TripId { get; set; }
        public TripStatus TripStatus { get; set; }
    }
}
