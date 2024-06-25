using AroundTheWorld.Application.Communication.Queries.Checklists.GetChecklistByParentId;
using AroundTheWorld.Application.Interfaces.Checklists;
using AroundTheWorld.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AroundTheWorld.Application.Communication.Queries.Checklists.GetCheckpointsFromChecklist
{
    public class GetCheckpointsFromChecklistQueryHandler : IRequestHandler<GetCheckpointsFromChecklistQuery, IQueryable<Checkpoint>>
    {

        private readonly IChecklistService _checklistService;
        public GetCheckpointsFromChecklistQueryHandler(IChecklistService checklistService)
        {
            _checklistService = checklistService;
        }

        public Task<IQueryable<Checkpoint>> Handle(GetCheckpointsFromChecklistQuery request, CancellationToken cancellationToken)
        {
            var checkpoints = _checklistService.GetCheckpointsFromChecklist(request.checkpointId);
            return checkpoints;
        }
    }
}
