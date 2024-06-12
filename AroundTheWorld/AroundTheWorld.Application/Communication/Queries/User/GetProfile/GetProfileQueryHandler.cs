using AroundTheWorld.Application.Communication.Commands.User.EditProfile;
using AroundTheWorld.Application.DTO.User;
using AroundTheWorld.Application.Interfaces.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AroundTheWorld.Application.Communication.Queries.User.GetProfile
{
    public class EditProfileQueryHandler : IRequestHandler<GetProfileQuery, ProfileInfoDTO>
    {

        private readonly IAccountService _accountService;
        public EditProfileQueryHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<ProfileInfoDTO> Handle(GetProfileQuery request, CancellationToken cancellationToken)
        {
            var profile =  await _accountService.GetProfile(request.userId);

            return profile;
        }
    }
}
