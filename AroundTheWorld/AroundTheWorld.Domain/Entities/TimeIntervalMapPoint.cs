using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AroundTheWorld.Domain.Entities
{
    public class TimeIntervalMapPoint
    {
        public MapPoint MapPoint { get; set; }
        public Guid ParentId { get; set; }
    }
}
