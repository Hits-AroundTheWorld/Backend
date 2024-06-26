using AroundTheWorld.Application.Communication.Commands.Checklist.CheckpointActions;
using AroundTheWorld.Application.Communication.Commands.Checklist.CreateChecklist;
using AroundTheWorld.Application.Communication.Commands.Checklist.DeleteChecklist;
using AroundTheWorld.Application.Communication.Commands.Checklist.EditChecklist;
using AroundTheWorld.Application.Communication.Queries.Checklists.GetChecklistByParentId;
using AroundTheWorld.Application.Communication.Queries.Checklists.GetCheckpointsFromChecklist;
using AroundTheWorld.Application.DTO.Checklist;
using AroundTheWorld.Application.DTO.TimeIntervals;
using AroundTheWorld.Application.DTO.Trip;
using AroundTheWorld.Domain.Entities;
using AroundTheWorld.Infrastructure.Policies;
using AroundTheWorld.Web.Controllers.Base;
using AroundTheWorld.Web.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AroundTheWorld.Web.Controllers
{
    [Route("api/checklist")]
    [ApiController]
    public class ChecklistController : BaseController
    {
        public ChecklistController(IMediator mediator) : base(mediator) { }

        [HttpPost("create")]
        [Authorize]
        [ServiceFilter(typeof(TokenBlacklistFilterAttribute))]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 400)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 401)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 404)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 500)]
        public async Task<ActionResult> CreateChecklist(CreateChecklistDTO checklistDTO)
        {
            var createTimeIntervalCommand = new CreateChecklistCommand(checklistDTO, UserId);
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
        public async Task<ActionResult> EditChecklist(EdtiChecklistDTO checklistInfo)
        {
            var editChecklistCommand = new EditChecklistCommand(checklistInfo);
            await Mediator.Send(editChecklistCommand);
            return Ok();
        }

        [HttpDelete("{chekclistId}")]
        [Authorize]
        [ServiceFilter(typeof(TokenBlacklistFilterAttribute))]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 400)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 401)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 404)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 500)]
        public async Task<ActionResult> DeleteChecklist([FromQuery] Guid chekclistId)
        {
            var deleteChecklistCommand = new DeleteChecklistCommand(chekclistId);
            await Mediator.Send(deleteChecklistCommand);
            return Ok();
        }

        [HttpGet("checklist/{parentId}")]
        [Authorize]
        [ServiceFilter(typeof(TokenBlacklistFilterAttribute))]
        [ProducesResponseType(typeof(IList<Checklist>), 200)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 400)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 401)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 404)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 500)]
        public async Task<ActionResult<IList<Checklist>>> GetChecklistByParentId([FromQuery] Guid parentId)
        {
            var getChecklistQuery = new GetChecklistByParentIdQuery(parentId);
            var checklists = await Mediator.Send(getChecklistQuery);
            return Ok(checklists);
        }

        [HttpGet("checkpointst/{checklistId}")]
        [Authorize]
        [ServiceFilter(typeof(TokenBlacklistFilterAttribute))]
        [ProducesResponseType(typeof(IQueryable<Checkpoint>), 200)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 400)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 401)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 404)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 500)]
        public async Task<ActionResult<IQueryable<Checkpoint>>> GetCheckpointFromChecklist([FromQuery] Guid checklistId)
        {
            var getCheckpointsQuery = new GetCheckpointsFromChecklistQuery(checklistId);
            var checkpoints = await Mediator.Send(getCheckpointsQuery);
            return Ok(checkpoints);
        }

        [HttpPost("checkpoints/actions")]
        [Authorize]
        [ServiceFilter(typeof(TokenBlacklistFilterAttribute))]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 400)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 401)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 404)]
        [ProducesResponseType(typeof(ExceptionResponseModel), 500)]
        public async Task<ActionResult<IQueryable<Checkpoint>>> CheckpointsActions(EditCheckpointsDTO checkpointDTO)
        {
            var checkpointsAcrtionsCommand = new CheckpointActionsCommand(checkpointDTO);
            await Mediator.Send(checkpointsAcrtionsCommand);
            return Ok();
        }

    }
}
