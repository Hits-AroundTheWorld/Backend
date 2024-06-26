using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AroundTheWorld.Application.DTO.Trip
{
    public class TripInfoDTO
    {
        public Guid TripId { get; set; }
        public string TripName { get; set; }
        public string? TripMiniDescription { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Boolean IsPublic { get; set; }
        public Guid TripFounderId { get; set; }
        public string TripFounderFullName { get; set; }
        public string? InvitationLink { get; set; }
        public int? MaxBudget { get; set; }
        public int MaxPeopleCount { get; set; }
        public int PeopleCountNow { get; set; }
        public DateTime CreatedTime { get; set; }

    }
}
