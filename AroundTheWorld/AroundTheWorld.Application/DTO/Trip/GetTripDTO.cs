using AroundTheWorld.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AroundTheWorld.Application.DTO.Trip
{
    public class GetTripDTO
    {
        public TripInfoDTO Trip {  get; set; }
        public List<MapPoint> MapPoints { get; set; }
    }
}
