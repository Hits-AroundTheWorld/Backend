
using AroundTheWorld.Application.Interfaces.Users;
using MediatR;


namespace AroundTheWorld.Application.Communication.Commands.User.EditProfile
{
    public class EditProfileCommandHandler : IRequestHandler<EditProfileCommand>
    {

        private readonly IAccountService _accountService;
        public EditProfileCommandHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task Handle(EditProfileCommand request, CancellationToken cancellationToken)
        {
            await _accountService.EditProfile(request.editProfileDTO, request.userId);
        }
    }
}
