using AroundTheWorld.Application.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AroundTheWorld.Application.Interfaces
{
    public interface IJwtService
    {
        public string CreateJWTToken(Guid userId);
    }
}
