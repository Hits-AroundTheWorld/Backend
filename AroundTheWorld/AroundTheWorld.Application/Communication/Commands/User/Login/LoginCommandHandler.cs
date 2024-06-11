using AroundTheWorld.Application.DTO.User;
using AroundTheWorld.Application.Interfaces.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AroundTheWorld.Application.Communication.Commands.User.Login
{
    public class LogintCommandHandler : IRequestHandler<LoginCommand, TokenResponseDTO>
    {

        private readonly IAuthService _authService;
        public LogintCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }


        public async Task<TokenResponseDTO> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            return await _authService.Login(request.loginCreds);
        }
    }
}
