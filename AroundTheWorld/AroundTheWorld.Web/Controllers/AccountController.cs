using AroundTheWorld.Application.Communication.Commands.User.EditProfile;
using AroundTheWorld.Application.Communication.Commands.User.Login;
using AroundTheWorld.Application.Communication.Commands.User.Register;
using AroundTheWorld.Application.Communication.Queries.User.GetProfile;
using AroundTheWorld.Application.DTO.User;
using AroundTheWorld.Web.Controllers.Base;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace AroundTheWorld.Web.Controllers
{
    [ApiController]
    [Route("/api/user")]
    public class UserController : BaseController
    {
        public UserController(IMediator mediator) : base(mediator) { }

        [HttpPost("login")]
        public async Task<ActionResult<TokenResponseDTO>> Login(LoginInfoDTO loginCreds)
        {
            var loginCommand = new LoginCommand(loginCreds);
            var tokenResponse = await Mediator.Send(loginCommand);

            return Ok(tokenResponse);
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterInfoDTO registerCreds)
        {
            var registerCommand = new RegisterCommand(registerCreds);
            var tokenResponse = await Mediator.Send(registerCommand);

            return Ok(tokenResponse);
        }
        [HttpGet("profile")]
        public async Task<ActionResult> Profile( )
        {
            var getProfileQuery = new GetProfileQuery(UserId);
            var profile = await Mediator.Send(getProfileQuery);

            return Ok(profile);
        }

        [HttpPut("profile")]
        public async Task<ActionResult> Profile(EditProfileDTO editProfileCreds)
        {
            var editProfileCommand = new EditProfileCommand(UserId, editProfileCreds);
            await Mediator.Send(editProfileCommand);

            return Ok();
        }

    }
}
