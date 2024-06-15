using AroundTheWorld.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AroundTheWorld.Domain.Entities
{
    public class TripAndUsers
    {
        public Guid TripId { get; set; }
        public Trip Trip { get; set; }
        public Guid UserId {  get; set; }
        public User User { get; set; }
        public UserRequestStatus Status { get; set; }

    }
}
