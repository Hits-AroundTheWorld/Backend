using AroundTheWorld.Application.Communication.Commands.TimeIntervals.CreateTimeInterval;
using AroundTheWorld.Application.Communication.Commands.TimeIntervals.DeleteTimeInterval;
using AroundTheWorld.Application.Communication.Commands.TimeIntervals.EditPointsOnMap;
using AroundTheWorld.Application.Communication.Commands.TimeIntervals.EditTimeInterval;
using AroundTheWorld.Application.Communication.Queries.TimeIntervals.GetTimeInterval;
using AroundTheWorld.Application.Communication.Queries.TimeIntervals.GetTimeIntervals;
using AroundTheWorld.Application.DTO.TimeIntervals;
using AroundTheWorld.Application.Interfaces.TimeIntervals;
using AroundTheWorld.Domain.Entities;
using AroundTheWorld.Infrastructure.Policies;
using AroundTheWorld.Web.Controllers.Base;
using AroundTheWorld.Web.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AroundTheWorld.Web.Controllers
{
    [Route("api/timeInterval")]
    [ApiController]
    public class TimeIntervalController : BaseController
    {
        private readonly ITimeIntervalService _timeIntervalService;
        public TimeIntervalController(IMediator mediator, ITimeIntervalService timeIntervalService) : base(mediator)
        {
            _timeIntervalService = timeIntervalService;
        }

        [HttpPost("create")]
        [Authorize]
        [ServiceFilter(typeof(TokenBlacklistFilterAttribute))]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 400)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 401)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 404)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 500)]
        public async Task<ActionResult> CreateTimeInterval(CreateTimeIntervalDTO createDayDTO)
        {
            var createTimeIntervalCommand = new CreateTimeIntervalCommand(createDayDTO);
            await Mediator.Send(createTimeIntervalCommand);
            return Ok();
        }

        [HttpPut("edit")]
        [Authorize]
        [ServiceFilter(typeof(TokenBlacklistFilterAttribute))]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 400)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 401)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 404)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 500)]
        public async Task<ActionResult> EditTimeInterval(EditTimeIntervalDTO editTimeIntervalDTO)
        {
            var editTimeIntervalCommand = new EditTimeIntervalCommand(editTimeIntervalDTO);
            await Mediator.Send(editTimeIntervalCommand);
            return Ok();
        }

        [HttpGet("{tripId}")]
        [Authorize]
        [ServiceFilter(typeof(TokenBlacklistFilterAttribute))]
        [ProducesResponseType(typeof(IQueryable<TimeInterval>), 200)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 400)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 401)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 404)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 500)]
        public async Task<ActionResult<IQueryable<TimeInterval>>> GetTripTimeIntervals(Guid tripId)
        {
            var getTripTimeIntervalsQuery = new GetTripTimeIntervalsQuery(tripId);
            var tripIntervals = await Mediator.Send(getTripTimeIntervalsQuery);
            return Ok(tripIntervals);
        }
        [HttpGet("{timeIntervalId}/get-trip-intervals")]
        [Authorize]
        [ServiceFilter(typeof(TokenBlacklistFilterAttribute))]
        [ProducesResponseType(typeof(GetTimeIntervalDTO), 200)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 400)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 401)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 404)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 500)]
        public async Task<ActionResult<GetTimeIntervalDTO>> GetTripTimeInterval(Guid timeIntervalId)
        {
            var getTripTimeIntervalQuery = new GetTripTimeIntervalQuery(timeIntervalId);
            var tripInterval = await Mediator.Send(getTripTimeIntervalQuery);
            return Ok(tripInterval);
        }

        [HttpPost("points-actions")]
        [Authorize]
        [ServiceFilter(typeof(TokenBlacklistFilterAttribute))]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 400)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 401)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 404)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 500)]
        public async Task<ActionResult> EditPointsOnMap(NewMapPointsDTO newMapPointsInfo)
        {
            var editPointsCommand = new EditPointsOnMapCommand(newMapPointsInfo);
            await Mediator.Send(editPointsCommand);
          
            return Ok();
        }

        [HttpDelete("delete/{timeIntervalId}")]
        [Authorize]
        [ServiceFilter(typeof(TokenBlacklistFilterAttribute))]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 400)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 401)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 404)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 500)]
        public async Task<ActionResult> EditPointsOnMap(Guid timeIntervalId)
        {
            var deleteTimeIntervalCommand = new DeleteTimeIntervalCommand(timeIntervalId);
            await Mediator.Send(deleteTimeIntervalCommand);
            return Ok();
        }

    }
}
