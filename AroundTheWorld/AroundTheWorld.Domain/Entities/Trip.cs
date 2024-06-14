using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AroundTheWorld.Domain.Entities
{
    public class Trip
    {
        [Key]
        public Guid TripId { get; set; }
        public string TripName { get; set; }
        public string? TripMiniDescription { get; set; }
        public Double? StartXCoordinate { get; set; }
        public Double? StartYCoordinate { get; set; }
        public Double? FinishXCoordinate { get; set; }
        public Double? FinishYCoordinate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Boolean IsPublic { get; set; }
        public Guid TripFounderId { get; set; }
        public string? InvitationLink { get; set; }
        public int? MaxBudget { get; set; }
        public int MaxPeopleCount { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}

