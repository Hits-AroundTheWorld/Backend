using AroundTheWorld.Application.DTO.Checklist;
using MediatR;

namespace AroundTheWorld.Application.Communication.Commands.Checklist.DeleteChecklist
{
    public record DeleteChecklistCommand(Guid checklistId) : IRequest{}
}
