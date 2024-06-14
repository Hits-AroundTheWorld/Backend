using AroundTheWorld.Application.Communication.Commands.Trip.CreateTrip;
using AroundTheWorld.Application.Communication.Queries.User.GetProfile;
using AroundTheWorld.Application.DTO.Trip;
using AroundTheWorld.Infrastructure.Policies;
using AroundTheWorld.Web.Controllers.Base;
using AroundTheWorld.Web.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AroundTheWorld.Web.Controllers
{
    [ApiController]
    [Route("/api/trip")]
    public class TripController:BaseController
    {
        public TripController(IMediator mediator) : base(mediator) { }

        [HttpPost("create")]
        [Authorize]
        [ServiceFilter(typeof(TokenBlacklistFilterAttribute))]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 400)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 401)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 404)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 500)]
        public async Task<ActionResult> CreateTrip([FromBody]CreateTripInfoDTO createTripCreds)
        {
            var createTrip = new CreateTripCommand(UserId, createTripCreds);
            await Mediator.Send(createTrip);
            return Ok();
        }
    }
}
