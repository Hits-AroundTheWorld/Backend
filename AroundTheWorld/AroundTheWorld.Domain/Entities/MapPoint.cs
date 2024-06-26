using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AroundTheWorld.Domain.Entities
{
    public class MapPoint
    {
        public Guid pointId { get; set; }
        public Guid ParentId { get; set; }
        public Double XCoordinate { get; set; }
        public Double YCoordinate { get; set; }
        public string? Description { get; set; }
        public string? Title { get; set; } 
    }
}
