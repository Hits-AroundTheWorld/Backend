using AroundTheWorld.Application.Interfaces.Users;
using AroundTheWorld.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AroundTheWorld.Application.Interfaces.Checklists
{
    public interface ICheckpointRepository : IBaseRepository<Checkpoint>
    {
        public IQueryable<Checkpoint> GetCheckpointsByChecklistId(Guid checklistId);
    }
}
