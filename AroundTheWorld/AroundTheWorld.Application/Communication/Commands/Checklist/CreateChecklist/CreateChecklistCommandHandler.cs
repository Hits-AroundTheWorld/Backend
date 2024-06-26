using AroundTheWorld.Application.Communication.Commands.Checklist.EditChecklist;
using AroundTheWorld.Application.Interfaces.Checklists;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AroundTheWorld.Application.Communication.Commands.Checklist.CreateChecklist
{
    public class CreateChecklistCommandHandler: IRequestHandler<CreateChecklistCommand>
    {
        private readonly IChecklistService _checklistService;

        public CreateChecklistCommandHandler(IChecklistService checklistService)
        {
            _checklistService = checklistService;
        }

        public async Task Handle(CreateChecklistCommand request, CancellationToken cancellationToken)
        {
            await _checklistService.CreateChecklist(request.checklistDTO, request.userId);
        }
    }
}
