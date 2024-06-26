using AroundTheWorld.Application.DTO.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AroundTheWorld.Application.Communication.Queries.User.GetUsers
{
    public record GetUsersQuery(GetUsersFilterDTO filters) : IRequest<GetUsersDTO>;
}
