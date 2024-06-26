using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AroundTheWorld.Application.DTO.User
{
    public class GetUsersDTO
    {
        public IList<GetUserDTO> Users { get; set; }
        public PaginationInfoDTO Pagination { get; set; }
    }
}
