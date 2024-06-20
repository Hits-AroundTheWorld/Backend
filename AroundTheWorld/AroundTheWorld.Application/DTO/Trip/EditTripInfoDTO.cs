using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AroundTheWorld.Application.DTO.Trip
{
    public class EditTripInfoDTO
    {
        public string TripName { get; set; }
        public string? TripMiniDescription { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Boolean IsPublic { get; set; }
        public int MaxPeopleCount { get; set; }
    }
}
