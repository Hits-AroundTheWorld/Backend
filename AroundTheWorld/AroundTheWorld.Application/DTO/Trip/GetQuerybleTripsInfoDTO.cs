using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AroundTheWorld.Application.DTO.Trip
{
    public class GetQuerybleTripsInfoDTO
    {
        public IQueryable<GetTripsInfoDTO> Trips { get; set; }
        public PaginationInfoDTO Pagination { get; set; }
    }
}
