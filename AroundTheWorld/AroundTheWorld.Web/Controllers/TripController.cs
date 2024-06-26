using AroundTheWorld.Application.Communication.Commands.Trip.ApplyForTrip;
using AroundTheWorld.Application.Communication.Commands.Trip.ChangeTripRequestStatus;
using AroundTheWorld.Application.Communication.Commands.Trip.ChangeTripStatus;
using AroundTheWorld.Application.Communication.Commands.Trip.CreateTrip;
using AroundTheWorld.Application.Communication.Commands.Trip.EditTrip;
using AroundTheWorld.Application.Communication.Commands.Trip.LeaveFromTrip;
using AroundTheWorld.Application.Communication.Commands.Trip.RemoveMyTripRequest;
using AroundTheWorld.Application.Communication.Commands.Trip.RemoveTrip;
using AroundTheWorld.Application.Communication.Queries.Trip.GetMyRequests;
using AroundTheWorld.Application.Communication.Queries.Trip.GetMyTrip;
using AroundTheWorld.Application.Communication.Queries.Trip.GetPublicTrips;
using AroundTheWorld.Application.Communication.Queries.Trip.GetTripRequests;
using AroundTheWorld.Application.Communication.Queries.Trip.GetUsersFromTrip;
using AroundTheWorld.Application.DTO.Trip;
using AroundTheWorld.Domain.Entities.Enums;
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
        [HttpPut("edit/{tripId}")]
        [Authorize]
        [ServiceFilter(typeof(TokenBlacklistFilterAttribute))]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 400)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 401)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 404)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 500)]
        public async Task<ActionResult> EditTrip(Guid tripId, EditTripInfoDTO editCreds)
        {
            var editTrip = new EditTripCommand(UserId, tripId, editCreds);
            await Mediator.Send(editTrip);
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
        public async Task<ActionResult<GetQuerybleTripsInfoDTO>> GetMyTrips([FromQuery] int size, int page, string? tripName, RequestSorting? requestSorting, DateTime? tripDate, bool isOwner=false)
        {
            var getTrips = new GetMyTripsQuery(size,page,UserId, tripName,requestSorting,tripDate, isOwner);
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
        [HttpPost("apply/{tripId}")]
        [Authorize]
        [ServiceFilter(typeof(TokenBlacklistFilterAttribute))]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 400)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 401)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 404)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 500)]
        public async Task<ActionResult> ApplyForTrip(Guid tripId)
        {
            var applyTrip = new ApplyForTripCommand(tripId, UserId);
            await Mediator.Send(applyTrip);
            return Ok();
        }
        [HttpPut("user/status")]
        [Authorize]
        [ServiceFilter(typeof(TokenBlacklistFilterAttribute))]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 400)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 401)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 404)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 500)]
        public async Task<ActionResult> ChangeUserStatus(ChangeRequestStatusInfoDTO changeRequestStatusInfoDTO)
        {
            var changeTripStatus = new ChangeTripRequestStatusCommand(UserId, changeRequestStatusInfoDTO);
            await Mediator.Send(changeTripStatus);
            return Ok();
        }
        [HttpPut("status")]
        [Authorize]
        [ServiceFilter(typeof(TokenBlacklistFilterAttribute))]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 400)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 401)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 404)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 500)]
        public async Task<ActionResult> ChangeStatus(ChangeTripStatusInfoDTO tripInfoCreds)
        {
            var changeTripStatus = new ChangeTripStatusCommand(UserId, tripInfoCreds);
            await Mediator.Send(changeTripStatus);
            return Ok();
        }
        [HttpPut("leave/{tripId}")]
        [Authorize]
        [ServiceFilter(typeof(TokenBlacklistFilterAttribute))]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 400)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 401)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 404)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 500)]
        public async Task<ActionResult> LeaveFromTrip(Guid tripId)
        {
            var leaveFromTrip = new LeaveFromTripCommand(UserId, tripId);
            await Mediator.Send(leaveFromTrip);
            return Ok();
        }
        [HttpPut("remove/request/{tripId}")]
        [Authorize]
        [ServiceFilter(typeof(TokenBlacklistFilterAttribute))]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 400)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 401)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 404)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 500)]
        public async Task<ActionResult> RemoveTripRequest(Guid tripId)
        {
            var removeTripRequest = new RemoveMyTripRequestCommand(UserId, tripId);
            await Mediator.Send(removeTripRequest);
            return Ok();
        }
        [HttpGet("{tripId}")]
        [Authorize]
        [ServiceFilter(typeof(TokenBlacklistFilterAttribute))]
        [ProducesResponseType(typeof(GetUsersFromTripInfoDTO),200)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 400)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 401)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 404)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 500)]
        public async Task<ActionResult<GetUsersFromTripInfoDTO>> GetUsersFromTrip(Guid tripId)
        {
            var getUsers = new GetUsersFromTripQuery(tripId);
            var result = await Mediator.Send(getUsers);
            return Ok(result);
        }
        [HttpGet("requests/{tripId}")]
        [Authorize]
        [ServiceFilter(typeof(TokenBlacklistFilterAttribute))]
        [ProducesResponseType(typeof(GetTripRequestsInfoDTO), 200)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 400)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 401)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 404)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 500)]
        public async Task<ActionResult<GetTripRequestsInfoDTO>> GetRequests(int page, int size, Guid tripId)
        {
            var getRequests = new GetTripRequestsQuery(size, page, tripId);
            var result = await Mediator.Send(getRequests);
            return Ok(result);
        }
        [HttpGet("requests/my")]
        [Authorize]
        [ServiceFilter(typeof(TokenBlacklistFilterAttribute))]
        [ProducesResponseType(typeof(GetMyRequestsDTO), 200)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 400)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 401)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 404)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 500)]
        public async Task<ActionResult<List<GetMyRequestsDTO>>> GetUserRequests()
        {
            var getRequests = new GetMyRequestsQuery(UserId);
            var result = await Mediator.Send(getRequests);
            return Ok(result);
        }

        [HttpDelete("remove/{tripId}")]
        [Authorize]
        [ServiceFilter(typeof(TokenBlacklistFilterAttribute))]
        [ProducesResponseType(typeof(GetTripRequestsInfoDTO), 200)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 400)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 401)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 404)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 500)]
        public async Task<ActionResult> RemoveTrip(Guid tripId)
        {
            var removeTrip = new RemoveTripCommand(UserId,tripId);
            await Mediator.Send(removeTrip);
            return Ok();
        }
    }
}
