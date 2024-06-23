using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AroundTheWorld.Domain.Entities
{
    public class CompanionsPair
    {
        public Guid FirstCompanion { get; set; }
        public Guid SecondCompanion { get; set; }
        public Double Rating { get; set; }
    }
}
