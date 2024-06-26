using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AroundTheWorld.Domain.Entities
{
    public class RatingElement
    {
        public Guid RatedUserId { get; set; }
        public Guid GivingRateUserId { get; set; }
        [Range(0, 5)]
        public float Rate { get; set; }
    }
}
