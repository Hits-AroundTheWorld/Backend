using AroundTheWorld.Application.DTO.Checklist;
using MediatR;

namespace AroundTheWorld.Application.Communication.Commands.Checklist.EditChecklist
{
    public record EditChecklistCommand(EdtiChecklistDTO checklistInfo) : IRequest{}
}
