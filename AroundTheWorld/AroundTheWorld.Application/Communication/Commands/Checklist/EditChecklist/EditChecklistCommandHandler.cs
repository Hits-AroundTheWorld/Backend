using AroundTheWorld.Application.DTO.Checklist;
using AroundTheWorld.Application.Interfaces.Checklists;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AroundTheWorld.Application.Communication.Commands.Checklist.EditChecklist
{
    internal class EditChecklistCommandHandler : IRequestHandler<EditChecklistCommand>
    {

        private readonly IChecklistService _checklistService;

        public EditChecklistCommandHandler(IChecklistService checklistService)
        {
            _checklistService = checklistService;
        }

        public async Task Handle(EditChecklistCommand request, CancellationToken cancellationToken)
        {
            await _checklistService.EditChecklist(request.checklistInfo);
        }
    }
}
