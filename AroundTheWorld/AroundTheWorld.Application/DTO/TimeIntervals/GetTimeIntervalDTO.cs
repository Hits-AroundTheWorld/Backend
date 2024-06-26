using AroundTheWorld.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AroundTheWorld.Application.DTO.TimeIntervals
{
    public class GetTimeIntervalDTO
    {
        public TimeInterval TimeInterval { get; set; }
        public List<TimeIntervalMapPoint> MapPoints { get; set;  }
    }
}
