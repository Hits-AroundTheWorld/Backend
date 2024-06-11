using AroundTheWorld.Application.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AroundTheWorld.Application.Interfaces.Users
{
    public interface IAuthService
    {
        public Task<TokenResponseDTO> Login(LoginInfoDTO loginCreds);
        public Task<TokenResponseDTO> Register(RegisterInfoDTO registerCreds);
        public Task Logout();
    }
}
