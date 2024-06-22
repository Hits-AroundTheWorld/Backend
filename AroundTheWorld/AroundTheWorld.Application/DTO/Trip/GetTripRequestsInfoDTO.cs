using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AroundTheWorld.Application.DTO.Trip
{
    public class GetTripRequestsInfoDTO
    {
        public IQueryable<RequestsInfoDTO> Requests { get; set; }
        public PaginationInfoDTO PaginationInfo { get; set; }
    }
}
