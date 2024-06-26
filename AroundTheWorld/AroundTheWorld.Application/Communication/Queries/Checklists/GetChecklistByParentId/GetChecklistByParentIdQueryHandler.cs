using AroundTheWorld.Application.Interfaces.Checklists;
using AroundTheWorld.Application.Interfaces.Trips;
using AroundTheWorld.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AroundTheWorld.Application.Communication.Queries.Checklists.GetChecklistByParentId
{
    public class GetChecklistByParentIdQueryHandler: IRequestHandler<GetChecklistByParentIdQuery, IList<Checklist>>
    {

        private readonly IChecklistService _checklistService;
        public GetChecklistByParentIdQueryHandler(IChecklistService checklistService)
        {
            _checklistService = checklistService;
        }
        public Task<IList<Checklist>> Handle(GetChecklistByParentIdQuery request, CancellationToken cancellationToken)
        {
            var cheklists = _checklistService.GetChecklistByParentId(request.parentId);
            return cheklists;
        }
    }
}
