using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AroundTheWorld.Domain.Entities
{
    public class TripDays
    {
        public Guid TripId { get; set; }
        public DateTime Day { get; set; }
        public string? DayDescription { get; set; }
        public string? DayName { get; set; }
    }
}
