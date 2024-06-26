using AroundTheWorld.Application.DTO.Checklist;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AroundTheWorld.Application.Communication.Commands.Checklist.CreateChecklist
{
    public record CreateChecklistCommand(CreateChecklistDTO checklistDTO, Guid userId) : IRequest{}
}
