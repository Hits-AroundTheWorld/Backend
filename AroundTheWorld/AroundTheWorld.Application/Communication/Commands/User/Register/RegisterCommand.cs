using AroundTheWorld.Application.DTO.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AroundTheWorld.Application.Communication.Commands.User.Register
{
    public record RegisterCommand(RegisterInfoDTO registerCreds) : IRequest<TokenResponseDTO>;
}
