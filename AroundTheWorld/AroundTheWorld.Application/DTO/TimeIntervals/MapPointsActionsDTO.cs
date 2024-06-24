using AroundTheWorld.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AroundTheWorld.Application.DTO.TimeIntervals
{
    public class NewMapPointsDTO
    {
        public List<MapPoint> MapPoints { get; set; }
        public Guid TimeIntervalId { get; set; }
    }
}
