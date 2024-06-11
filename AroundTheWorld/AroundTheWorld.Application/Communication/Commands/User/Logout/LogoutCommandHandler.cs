using AroundTheWorld.Application.DTO.User;
using AroundTheWorld.Application.Interfaces.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AroundTheWorld.Application.Communication.Commands.User.Logout
{
    public class LogoutCommandHandler : IRequestHandler<LogoutCommand>
    {

        private readonly IAuthService _authService;
        public LogoutCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task Handle(LogoutCommand request, CancellationToken cancellationToken)
        {
            await _authService.Logout();
        }
    }
}
