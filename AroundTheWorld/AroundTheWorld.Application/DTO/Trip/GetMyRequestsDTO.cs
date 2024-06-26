using AroundTheWorld.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AroundTheWorld.Application.DTO.Trip
{
    public class GetMyRequestsDTO
    {
        public Guid TripId { get; set; } 
        public string TripName { get; set; }
        public UserRequestStatus Status { get; set; }
    }
}
