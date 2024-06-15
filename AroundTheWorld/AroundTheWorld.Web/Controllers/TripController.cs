using AroundTheWorld.Application.Communication.Commands.Trip.CreateTrip;
using AroundTheWorld.Application.Communication.Queries.Trip.GetMyTrip;
using AroundTheWorld.Application.Communication.Queries.Trip.GetPublicTrips;
using AroundTheWorld.Application.Communication.Queries.User.GetProfile;
using AroundTheWorld.Application.DTO.Trip;
using AroundTheWorld.Domain.Entities.Enums;
using AroundTheWorld.Infrastructure.Policies;
using AroundTheWorld.Web.Controllers.Base;
using AroundTheWorld.Web.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

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
        [HttpGet("my")]
        [Authorize]
        [ServiceFilter(typeof(TokenBlacklistFilterAttribute))]
        [ProducesResponseType(typeof(GetQuerybleTripsInfoDTO), 200)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 400)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 401)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 404)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 500)]
        public async Task<ActionResult<GetQuerybleTripsInfoDTO>> GetMyTrips([FromQuery] int size, int page, string? tripName, RequestSorting? requestSorting, DateTime? tripDate)
        {
            var getTrips = new GetMyTripsQuery(size,page,UserId, tripName,requestSorting,tripDate);
            var trips = await Mediator.Send(getTrips);
            return Ok(trips);
        }
        [HttpGet("public")]
        [Authorize]
        [ServiceFilter(typeof(TokenBlacklistFilterAttribute))]
        [ProducesResponseType(typeof(GetQuerybleTripsInfoDTO), 200)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 400)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 401)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 404)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 500)]
        public async Task<ActionResult<GetQuerybleTripsInfoDTO>> GetPublicTrips([FromQuery] int size, int page,Guid? personId, string? tripName, RequestSorting? requestSorting, DateTime? tripDate)
        {
            var getTrips = new GetPublicTripsQuery(size, page, personId, tripName, requestSorting, tripDate);
            var trips = await Mediator.Send(getTrips);
            return Ok(trips);
        }
    }
}
