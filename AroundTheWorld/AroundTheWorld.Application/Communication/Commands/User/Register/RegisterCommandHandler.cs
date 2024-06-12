using AroundTheWorld.Application.Communication.Commands.User.Logout;
using AroundTheWorld.Application.DTO.User;
using AroundTheWorld.Application.Interfaces.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AroundTheWorld.Application.Communication.Commands.User.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, TokenResponseDTO>
    {

        private readonly IAuthService _authService;
        public RegisterCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<TokenResponseDTO> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            return await _authService.Register(request.registerCreds);
        }
    }
}
