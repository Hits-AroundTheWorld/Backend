using AroundTheWorld.Application.DTO.Checklist;
using MediatR;

namespace AroundTheWorld.Application.Communication.Commands.Checklist.CheckpointActions
{
    public record CheckpointActionsCommand(EditCheckpointsDTO checkpointDTO) : IRequest{}
}
