using AroundTheWorld.Application.DTO.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AroundTheWorld.Application.Communication.Commands.User.Login
{
    public record LoginCommand(LoginInfoDTO loginCreds) : IRequest<TokenResponseDTO>;
}
