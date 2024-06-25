using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AroundTheWorld.Application.DTO.User
{
    public class SetRatingDTO
    {
        public Guid RatedUserId { get; set; }
        public Guid GivingRateUserId { get; set; }  
        public float Rate { get; set; }
    }
}
