using AroundTheWorld.Application.Communication.Commands.User.EditProfile;
using AroundTheWorld.Application.Communication.Commands.User.Login;
using AroundTheWorld.Application.Communication.Commands.User.Register;
using AroundTheWorld.Application.Communication.Queries.User.GetProfile;
using AroundTheWorld.Application.Communication.Queries.User.GetUsers;
using AroundTheWorld.Application.DTO;
using AroundTheWorld.Application.DTO.User;
using AroundTheWorld.Infrastructure.Policies;
using AroundTheWorld.Web.Controllers.Base;
using AroundTheWorld.Web.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace AroundTheWorld.Web.Controllers
{
    [ApiController]
    [Route("/api/user")]
    public class UserController : BaseController
    {
        public UserController(IMediator mediator) : base(mediator) { }

        [HttpPost("login")]
        [ServiceFilter(typeof(TokenBlacklistFilterAttribute))]
        [ProducesResponseType(typeof(TokenResponseDTO), 200)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 400)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 500)]
        public async Task<ActionResult<TokenResponseDTO>> Login(LoginInfoDTO loginCreds)
        {
            var loginCommand = new LoginCommand(loginCreds);
            var tokenResponse = await Mediator.Send(loginCommand);

            return Ok(tokenResponse);
        }

        [HttpPost("register")]
        [ServiceFilter(typeof(TokenBlacklistFilterAttribute))]
        [ProducesResponseType(typeof(TokenResponseDTO), 200)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 400)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 500)]
        public async Task<ActionResult> Register(RegisterInfoDTO registerCreds)
        {
            var registerCommand = new RegisterCommand(registerCreds);
            var tokenResponse = await Mediator.Send(registerCommand);

            return Ok(tokenResponse);
        }
        [HttpGet("profile/my")]
        [Authorize]
        [ServiceFilter(typeof(TokenBlacklistFilterAttribute))]
        [ProducesResponseType(typeof(ProfileInfoDTO), 200)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 400)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 401)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 404)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 500)]
        public async Task<ActionResult<ProfileInfoDTO>> Profile( )
        {
            var getProfileQuery = new GetProfileQuery(UserId);
            var profile = await Mediator.Send(getProfileQuery);

            return Ok(profile);
        }
        [HttpGet("profile/{userId}")]
        [Authorize]
        [ServiceFilter(typeof(TokenBlacklistFilterAttribute))]
        [ProducesResponseType(typeof(ProfileInfoDTO), 200)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 400)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 401)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 404)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 500)]
        public async Task<ActionResult<ProfileInfoDTO>> GetUserProfile(Guid userId)
        {
            var userProfile = new GetProfileQuery(userId);
            var result = await Mediator.Send(userProfile);
            return Ok(result);
        }

        [HttpPut("profile")]
        [Authorize]
        [ServiceFilter(typeof(TokenBlacklistFilterAttribute))]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 400)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 401)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 404)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 500)]
        public async Task<ActionResult> Profile(EditProfileDTO editProfileCreds)
        {
            var editProfileCommand = new EditProfileCommand(UserId, editProfileCreds);
            await Mediator.Send(editProfileCommand);

            return Ok();
        }

        [HttpGet("users")]
        [Authorize]
        [ServiceFilter(typeof(TokenBlacklistFilterAttribute))]
        [ProducesResponseType(typeof(GetUsersDTO), 200)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 400)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 401)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 404)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 500)]
        public async Task<ActionResult<GetUsersDTO>> GetUsers(
            [FromQuery] string? fullName,
            [FromQuery] string? email,
            [FromQuery] string? Country,
            [FromQuery] MinMaxAgeDTO? Age,
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10
            )
        {
            var filtersDTO = new GetUsersFilterDTO
            {
                Age = Age,
                FullName = fullName,
                Country = Country,
                Email = email,
                PageSize = pageSize,
                currentPage = page
            };

            var editProfileCommand = new GetUsersQuery(filtersDTO);
            var users = await Mediator.Send(editProfileCommand);

            return Ok(users);
        }

    }
}
