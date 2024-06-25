using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AroundTheWorld.Application.DTO.User
{
    public class GetUserDTO: ProfileInfoDTO
    {
        public Guid UserId { get; set;}
    }
}
