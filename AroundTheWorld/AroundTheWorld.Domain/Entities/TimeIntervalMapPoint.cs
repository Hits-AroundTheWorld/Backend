﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AroundTheWorld.Domain.Entities
{
    public class TimeIntervalMapPoint
    {
        public Guid pointId { get; set; }
        public Guid ParentId { get; set; }
        public Double XCoordinate { get; set; }
        public Double YCoordinate { get; set; }
    }
}
