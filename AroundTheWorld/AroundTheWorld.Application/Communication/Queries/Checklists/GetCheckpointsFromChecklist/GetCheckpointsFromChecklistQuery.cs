using AroundTheWorld.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AroundTheWorld.Application.Communication.Queries.Checklists.GetCheckpointsFromChecklist
{
    public record GetCheckpointsFromChecklistQuery(Guid checkpointId) : IRequest<IQueryable<Checkpoint>> {}
}
