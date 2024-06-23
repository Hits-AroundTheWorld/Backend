using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AroundTheWorld.Domain.Entities
{
    public class DayMapPoint
    {
        public MapPoint MapPoint { get; set; }
        public Guid DayId { get; set; }
    }
}
