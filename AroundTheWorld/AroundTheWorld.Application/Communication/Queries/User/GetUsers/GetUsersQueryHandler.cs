using AroundTheWorld.Application.Communication.Commands.User.EditProfile;
using AroundTheWorld.Application.DTO.User;
using AroundTheWorld.Application.Interfaces.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AroundTheWorld.Application.Communication.Queries.User.GetUsers
{
    public class EditProfileQueryHandler : IRequestHandler<GetUsersQuery, GetUsersDTO>
    {

        private readonly IAccountService _accountService;
        public EditProfileQueryHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<GetUsersDTO> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var profile = await _accountService.GetAllAusers(request.filters);

            return profile;
        }
    }
}
